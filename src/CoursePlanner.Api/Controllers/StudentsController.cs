using CoursePlanner.Api.Models;
using CoursePlanner.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _svc;
    public StudentsController(IStudentService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll() =>
        Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var s = await _svc.GetAsync(id);
        return s is null ? NotFound() : Ok(s);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student s)
    {
        var created = await _svc.CreateAsync(s);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Student s) =>
        await _svc.UpdateAsync(id, s) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _svc.DeleteAsync(id) ? NoContent() : NotFound();
}
