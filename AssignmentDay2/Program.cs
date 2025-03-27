using System.Runtime.InteropServices;
using DefaultNamespace;

namespace AssignmentDay2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string make;
            while (true)
            {
                Console.Write("Enter car make: ");
                make = Console.ReadLine();
        
                if (!string.IsNullOrWhiteSpace(make))
                {
                    break;
                }
                Console.WriteLine("Car make cannot be empty. Please try again!");
            }

            string model;
            while (true)
            {
                Console.Write("Enter car model: ");
                model = Console.ReadLine();
        
                if (!string.IsNullOrWhiteSpace(model))
                {
                    break;
                }
                Console.WriteLine("Car model cannot be empty. Please try again!");
            }
            
            var year = GetValidYear();
            var lastMaintenanceDate = GetValidMaintenanceDate();
            var car = GetCarType(make, model, year, lastMaintenanceDate);
            car.DisplayDetails();
            
            Console.Write("\nDo you want to refuel or charge the car? (Y/N): ");
            var choice = GetYesNoInput();
            if (choice != "Y") return;
            
            var refuelChargeTime = GetValidDateTime();
            ProcessRefuelOrCharge(car, refuelChargeTime);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void ProcessRefuelOrCharge(Car car, DateTime refuelChargeTime)
    {
        switch (car)
        {
            case IFuelable fuelableCar:
                fuelableCar.Refuel(refuelChargeTime);
                break;
            case IChargable chargableCar:
                chargableCar.Charge(refuelChargeTime);
                break;
            default:
                throw new InvalidOperationException("Unsupported car type");
        }
    }

    private static string GetYesNoInput()
    {
        while (true)
        {
            var input = Console.ReadLine()?.Trim().ToUpper();
            if (input is "Y" or "N")
                return input;
            Console.Write("Invalid input! Please enter 'Y' or 'N': ");
        }
    }

    private static DateTime GetValidDateTime()
    {
        while (true)
        {
            Console.Write($"Enter refuel/charge time (format: yyyy-MM-dd HH:mm, e.g.: 2025-01-01 12:00): ");
            if (DateTime.TryParse(Console.ReadLine(), out var result))
            {
                return result;
            }
            Console.WriteLine($"Invalid date! Please enter a valid date in the format yyyy-MM-dd HH:mm.");
        }
    }

    private static Car GetCarType(string? make, string? model, int year, DateTime lastMaintenanceDate)
    {
        while (true)
        {
            Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
            var carType = Console.ReadLine()?.Trim().ToUpper();

            switch (carType)
            {
                case "F":
                    return new FuelCar(make, model, year, lastMaintenanceDate);
                case "E":
                    return new ElectricCar(make, model, year, lastMaintenanceDate);
                default:
                    Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
                    break;
            }
        }
    }

    private static DateTime GetValidMaintenanceDate()
    {
        while (true)
        {
            Console.Write($"Enter last maintenance date (format: yyyy-MM-dd, e.g.: 2025-01-01): ");
            if (DateTime.TryParse(Console.ReadLine(), out var result))
            {
                return result;
            }
            Console.WriteLine($"Invalid date! Please enter a valid date in the format yyyy-MM-dd.");
        }
    }

    private static int GetValidYear()
    {
        while (true)
        {
            Console.Write("Enter car year (e.g.: 2025): ");
            if (int.TryParse(Console.ReadLine(), out var year) && year >= 1886 && year <= DateTime.Now.Year)
            {
                return year;
            }
            Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
        }
    }
}