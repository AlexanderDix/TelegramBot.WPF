using System.IO;
using Newtonsoft.Json;

namespace TelegramBot.Infrastructure;

internal static class Serializator
{
    /// <summary>
    /// Сериализация данных в файл JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">Источник</param>
    /// <param name="path">Название файла</param>
    public static void Serialize<T>(T source, string path = "senders.json")
    {
        var json = JsonConvert.SerializeObject(source);

        File.WriteAllText(path, json);
    }

    /// <summary>
    /// Десериализация данных из файла JSON 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">Название файла</param>
    /// <returns>Возвращает данные из файла</returns>
    public static T Deserialize<T>(string path = "senders.json")
    {
        CheckFile(path);

        var json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// Проверка файла на существование, при отсутствии создает новый файл с тестовым пользователем
    /// </summary>
    /// <param name="path">Название файла</param>
    private static void CheckFile(string path)
    {
        if (File.Exists(path)) return;
        const string text =
            "[{\"Id\": 0,\"ChatId\": 1245471259,\"FirstName\": \"Тестовый пользователь\",\"LastName\": null,\"UserName\": \"testUser\",\"Messages\": [{\"Id\": 0,\"Text\": \"Погода\",\"Date\": \"2022-08-23T15:46:04+05:00\",\"IsBot\": false}]}]";

        File.WriteAllText(path, text);
    }
}