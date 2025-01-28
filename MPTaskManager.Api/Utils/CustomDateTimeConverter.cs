using System.Text.Json;
using System.Text.Json.Serialization;
namespace MPTaskManager.Shared.Utils;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _format;

    public CustomDateTimeConverter() : this("yyyy-MM-dd HH:mm")
    {
    }
    public CustomDateTimeConverter(string format = "yyyy-MM-dd HH:mm")
    {
        _format = format;
    }
    
    

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (dateString is null)
            throw new JsonException("Expected date string.");

        if (DateTime.TryParseExact(dateString, _format, null,
                System.Globalization.DateTimeStyles.None, out var dateTime))
        {
            return DateTime.ParseExact(reader.GetString(), _format, null);
        }

        throw new JsonException($"Date must be in format {_format}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}