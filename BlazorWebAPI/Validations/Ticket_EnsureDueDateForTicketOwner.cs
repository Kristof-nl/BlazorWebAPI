using BlazorWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAPI.Validations
{
    public class Ticket_EnsureDueDateForTicketOwner : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.DueDate.HasValue)
                    return new ValidationResult("Due date is required when the ticket has an owner");

            }
            return ValidationResult.Success;
        }
    }
}
