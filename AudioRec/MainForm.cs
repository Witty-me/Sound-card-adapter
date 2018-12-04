using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSCore;
using CSCore.SoundIn;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using System.IO;
using CSCore.DSP;
using CSCore.Streams;
using CSCore.Streams.SampleConverter;


namespace AudioRec
{
	public partial class MainForm : Form
	{
		WasapiCapture capture;
		WaveWriter writer;
		TimeSpan recordTime;
		EventHandler<DataAvailableEventArgs> writeEvent;
        StreamWriter sw;
        System.DateTime time;
        DmoResampler resampler;
        WaveFileReader streamReader;
        const int sampleRate = 10000;
        const int bufsize = sampleRate;
        

		bool recording = false;

        private short GetShortFromLittleEndianBytes(byte[] data, int startIndex)
        {
            return (short)((data[startIndex + 1] << 8)
                 | data[startIndex]);
        }

        public MainForm()
		{
			InitializeComponent();

			recordTime = new TimeSpan();
            time = new System.DateTime(0);
            //streamBuffer = new MemoryStream();
            //streamReader = new WaveFileReader(streamBuffer);
            //sampleRate = 100000;

            writeEvent = new EventHandler<DataAvailableEventArgs>((s, e) =>
			{
                //Console.Write("Timestamp: ");
                //Console.Write(currTime.Ticks);
                //Console.Write(" ");


                //byte[] mybyte = Encoding.UTF8.GetBytes("hello");
                //sw.Write("hello");


                //Console.Write("\n");

                //buffer.Read(e.Data, e.Offset, e.ByteCount);
                writer.Write(e.Data, e.Offset, e.ByteCount);
                //writer.Write(e.ByteCount);
                //Console.WriteLine(e.ByteCount);
                //sw.WriteLine("timestamp: " + time.Ticks);
                time = time.AddTicks(1);
                //resampler = new DmoResampler(capture, 10000);
                
                //resampler = new DmoResampler(streamReader, 10000);
                
                //resampler.WriteToWaveStream(sw);
                

                for(int i = 0; i < e.ByteCount; i += 8)
                {
                    //Console.Write(BitConverter.ToSingle(e.Data, i) + " ");
                    //writer.WriteSample(BitConverter.ToSingle(e.Data, i));
                    /*sw.WriteLine(BitConverter.ToInt32(e.Data, i)
                        + "\t" + BitConverter.ToInt32(e.Data, i + 4));*/
                    
                    /*Console.WriteLine(e.Data[i] + " "
                         + e.Data[i + 1] + " "
                         + e.Data[i + 2] + " "
                         + e.Data[i + 3]);*/
                }
                //sw.WriteLine("\n");
                
                Console.WriteLine(e.ByteCount);
			});
		}

		private void btnFindDevices_Click(object sender, EventArgs e)
		{
			listDevices.Items.Clear();
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
			{
				using (MMDeviceCollection devices = enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
				{
					foreach (MMDevice device in devices)
					{
						Console.WriteLine("Found device: {0}", device.ToString());
						listDevices.Items.Add(new ListViewItem(device.FriendlyName) { Tag = device });
					}
				}
			}
		}

		private void btnSelectDevice_Click(object sender, EventArgs e)
		{
			if (listDevices.SelectedItems.Count > 0)
			{
				MMDevice device = (MMDevice)listDevices.SelectedItems[0].Tag;
				capture = new WasapiCapture();
                /*capture = new WasapiCapture(true, AudioClientShareMode.Shared, 0,
                    new WaveFormat(44100, 16, 2, AudioEncoding.Extensible)
                    );*/
                capture.Device = device;
                capture.Initialize();
                Console.WriteLine(capture.WaveFormat);
                
                capture.DataAvailable -= writeEvent;
				capture.DataAvailable += writeEvent;

				btnSelectDevice.Text = "Selected!";
				groupDeviceSelection.Enabled = true;

                
                Console.WriteLine("Selected device: {0}", device.ToString());
			}
		}

		private void btnBrowseFile_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = "Text files|*.txt";
            
			if (saveDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				textOutputFile.Text = saveDialog.FileName;
				Console.WriteLine("Output file set to \"{0}\"", saveDialog.FileName);
			}
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			if (!recording)
			{
				btnStartStop.Text = "Stop";

                /* clear the existing file */
                sw = new StreamWriter(textOutputFile.Text);
                sw.Dispose();

                writer = new WaveWriter(textOutputFile.Text, capture.WaveFormat);
                //writer = new WaveWriter(streamBuffer, capture.WaveFormat);
                //sw = new StreamWriter(textOutputFile.Text);
                

                capture.Start();
				recording = true;

				recordTime = new TimeSpan();
				recordTimer.Enabled = true;
				btnSelectDevice.Enabled = false;

				Console.WriteLine("Started recording");
			}
			else
			{
				btnStartStop.Text = "Start!";

				capture.Stop();
                writer.Dispose();
                //sw.Dispose();
				recording = false;

				recordTimer.Enabled = false;
				btnSelectDevice.Enabled = true;

                output_to_file();

				Console.WriteLine("Stopped recording");
			}
		}

