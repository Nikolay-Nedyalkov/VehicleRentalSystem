using System;
namespace VehicleRentalSystem
{
    abstract class Vehicle
    {
        public Vehicle(string brand, string model, double value)
        {
            Brand = brand;
            Model = model;
            Value = value;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double Value { get; set; }

        public virtual void PrintVehicleInfo()
        {
            Console.WriteLine($"{Brand} {Model} {Value}");
        }
    }
}
