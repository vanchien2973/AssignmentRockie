namespace AssignmentDay2;

public class FuelCar(string make, string model, int year, DateTime lastMaintenanceDate)
    : Car(make, model, year, lastMaintenanceDate), IFuelable
{
    public void Refuel(DateTime timeOfRefuel)
    {
        Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}");
    }
}