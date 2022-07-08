using course_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddDbContext<DataContext>(opt=> opt.UseInMemoryDatabase("Database"));
builder.Services.AddSwaggerGen(c=> 
            {
               c.SwaggerDoc("v1", new OpenApiInfo {Title = "CourseApi", Version = "v1"}); 
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
