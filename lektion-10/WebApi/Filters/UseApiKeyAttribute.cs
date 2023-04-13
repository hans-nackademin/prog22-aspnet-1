using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
        var apiKey = config!.GetValue<string>("ApiKey");

        if(!context.HttpContext.Request.Query.TryGetValue("key", out var key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if(!apiKey!.Equals(key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
