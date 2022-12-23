using Microsoft.EntityFrameworkCore;
using WebApplication1.database;
using WebApplication1.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>
    (o => o.UseInMemoryDatabase("productsDb"));
var dataContext = builder.Services.BuildServiceProvider().GetService<DataContext>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
DbInit.initData(dataContext);
app.Run();