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
        Console.Write("\nEnter type to filter (0 for Electric, 1 for Fuel): ");
        if (!Enum.TryParse(Console.ReadLine(), out CarType type))
        {
            Console.WriteLine("Invalid type.");
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
        Console.WriteLine(Car.GetTableHeader());
        foreach (var car in carsToDisplay)
        {
            Console.WriteLine(car);
        }
        Console.WriteLine(Car.GetTableFooter());
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
        if (results.Count == 0)
            Console.WriteLine("No cars found with the make '{0}'.", searchTerm);
        else
        {
            Console.WriteLine($"\nFound {results.Count} car(s) from {searchTerm}:");
            Console.WriteLine(Car.GetTableHeader());
            foreach (var car in results)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine(Car.GetTableFooter());
        }
    }

    private static void ViewAllCars()
    {
        Console.WriteLine("\nList of Cars:");
        if (cars.Count == 0)
            Console.WriteLine("No cars available.");
        else
        {
            Console.WriteLine(Car.GetTableHeader());
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine(Car.GetTableFooter());
        }
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
            Console.WriteLine("Make cannot be empty. Please try again!");
        }
        
        int year;
        while (true)
        {
            Console.Write($"Enter Year: ");
            var yearInput = Console.ReadLine();
        
            if (int.TryParse(yearInput, out year))
            {
                if (!string.IsNullOrWhiteSpace(model))
                {
                    break;
                }
                Console.WriteLine("Year cannot be empty. Please try again!");
            }
            else
            {
                Console.WriteLine("Year must be a number. Please try again!");
            }
        }
        CarType type;
        while (true)
        {
            Console.Write("Enter type (0 for Electric, 1 for Fuel): ");
            var typeInput = Console.ReadLine();
        
            if (Enum.TryParse(typeInput, out type))
            {
                break;
            }
            Console.WriteLine("Invalid type. Please enter 0 for Electric or 1 for Fuel!");
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