using System.Text.Json.Serialization;

namespace WP.API.DTOs.Messages;

public class TextMessageDto
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = string.Empty;
}
