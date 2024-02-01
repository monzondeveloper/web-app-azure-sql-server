using WebAppSqlServer.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://appconfiguration3000.azconfig.io;Id=vPw7;Secret=pnP//wgpxv/B/cYxuei2oQBoJY+O2a3MLkFP0CO0Htc=";

builder.Host.ConfigureAppConfiguration(x =>
{
    x.AddAzureAppConfiguration(connectionString);
});

builder.Services.AddScoped<IProductService, ProductService>();


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
