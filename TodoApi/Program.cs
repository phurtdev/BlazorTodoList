var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to allow requests from the WebClient
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable HTTPS and handle development exceptions.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Enable Swagger in development
    app.UseSwaggerUI(); // Use Swagger UI
    app.UseCors("AllowAllOrigins"); // Use the CORS policy in development mode
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map the API controllers so they can respond to API requests.
app.MapControllers();

app.Run();
