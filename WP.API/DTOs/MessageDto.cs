using WP.API.DTOs.Messages;
using WP.API.DTOs.Templates;

namespace WP.API.DTOs;

// Geriye dönük uyumluluk takma adları (Backward Compatibility Aliases)
public class Root : CreateTemplateRequest { }
public class Component : TemplateComponentDto { }
public class WPMessage : SendMessageRequest { }

public interface IMessageContent { }

public class TypeText : IMessageContent
{
    public string text { get; set; } = string.Empty;
}

public class TypeDocument : IMessageContent
{
    public string caption { get; set; } = string.Empty;
    public string filename { get; set; } = string.Empty;
    public Guid guid { get; set; }
}