using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class FrmMain : Form
    {
        [DllImport("User32.dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private string ffmpegPath = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";
        private Process process;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            process = new Process();
            process.StartInfo = utils.GetProcessStartInfo(ffmpegPath, "-f dshow -i video=\"" + txtVideoDevice.Text + "\":audio=\"" + txtAudioDevice.Text + "\"  -vcodec libx264 -preset:v ultrafast -tune:v zerolatency " + txtOutPath.Text + txtFileName.Text);
            process.Start();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Guid.NewGuid() + ".wmv";
            txtOutPath.Text = AppDomain.CurrentDomain.BaseDirectory;

            Process[] processes = Process.GetProcessesByName("ffmpeg");
            foreach (Process p in processes)
            {
                p.Kill();
            }
        }

        private void txtOutPath_DoubleClick(object sender, EventArgs e)
        {
            FBD.ShowDialog();
            txtOutPath.Text = FBD.SelectedPath + "\\";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("ffmpeg");
            foreach (Process p in processes)
            {
                var hWnd = p.MainWindowHandle;
                PostMessage(hWnd, 0x100, (int)Keys.Q, 0);
                p.Kill();
            }
        }
    }
}