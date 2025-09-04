namespace CoursePlanner.Api.Models;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = "";   // e.g., "CS501"
    public string Title { get; set; } = "";
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
