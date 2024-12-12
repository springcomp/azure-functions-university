using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzFuncUni.LongRunningTask
{
    public class HelloWorldHttpTrigger
    {
        private readonly ILogger<HelloWorldHttpTrigger> _logger;

        public HelloWorldHttpTrigger(ILogger<HelloWorldHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("HelloWorldHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
