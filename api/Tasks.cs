using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace RoutingApp.Function;

public class Tasks
{
    private readonly ILogger<Message> _logger;

    private Task[] tasks = new Task[]
    {
        new Task
        {
            id = "t1",
            userId ="u1",
            title = "Master Angular",
            summary = "Learn all the basic and advanced features of Angular & how to apply them.",
            dueDate = "2025-12-31",
    },
        new Task
        {
            id = "t2",
            userId = "u2",
            title = "Build first prototye",
            summary = "Build a first prototype of the online shop website",
            dueDate = "2025-05-31"
        }, 
         new Task
        {
            id = "t3",
            userId = "u3",
            title = "Prepare issue template",
            summary = "Prepare and describe an issue template which will help with project management",
            dueDate = "2025-06-15"
        }
    };

    public Tasks(ILogger<Message> logger)
    {
        _logger = logger;
    }

    [Function("Tasks")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new JsonResult(JsonSerializer.Serialize(tasks));
        // return new OkObjectResult("Welcome to Azure Functions!");
    }
    
}