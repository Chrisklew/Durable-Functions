using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

public static class FetchDataActivity
{
    // This function is called by the Orchestrator to fetch data for each ID
    [Function("FetchDataActivity")]
    public static string Run([ActivityTrigger] int id, FunctionContext context)
    {
        // Create a logger to log messages for the activity function
        var logger = context.GetLogger("FetchDataActivity");

        // Log the fetching process for debugging purposes
        logger.LogInformation($"Fetching data for ID: {id}");

        // Return the result, which is a string indicating the data for the given ID
        return $"Data for ID {id}";
    }
}
