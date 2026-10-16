using System.Text.Json.Serialization;

namespace WP.API.DTOs.Messages;
/// <summary>
/// bura kapalı
/// </summary>
public class SendMessageRequest
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";

    [JsonPropertyName("recipient_type")]
    public string RecipientType { get; set; } = "individual";

    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TextMessageDto? Text { get; set; }

    [JsonPropertyName("document")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DocumentMessageDto? Document { get; set; }

    
    [JsonPropertyName("recipient_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string? RecipientTyp
    {
        get => RecipientType;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                RecipientType = value;
        }
    }
}
