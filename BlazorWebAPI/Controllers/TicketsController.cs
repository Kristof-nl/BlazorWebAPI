using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading the ticket #{id}.");
        }


        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }


        [HttpPut]
        public IActionResult Update([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting a ticket #{id}.");
        }
    }
}
