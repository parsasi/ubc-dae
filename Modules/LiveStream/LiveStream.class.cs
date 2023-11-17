
using System.Diagnostics;
using Modules.Robot;

namespace Modules.LiveStream
{
    public class LiveStream : IRobotOutlet
    {   
        protected readonly List<string> supportedFileTypes = new List<string> { ".jpg", ".png", ".gif" };

        public void OutputText(string text)
        {
            StreamText(text);
        }

        public void OutputMedia(string media)
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo(media);

            process.Start();
        }


        public bool ValidateMedia(string path)
        {
            var extension = Path.GetExtension(path);
            return this.supportedFileTypes.Contains(extension);
        }

        protected void StreamText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Livestream]  ");
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
