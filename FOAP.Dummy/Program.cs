using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;


public class Message
{
    public string content { get; set; }
    public string role { get; set; }
}

public class Choice
{
    public Message message { get; set; }
}

public class ApiResponse
{
    public Choice[] choices { get; set; }
}


class Program
{
    private readonly IConfiguration _configuration;
    private const string API_KEY = "621526eace0f4b36bbd5864f8ffd9aa0"; // Set your key here
    //var apikey = _configuration["AzureOpenAI:ApiKey"];

    private const string IMAGE_PATH = "YOUR_IMAGE_PATH"; // Set your image path here
    private const string QUESTION = "provide estimation for a medium size restaurant application"; // Set your question here

    private const string ENDPOINT = "https://moap-ai.openai.azure.com/openai/deployments/moap-4o/chat/completions?api-version=2024-02-15-preview";
    static async Task Main()
    {
        //var encodedImage = Convert.ToBase64String(File.ReadAllBytes(IMAGE_PATH));



        if (true)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestBody = new
                {
                    prompt = QUESTION,
                    max_tokens = 150
                };

                client.DefaultRequestHeaders.Add("api-key", API_KEY);

                string jsonContent = JsonConvert.SerializeObject(requestBody);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var payload = new
                {
                    messages = new object[]
        {
                  new {
                      role = "system",
                      content = new object[] {
                          new {
                              type = "text",
                              text = "You are an AI assistant that helps people find information."
                          }
                      }
                  },
                  new {
                      role = "user",
                      content = new object[] {
                          //new {
                          //    type = "image_url",
                          //    image_url = new {
                          //        url = $"data:image/jpeg;base64,{encodedImage}"
                          //    }
                          //},
                          new {
                              type = "text",
                              text = QUESTION
                          }
                      }
                  }
        },
                    temperature = 0.7,
                    top_p = 0.95,
                    max_tokens = 800,
                    stream = false
                };



                HttpResponseMessage response = await client.PostAsync(ENDPOINT, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));



                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //JObject parsedResponse = JObject.Parse(jsonResponse);
                    //Console.WriteLine(parsedResponse.ToString());

                    ApiResponse parsedResponse2 = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                    // Access the content of the first choice's message
                    string messageContent = parsedResponse2.choices[0].message.content;
                    Console.WriteLine(messageContent.ToString());

                }
                else
                {
                    //return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
        else
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("api-key", API_KEY);
                var payload = new
                {
                    messages = new object[]
                    {
                  new {
                      role = "system",
                      content = new object[] {
                          new {
                              type = "text",
                              text = "You are an AI assistant that helps people find information."
                          }
                      }
                  },
                  new {
                      role = "user",
                      content = new object[] {
                          //new {
                          //    type = "image_url",
                          //    image_url = new {
                          //        url = $"data:image/jpeg;base64,{encodedImage}"
                          //    }
                          //},
                          new {
                              type = "text",
                              text = QUESTION
                          }
                      }
                  }
                    },
                    temperature = 0.7,
                    top_p = 0.95,
                    max_tokens = 800,
                    stream = false
                };

                var response = await httpClient.PostAsync(ENDPOINT, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
                var respuesta = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {

                    //var responseData = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                    Console.WriteLine(respuesta);
                    //var message = response.Value.Choices[0].ToString();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                }
            }
        }
    }
}