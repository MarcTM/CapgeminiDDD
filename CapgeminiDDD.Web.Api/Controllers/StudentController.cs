using CapgeminiDDD.Common.Model;
using CapgeminiDDD.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapgeminiDDD.Web.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _studentRepository.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Student> GetOne([FromRoute] int id)
        {
            return await _studentRepository.GetOneAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _studentRepository.CreateAsync(student);

            if (created)
            {
                return Created("Created", new { Response = StatusCode(201) });
            }
            else
            {
                return Created("Not Created", new { Response = StatusCode(404) });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Student student, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Student updated = await _studentRepository.UpdateAsync(student, id);

            if (updated != null)
            {
                return Created("Updated", new { Response = StatusCode(201) });
            }
            else
            {
                return Created("Not Updated", new { Response = StatusCode(404) });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var deleted = await _studentRepository.DeleteAsync(id);

            if (deleted)
            {
                return Created("Deleted", new { Response = StatusCode(201) });
            }
            else
            {
                return Created("Not Deleted", new { Response = StatusCode(404) });
            }
        }
    }
}
