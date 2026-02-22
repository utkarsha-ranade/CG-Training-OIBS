using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = ConfigurationManager.AppSettings["filePath"];

            if (File.Exists(filepath))
            {
                FileInfo finfo = new FileInfo(filepath);
                Console.WriteLine($"File Path: {finfo.FullName}");
                Console.WriteLine($"Size: {finfo.Length}");
                Console.WriteLine($"Creation Date: {finfo.CreationTime}");
            }
            else
                Console.WriteLine("File doesn't exist.");
            Console.Read();
        }
    }
}
