﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day06.CustomFilter
{
    public class MyExceptionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception!=null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult()
                {
                    ViewName = "MyError"
                };

            }
            base.OnActionExecuted(context);
        }
    }
}
