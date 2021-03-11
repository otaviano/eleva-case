using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
            schoolService.Create(model);

            return Ok(model);
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string name)
        {
            var schools = schoolService.SearchSchools(name);

            return Ok(schools);
        }
    }
}
