using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Factories;
using InsuranceManagementSystem.Observers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<InsuranceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CreatePolicyFactory>();

var loggingService = new LoggingService();
var insuranceCaseService = new InsuranceCaseService();
insuranceCaseService.Attach(loggingService);

builder.Services.AddSingleton(loggingService);
builder.Services.AddSingleton(insuranceCaseService);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();