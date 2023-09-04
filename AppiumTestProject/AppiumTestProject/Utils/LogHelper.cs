using System;
using System.IO;
using System.Text;

namespace AppiumTestProject.Utils
{
    public static class LogHelper
    {
        private static object sync = new object();
        private static DateTime dateTime = DateTime.Now;

        public static void WriteExceprion(Exception ex)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(pathToLog))
                Directory.CreateDirectory(pathToLog);
            string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy.HH.mm.ss}.log",
            AppDomain.CurrentDomain.FriendlyName, dateTime));
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\r\n",
            DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
            lock (sync)
            {
                File.AppendAllText(filename, fullText, Encoding.Default);
            }
        }

        public static void WriteMessage(string message)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(pathToLog))
                Directory.CreateDirectory(pathToLog);
            string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy.HH.mm.ss}.log",
            AppDomain.CurrentDomain.FriendlyName, dateTime));
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}]\r\n",
            DateTime.Now, message);
            lock (sync)
            {
                File.AppendAllText(filename, fullText, Encoding.Default);
            }
        }

        public static void WriteStepHeader(string stepNumber, string message)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(pathToLog))
                Directory.CreateDirectory(pathToLog);
            string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy.HH.mm.ss}.log",
            AppDomain.CurrentDomain.FriendlyName, dateTime));
            string fullText = string.Format("\r\n///////////////////////////////////\r\n" +
                "[{0:dd.MM.yyy HH:mm:ss.fff}] [Step {2}] [{1}]\r\n" +
                "///////////////////////////////////\r\n",
            DateTime.Now, message, stepNumber);
            lock (sync)
            {
                File.AppendAllText(filename, fullText, Encoding.Default);
            }
        }
    }
}
