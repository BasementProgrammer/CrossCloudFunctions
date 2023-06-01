using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using CrossCloudAPI;

namespace CrossCloudAPI.Azure;

public static class CrossCloudApiTrigger
{
    [FunctionName("CrossCloudApiTrigger")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string name = req.Query["name"];

        URLFormatter urlFormatter = new URLFormatter();
        string url = urlFormatter.Format(name);

        return name != null
            ? (ActionResult)new OkObjectResult($"URL = , {url}")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        
    }
}