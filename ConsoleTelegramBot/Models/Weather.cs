using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

/// <summary>
/// Погодные условия
/// </summary>
public class Weather
{
    /// <summary>
    /// Идентификатор погодных условий
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Группа погодных условий
    /// </summary>
    [JsonPropertyName("main")]
    public string? Main { get; set; }

    /// <summary>
    /// Описание погодных условий
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Изображение погодных условий
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }
}