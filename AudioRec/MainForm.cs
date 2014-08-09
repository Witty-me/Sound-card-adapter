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

namespace AudioRec
{
	public partial class MainForm : Form
	{
		WasapiCapture capture;
		WaveWriter writer;
		TimeSpan recordTime;
		EventHandler<DataAvailableEventArgs> writeEvent;

		bool recording = false;

		public MainForm()
		{
			InitializeComponent();

			recordTime = new TimeSpan();

			writeEvent = new EventHandler<DataAvailableEventArgs>((s, e) =>
			{
				writer.Write(e.Data, e.Offset, e.ByteCount);
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
				capture.Device = device;
				capture.Initialize();

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
			saveDialog.Filter = "Waveform files|*.wav";
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

				writer = new WaveWriter(textOutputFile.Text, capture.WaveFormat);
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
				recording = false;

				recordTimer.Enabled = false;
				btnSelectDevice.Enabled = true;

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
	}
}
