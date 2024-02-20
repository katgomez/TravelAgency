
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApplicationServices.Controllers
{
    public class TokenValidationAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Check if the token exists in the request headers
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Result = new BadRequestObjectResult("Token is missing");
                return;
            }

            // Validate the token using your token validation logic
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync($"http://localhost:9060/api/tokens/{token.ToString().Replace("Bearer ", "")}");
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        context.Result = new NotFoundResult();
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                        context.Result = new UnauthorizedResult();
                    else
                        context.Result = new StatusCodeResult((int)response.StatusCode);
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new BadRequestResult();
                return;
            }

            await next(); // Continue to the action method
        }
    }
}