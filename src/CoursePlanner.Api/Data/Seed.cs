using CoursePlanner.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner.Api.Data;

public static class Seed
{
    public static async Task RunAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        if (!db.Courses.Any())
        {
            db.Courses.AddRange(
                new Course { Code = "CS501", Title = "Algorithms" },
                new Course { Code = "CS535", Title = "Machine Learning" }
            );
        }

        if (!db.Students.Any())
        {
            db.Students.AddRange(
                new Student { FullName = "Alex Kim" },
                new Student { FullName = "Riley Chen" }
            );
        }

        await db.SaveChangesAsync();
    }
}
