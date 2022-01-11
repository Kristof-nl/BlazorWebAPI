using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the projects");
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading the project #{id}.");
        }


        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Creating a project");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Updating a project");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting a project #{id}.");
        }
    }
}
