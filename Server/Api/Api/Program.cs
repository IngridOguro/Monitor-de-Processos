
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/process", () =>
{
    // Chame a função de HelloWorld.cs
    var message = Processes.ListarProcessos();

    // Retorne a mensagem
    return Results.Ok(message);
});

app.Run();

class Process
{
    public required string ProcessName {  get; set; }
    public required double MemoryUsage { get; set; }
    public required double CpuUsage { get; set; }

}