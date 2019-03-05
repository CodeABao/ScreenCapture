using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class FrmMain : Form
    {
        [DllImport("User32.dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private string ffmpegPath = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            btnRecord.Enabled = false;
            btnRecord.Text = "正在录制";


            Process process = new Process();

            string ffmpgArg = "-f dshow -i video=\"" + txtVideoDevice.Text + "\":audio=\"" + txtAudioDevice.Text + "\"  -vcodec libx264 -preset:v ultrafast -tune:v zerolatency " + txtOutPath.Text + txtFileName.Text;
            process.StartInfo = utils.GetProcessStartInfo(ffmpegPath, ffmpgArg);

            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.Start();
            process.BeginErrorReadLine();

            btnStop.Enabled = true;

        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnRecord.Enabled = true;
            btnStop.Enabled = false;

            txtFileName.Text = Guid.NewGuid() + ".mkv";
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

                Process[] processes = Process.GetProcessesByName("ffmpeg");
                foreach (Process p in processes)
                {
                    PostMessage(p.MainWindowHandle, 0x100, (int)Keys.Q, 0);
                    Thread.Sleep(1000);
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