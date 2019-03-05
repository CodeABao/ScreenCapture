using System.Diagnostics;
using System.Text;

namespace ScreenCapture
{
    public class utils
    {
        public static ProcessStartInfo GetProcessStartInfo(string fileName, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            return startInfo;
        }
    }
}
