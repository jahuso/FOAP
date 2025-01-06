using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace CaFOAP
{
    internal class Program
    {
        private readonly IConfiguration _configuration;
        private const string API_KEY = "621526eace0f4b36bbd5864f8ffd9aa0"; // Set your key here
                                                                           //var apikey = _configuration["AzureOpenAI:ApiKey"];

        private const string IMAGE_PATH = "YOUR_IMAGE_PATH"; // Set your image path here


        private const string QUESTION = "generate a ms sql script for a small random niche table structure";

        //private const string QUESTION = "provide estimation for a medium size restaurant application";

        private const string ENDPOINT = "https://moap-ai.openai.azure.com/openai/deployments/moap-4o/chat/completions?api-version=2024-02-15-preview";

        static async Task Main(string[] args)
        {

            // File path to your JSON file
            string jsonFilePath = "C:\\Pers\\FOAP\\CaFOAP\\params.json";

            // Read the JSON file content
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON content into a C# object
            CalculateApp appData = JsonSerializer.Deserialize<CalculateApp>(jsonContent);

            // Print the deserialized data
            Console.WriteLine("Niche: " + appData.Niche);
            Console.WriteLine("Features: " + appData.Features);
            Console.WriteLine("Size: " + appData.Size);
            Console.WriteLine("Name: " + appData.Name);

            if (appData.IsResponsive)
            {
                appData.Additionals += 20;
            }

            if (appData.IsIntegrated)
            {
                appData.Additionals += 20;
            }

            if (appData.IsQAIncluded)
            {
                appData.Additionals += 20;
            }

            if (appData.IsDocumented)
            {
                appData.Additionals += 10;
            }

            if (appData.IsSupported)
            {
                appData.Additionals += 20;
            }

            Console.WriteLine("Estimation: " + ((appData.Features * appData.Size) + appData.Additionals) + " hours approx");

        }

            //generate the script
            //put it into a folder
            //run the script
            //Create the migration
            //Create the controllers
            //Test the API
            //Verify / Generate Unit Tests
            //Generate UI
            //Deploy to DEV
}

    public class CalculateApp
    {
        public string Niche { get; set; }
        public int Features { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public bool IsResponsive { get; set; }
        public bool IsIntegrated { get; set; }
        public bool IsQAIncluded { get; set; }
        public bool IsDocumented { get; set; }
        public bool IsSupported { get; set; }

        public int? Additionals { get; set; } = 0;
    }
}
