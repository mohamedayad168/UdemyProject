using Microsoft.Extensions.Hosting;
using Udemy.Extensions;
using Udemy.Presentation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(ControllerReference).Assembly);

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAutoMapperService();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.ConfigureCloudinaryService();
builder.Services.ConfigureCloudinarySettings(builder.Configuration);
builder.Services.ConfigureCORS();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.ConfigureApplicationDevelopmentCookie();
}
else
{
    builder.Services.ConfigureApplicationProductionCookie();
}


var app = builder.Build();


app.ConfigureExceptionHandler();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAngularDevelopment");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseCors("AllowAngularProduction");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

