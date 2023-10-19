using BusinnesLayer;
using Microsoft.AspNetCore.Mvc;
using SchoolBeDoo.Model;

namespace SchoolBeDoo.Controllers
{
    public class StudentController : Controller
    {
        [HttpPost(nameof(StudentCreate))]
        public IActionResult StudentCreate(Student student_model)
        {
            StudentBusinnes businnesLayer = new StudentBusinnes();
            var result = businnesLayer.CreateRequestStudent(student_model);
            if (result != "başarılı")
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet(nameof(GetByIdInStudent))]
        public IActionResult GetByIdInStudent(int student_id)
        {
            StudentBusinnes businnesLayer = new StudentBusinnes();
            var result = businnesLayer.GetRequestByIdStudent(student_id);
            if (result == null)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }

        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent( )
        {
            StudentBusinnes businnesLayer = new StudentBusinnes();
            var result = businnesLayer.GetAllRequestByStudentName();
            if (result == null)
            {
                return BadRequest(result);

            }
            return Ok(result);


        }

        [HttpPut(nameof(StudentUpdateById))]
        public IActionResult StudentUpdateById(Student studentModel)
        {
            StudentBusinnes businneslayer = new StudentBusinnes();
            var result = businneslayer.UptadeRequestByIdStudent(studentModel);
            if (result == null)
            {
                return NotFound(result);

            }
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteByIdStudent))]
        public IActionResult DeleteByIdStudent(int student_id)
        {
            StudentBusinnes businnesLayer = new StudentBusinnes();
            var result = businnesLayer.DeleteRequestByIdStudent(student_id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
    }
}
