namespace AssignmentDay1;

enum CarType
{
    Electric,
    Fuel
}

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public CarType Type { get; set; }
    
    public override string ToString()
    {
        return $"| {Year,-6} | {Make,-10} | {Model,-20} | {Type,-8} |";
    }
}

static class CarTableHelper
{
    public static string GetTableHeader()
    {
        return new string('-', 55) + "\n" +
               $"| {"Year",-6} | {"Make",-10} | {"Model",-20} | {"Type",-8} |\n" +
               new string('-', 55);
    }

    public static string GetTableFooter()
    {
        return new string('-', 55);
    }
}