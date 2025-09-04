using CoursePlanner.Api.Models;

namespace CoursePlanner.Api.Services;

public interface IStudentService
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetAsync(int id);
    Task<Student> CreateAsync(Student s);
    Task<bool> UpdateAsync(int id, Student s);
    Task<bool> DeleteAsync(int id);
}
