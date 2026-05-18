using VehiclePartsFrontend.Components;
using VehiclePartsFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var backendBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5173/";
builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = new Uri(backendBaseUrl);
});
builder.Services.AddScoped<AuthStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
