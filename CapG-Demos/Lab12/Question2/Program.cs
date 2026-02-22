using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the source file name: ");
            string sourceFile = Console.ReadLine();
            Console.Write("Enter the destination file name: ");
            string destinationFile = Console.ReadLine(); ;
            try
            {
                File.Copy(sourceFile, destinationFile, true);
                using (StreamReader file = new StreamReader(destinationFile))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    file.Close();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
