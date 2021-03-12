using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevaCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService classService;

        public ClassesController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClassViewModel model)
        {
            try
            {
                classService.Create(model);

                return Accepted();
            }
            // TODO : tratamento de exceptions
            //catch (ValidationException e)
            //{
            //    return BadRequest(new JsonErrorResponse(e.Errors));
            //}
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int schoolId, [FromQuery] string name)
        {
            try
            {
                var classes = classService.SearchClasses(schoolId, name);

                return Ok(classes);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
