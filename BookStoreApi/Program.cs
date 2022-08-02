using HostBase.Configuration;
using HostBase.Constant;
using Entity.ConfigModel;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

//// Configure JSON options
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.PropertyNameCaseInsensitive = true;
//});

// Thêm các config 
builder.Host.ConfigureAppsettings(new string[] { ConfigFileName.Connections });
builder.Services.InjectConfig<DefaultConfig>(builder.Configuration);

// Add services to the container.
builder.Services.
    AddControllers().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
