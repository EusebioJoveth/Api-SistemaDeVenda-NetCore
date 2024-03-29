using SistemaVenda.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjectarDependencias(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("NovaPolitica", app =>
    {
        app.AllowAnyOrigin().
         AllowAnyHeader()
        .AllowAnyMethod();
        
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NovaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
