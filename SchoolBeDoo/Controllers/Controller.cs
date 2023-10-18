using BusinnesLayer;
using Microsoft.AspNetCore.Mvc;
using SchoolBeDoo.Model;
using System.Text.Json;

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

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int class_id)
        {
            Businnes businnesLayer = new Businnes();
            var result = businnesLayer.GetRequestById(class_id);
           if (result == null)
            {
                return BadRequest(result);

            }
            
            return Ok(result);
        }
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll(string class_Name)
        {
            Businnes businnesLayer = new Businnes();
            var result = businnesLayer.GetAllRequestByClassName(class_Name);
            if (result == null)
            {
                return BadRequest(result);

            }
            return Ok(result);


        }
    }
}
