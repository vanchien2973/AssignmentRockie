namespace AssignmentDay1;

class Program
{
    static List<Car> cars = new List<Car>()
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
        string model = Console.ReadLine();
        var car = cars.FirstOrDefault(car => car.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
        if (car == null)
            Console.WriteLine("No car found with the model '{0}'.", model);
        else
        {
            cars.Remove(car);
            Console.WriteLine("Car removed successfully!");
        }
    }

    private static void FilterCarByType()
    {
        Console.Write("\nEnter type to filter (0 for Electric, 1 for Fuel): ");
        if (!Enum.TryParse(Console.ReadLine(), out CarType type) || !Enum.IsDefined(typeof(CarType), type))
        {
            Console.WriteLine("Invalid type.");
            return;
        }
        var results = cars.Where(c => c.Type == type)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .ToList();
        if (!results.Any())
            Console.WriteLine("No cars found with the type '{0}'.", type);
        else
        {
            Console.WriteLine($"\nFound {results.Count} {type} car(s):");
            foreach (var car in results)
            {
                Console.WriteLine(car);
            }
        }
    }

    private static void SearchCarByMake()
    {
        Console.Write("\nEnter make to search: ");
        string make = Console.ReadLine();
        var results = cars.Where(car => car.Make.Equals(make, StringComparison.OrdinalIgnoreCase))
            .OrderBy(c => c.Year)
            .ToList();
        if (!results.Any())
            Console.WriteLine("No cars found with the make '{0}'.", make);
        else
        {
            Console.WriteLine($"\nFound {results.Count} car(s) from {make}:");
            foreach (var car in results)
            {
                Console.WriteLine(car);
            }
        }
    }

    private static void ViewAllCars()
    {
        Console.WriteLine("\nList of Cars:");
        if (!cars.Any())
            Console.WriteLine("No cars available.");
        else
        {
            foreach (var car in cars.OrderBy(c => c.Make).ThenBy(c => c.Model))
            {
                Console.WriteLine(car);
            }
        }
    }

    private static void AddCar()
    {
        Console.WriteLine("\nAdding new car...");
        Console.Write("Enter make: ");
        string make = Console.ReadLine();
        Console.Write("Enter model: ");
        string model = Console.ReadLine();
        Console.Write("Enter year: ");
        if (!int.TryParse(Console.ReadLine(), out int year) || year > DateTime.Now.Year + 1)
        {
            Console.WriteLine("Invalid year. Car not added.");
            return;
        }
        Console.Write("Enter type (0 for Electric, 1 for Fuel): ");
        if (!Enum.TryParse(Console.ReadLine(), out CarType type) || !Enum.IsDefined(typeof(CarType), type))
        {
            Console.WriteLine("Invalid type. Car not added.");
            return;
        }
        cars.Add(new Car { Make = make, Model = model, Year = year, Type = type });
        Console.WriteLine("Car added successfully!");
    }

    static void DisplayMenu()
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