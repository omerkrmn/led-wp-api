using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WP.API.DTOs.Messages;

public class SendTextMessageRequest
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";

    [JsonPropertyName("recipient_type")]
    public string RecipientType { get; set; } = "individual";
    [Phone]
    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = "text";

    [JsonPropertyName("text")]
    public TextMessageDto Text { get; set; } = new();
}
