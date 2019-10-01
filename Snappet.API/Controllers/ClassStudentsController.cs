using System.Collections.Generic;
using API;
using Microsoft.AspNetCore.Mvc;
using Snappet.Core;

namespace Snappet.API.Controllers
{
    [Route("api/v1/class")]
    [ApiController]
    public class ClassStudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public ClassStudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("students")]
        public IActionResult GetClassStudents()
        {
            var students = _studentsService.GetClassStudents();

            return Ok(ApiResponse<List<Student>>.Success(students));
        }
    }
}
