using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QLNS.API.Application.DTOs.Error;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.API.Application.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before controller
            if(!context.ModelState.IsValid)
            {
                Console.WriteLine("Check --------------------------------");
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kv => kv.Key, kv => kv.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                //Add error to list errors
                var errorsRespone = new ErrorRespone();
                foreach(var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new Error
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorsRespone.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorsRespone);
                return;
            }

            //next
            await next();

            //after controller
        }
    }
}
