using System.Text.Json.Serialization;

namespace WP.API.DTOs.Templates;

public class TemplateComponentDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
