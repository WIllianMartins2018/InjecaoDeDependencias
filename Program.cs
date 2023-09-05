using DemoInjecaoDependencias.Extensions;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<SqlConnection>();
builder.Services.AddRepositories();
builder.Services.AddServices();


builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();