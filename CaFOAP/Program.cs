using System.Text.Json;

namespace CaFOAP
{
    internal class Program
{
    static void Main(string[] args)
    {
        // File path to your JSON file
        string jsonFilePath = "C:\\Users\\Mieles\\source\\repos\\CaFOAP\\CaFOAP\\params.json";

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

        //Setup features
        //('Menu Management', 'Manage restaurant menu items'),
        //('Order Processing', 'Handle customer orders'),
        //('Table Reservations', 'Manage table bookings'),
        //('Billing', 'Generate and process customer bills');

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
