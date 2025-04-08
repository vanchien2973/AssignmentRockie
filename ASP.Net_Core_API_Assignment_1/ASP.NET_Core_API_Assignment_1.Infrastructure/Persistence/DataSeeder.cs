using ASP.NET_Core_API_Assignment_1.Domain.Entities;

namespace ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void TasksSeed(ApplicationDbContext context)
    {
        if (context.Tasks.Any()) return;
        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id = Guid.NewGuid(), 
                Title = "Complete API Assignment", 
                IsCompleted = false
            },
            new TaskItem
            {
                Id = Guid.NewGuid(), 
                Title = "Review Clean Architecture",
                IsCompleted = true
            },
            new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = "Prepare Presentation", 
                IsCompleted = false
            }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
    
    public static void PersonsSeed(ApplicationDbContext context)
    {
        if (context.People.Any()) return;
        var persons = new List<Person>
        {
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1980, 1, 15),
                Gender = "Male",
                BirthPlace = "New York",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1985, 5, 20),
                Gender = "Female",
                BirthPlace = "Los Angeles",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Robert",
                LastName = "Johnson",
                Email = "robert.j@example.com",
                DateOfBirth = new DateTime(1990, 8, 10),
                Gender = "Male",
                BirthPlace = "Chicago",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Emily",
                LastName = "Williams",
                Email = "emily.w@example.com",
                DateOfBirth = new DateTime(1992, 3, 25),
                Gender = "Female",
                BirthPlace = "New York",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Michael",
                LastName = "Brown",
                Email = "michael.b@example.com",
                DateOfBirth = new DateTime(1988, 11, 5),
                Gender = "Male",
                BirthPlace = "Houston",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Sarah",
                LastName = "Davis",
                Email = "sarah.d@example.com",
                DateOfBirth = new DateTime(1995, 7, 30),
                Gender = "Female",
                BirthPlace = "Los Angeles",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Miller",
                Email = "david.m@example.com",
                DateOfBirth = new DateTime(1982, 9, 12),
                Gender = "Male",
                BirthPlace = "Chicago",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Jennifer",
                LastName = "Wilson",
                Email = "jennifer.w@example.com",
                DateOfBirth = new DateTime(1991, 4, 18),
                Gender = "Female",
                BirthPlace = "New York",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
        context.People.AddRange(persons);
        context.SaveChanges();
    }
}