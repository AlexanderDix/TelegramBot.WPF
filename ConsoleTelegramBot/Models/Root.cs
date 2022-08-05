using System.Text.Json.Serialization;

namespace ConsoleTelegramBot.Models;

public class Root
{
    /// <summary>
    /// Географическое положение города
    /// </summary>
    [JsonPropertyName("coord")]
    public Coordinates? Coordinates { get; set; }

    /// <summary>
    /// Список с погодными условиями
    /// </summary>
    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }

    /// <summary>
    /// Внутренний параметр
    /// </summary>
    [JsonPropertyName("base")]
    public string? Base { get; set; }

    /// <summary>
    /// Основные данные о погоде
    /// </summary>
    [JsonPropertyName("main")]
    public Main? Main { get; set; }

    /// <summary>
    /// Видимость в метрах, максимальное значение составляет 10км
    /// </summary>
    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    /// <summary>
    /// Данные о ветре
    /// </summary>
    [JsonPropertyName("wind")]
    public Wind? Wind { get; set; }

    /// <summary>
    /// Облачность
    /// </summary>
    [JsonPropertyName("clouds")]
    public Clouds? Clouds { get; set; }

    /// <summary>
    /// Время вычисления данных, unix, UTC
    /// </summary>
    [JsonPropertyName("dt")]
    public int Dt { get; set; }

    /// <summary>
    /// Системные данные
    /// </summary>
    [JsonPropertyName("sys")]
    public Sys? Sys { get; set; }

    /// <summary>
    /// Сдвиг в секундах от UTC
    /// </summary>
    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    /// <summary>
    /// Идентификатор города
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Название города
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Внутренний параметр
    /// </summary>
    [JsonPropertyName("cod")]
    public int Cod { get; set; }
}