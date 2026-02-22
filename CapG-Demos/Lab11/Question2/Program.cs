using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        public delegate void DownloadCompeteHandler(int perc);

        public class FileDownloader
        {
            protected string resourceUrl;
            protected string resourceSavePath;

            public event DownloadCompeteHandler DownLoadComplete;

            public FileDownloader(string url, string savepath)
            {
                this.resourceUrl = url;
                this.resourceSavePath = savepath;
            }
            public void DownLoadResource()
            {
                for (int i = 1; i <= 4; i++)
                {
                    OnDownLoadComplete(i * 25);
                    int milliseconds = 2000;
                    Thread.Sleep(milliseconds);
                }
            }
            protected void OnDownLoadComplete(int k)
            {
                if (DownLoadComplete != null)
                {
                    DownLoadComplete(k);
                }
            }
        }
        public static void Main(string[] args)
        {
            FileDownloader fd = new FileDownloader("http://www.microsoft.com/vstudio/expressv10.zip", "d:\\setups");
            fd.DownLoadComplete += fd_DownLoadComplete;
            fd.DownLoadResource();

            Console.ReadKey();
        }
        static void fd_DownLoadComplete(int perc)
        {
            Console.SetCursorPosition(10, 10);
            Console.Write("Downloading {0} Percent Complete", perc);
        }
    }
}
