using Microsoft.AspNetCore.Mvc;

namespace ArtQuire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IClientService _clientService;

        public Controller(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _studentService.UpdateStudent(id, student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}