
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

var app = builder.Build();
app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



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