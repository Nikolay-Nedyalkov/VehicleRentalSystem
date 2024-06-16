namespace VehicleRentalSystem
{
    class CargoVan : Vehicle
    {
        public CargoVan(string brand, string model, double value)
            :base(brand,model,value)
        {

        }

        public int YearsOfExperience { get; set; }
    }
}
