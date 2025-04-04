using ASP.NET_Core_API_Assignment_1.Domain.Entities;

namespace ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Tasks.Any()) return;
        var tasks = new List<TaskItem>
        {
            new TaskItem { Id = Guid.NewGuid(), Title = "Complete API Assignment", IsCompleted = false },
            new TaskItem { Id = Guid.NewGuid(), Title = "Review Clean Architecture", IsCompleted = true },
            new TaskItem { Id = Guid.NewGuid(), Title = "Prepare Presentation", IsCompleted = false }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
}