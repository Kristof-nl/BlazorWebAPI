using BlazorWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorWebAPI.Filters
{
    public class Ticket_ValidateDatesActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null &&
                !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                bool isValid = true;

                if (ticket.EnteredDate.HasValue == false)
                {
                    context.ModelState.AddModelError("EnteredDate", "EnteredDate is required.");
                    isValid = false;
                }

                if (ticket.EnteredDate.HasValue && ticket.DueDate.HasValue && ticket.EnteredDate > ticket.DueDate)
                {
                    context.ModelState.AddModelError("DueDate", "DueDate has be later than the EnteredDate.");
                    isValid = false;
                }


                if (!isValid)
                    context.Result = new BadRequestObjectResult(context.ModelState);
                
            }
        }
    }
}