using System;
using System.Linq;
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
    /// Получить данные о погоде в указанном городе
    /// </summary>
    /// <param name="city">Город, в котором необходимо узнать погоду, стандартное значение - Москва</param>
    /// <returns>Возвращает класс Root с погодой в указанном городе</returns>
    private async Task<Root?> GetWeatherAsync(string city = "Москва")
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage httpResponse = await httpClient.GetAsync($"{Url}q={city}{UrlParameters}");

        if (!httpResponse.IsSuccessStatusCode) return null;

        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Root>(responseContent);
    }

    /// <summary>
    /// Отправить данные о погоде пользователю
    /// </summary>
    /// <param name="city">Город</param>
    /// <returns>Возвращает строку с данными о погоде</returns>
    public async Task<string> SendWeatherAsync(string city = "Москва")
    {
        Root? weather = await GetWeatherAsync(city);

        if (weather is null) return "Ошибка в получении данных";

        Weather? test = weather.Weather?.FirstOrDefault();

        return $"<b>ПОГОДА В ГОРОДЕ {city.ToUpper()}</b>\n\n" +
               $"Температура: {weather.Main?.Temperature} °C\n" +
               $"Ощущается как: {weather.Main?.FeelsLike} °C\n" +
               $"На улице {test?.Description} {GetIcon(test!.Id)}\n";
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