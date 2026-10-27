using System.Text.Encodings.Web;
using System.Text.Json;
using OOP5_prak_5;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string filePath = "config.json";

if (!File.Exists(filePath))
{
    var defaultConfig = new Config { AppName = "MyApp", Version = 1 };
    var options = new JsonSerializerOptions { WriteIndented = true };

    string initialJson = JsonSerializer.Serialize(defaultConfig, options);
    File.WriteAllText(filePath, initialJson);
}
try
{
    string jsonContent = File.ReadAllText(filePath);
    Config? config = JsonSerializer.Deserialize<Config>(jsonContent);

    if (config is not null)
    {
        Console.WriteLine($"Конфігурацію успішно завантажено: {config.AppName} (v{config.Version})");
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Помилка: Файл '{filePath}' не знайдено!");
}
catch (JsonException)
{
    Console.WriteLine("Помилка: Некоректний формат JSON у файлі!");
}
