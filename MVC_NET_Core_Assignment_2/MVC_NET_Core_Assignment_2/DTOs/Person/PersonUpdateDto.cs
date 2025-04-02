using System.ComponentModel.DataAnnotations;

namespace MVC_NET_Core_Assignment_1.DTOs;

public class PersonUpdateDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; }

    public string BirthPlace { get; set; }
    public bool IsGraduated { get; set; }
}