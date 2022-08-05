using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Системные данные
/// </summary>
public class Sys
{
    /// <summary>
    /// Страна
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Время восхода солнца
    /// </summary>
    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }

    /// <summary>
    /// Время захода солнца
    /// </summary>
    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }
}