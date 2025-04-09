namespace EF_Core_Assignment_1.Core.Entities;

public class Salaries
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}