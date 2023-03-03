using DevJJGR.Application.Behaviors;
using DevJJGR.Infrastructure;
using DevJJGR.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder
//    .Services
//    .Scan(
//        selector => selector
//            .FromAssemblies(
//                DevJJGR.Infrastructure.AssemblyReference.Assembly,
//                DevJJGR.Persistence.AssemblyReference.Assembly)
//            .AddClasses(false)
//            .AsImplementedInterfaces()
//            .WithScopedLifetime());
builder.Services.AddServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddMediatR(DevJJGR.Application.AssemblyReference.Assembly);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(DevJJGR.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

string connectionString = builder.Configuration.GetConnectionString("Database");



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    connectionString,
    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure()));
//builder.Services.AddQuartzHostedService();

builder
    .Services
    .AddControllers()
.AddApplicationPart(DevJJGR.Presentation.AssemblyReference.Assembly);

builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.EnableDetailedErrors = true;
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "api/v{version}/[controller]");
app.Run();
