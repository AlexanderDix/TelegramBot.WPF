using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Основные данные
/// </summary>
public class Main
{
    /// <summary>
    /// Температура
    /// </summary>
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    /// <summary>
    /// Ощущение температуры человеком
    /// </summary>
    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    /// <summary>
    /// Минимальная температура
    /// </summary>
    [JsonPropertyName("temp_min")]
    public double TemperatureMin { get; set; }

    /// <summary>
    /// Максимальная температура
    /// </summary>
    [JsonPropertyName("temp_max")]
    public double TemperatureMax { get; set; }

    /// <summary>
    /// Атмосферное давление (на уровне моря, если нет данных об уровне земли), ГПа
    /// </summary>
    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    /// <summary>
    /// Влажность воздуха
    /// </summary>
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    /// <summary>
    /// Атмосферное давление на уровне моря, ГПа
    /// </summary>
    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    /// <summary>
    /// Атмосферное давление на уровне земли, ГПа
    /// </summary>
    [JsonPropertyName("grnd_level")]
    public int GroundLevel { get; set; }
}