using System.Text.Json.Serialization;

namespace WP.API.DTOs.Messages;

public class SendDocumentMessageRequest
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";

    [JsonPropertyName("recipient_type")]
    public string RecipientType { get; set; } = "individual";

    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = "document";

    [JsonPropertyName("document")]
    public DocumentMessageDto Document { get; set; } = new();
}
