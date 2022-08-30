# PollyWithNET6
Sample .NET6 application with Polly - using to handle with transient faults, that exist for short periods of time. Resilence & transien fault handling library for .NET

# Technologies&Features
- .NET 6 MVC API
- VS Code
- Polly
- HttpClientFactory

# Step by step
## 1. Create Response service
- Create project with command:
```bash
dotnet new webapi -n ResponseService
```
- Open project in VS Code:
```bash
code -r ResponseService
```
- Try to first run:
```bash
dotnet run
```
- Create ResponseController with simpple endpoint.
## 2. Create Request service
- Create project with command:
```bash
dotnet new webapi -n RequestService
```
- Open project in VS Code:
```bash
code -r RequestService
```
- Try to first run:
```bash
dotnet run
```
- Install Polly Nuget
```bash
dotnet add package Microsoft.Extensions.Http.Polly
```
- Create Policies with Polly
- Create Controller
- Create simple HttpClient to call ResponseService
- Register HttpClientFactory
- Optional disable ssl for testing
- Add policy to HttpClientFactory
## 3.Test services using Postman

