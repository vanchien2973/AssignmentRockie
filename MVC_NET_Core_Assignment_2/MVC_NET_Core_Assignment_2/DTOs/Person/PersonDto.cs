namespace MVC_NET_Core_Assignment_1.DTOs.Person;

public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public bool IsGraduated { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Age => DateTime.Now.Year - DateOfBirth.Year;
    public string FullName => $"{LastName} {FirstName}";
}