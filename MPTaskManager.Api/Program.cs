using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MPTaskManager.Api.Controllers;
using MPTaskManager.Api.Infrastructure;
using MPTaskManager.Api.Middlewares;
using MPTaskManager.Api.Repositories;
using MPTaskManager.Api.Services;
using MPTaskManager.Shared.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd HH:mm"));
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

// Adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.AllowAnyOrigin() // Substitua pelo URL do front-end
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add controller conventions
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new LowerCaseControllerRouteConvention());
});


// Add DbContext
builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // Ajuste a versão do seu MySQL
    );
});


// Add MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(TaskController).Assembly);
        
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Transactions API",
        Version = "v1",
        Description = "API para transações financeiras",
        Contact = new OpenApiContact
        {
            Name = "Transactions-Maurício Pereira",
            Email = "mauricio.pvieira1@gmail.com",
        },
        
    });   
    c.MapType<DateTime>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Format = "date-time",
        Example = new Microsoft.OpenApi.Any.OpenApiString("2025-01-23 15:25")
    });
});

// Add WebHost
builder.WebHost.UseUrls("http://localhost:5001", "https://localhost:7003");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");
app.Run();
