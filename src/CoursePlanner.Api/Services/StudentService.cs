using CoursePlanner.Api.Data;
using CoursePlanner.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner.Api.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _db;
    public StudentService(AppDbContext db) => _db = db;

    public Task<List<Student>> GetAllAsync() =>
        _db.Students.AsNoTracking().ToListAsync();

    public Task<Student?> GetAsync(int id) =>
        _db.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Student> CreateAsync(Student s)
    {
        _db.Students.Add(s);
        await _db.SaveChangesAsync();
        return s;
    }

    public async Task<bool> UpdateAsync(int id, Student s)
    {
        var existing = await _db.Students.FindAsync(id);
        if (existing is null) return false;
        existing.FullName = s.FullName;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Students.FindAsync(id);
        if (existing is null) return false;
        _db.Students.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}
