using HelloMD.Helpers;
using HelloMD.Hubs;
using HelloMD.Repositories;
using HelloMD.Repositories.Interfaces;
using HelloMD.Services;
using HelloMD.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NameAPIProxyService.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to DI container
{
    var services = builder.Services;
    builder.Services.AddSignalR();

    services.AddCors();
    services.AddControllers().AddNewtonsoftJson();

    builder.Services.AddSingleton<IUserRepository, UserRepository>();

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    //AutoMapper
    builder.Services.AddAutoMapper(typeof(Program));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IMessageService, MessageService>();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //
    builder.Services.AddDbContextFactory<HelloMDDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbPath"));
    });

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}


// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();
    app.UseRouting();
    app.MapControllers();
}

app.UseEndpoints(endpoints => endpoints.MapHub<ChatHub>("/ChatHub"));

app.Run();