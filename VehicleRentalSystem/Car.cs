using System;

namespace VehicleRentalSystem
{
    class Car : Vehicle
    {
        public Car(string brand, string model, double value, int rating)
            : base(brand, model, value)
        {
            Rating = rating;
        }

        public int Rating { get; set; }

        public override void PrintVehicleInfo()
        {
            Console.WriteLine($"{Brand} {Model} ${Value} Safety Rating: {Rating}");
        }
    }
}
