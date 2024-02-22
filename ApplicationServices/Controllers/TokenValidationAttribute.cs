
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;

namespace ApplicationServices.Controllers
{
    public class TokenValidationAttribute : ActionFilterAttribute
    { 

          
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceProvider = context.HttpContext.RequestServices;
           

            // Check if the token exists in the request headers
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Result = new BadRequestObjectResult("Token is missing");
                return;
            }

            // Validate the token using your token validation logic
            try
            {
                var response = this.ValidateToken(token.ToString().Replace("Bearer ", ""));


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
            catch (Exception e)
            {
                Console.WriteLine(e);
                context.Result = new BadRequestResult();
                return;
            }

            await next(); // Continue to the action method
        }
        private RestResponse ValidateToken(string token)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).AddEnvironmentVariables().Build();

            var options = new RestClientOptions(
              configuration.GetValue<string>("ApplicationSettings:SecurityEndPoint"));

            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;

            var restClient = new RestClient(options);

            var request = new RestRequest("/{token}", Method.Get);

            request.AddParameter("token", token, ParameterType.UrlSegment);
            return restClient.ExecuteAsync(request).Result;
        }
    }

   
}