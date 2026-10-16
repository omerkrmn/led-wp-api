using System.Text.Json.Serialization;
using WP.API.Enums;

namespace WP.API.DTOs.Templates;

public class CreateTemplateRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("language")]
    public string Language { get; set; } = "tr";

    [JsonPropertyName("category")]
    public string Category { get; set; } = TemplateCategory.UTILITY.ToString();

    [JsonPropertyName("components")]
    public List<TemplateComponentDto> Components { get; set; } = [];
}
