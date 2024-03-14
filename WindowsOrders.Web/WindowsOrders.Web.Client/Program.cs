using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WindowsOrders.BLL.ApiServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IApiService>(x => {
    return new ApiService("https://localhost:7136/");     
});
builder.Services.AddBlazoredSessionStorage();


await builder.Build().RunAsync();
