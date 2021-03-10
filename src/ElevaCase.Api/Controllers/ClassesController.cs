using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
            classService.Create(model);

            return Ok(model);
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int schoolId)
        {
            var classes = classService.GetClasses(schoolId);

            return Ok(classes);
        }
    }
}
