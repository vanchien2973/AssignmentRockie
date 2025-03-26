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
        return $"{Year} | {Make} | {Model} | ({Type})";
    }
}