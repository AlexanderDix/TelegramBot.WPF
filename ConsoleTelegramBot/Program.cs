using System.Text.Json;
using ConsoleTelegramBot.Models;

namespace ConsoleTelegramBot;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.ReadLine();
    }

    private const string UrlParameters = $"q=Ишим&appid={Configuration.ApiKey}&units=metric&lang=ru";
    private const string Url = "https://api.openweathermap.org/data/2.5/weather?";

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    private static async Task ConnectAsync()
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage httpResponse = await httpClient.GetAsync(Url + UrlParameters);

        if (httpResponse.IsSuccessStatusCode)
        {
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<Root>(responseContent);

            Console.WriteLine($"Температура в городе {response?.Name}: {response?.Main?.Temperature} градусов");

            foreach (Weather weather in response?.Weather!)
            {
                Console.WriteLine($"Погода: {weather.Main} - {weather.Description}");
                Console.WriteLine($"Icon: {weather.Icon}");
            }
        }
        else
        {
            Console.WriteLine($"{(int)httpResponse.StatusCode} - {httpResponse.ReasonPhrase}");
        }
    }
}
