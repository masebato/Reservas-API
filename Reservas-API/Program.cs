using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Serilog;
using Autofac;
using System.Data;
using Npgsql;
using Figgle;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Reservas_INFRASTRUCTURE;
using Reservas_API.Infrastructure.AutoFactModules;
using Reservas_API.Infrastructure.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new InfrastructureModule()));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<IDbConnection>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("postgrestDB");
    return new NpgsqlConnection(connectionString);
});


builder.Services.AddDbContext<ReservasDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("postgrestDB"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

var appName = builder.Configuration.GetSection("AppName").Value;
Console.WriteLine(FiggleFonts.Standard.Render(appName));
Log.Information("Starting web host ({ApplicationContext})...", appName);



app.MapControllers();

app.Run();
