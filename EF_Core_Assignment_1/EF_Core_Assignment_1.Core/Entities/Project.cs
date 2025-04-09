namespace EF_Core_Assignment_1.Core.Entities;

public class Projects
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}