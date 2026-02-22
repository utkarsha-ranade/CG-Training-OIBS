using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWriteLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["FilePath"];

                //write
                //using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                //{
                //    using (StreamWriter sw = new StreamWriter(fs))
                //    {
                //        sw.WriteLine("Hello!");
                //        sw.WriteLine("Welcome to CapG!");
                //        Console.WriteLine("Done!!!");
                //    }
                //}                           
                //sw.Close();
                //fs.Close();

                //read
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        Console.WriteLine("Done!!!");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