		private void recordTimer_Tick(object sender, EventArgs e)
		{
			recordTime.Add(TimeSpan.FromSeconds(1));
			lblTime.Text = "Time: " + recordTime.ToString();
		}

		private void textOutputFile_TextChanged(object sender, EventArgs e)
		{
			if (textOutputFile.Text.Trim() != "")
				btnOpenFileLoc.Enabled = true;
			else
				btnOpenFileLoc.Enabled = false;
		}

		private void btnOpenFileLoc_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(textOutputFile.Text))
				System.Diagnostics.Process.Start(textOutputFile.Text);
		}

        private void output_to_file()
        {
            streamReader = new WaveFileReader(textOutputFile.Text);
            Console.WriteLine(streamReader.WaveFormat);
            resampler = new DmoResampler(streamReader, sampleRate);

            //resampler = new DmoResampler(streamReader, new WaveFormat(sampleRate, 16, capture.WaveFormat.Channels));
            //resampler.WriteToFile("C:\\Users\\Witty-me\\Desktop\\tmp.wav");

            //streamReader.Dispose();
            //resampler.WriteToFile(textOutputFile.Text);

            //resampler.Dispose();
            //streamReader = new WaveFileReader("C:\\Users\\Witty-me\\Desktop\\tmp");
            //streamReader = new WaveFileReader(textOutputFile.Text);
            //Pcm16BitToSample con = new Pcm16BitToSample(streamReader);



            //Console.WriteLine(streamReader.WaveFormat);
            //Console.WriteLine(resampler.BaseStream.WaveFormat);
            //Pcm16BitToSample con = new Pcm16BitToSample(resampler.BaseStream);
            /*byte[] array = new byte[resampler.Length];
            //con.Read(array, 0, (int)con.Length);
            resampler.Read(array, 0, (int)resampler.Length);
            resampler.Dispose();*/

            byte[] array = new byte[bufsize];

            //Console.WriteLine(resampler.BaseStream.Length);
            //Console.WriteLine(streamReader.Length);
            //Console.WriteLine(resampler.Length);
            //streamReader.Read(array, 0, (int)streamReader.Length);
            //streamReader.Dispose();
            sw = new StreamWriter(textOutputFile.Text.Insert
                (textOutputFile.Text.Length - 4, "_resample"));

            while (true)
            {
                int rdcnt = resampler.Read(array, 0, bufsize);
                if(rdcnt <= 0)
                    break;
                for (int i = 0; i < array.Length; i += 8)
                {
                    sw.WriteLine(BitConverter.ToSingle(array, i)
                        + "\t"
                        + BitConverter.ToSingle(array, i + 4));
                }
            }
            resampler.Dispose();
            streamReader.Dispose();
            sw.Dispose();


            streamReader = new WaveFileReader(textOutputFile.Text);
            array = new byte[streamReader.Length];
            streamReader.Read(array, 0, (int)streamReader.Length);
            streamReader.Dispose();
            sw = new StreamWriter(textOutputFile.Text);
            for(int i = 0; i < array.Length; i += 8)
            {
                sw.WriteLine(BitConverter.ToSingle(array, i)
                    + "\t"
                    + BitConverter.ToSingle(array, i + 4));

            }
            sw.Dispose();

        }
    }
}
