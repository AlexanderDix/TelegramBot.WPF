using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Ветер
/// </summary>
public class Wind
{
    /// <summary>
    /// Скорость ветра
    /// </summary>
    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    /// <summary>
    /// Направление ветра (метеорологическое)
    /// </summary>
    [JsonPropertyName("deg")]
    public int Degrees { get; set; }

    /// <summary>
    /// Порыв ветра, метров в секунду
    /// </summary>
    [JsonPropertyName("gust")]
    public double Gust { get; set; }
}