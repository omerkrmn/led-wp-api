using Carter;

var builder = WebApplication.CreateBuilder(args);

// Servis kayıtları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();

// CORS politikası - şuanlık tüm metodlar aktif
builder.Services.AddCors(options =>
{
    options.AddPolicy("allow-all", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetPreflightMaxAge(TimeSpan.FromHours(24));
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WP.API v1");
    });
}

app.UseCors("allow-all");
app.MapCarter();

app.Run();