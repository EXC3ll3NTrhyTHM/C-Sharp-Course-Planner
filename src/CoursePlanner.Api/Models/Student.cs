namespace CoursePlanner.Api.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
