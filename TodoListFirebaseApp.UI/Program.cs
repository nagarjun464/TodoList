using TodoListFirebaseApp.Services;
using TodoListFirebaseApp.UI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<FirebaseService>();
builder.Services.AddHttpClient("TodoAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7113/"); // Make sure this matches your API port
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7113/") });



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
