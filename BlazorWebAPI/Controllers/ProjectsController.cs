using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext db;

        public ProjectsController(BugsContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Projects.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectsTickets(int pid)
        {
            var tickets = db.Tickets.Where(t => t.ProjectId == pid).ToList();
            if (tickets == null || tickets.Count <= 0)
                return NotFound();

            return Ok(tickets);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Projects.Find(id) == null)
                    return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null) return NotFound();

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
