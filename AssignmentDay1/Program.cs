namespace AssignmentDay1;

class Program
{
    private static List<Car> cars = new List<Car>()
    {
        new Car { Make = "Tesla", Model = "Model S", Year = 2022, Type = CarType.Electric },
        new Car { Make = "Toyota", Model = "Corolla", Year = 2021, Type = CarType.Fuel },
        new Car { Make = "Ford", Model = "Mustang Mach-E", Year = 2023, Type = CarType.Electric },
        new Car { Make = "Honda", Model = "Civic", Year = 2020, Type = CarType.Fuel },
        new Car { Make = "Rivian", Model = "R1T", Year = 2023, Type = CarType.Electric }
    };
    
    static void Main(string[] args)
    {
        int option;

        do
        {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    AddCar();
                    break;
                case 2:
                    ViewAllCars();
                    break;
                case 3:
                    SearchCarByMake();
                    break;
                case 4:
                    FilterCarByType();
                    break;
                case 5:
                    RemoveCarByModel();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option! Please select a valid option.");
                    break;
            }
        } while (option != 6);
    }

    private static void RemoveCarByModel()
    {
        Console.Write("\nEnter model to remove: ");
        var model = Console.ReadLine();
        var carToRemove = cars.FirstOrDefault(car => car.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
    
        if (carToRemove == null)
        {
            Console.WriteLine("Car not found!");
            return;
        }

        cars.Remove(carToRemove);
        Console.WriteLine("Car removed successfully!");
    }

    private static void FilterCarByType()
    {
        Console.Write("\nEnter type to filter (Electric or Fuel): ");
        var typeInput = Console.ReadLine();
        
        if (!Enum.TryParse(typeInput, true, out CarType type) || !Enum.IsDefined(typeof(CarType), type))
        {
            Console.WriteLine("Invalid type. Please enter either 'Electric' or 'Fuel'.");
            return;
        }
        
        var filteredCars = cars.Where(car => car.Type == type).ToList();
        DisplayCars(filteredCars, $"Found {filteredCars.Count} {type} car(s):");
    }

    private static void DisplayCars(List<Car> carsToDisplay, string title)
    {
        if (carsToDisplay.Count == 0)
        {
            Console.WriteLine("No cars found.");
            return;
        }

        Console.WriteLine($"\n{title}");
        Console.WriteLine(CarTableHelper.GetTableHeader());
        foreach (var car in carsToDisplay)
        {
            Console.WriteLine(car);
        }
        Console.WriteLine(CarTableHelper.GetTableFooter());
    }
    
    private static void SearchCarByMake()
    {
        Console.Write("\nEnter make to search: ");
        var searchTerm = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            Console.WriteLine("Please enter a search term!");
            return;
        }
        var results = cars.Where(c => c.Make.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplayCars(results, $"Found {results.Count} car(s) from {searchTerm}:");
    }

    private static void ViewAllCars()
    {
        DisplayCars(cars, "List of Cars:");
    }

    private static void AddCar()
    {
        Console.WriteLine("\nAdding new car...");
        string make;
        while (true)
        {
            Console.Write("Enter Make (Example: Toyota, Honda): ");
            make = Console.ReadLine();
        
            if (!string.IsNullOrWhiteSpace(make))
            {
                break;
            }
            Console.WriteLine("Make cannot be empty. Please try again!");
        }
        
        string model;
        while (true)
        {
            Console.Write("Enter Model (Example: Camry, Civic): ");
            model = Console.ReadLine();
        
            if (!string.IsNullOrWhiteSpace(model))
            {
                break;
            }
            Console.WriteLine("Model cannot be empty. Please try again!");
        }
        
        int year;
        while (true)
        {
            Console.Write("Enter Year: ");
            var yearInput = Console.ReadLine();
        
            if (int.TryParse(yearInput, out year) && year > 0)
            {
                break;
            }
            Console.WriteLine("Year must be a positive number. Please try again!");
        }

        CarType type;
        while (true)
        {
            Console.Write("Enter type (Electric or Fuel): ");
            var typeInput = Console.ReadLine();
        
            if (Enum.TryParse(typeInput, true, out type) && Enum.IsDefined(typeof(CarType), type))
            {
                break;
            }
            Console.WriteLine("Invalid type. Please enter either 'Electric' or 'Fuel'!");
        }

        cars.Add(new Car { Make = make, Model = model, Year = year, Type = type });
        Console.WriteLine("Car added successfully!");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("========== Menu ==========");
        Console.WriteLine("1. Add a car");
        Console.WriteLine("2. View all cars");
        Console.WriteLine("3. Search car by Make");
        Console.WriteLine("4. Filter car by Type");
        Console.WriteLine("5. Remove a car by Model");
        Console.WriteLine("6. Exit");
        Console.WriteLine("==========================");
        Console.Write("Select an option: ");
    }
}