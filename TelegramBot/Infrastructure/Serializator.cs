using System.IO;
using Newtonsoft.Json;

namespace TelegramBot.Infrastructure;

internal static class Serializator
{
    public static void Serialize<T>(T source, string path = "senders.json")
    {
        var json = JsonConvert.SerializeObject(source);

        File.WriteAllText(path, json);
    }

    public static T Deserialize<T>(string path = "senders.json")
    {
        var json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<T>(json);
    }
}