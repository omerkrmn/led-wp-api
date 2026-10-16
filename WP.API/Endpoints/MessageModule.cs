using Carter;
using Microsoft.AspNetCore.Mvc;
using WP.API.DTOs.Messages;

namespace WP.API.Endpoints;

public class MessageModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/message")
                       .WithTags("Messages");

        
        group.MapPost("/send-text", ([FromBody] SendTextMessageRequest request, CancellationToken ct) =>
        {
            if (string.IsNullOrWhiteSpace(request.To))
                return Results.BadRequest(new { error = "'to' alanı zorunludur." });

            if (request.Text == null || string.IsNullOrWhiteSpace(request.Text.Body))
                return Results.BadRequest(new { error = "'text.body' alanı zorunludur." });

            return Results.Ok(new
            {
                success = true,
                message = "Metin mesajı başarıyla işleme alındı.",
                data = request
            });
        })
        .Produces<object>(StatusCodes.Status200OK)
        .Produces<object>(StatusCodes.Status400BadRequest)
        .WithName("SendTextMessage")
        .WithSummary("WhatsApp metin mesajı gönderir");

        group.MapPost("/send-document", ([FromBody] SendDocumentMessageRequest request, CancellationToken ct) =>
        {
            if (string.IsNullOrWhiteSpace(request.To))
                return Results.BadRequest(new { error = "'to' alanı zorunludur." });

            if (request.Document == null)
                return Results.BadRequest(new { error = "'document' nesnesi zorunludur." });

            if (string.IsNullOrWhiteSpace(request.Document.Filename))
                return Results.BadRequest(new { error = "'document.filename' alanı zorunludur." });

            if (request.Document.Guid == Guid.Empty)
                return Results.BadRequest(new { error = "'document.guid' geçerli bir GUID olmalıdır." });

            return Results.Ok(new
            {
                success = true,
                message = "Doküman mesajı başarıyla işleme alındı.",
                data = request
            });
        })
        .Produces<object>(StatusCodes.Status200OK)
        .Produces<object>(StatusCodes.Status400BadRequest)
        .WithName("SendDocumentMessage")
        .WithSummary("WhatsApp doküman mesajı gönderir");
    }

    private static string? ValidateSendMessageRequest(SendMessageRequest request)
    {
        if (request == null)
            return "İstek gövdesi boş olamaz.";

        if (string.IsNullOrWhiteSpace(request.To))
            return "'to' alanı zorunludur.";

        if (string.IsNullOrWhiteSpace(request.Type))
            return "'type' alanı ('text' veya 'document') zorunludur.";

        var type = request.Type.Trim().ToLowerInvariant();
        if (type == "text")
        {
            if (request.Text == null || string.IsNullOrWhiteSpace(request.Text.Body))
                return "'type' text olduğunda 'text.body' alanı zorunludur.";
        }
        else if (type == "document")
        {
            if (request.Document == null)
                return "'type' document olduğunda 'document' nesnesi zorunludur.";

            if (string.IsNullOrWhiteSpace(request.Document.Filename))
                return "'document.filename' alanı zorunludur.";

            if (request.Document.Guid == Guid.Empty)
                return "'document.guid' geçerli bir GUID olmalıdır.";
        }
        else
        {
            return $"Desteklenmeyen mesaj tipi: '{request.Type}'. Yalnızca 'text' ve 'document' desteklenmektedir.";
        }

        return null;
    }
}
