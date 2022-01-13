using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly BugsContext db;

        public TicketsController(BugsContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Tickets.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket == null)
                return BadRequest();

            return Ok(ticket);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = ticket.TicketId }, ticket);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();

            db.Entry(ticket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Tickets.Find(id) == null)
                    return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket == null)
                return NotFound();

            db.Tickets.Remove(ticket);
            db.SaveChanges();


            return Ok(ticket);
        }
    }
}
