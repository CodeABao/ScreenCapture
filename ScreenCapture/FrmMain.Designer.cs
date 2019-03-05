namespace ScreenCapture
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.txtAudioDevice = new System.Windows.Forms.TextBox();
            this.txtVideoDevice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "音频";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "图像";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(693, 209);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(110, 31);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "开始录屏";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // txtAudioDevice
            // 
            this.txtAudioDevice.Location = new System.Drawing.Point(92, 20);
            this.txtAudioDevice.Name = "txtAudioDevice";
            this.txtAudioDevice.Size = new System.Drawing.Size(381, 25);
            this.txtAudioDevice.TabIndex = 6;
            this.txtAudioDevice.Text = "virtual-audio-capturer";
            // 
            // txtVideoDevice
            // 
            this.txtVideoDevice.Location = new System.Drawing.Point(91, 62);
            this.txtVideoDevice.Name = "txtVideoDevice";
            this.txtVideoDevice.Size = new System.Drawing.Size(382, 25);
            this.txtVideoDevice.TabIndex = 7;
            this.txtVideoDevice.Text = "screen-capture-recorder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "输出目录";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(91, 108);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(382, 25);
            this.txtOutPath.TabIndex = 9;
            this.txtOutPath.DoubleClick += new System.EventHandler(this.txtOutPath_DoubleClick);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(91, 152);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(382, 25);
            this.txtFileName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "文件名";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(820, 209);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 31);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 252);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVideoDevice);
            this.Controls.Add(this.txtAudioDevice);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TextBox txtAudioDevice;
        private System.Windows.Forms.TextBox txtVideoDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStop;
    }
}

