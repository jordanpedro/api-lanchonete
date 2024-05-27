using ApiLanchonete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.BuildServices(builder.Configuration);
var app = builder.Build();
app.UseServices(builder.Environment);
app.Run();
