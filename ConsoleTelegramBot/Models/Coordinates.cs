using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Географическое положение города
/// </summary>
public class Coordinates
{
    /// <summary>
    /// Географическое положение города, долгота
    /// </summary>
    [JsonPropertyName("lon")]
    public double Longitude { get; set; }

    /// <summary>
    /// Географическое положение города, широта
    /// </summary>
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }
}