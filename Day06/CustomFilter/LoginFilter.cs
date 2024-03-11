using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day06.CustomFilter
{
    public class LoginFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {
                context.Result = new RedirectToActionResult("Login", "account",null);
            }
          
            // base.OnActionExecuted(context);
        }
    }
}
