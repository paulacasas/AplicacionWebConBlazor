var builder = WebApplication.CreateBuilder(args);

// Agrega CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7198", "http://localhost:7198")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Agrega HttpClient Factory
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// USA CORS antes de Authorization
app.UseCors("AllowBlazorClient");

app.UseAuthorization();

app.MapControllers();

app.Run();

