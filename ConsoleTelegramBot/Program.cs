using System.Text.Json;
using ConsoleTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleTelegramBot;

internal static class Program
{
    private const string UrlParameters = $"q=Ишим&appid={Configuration.ApiKey}&units=metric&lang=ru";
    private const string Url = "https://api.openweathermap.org/data/2.5/weather?";
    private static readonly CancellationTokenSource Cts = new();

    private static void Main(string[] args)
    {
        ITelegramBotClient botClient = new TelegramBotClient(Configuration.Token);
        CancellationToken cancellationToken = Cts.Token;
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = { }
        };
        botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);

        Console.ReadLine();
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    private static async Task<string> ConnectAsync()
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage httpResponse = await httpClient.GetAsync(Url + UrlParameters);

        if (httpResponse.IsSuccessStatusCode)
        {
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<Root>(responseContent);

            var header = $"Температура в городе {response?.Name}: {response?.Main?.Temperature} градусов\n";

            foreach (Weather weather in response?.Weather!)
            {
                header += $"Погода: {weather.Main} - {weather.Description}\n" +
                          $"Icon: {weather.Icon}";

                Console.WriteLine(header);
            }

            return header;
        }

        Console.WriteLine($"{(int)httpResponse.StatusCode} - {httpResponse.ReasonPhrase}");

        return "Нет доступа к серверу";
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            Message? message = update.Message;

            if (message?.Text is null) return;

            switch (message.Text.ToLower())
            {
                case "/start":
                    await bot.SendTextMessageAsync(message.Chat, "Добро пожаловать 🖖", cancellationToken: cancellationToken);
                    return;
                case "/weather":
                case "/погода":
                    var response = await ConnectAsync();
                    await bot.SendTextMessageAsync(message.Chat, response, cancellationToken: cancellationToken);
                    return;
            }

            await bot.SendTextMessageAsync(message.Chat, "💡", cancellationToken: cancellationToken);
        }
    }

    private static async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception,
        CancellationToken cancellationToken)
    {
        await Task.Run(() => Console.WriteLine($"{exception}"), cancellationToken);
    }
}
