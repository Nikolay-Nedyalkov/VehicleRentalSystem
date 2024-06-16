using System;
using System.Collections.Generic;

namespace VehicleRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Thanks for choosing our services!\nWhat are we gonna be driving today? :D");
            List<Car> cars = GetCars();
            List<Motorcycle> motorcycles = GetMotorcycles();
            List<CargoVan> cargoVans = GetCargoVans();
            string vehicleType = GetValidVehicleType();

            switch (vehicleType)
            {
                case "car":
                    PrintCars(cars);
                    int selectedCarIndex = GetSelectedVehicleIndex(cars.Count, vehicleType);
                    Car selectedCar = cars[selectedCarIndex];
                    Console.Write("Selected: ");
                    selectedCar.PrintVehicleInfo();
                    RentVehicle(selectedCar, vehicleType);
                    break;
                case "motorcycle":
                    PrintMotorcycles(motorcycles);
                    int selectedMotorcycleIndex = GetSelectedVehicleIndex(motorcycles.Count, vehicleType);
                    Motorcycle selectedMotorcycle = motorcycles[selectedMotorcycleIndex];
                    Console.Write("Selected: ");
                    selectedMotorcycle.PrintVehicleInfo();
                    int riderAge = GetValidRiderAge();
                    selectedMotorcycle.RiderAge = riderAge;
                    RentVehicle(selectedMotorcycle, vehicleType);
                    break;
                case "cargo van":
                    PrintCargoVans(cargoVans);
                    int selectedCargoVanIndex = GetSelectedVehicleIndex(cargoVans.Count, vehicleType);
                    CargoVan selectedCargoVan = cargoVans[selectedCargoVanIndex];
                    Console.Write("Selected: ");
                    selectedCargoVan.PrintVehicleInfo();
                    int yearsOfExperience = GetValidInteger("Years of driving experience: ");
                    selectedCargoVan.YearsOfExperience = yearsOfExperience;
                    RentVehicle(selectedCargoVan, vehicleType);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>
            {
                new Car("Volvo", "V70", 6000, 5),
                new Car("Honda", "Accord", 10000, 4),
                new Car("Ford", "Fusion", 15000, 3),
                new Car("Toyota", "Camry", 12000, 2),
                new Car("BMW", "316ti", 3000, 1),
                new Car("Opel", "Corsa", 1000, 3),
                new Car("BMW", "M340i", 120000, 3)
            };

            return cars;
        }

        static List<Motorcycle> GetMotorcycles()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>
            {
                new Motorcycle("Yamaha", "YZF-R3", 5000),
                new Motorcycle("Kawasaki", "Ninja 300", 6000),
                new Motorcycle("Honda", "CBR500R", 7000),
                new Motorcycle("Yamaha", "R1", 18000),
                new Motorcycle("BMW", "S1000rr", 25000),
                new Motorcycle("Husqvarna", "FE 501", 10000)
            };

            return motorcycles;
        }

        static List<CargoVan> GetCargoVans()
        {
            List<CargoVan> cargoVans = new List<CargoVan>
            {
                new CargoVan("Ford", "Transit", 25000),
                new CargoVan("Mercedes", "Sprinter", 30000),
                new CargoVan("Ram", "ProMaster", 28000),
                new CargoVan("Chevrolet", "Express", 20000),
                new CargoVan("Renault", "Master", 15000),
                new CargoVan("Opel", "Combo Cargo", 10000)
            };

            return cargoVans;
        }

        static string GetValidVehicleType()
        {
            string vehicleType;
            while (true)
            {
                Console.WriteLine("Car, motorcycle or cargo van?:");
                vehicleType = Console.ReadLine().Trim().ToLower();

                if (vehicleType == "car" || vehicleType == "motorcycle" || vehicleType == "cargo van")
                {
                    return vehicleType;
                }

                Console.WriteLine("Invalid input. Please enter 'car', 'motorcycle', or 'cargo van'.");
            }
        }

        static void PrintCars(List<Car> cars)
        {
            int counter = 1;

            foreach (Car car in cars)
            {
                Console.Write($"{counter++}. ");
                car.PrintVehicleInfo();
            }
        }

        static void PrintMotorcycles(List<Motorcycle> motorcycles)
        {
            int counter = 1;

            foreach (Motorcycle motorcycle in motorcycles)
            {
                Console.Write($"{counter++}. ");
                motorcycle.PrintVehicleInfo();
            }
        }

        static void PrintCargoVans(List<CargoVan> vans)
        {
            int counter = 1;

            foreach (CargoVan van in vans)
            {
                Console.Write($"{counter++}. ");
                van.PrintVehicleInfo();
            }
        }

        static int GetSelectedVehicleIndex(int count, string vehicleType)
        {
            int index;
            while (true)
            {
                Console.WriteLine($"Select a {vehicleType} by number:");
                string input = Console.ReadLine().Trim();

                if (int.TryParse(input, out index) && index > 0 && index <= count)
                {
                    return index - 1;
                }

                Console.WriteLine("Invalid input. Please select a valid number from the list.");
            }
        }

        static int GetValidRiderAge()
        {
            int value;
            while (true)
            {
                Console.WriteLine("Rider age: ");
                string input = Console.ReadLine().Trim();

                if (int.TryParse(input, out value) && value >= 18)
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Rider should be atleast 18 years old.");
            }
        }

        static void RentVehicle(Vehicle vehicle, string vehicleType)
        {
            string customerName = GetValidInput("Enter your name: ");

            Console.WriteLine("Start date for the rental (yyyy-mm-dd):");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format:");
            }

            int rentalDays = GetValidInteger("Enter the number of rental days: ");

            DateTime endDate = startDate.AddDays(rentalDays);

            Console.WriteLine("Return date for the rental (yyyy-mm-dd):    //simulates the scenario when the customer returns the vehicle");
            DateTime returnDate;
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out returnDate))
                {
                    if (returnDate <= endDate && returnDate > startDate)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid return date. Please enter a valid date:");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format:");
                }
            }

            Invoice invoice = new Invoice(customerName, vehicle, startDate, endDate, returnDate);
            invoice.PrintInvoice();
        }

        static string GetValidInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }

                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        static int GetValidInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().Trim();

                if (int.TryParse(input, out value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
    }
}
