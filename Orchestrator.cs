using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using System.Collections.Generic;

public static class Orchestrator
{
    // This function orchestrates the calls to multiple activities and aggregates the results
    [Function("Orchestrator")]
    public static async Task<List<string>> RunOrchestrator([OrchestrationTrigger] TaskOrchestrationContext context)
    {
        // Create a list to store the outputs from each activity
        var outputs = new List<string>();

        // Loop to fan-out 5 parallel tasks (one for each ID)
        for (int i = 1; i <= 5; i++)
        {
            // Call the FetchDataActivity function for each ID (asynchronous)
            // This is the fan-out part where multiple tasks are executed concurrently
            string result = await context.CallActivityAsync<string>("FetchDataActivity", i);

            // Add the result to the outputs list
            outputs.Add(result);
        }

        // Return the aggregated list of results once all activities are complete (fan-in part)
        return outputs;
    }
}
