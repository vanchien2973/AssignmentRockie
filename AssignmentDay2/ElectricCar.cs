using AssignmentDay2;

namespace DefaultNamespace;

public class ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate)
    : Car(make, model, year, lastMaintenanceDate), IChargable
{
    public void Charge(DateTime timeOfCharge)
    {
        // History.Add($"Charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
    }
    
    public override void DisplayDetails()
    {
        base.DisplayDetails();
    }
}