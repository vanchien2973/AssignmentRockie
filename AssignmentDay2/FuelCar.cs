namespace AssignmentDay2;

public class FuelCar(string make, string model, int year, DateTime lastMaintenanceDate)
    : Car(make, model, year, lastMaintenanceDate), IFuelable
{
    public void Refuel(DateTime timeOfRefuel)
    {
        // History.Add($"Refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
    }
}