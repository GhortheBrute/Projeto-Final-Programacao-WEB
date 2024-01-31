using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters;

public class CustomActionFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Antes");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Depois");
    }
}
