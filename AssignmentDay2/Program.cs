using System.Runtime.InteropServices;
using DefaultNamespace;

namespace AssignmentDay2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string make = GetNonEmptyInput("Enter car make: ", "Car make cannot be empty. Please try again!");
            string model = GetNonEmptyInput("Enter car model: ", "Car model cannot be empty. Please try again!");
            
            var year = GetValidYear();
            var lastMaintenanceDate = GetValidMaintenanceDate();
            var car = GetCarType(make, model, year, lastMaintenanceDate);
            car.DisplayDetails();
            
            Console.Write("\nDo you want to refuel or charge the car? (Y/N): ");
            var choice = GetYesNoInput();
            if (choice != "Y") return;
            
            var operationDate = GetValidDateTime();
            ProcessRefuelOrCharge(car, operationDate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static string GetNonEmptyInput(string prompt, string errorMessage)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
        
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine(errorMessage);
        }
    }

    private static void ProcessRefuelOrCharge(Car car, DateTime operationDate)
    {
        switch (car)
        {
            case IFuelable fuelCar:
                fuelCar.Refuel(operationDate);
                break;
            case IChargable electricCar:
                electricCar.Charge(operationDate);
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

    private static Car GetCarType(string make, string model, int year, DateTime lastMaintenanceDate)
    {
        while (true)
        {
            Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
            var carType = Console.ReadLine()?.Trim().ToUpper();

            try
            {
                return carType switch
                {
                    "F" => new FuelCar(make, model, year, lastMaintenanceDate),
                    "E" => new ElectricCar(make, model, year, lastMaintenanceDate),
                    _ => throw new ArgumentException("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.")
                };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
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