using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TelegramBot.Infrastructure;
using TelegramBot.Models.WeatherModels;

namespace TelegramBot.Services;

internal class WeatherManager
{
    private const string Url = "https://api.openweathermap.org/data/2.5/weather?";
    private const string UrlParameters = $"&appid={Configuration.ApiKey}&units=metric&lang=ru";

    /// <summary>
    /// Отправляем пользователю погодную сводку
    /// </summary>
    /// <param name="city">Название города</param>
    /// <returns>Возвращает строку с данными о погоде</returns>
    public async Task<string> SendWeatherAsync(string city)
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage httpResponse = await httpClient.GetAsync($"{Url}q={city}{UrlParameters}");

        switch (httpResponse.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                return "Ошибка со стороны сервиса";
            case HttpStatusCode.NotFound:
                return "Указанного города не существует";
            case HttpStatusCode.TooManyRequests:
                return "Превышено количество вызовов";
        }

        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var root = JsonSerializer.Deserialize<Root>(responseContent);

        if (root is null) return "Ошибка в получении данных";

        Weather? weather = root.Weather?.FirstOrDefault();

        return $"ПОГОДА В ГОРОДЕ {city.ToUpper()}\n\n" +
               $"Температура: {root.Main?.Temperature} °C\n" +
               $"Ощущается как: {root.Main?.FeelsLike} °C\n" +
               $"На улице {weather?.Description} {GetIcon(weather!.Id)}";
    }

    /// <summary>
    /// Возвращает эмодзи на основании идентификатора погодных условий
    /// </summary>
    /// <param name="id">Идентификатор погодных условий</param>
    /// <returns>Возвращает эмодзи в виде строки</returns>
    private string? GetIcon(int id)
    {
        return id switch
        {
            > 199 and <= 232 => "🌩",
            > 299 and <= 321 => "🌧",
            > 499 and <= 531 => "🌦",
            > 599 and <= 622 => "❄️",
            > 700 and <= 781 => "🌫",
            > 800 and <= 804 => "🌤",
            800 => "☀️",
            _ => null
        };
    }
}