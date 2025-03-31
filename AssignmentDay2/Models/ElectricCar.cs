using AssignmentDay2;

namespace DefaultNamespace;

public class ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate)
    : Car(make, model, year, lastMaintenanceDate), IChargable
{
    public void Charge(DateTime timeOfCharge)
    {
        Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
    }
}