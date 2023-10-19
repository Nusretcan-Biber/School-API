using BusinnesLayer;
using Microsoft.AspNetCore.Mvc;
using SchoolBeDoo.Model;
using System.Text.Json;

namespace SchoolBeDoo.Controllers
{
    [Route("/api/SchoolBeDoo")]
    [ApiController]


    public class ClassesController : ControllerBase
    {
        [HttpPost(nameof(ClassesCreate))]
        public IActionResult ClassesCreate(Classes classModel)
        {
            ClassesBusinnes businnesLayer = new ClassesBusinnes();
            var result = businnesLayer.CreateRequest(classModel);
            if (result != "başarılı")
            {
                return BadRequest(result);
                
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetByIdInClasses))]
        public IActionResult GetByIdInClasses(int class_id)
        {
            ClassesBusinnes businnesLayer = new ClassesBusinnes();
            var result = businnesLayer.GetRequestById(class_id);
           if (String.IsNullOrEmpty(result))
            {
                return BadRequest(result);

            }
            
            return Ok(result);
        }
       
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            ClassesBusinnes businnesLayer = new ClassesBusinnes();
            var result = businnesLayer.GetAllRequestByClassName();
            if (result == null)
            {
                return BadRequest(result);

            }
            return Ok(result);


        }
       
        [HttpPut(nameof(ClassesUpdateById))]
        public IActionResult ClassesUpdateById(Classes classModel)
        {
            ClassesBusinnes businneslayer = new ClassesBusinnes();
            var result = businneslayer.UptadeRequestByIdClasses(classModel);
            if (result == null)
            {
                return NotFound(result);

            }
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteByIdClasses))]
        public IActionResult DeleteByIdClasses(int class_id)
        {
            ClassesBusinnes businnesLayer = new ClassesBusinnes();
            var result = businnesLayer.DeleteRequestByIdClasses(class_id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

    }
}
