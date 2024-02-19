using ApplicationServices;
using ApplicationServices.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WS Unit09",
        Description = "Web Services - MIW",
        Contact = new OpenApiContact
        {
            Name = "Miguel Garcia Rodriguez",
            Url = new Uri("https://reflection.uniovi.es/miguel")
        }
    });
   
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = new DataContext();
    //context.Database.EnsureDeleted(); //Delete ddbb always
    context.Database.EnsureCreated();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
