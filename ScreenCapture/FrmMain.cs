using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class FrmMain : Form
    {
        private string ffmpegPath = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";
        private Process process;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate ()
            {
                if (btnRecord.InvokeRequired)
                {
                    btnRecord.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        btnRecord.Enabled = false;
                        btnRecord.Text = "正在录制";

                    }));
                }
                else
                {
                    btnRecord.Enabled = false;
                    btnRecord.Text = "正在录制";
                }

                if (btnStop.InvokeRequired)
                {
                    btnRecord.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        btnStop.Enabled = true;
                    }));
                }
                else
                {
                    btnStop.Enabled = true;
                }

                process = new Process();

                string ffmpgArg = "-f dshow -i video=\"" + txtVideoDevice.Text + "\":audio=\"" + txtAudioDevice.Text + "\"  -vcodec libx264 -preset:v ultrafast -tune:v zerolatency " + txtOutPath.Text + txtFileName.Text;
                process.StartInfo = utils.GetProcessStartInfo(ffmpegPath, ffmpgArg);
                process.Start();


            }).Start();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnRecord.Enabled = true;
            btnStop.Enabled = false;

            txtFileName.Text = Guid.NewGuid() + ".AVI";
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
            new Thread((ThreadStart)delegate ()
            {
                if (btnStop.InvokeRequired)
                {
                    btnStop.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        btnStop.Text = "停止中...";
                        btnStop.Enabled = false;
                    }));
                }
                else
                {
                    btnStop.Text = "停止中...";
                    btnStop.Enabled = false;
                }

                Thread.Sleep(10000);
                process.StandardInput.WriteLine("q");
                process.Close();
                Process[] processes = Process.GetProcessesByName("ffmpeg");
                foreach (Process p in processes)
                {
                    p.Kill();
                }

                if (btnStop.InvokeRequired)
                {
                    btnStop.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        btnStop.Text = "停止";
                    }));
                }
                else
                {
                    btnStop.Text = "停止";
                }

                if (btnRecord.InvokeRequired)
                {
                    btnRecord.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        btnRecord.Text = "开始录屏";
                        btnRecord.Enabled = true;
                    }));
                }
                else
                {
                    btnRecord.Text = "开始录屏";
                    btnRecord.Enabled = true;
                }

            }).Start();
        }
    }
}