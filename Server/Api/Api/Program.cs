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

var processes = new List<Process>
{
    new Process { ProcessName = "edge", MemoryUsage = 1, CpuUsage = 1},
};

app.MapGet("/process", () =>
{
    return processes;
});

app.Run();

class Process
{
    public required string ProcessName {  get; set; }
    public required double MemoryUsage { get; set; }
    public required double CpuUsage { get; set; }

}