using FreeRedis;
using NetCore.Web.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new LongToStringConverter());
    options.SerializerSettings.Converters.Add(new DateOnlyConverter());
    options.SerializerSettings.Converters.Add(new TimeOnlyConverter());
    options.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";
});
builder.Logging.AddLog4Net("log4net.config");
builder.Services.AddGlobalModelStateFilter();
builder.Services.AddGlobalExceptionFilter();
builder.Services.AddCors(option =>
    option.AddPolicy("Cors", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddSingleton(new RedisClient(builder.Configuration.GetValue<string>("RedisConnectionString")));

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

app.UseCors("Cors");
app.UseAuthorization();

app.MapControllers();

app.Run();