namespace AudioRec
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupDeviceSelection = new System.Windows.Forms.GroupBox();
			this.btnFindDevices = new System.Windows.Forms.Button();
			this.btnSelectDevice = new System.Windows.Forms.Button();
			this.listDevices = new System.Windows.Forms.ListView();
			this.groupOutputFileSelection = new System.Windows.Forms.GroupBox();
			this.btnBrowseFile = new System.Windows.Forms.Button();
			this.textOutputFile = new System.Windows.Forms.TextBox();
			this.groupRecording = new System.Windows.Forms.GroupBox();
			this.btnOpenFileLoc = new System.Windows.Forms.Button();
			this.lblTime = new System.Windows.Forms.Label();
			this.btnStartStop = new System.Windows.Forms.Button();
			this.recordTimer = new System.Windows.Forms.Timer(this.components);
			this.groupDeviceSelection.SuspendLayout();
			this.groupOutputFileSelection.SuspendLayout();
			this.groupRecording.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupDeviceSelection
			// 
			this.groupDeviceSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupDeviceSelection.Controls.Add(this.btnFindDevices);
			this.groupDeviceSelection.Controls.Add(this.btnSelectDevice);
			this.groupDeviceSelection.Controls.Add(this.listDevices);
			this.groupDeviceSelection.Location = new System.Drawing.Point(13, 13);
			this.groupDeviceSelection.Name = "groupDeviceSelection";
			this.groupDeviceSelection.Size = new System.Drawing.Size(356, 166);
			this.groupDeviceSelection.TabIndex = 0;
			this.groupDeviceSelection.TabStop = false;
			this.groupDeviceSelection.Text = "1. Select recording device";
			// 
			// btnFindDevices
			// 
			this.btnFindDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFindDevices.Location = new System.Drawing.Point(6, 137);
			this.btnFindDevices.Name = "btnFindDevices";
			this.btnFindDevices.Size = new System.Drawing.Size(105, 23);
			this.btnFindDevices.TabIndex = 2;
			this.btnFindDevices.Text = "Find devices";
			this.btnFindDevices.UseVisualStyleBackColor = true;
			this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
			// 
			// btnSelectDevice
			// 
			this.btnSelectDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectDevice.Location = new System.Drawing.Point(245, 137);
			this.btnSelectDevice.Name = "btnSelectDevice";
			this.btnSelectDevice.Size = new System.Drawing.Size(105, 23);
			this.btnSelectDevice.TabIndex = 1;
			this.btnSelectDevice.Text = "Select";
			this.btnSelectDevice.UseVisualStyleBackColor = true;
			this.btnSelectDevice.Click += new System.EventHandler(this.btnSelectDevice_Click);
			// 
			// listDevices
			// 
			this.listDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listDevices.HideSelection = false;
			this.listDevices.Location = new System.Drawing.Point(6, 19);
			this.listDevices.MultiSelect = false;
			this.listDevices.Name = "listDevices";
			this.listDevices.Size = new System.Drawing.Size(344, 112);
			this.listDevices.TabIndex = 0;
			this.listDevices.UseCompatibleStateImageBehavior = false;
			this.listDevices.View = System.Windows.Forms.View.List;
			// 
			// groupOutputFileSelection
			// 
			this.groupOutputFileSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupOutputFileSelection.Controls.Add(this.btnBrowseFile);
			this.groupOutputFileSelection.Controls.Add(this.textOutputFile);
			this.groupOutputFileSelection.Location = new System.Drawing.Point(13, 186);
			this.groupOutputFileSelection.Name = "groupOutputFileSelection";
			this.groupOutputFileSelection.Size = new System.Drawing.Size(356, 50);
			this.groupOutputFileSelection.TabIndex = 1;
			this.groupOutputFileSelection.TabStop = false;
			this.groupOutputFileSelection.Text = "2. Select output file";
			// 
			// btnBrowseFile
			// 
			this.btnBrowseFile.Location = new System.Drawing.Point(275, 18);
			this.btnBrowseFile.Name = "btnBrowseFile";
			this.btnBrowseFile.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseFile.TabIndex = 1;
			this.btnBrowseFile.Text = "Browse";
			this.btnBrowseFile.UseVisualStyleBackColor = true;
			this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
			// 
			// textOutputFile
			// 
			this.textOutputFile.Location = new System.Drawing.Point(7, 20);
			this.textOutputFile.Name = "textOutputFile";
			this.textOutputFile.Size = new System.Drawing.Size(262, 20);
			this.textOutputFile.TabIndex = 0;
			this.textOutputFile.TextChanged += new System.EventHandler(this.textOutputFile_TextChanged);
			// 
			// groupRecording
			// 
			this.groupRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupRecording.Controls.Add(this.btnOpenFileLoc);
			this.groupRecording.Controls.Add(this.lblTime);
			this.groupRecording.Controls.Add(this.btnStartStop);
			this.groupRecording.Location = new System.Drawing.Point(13, 243);
			this.groupRecording.Name = "groupRecording";
			this.groupRecording.Size = new System.Drawing.Size(356, 65);
			this.groupRecording.TabIndex = 2;
			this.groupRecording.TabStop = false;
			this.groupRecording.Text = "3. Record!";
			// 
			// btnOpenFileLoc
			// 
			this.btnOpenFileLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFileLoc.Enabled = false;
			this.btnOpenFileLoc.Location = new System.Drawing.Point(222, 19);
			this.btnOpenFileLoc.Name = "btnOpenFileLoc";
			this.btnOpenFileLoc.Size = new System.Drawing.Size(128, 23);
			this.btnOpenFileLoc.TabIndex = 2;
			this.btnOpenFileLoc.Text = "Open output location";
			this.btnOpenFileLoc.UseVisualStyleBackColor = true;
			this.btnOpenFileLoc.Click += new System.EventHandler(this.btnOpenFileLoc_Click);
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point(88, 33);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(33, 13);
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "Time:";
			// 
			// btnStartStop
			// 
			this.btnStartStop.Location = new System.Drawing.Point(7, 20);
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.Size = new System.Drawing.Size(75, 39);
			this.btnStartStop.TabIndex = 0;
			this.btnStartStop.Text = "Start!";
			this.btnStartStop.UseVisualStyleBackColor = true;
			this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
			// 
			// recordTimer
			// 
			this.recordTimer.Interval = 1000;
			this.recordTimer.Tick += new System.EventHandler(this.recordTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 320);
			this.Controls.Add(this.groupRecording);
			this.Controls.Add(this.groupOutputFileSelection);
			this.Controls.Add(this.groupDeviceSelection);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Audio Recorder";
			this.groupDeviceSelection.ResumeLayout(false);
			this.groupOutputFileSelection.ResumeLayout(false);
			this.groupOutputFileSelection.PerformLayout();
			this.groupRecording.ResumeLayout(false);
			this.groupRecording.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupDeviceSelection;
		private System.Windows.Forms.ListView listDevices;
		private System.Windows.Forms.Button btnSelectDevice;
		private System.Windows.Forms.GroupBox groupOutputFileSelection;
		private System.Windows.Forms.TextBox textOutputFile;
		private System.Windows.Forms.Button btnBrowseFile;
		private System.Windows.Forms.GroupBox groupRecording;
		private System.Windows.Forms.Button btnStartStop;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Button btnOpenFileLoc;
		private System.Windows.Forms.Button btnFindDevices;
		private System.Windows.Forms.Timer recordTimer;
	}
}

