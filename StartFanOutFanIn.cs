using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

public static class StartFanOutFanIn
{
    // HTTP Trigger that starts the orchestration process
    [Function("StartFanOutFanIn")]
    public static async Task<HttpResponseData> Run(
        // The HTTP request data and Durable Task client are passed as parameters
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
        [DurableClient] DurableTaskClient client,
        FunctionContext executionContext)
    {
        // Create a logger for the function
        var logger = executionContext.GetLogger("StartFanOutFanIn");

        // Start the orchestration by calling the Orchestrator function
        // The orchestration will be executed asynchronously, and we retrieve its instance ID
        string instanceId = await client.ScheduleNewOrchestrationInstanceAsync("Orchestrator");

        // Log the instance ID for debugging purposes
        logger.LogInformation($"Started orchestration with ID = '{instanceId}'.");

        // Return a response with the orchestration status URL and instance ID
        return await client.CreateCheckStatusResponseAsync(req, instanceId);
    }
}
