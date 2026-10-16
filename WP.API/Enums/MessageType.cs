using System.Text.Json.Serialization;

namespace WP.API.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageType
{
    [JsonStringEnumMemberName("text")]
    Text = 0,

    [JsonStringEnumMemberName("document")]
    Document = 1,

    // Geriye dönük uyumluluk için takma ad
    [JsonStringEnumMemberName("media")]
    Media = 1
}
