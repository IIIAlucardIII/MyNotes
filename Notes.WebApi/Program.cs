using Notes.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var connectionString = builder.Configuration.GetConnectionString("NotesDb");
builder.Services.AddDbContext<NotesDbContext>(x => x.UseSqlServer(connectionString));
app.MapGet("/", () => "Hello World!");

app.Run();
