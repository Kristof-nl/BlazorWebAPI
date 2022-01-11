using BlazorWebAPI.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAPI.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }
        [Required]
        public int? ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        [Ticket_EnsureDueDateIsInTheFuture]
        public DateTime? DueDate { get; set; }
    }
}
