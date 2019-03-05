using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ScreenCapture
{
    public class utils
    {
        public static ProcessStartInfo GetProcessStartInfo(string fileName, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.StandardErrorEncoding = Encoding.UTF8;
            startInfo.StandardOutputEncoding = Encoding.UTF8;

            return startInfo;
        }
    }
}
