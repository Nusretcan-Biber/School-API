using BusinnesLayer;
using Microsoft.AspNetCore.Mvc;
using SchoolBeDoo.Model;
namespace SchoolBeDoo.Controllers
{
    [Route("/api/SchoolBeDoo")]
    [ApiController]


    public class Controller : ControllerBase
    {
        [HttpPost(nameof(ClassesCreate))]
        public IActionResult ClassesCreate(Classes classModel)
        {
            Businnes businnesLayer = new Businnes();
            var result = businnesLayer.CreateRequest(classModel);
            if (result != "başarılı")
            {
                return BadRequest(result);
                
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetClasses))]
        public IActionResult GetClasses(int class_id)
        {
            Businnes businnesLayer = new Businnes();
            var result = businnesLayer.GetRequest(class_id);
            if (result != "başarılı")
            {
                return BadRequest(result);

            }
            return Ok(result);
        }
    }
}
