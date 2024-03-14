using Microsoft.EntityFrameworkCore;
using WindowsOrders.BLL.Repos;
using WindowsOrders.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WindowsOrdersContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        b => b.MigrationsAssembly("WindowsOrders.Api"));
});

builder.Services.AddScoped<IWindowsOrdersRepo, WindowsOrdersRepo>();
builder.Services.AddScoped<IWindowsOrdersMetaRepo, WindowsOrdersMetaRepo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Use(async (context, next) =>
{
    //context.Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:7188");
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    await next.Invoke();
});
app.Run();
