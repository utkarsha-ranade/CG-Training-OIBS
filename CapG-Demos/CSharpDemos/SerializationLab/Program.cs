using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                ID = 1,
                Name = "Sid",
                DOB = new DateTime(2000, 7, 4)
            };

            List<Customer> list = new List<Customer>()
            {
                new Customer
                {
                    ID = 1,
                    Name = "Sid",
                    DOB = new DateTime(2000, 7, 4)
                },
                new Customer
                {
                    ID = 2,
                    Name = "Sid2",
                    DOB = new DateTime(2000, 7, 4)
                }
            };
            //SerializeBinary(customer1);
            //DeSerializeBinary();
            //SerializeXML(list);
            //DeSerializeXML();
            //SerializeJSON(list);
            //DeSerializeJSON();
            SerializeJSONConvert(list);
            Console.Read();
        }
        static void SerializeJSONConvert(List<Customer> list)
        {
            string filepath = ConfigurationManager.AppSettings["JSONFile"];

            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                string jsonData = JSONConvert.SerializeObject(list);
                Console.WriteLine("Done!!!");
            }
        }
        static void DeSerializeJSON()
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["JSONFile"];

                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(List<Customer>));
                    var data = jser.ReadObject(fs);
                    if (data != null)
                    {
                        if (data is List<Customer> list)
                        {
                            foreach (var customer in list)
                            {
                                Console.WriteLine(customer);
                            }
                        }
                    }
                    Console.WriteLine("Done!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SerializeJSON(List<Customer> list)
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["JSONFile"];

                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(List<Customer>));
                    jser.WriteObject(fs, list);
                    Console.WriteLine("Done!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeSerializeXML()
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["XMLFile"];

                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Customer>));
                    var data = xmlSerializer.Deserialize(fs);                
                    if (data != null)
                    {
                        if (data is List<Customer> list)
                        {
                            foreach (var customer in list)
                            {
                                Console.WriteLine(customer);
                            }
                        }
                    }
                    Console.WriteLine("Done!!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SerializeXML(List<Customer> list)
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["XMLFile"];

                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Customer>));
                    xmlSerializer.Serialize(fs, list);
                 
                    Console.WriteLine("Done!!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeSerializeBinary()
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["FilePath"];

                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binaryForm = new BinaryFormatter();
                    object data = binaryForm.Deserialize(fs);                //var can also be used instead of objects
                    if (data != null)
                    {
                        if (data is Customer customer1)
                        {
                            Console.WriteLine(customer1);
                        }
                    }
                    Console.WriteLine("Done!!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SerializeBinary(Customer customer)
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["FilePath"];

                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter binaryForm = new BinaryFormatter();
                    binaryForm.Serialize(fs, customer);
                    Console.WriteLine("Done!!!!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
