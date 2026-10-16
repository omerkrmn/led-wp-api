using Carter;
using Microsoft.AspNetCore.Mvc;
using WP.API.DTOs.Messages;
using WP.API.DTOs.Templates;
using WP.API.Enums;

namespace WP.API.Endpoints;

public class TemplateModule : ICarterModule
{
    private static readonly HashSet<string> AllowedTemplateTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "Text",
        "Document",
        "Media"
    };

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/template")
                       .WithTags("Templates");

        group.MapPost("/create", ([FromBody] TemplateQuery request, [FromQuery] string type, CancellationToken ct) =>
        {
            if (string.IsNullOrWhiteSpace(type))
                return Results.BadRequest(new { error = "'type' query parametresi zorunludur ('text', 'Document', 'Media')." });
            

            if (!AllowedTemplateTypes.Contains(type))
                return Results.BadRequest(new { error = $"'type' query parametresi 'text', 'Document' veya 'Media' olmalıdır. Girilen değer: '{type}'" });
            

            var error = ValidateTemplateRequest(request);
            if (error != null)
                return Results.BadRequest(new { error });

            var temp = new CreateTemplateRequest
            {
                Name = request.Name,
                Category = request.Category,
                Language = request.Lang,
                Components = {
                    new TemplateComponentDto
                    {
                        Type = "HEADER",
                        Format = "TEXT",
                        Text = request.Header
                    },
                    new TemplateComponentDto
                    {
                        Type = "BODY",
                        Text = request.Body
                    },
                    new TemplateComponentDto
                    {
                        Type = "FOOTER",
                        Text = request.Footer
                    }
                }
            };

            return Results.Ok(new
            {
                success = true,
                message = $"{type} tipinde şablon başarıyla oluşturuldu.",
                type = type,
                data = temp
            });
        })
        .Produces<object>(StatusCodes.Status200OK)
        .Produces<object>(StatusCodes.Status400BadRequest)
        .WithName("CreateTemplate")
        .WithSummary("Yeni bir WhatsApp mesaj şablonu (template) oluşturur. Type bilgisi query string üzerinden alınır ('text', 'Document', 'Media').");
    }

    private static string? ValidateTemplateRequest(TemplateQuery request)
    {
        if (request == null)
            return "İstek gövdesi boş olamaz.";


        if (!Enum.IsDefined(typeof(TemplateCategory), request.Category))
            return "'category' alanı 'MARKETING', 'UTILITY' veya 'AUTHENTICATION' olmalıdır.";

        return null;
    }
}
