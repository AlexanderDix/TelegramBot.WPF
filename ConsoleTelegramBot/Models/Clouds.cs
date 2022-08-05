using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Облачность
/// </summary>
public class Clouds
{
    /// <summary>
    /// Облачность в процентах
    /// </summary>
    [JsonPropertyName("all")]
    public int All { get; set; }
}