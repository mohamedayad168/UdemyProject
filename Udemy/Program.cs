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
builder.Services.ConfigureApplicationCookie();
builder.Services.AddAuthorization();
builder.Services.ConfigureCloudinaryService();
builder.Services.ConfigureCloudinarySettings(builder.Configuration);



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevelopment",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:4200",//student & instructor frontend
                "http://localhost:54377"// admin frontend
            )
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });


    options.AddPolicy("AllowAngularProduction",
        policy =>
        {
            policy.WithOrigins("https://production:bomba")
                  .AllowCredentials()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.Use(async (contex, next) =>
{
    Console.WriteLine(
        contex);
    await next();
});

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
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

