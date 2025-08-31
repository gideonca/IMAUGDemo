using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

class Program
{
	static async Task Main(string[] args)
	{
		Console.WriteLine("What do you want to ask:");
	    string prompt = Console.ReadLine() ?? "";

        while (prompt.ToLower() != "exit")
        {
            var apiUrl = "http://localhost:1234/v1/chat/completions";
            var requestBody = new
            {
                model = "llama3",
                messages = new[] {
                    new { role = "system", content = "You are a helpful assistant that takes natural language and converts it to SQL queries." }, // initial/system prompt
                    new { role = "user", content = prompt }
                }
            };

            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(5); // Increase timeout for long LM Studio responses
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseBody);
                var reply = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();
                Console.WriteLine(reply);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("Is there anything else? (Type 'exit' to quit)");
            prompt = Console.ReadLine() ?? "";
        }		
	}
}
