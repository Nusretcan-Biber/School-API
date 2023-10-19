using BusinnesLayer;
using Microsoft.AspNetCore.Mvc;
using SchoolBeDoo.Model;

namespace SchoolBeDoo.Controllers
{
    public class CoursesController : Controller
    {
        [HttpPost(nameof(CoursesCreate))]
        public IActionResult CoursesCreate([FromBody]Courses courseModel)
        {
            CoursesBusinnes businnesLayer = new CoursesBusinnes();
            var result = businnesLayer.CreateRequestCourses(courseModel);
            if (result != "başarılı")
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet(nameof(GetByIdInCourses))]
        public IActionResult GetByIdInCourses(int course_id)
        {
            CoursesBusinnes businnesLayer = new CoursesBusinnes();
            var result = businnesLayer.GetRequestByIdCourses(course_id);
            if (result == null)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }

        [HttpGet(nameof(GetAllCourses))]
        public IActionResult GetAllCourses()
        {
            CoursesBusinnes businnesLayer = new CoursesBusinnes();
            var result = businnesLayer.GetAllRequestByCourseName();
            if (result == null)
            {
                return BadRequest(result);

            }
            return Ok(result);


        }

        [HttpPut(nameof(CoursesUpdateById))]
        public IActionResult CoursesUpdateById(Courses courseModel)
        {
            CoursesBusinnes businneslayer = new CoursesBusinnes();
            var result = businneslayer.UptadeRequestByIdCourses(courseModel);
            if (result == null)
            {
                return NotFound(result);

            }
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteByIdCourses))]
        public IActionResult DeleteByIdCourses(int Course_id)
        {
            CoursesBusinnes businnesLayer = new CoursesBusinnes();
            var result = businnesLayer.DeleteRequestByIdCourses(Course_id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

    }
}
