using Merchant_API.services;
using Merchant_API.models;
//var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.Configure<MongoDBSettings>(
                builder.Configuration.GetSection(nameof(MongoDBSettings)));

// Add our services for DI
MongoDBSettings options = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
// override connection string from environment variables, you can also do the same for the rest
string connection_string = builder.Configuration.GetValue<string>("CONNECTION_STRING");
if (!string.IsNullOrEmpty(connection_string)) {
    options.ConnectionString = connection_string;
}


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add our services for direct injection


builder.Services.AddSingleton<ShopItemService>();
builder.Services.AddSingleton<ShopUserService>();
builder.Services.AddSingleton<ChatService>();
//builder.Services.AddSingleton<TodoService>();
//builder.Services.AddSingleton<ShopService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
