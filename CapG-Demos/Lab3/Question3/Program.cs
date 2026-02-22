using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    internal class Program
    {
        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double SalePrice { get; set; }
            public Car() { }
            public Car(string make, string model, int year, double salePrice)
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
                this.SalePrice = salePrice;
            }
        }
        static void Main(string[] args)
        {
            int operation = 0;
            Car[] allCars = new Car[20];
            int nCars = 0;

            while (operation != 6)
            {
                Console.WriteLine("1. Adding a new car");
                Console.WriteLine("2. Modify the details of a particular car");
                Console.WriteLine("3. Search for a particular car in the Catalog");
                Console.WriteLine("4. List all the cars in the Catalog");
                Console.WriteLine("5. Delete a car from the Catalog");
                Console.WriteLine("6. Quit");

                Console.Write("Select one menu item: ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddNewCar(allCars, ref nCars);
                            break;
                        case 2:
                            ModifyDetailsParticularCar(allCars, nCars);
                            break;
                        case 3:
                            SearchParticularCarCatalog(allCars, nCars);
                            break;
                        case 4:
                            ListAllCarsInCatalog(allCars, nCars);
                            break;
                        case 5:
                            DeleteCarFromCatalog(allCars, ref nCars);
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Wrong Choice.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid Choice");
            }
            Console.Read();
        }
        private static void AddNewCar(Car[] allCars, ref int nCars)
        {
            allCars[nCars] = new Car();
            Console.Write("Enter make of a car: ");
            allCars[nCars].Make = Console.ReadLine();
            Console.Write("Enter model of a car: ");
            allCars[nCars].Model = Console.ReadLine();
            Console.Write("Enter year of a car: ");
            allCars[nCars].Year = int.Parse(Console.ReadLine());
            Console.Write("Enter sale price of a car: ");
            allCars[nCars].SalePrice = double.Parse(Console.ReadLine());
            nCars++;
        }
        private static void ListAllCarsInCatalog(Car[] allCars, int nCars)
        {
            if (nCars > 0)
            {
                Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}", "Car ID", "Make", "Model", "Year", "Sale Price");
                for (int i = 0; i < nCars; i++)
                {
                    Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}", (i + 1), allCars[i].Make, allCars[i].Model, allCars[i].Year, allCars[i].SalePrice);
                }
            }
            else
            {
                Console.WriteLine("\nThe catalog is empty.\n");
            }
        }
        private static void ModifyDetailsParticularCar(Car[] allCars, int nCars)
        {
            if (nCars > 0)
            {
                ListAllCarsInCatalog(allCars, nCars);
                Console.Write("Enter ID of a car you want to edit: ");
                int selectedCar = int.Parse(Console.ReadLine());
                selectedCar--;
                if (selectedCar >= 0 && selectedCar < nCars)
                {
                    Console.Write("Enter a new make of a car: ");
                    allCars[selectedCar].Make = Console.ReadLine();
                    Console.Write("Enter a new model of a car: ");
                    allCars[selectedCar].Model = Console.ReadLine();
                    Console.Write("Enter a new year of a car: ");
                    allCars[selectedCar].Year = int.Parse(Console.ReadLine());
                    Console.Write("Enter a new sale price of a car: ");
                    allCars[selectedCar].SalePrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("\nSelected car has been updated.\n");
                }
                else
                {
                    Console.WriteLine("\nWrong ID.\n");
                }
            }
            else
            {
                Console.WriteLine("\nThe catalog is empty.\n");
            }
        }
        private static void SearchParticularCarCatalog(Car[] allCars, int nCars)
        {
            if (nCars > 0)
            {
                Console.Write("Enter make of a car to search: ");
                string make = Console.ReadLine();
                Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}", "Car ID", "Make", "Model", "Year", "Sale Price");
                for (int i = 0; i < nCars; i++)
                {
                    bool exist = false;
                    if (allCars[i].Make.CompareTo(make) == 0 || allCars[i].Model.CompareTo(make) == 0)
                    {
                        Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}", (i + 1), allCars[i].Make, allCars[i].Model, allCars[i].Year, allCars[i].SalePrice);
                        exist = true;
                    }
                    if (!exist)
                    {
                        Console.WriteLine("\nThe car with the make does not exist.\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThe catalog is empty.\n");
            }
        }
        private static void DeleteCarFromCatalog(Car[] allCars, ref int nCars)
        {
            if (nCars > 0)
            {
                ListAllCarsInCatalog(allCars, nCars);
                Console.Write("Enter ID of a car to delete: ");
                int selectedCar = int.Parse(Console.ReadLine());
                selectedCar--;
                if (selectedCar >= 0 && selectedCar < nCars)
                {
                    for (int i = selectedCar; i < nCars - 1; i++)
                    {
                        allCars[i] = allCars[i + 1];
                    }
                    nCars--;
                    Console.WriteLine("\nThe car has been deleted.\n");
                }
                else
                {
                    Console.WriteLine("\nWrong ID.\n");
                }
            }
            else
            {
                Console.WriteLine("\nThe catalog is empty.\n");
            }
        }
    }
}
