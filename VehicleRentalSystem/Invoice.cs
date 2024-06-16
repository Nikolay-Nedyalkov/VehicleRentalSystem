using System;

namespace VehicleRentalSystem
{
    class Invoice
    {
        public string CustomerName { get; set; }
        public Vehicle RentedVehicle { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ReservedRentalDays => (ReservationEndDate - ReservationStartDate).Days;
        public int ActualRentalDays => (ActualReturnDate - ReservationStartDate).Days;

        public Invoice(string customerName, Vehicle rentedVehicle, DateTime reservationStartDate,
            DateTime reservationEndDate, DateTime actualReturnDate)
        {
            CustomerName = customerName;
            RentedVehicle = rentedVehicle;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ActualReturnDate = actualReturnDate;
        }

        public void PrintInvoice()
        {
            Console.WriteLine();
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine($"Date: {DateTime.Now.ToString("yyyy/MM/dd")}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Rented Vehicle: {RentedVehicle.Brand} {RentedVehicle.Model}");
            Console.WriteLine();
            Console.WriteLine($"Reservation start date: {ReservationStartDate.ToString("yyyy/MM/dd")}");
            Console.WriteLine($"Reservation end date: {ReservationEndDate.ToString("yyyy/MM/dd")}");
            Console.WriteLine($"Reserved rental days: {ReservedRentalDays} days");
            Console.WriteLine();
            Console.WriteLine($"Actual Return date: {ActualReturnDate.ToString("yyyy/MM/dd")}");
            Console.WriteLine($"Actual rental days: {ActualRentalDays} days");
            Console.WriteLine();
            double rentalCostPerDay = CalculateDailyRent();
            double insurancePerDay = CalculateInitialDailyInsurance();
            Console.WriteLine($"Rental cost per day: ${rentalCostPerDay:F2}");
            if (RentedVehicle is Car && ((Car)RentedVehicle).Rating > 3)
            {
                Console.WriteLine($"Initial insurance per day: ${insurancePerDay:F2}");
                Console.WriteLine($"Insurance discount per day: ${(insurancePerDay * 0.1):F2}");
                insurancePerDay *= 0.9;
            }
            if (RentedVehicle is Motorcycle && ((Motorcycle)RentedVehicle).RiderAge < 25)
            {
                Console.WriteLine($"Initial insurance per day: ${insurancePerDay:F2}");
                Console.WriteLine($"Insurance addition per day: ${(insurancePerDay * 0.2):F2}");
                insurancePerDay *= 1.2;
            }
            if (RentedVehicle is CargoVan && ((CargoVan)RentedVehicle).YearsOfExperience > 5)
            {
                Console.WriteLine($"Initial insurance per day: ${insurancePerDay:F2}");
                Console.WriteLine($"Insurance discount per day: ${(insurancePerDay * 0.15):F2}");
                insurancePerDay *= 0.85;
            }
            Console.WriteLine($"Insurance per day: ${insurancePerDay:F2}");
            Console.WriteLine();
            if (ReservedRentalDays > ActualRentalDays)
            {
                Console.WriteLine($"Early return discount for rent: " +
                    $"${((ReservedRentalDays - ActualRentalDays) * rentalCostPerDay * 0.5):F2}");
                Console.WriteLine($"Early return discount for insurance: " +
                    $"${((ReservedRentalDays - ActualRentalDays) * insurancePerDay):F2}");
                Console.WriteLine();
            }
            double totalInsurance = ActualRentalDays * insurancePerDay;
            double totalRent = CalculateTotalRent(rentalCostPerDay);
            Console.WriteLine($"Total rent: ${totalRent:F2}");
            Console.WriteLine($"Total insurance: ${totalInsurance:F2}");
            Console.WriteLine($"Total: ${(totalRent + totalInsurance):F2}");
            Console.WriteLine("XXXXXXXXXX");
        }

        private int CalculateDailyRent()
        {
            if (ActualRentalDays <= 7)
            {
                if (RentedVehicle is Car)
                    return 20;
                else if (RentedVehicle is Motorcycle)
                    return 15;
                else
                    return 50;
            }
            else
            {
                if (RentedVehicle is Car)
                    return 15;
                else if (RentedVehicle is Motorcycle)
                    return 10;
                else
                    return 40;
            }
        }

        private double CalculateInitialDailyInsurance()
        {
            if (RentedVehicle is Car)
                return (RentedVehicle.Value * 0.01 / 100);
            else if (RentedVehicle is Motorcycle)
                return (RentedVehicle.Value * 0.02 / 100);
            else
                return (RentedVehicle.Value * 0.03 / 100);
        }

        private double CalculateTotalRent(double rentalCostPerDay)
        {
            if (ActualRentalDays < ReservedRentalDays)
                return ActualRentalDays * rentalCostPerDay + (ReservedRentalDays - ActualRentalDays) * rentalCostPerDay * 0.5;
            else
                return ReservedRentalDays * rentalCostPerDay;
        }
    }
}
