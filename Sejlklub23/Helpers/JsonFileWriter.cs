using System.Text.Json;

namespace Sejlklub23.Helpers
{
    public class JsonFileWriter<T>
    {
        public static void WriteToJson(List<T> elements, string jsonFileName)
        {
            using (FileStream outputStream = File.Create(jsonFileName))
            {
                var writter = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                }
                );
                JsonSerializer.Serialize<T[]>(writter, elements.ToArray());
            }
        }
    }
