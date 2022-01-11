using BlazorWebAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAPI.Validations
{
    public class Ticket_EnsureDueDateIsInTheFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket != null && ticket.TicketId == null)
            {
                if (ticket.DueDate.HasValue && ticket.DueDate.Value < DateTime.Now)
                    return new ValidationResult("Due date must be in the future");

            }
            return ValidationResult.Success;
        }

    }
}
