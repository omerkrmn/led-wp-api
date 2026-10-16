using System.Text.Json.Serialization;

namespace WP.API.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TemplateCategory
{
    [JsonStringEnumMemberName("MARKETING")]
    MARKETING,

    [JsonStringEnumMemberName("UTILITY")]
    UTILITY,

    [JsonStringEnumMemberName("AUTHENTICATION")]
    AUTHENTICATION
}
