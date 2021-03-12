using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevaCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            this.schoolService = schoolService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SchoolViewModel model)
        {
            try
            {
                schoolService.Create(model);

                return Accepted();
            }
            // TODO : tratamento de exceptions
            //catch (ValidationException e)
            //{
            //    return BadRequest(new JsonErrorResponse(e.Errors));
            //}
            catch
            {
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string name)
        {
            try
            {
                var schools = schoolService.SearchSchools(name);
            
                return Ok(schools);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
