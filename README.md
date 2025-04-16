# Azure Durable Functions - Fan-Out/Fan-In Pattern

This project demonstrates the fan-out/fan-in pattern using Azure Durable Functions in .NET. It includes:
- An HTTP starter function to trigger the orchestration.
- An orchestrator function to run parallel tasks.
- An activity function that simulates fetching data.

## 🛠 Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [Azure Functions Core Tools v4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite) (for local Storage Emulator, optional)

## 🚀 Setup and Run

1. **Clone the Repository**
   ```bash
   git clone <repo-url>
   cd azure-durable-functions/FanOutFanInProject
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Start Azurite (optional for local storage)**
   ```bash
   azurite
   ```

4. **Run the Function App Locally**
   ```bash
   func start
   ```

5. **Trigger the Orchestration**
   
   Visit the URL provided in the terminal (usually something like `http://localhost:7071/api/StartFanOutFanIn`). This starts the orchestration.

6. **Check the Status**

   You'll receive a JSON response with statusQueryGetUri. Visit that URI to check the status and view output like:
   ```json
   [
     "Data for ID 1",
     "Data for ID 2",
     "Data for ID 3",
     "Data for ID 4",
     "Data for ID 5"
   ]
   ```

## 📂 Project Structure

```
FanOutFanInProject/
├── FetchDataActivity.cs         # Activity Function
├── Orchestrator.cs              # Orchestration Function
├── StartFanOutFanIn.cs          # HTTP Trigger Function
├── local.settings.json          # Local app settings
├── FanOutFanInProject.csproj    # Project file
```

## 🧠 Fan-Out/Fan-In Summary
- **Fan-Out:** The orchestrator calls multiple instances of `FetchDataActivity` in parallel.
- **Fan-In:** It waits for all tasks to complete, collects their results, and returns them.

---

Next up: building a Travel Booking Aggregator using this same pattern! ✈️

