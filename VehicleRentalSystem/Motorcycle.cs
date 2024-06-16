namespace VehicleRentalSystem
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string brand, string model, double value)
            :base(brand, model, value)
        {

        }

        public int RiderAge { get; set; }
    }
}
