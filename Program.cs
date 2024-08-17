using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Sqlite;
using Blogging_Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<BlogContext>(db => db.UseSqlite("Data Source = blog.db"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Maps attribute-routed controllers

app.Run();

