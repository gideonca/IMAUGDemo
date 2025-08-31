# .NET Console App: LM Studio Phi-4 Connector

This application prompts the user for input, sends it to LM Studio (Phi-4 model) via its API, and displays the response.

## Usage
1. Ensure LM Studio is running and the Phi-4 model is loaded.
2. Update the LM Studio API endpoint in `Program.cs` if needed.
3. Run the application:
   ```bash
   dotnet run
   ```
4. Enter your prompt when asked.

## Requirements
- .NET 6.0 or later
- LM Studio running Phi-4 model with API enabled

## Configuration
- Edit the API endpoint in `Program.cs` if your LM Studio instance uses a custom port or address.
