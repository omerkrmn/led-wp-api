using System.ComponentModel.DataAnnotations;

namespace WP.API.DTOs.Messages;

public class TemplateQuery
{
    public string Name { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    [MaxLength(3)]
    public string Lang { get; set; }
    [Required] 
    public string Header { get; set; }
    [Required] 
    public string Body { get; set; }
    [Required] 
    public string Footer { get; set; }
}
