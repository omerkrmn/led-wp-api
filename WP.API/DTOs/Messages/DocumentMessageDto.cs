using System.Text.Json.Serialization;

namespace WP.API.DTOs.Messages;

public class DocumentMessageDto
{
    [JsonPropertyName("caption")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Caption { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public Guid Guid { get; set; }
}
