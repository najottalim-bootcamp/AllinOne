using AllinOne.Models;
using AllinOne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllinOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentService studentService = new StudentService();
        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            Student student = studentService.GetStudentById(id);
            return Ok(student);
        }
    }
}
