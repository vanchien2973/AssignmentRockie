namespace AssignmentDay2;

public abstract class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public DateTime LastMaintenanceDate { get; set; }
    public DateTime NextMaintenanceDate { get; private set; }
    
    public Car(string make, string model, int year, DateTime lastMaintenanceDate)
    {
        Make = make;
        Model = model;
        Year = year;
        LastMaintenanceDate = lastMaintenanceDate;
    }

    public void ScheduleMaintenance()
    {
        NextMaintenanceDate = LastMaintenanceDate.AddMonths(6);
    }

    public virtual void DisplayDetails()
    {
        ScheduleMaintenance();
        Console.WriteLine($"\nCar: {Make} {Model} ({Year})");
        Console.WriteLine($"Last Maintenance: {LastMaintenanceDate:yyyy-MM-dd}");
        Console.WriteLine($"Next Maintenance: {NextMaintenanceDate:yyyy-MM-dd}");
    }
}