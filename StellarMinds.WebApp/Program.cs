var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];
if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new InvalidOperationException("ApiSettings:BaseUrl is not configured.");
}

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IApiClient, StellarMinds.WebApp.Services.Api.ApiClient>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IAuthApiService, StellarMinds.WebApp.Services.Api.AuthApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IUsuariosApiService, StellarMinds.WebApp.Services.Api.UsuariosApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IEquiposApiService, StellarMinds.WebApp.Services.Api.EquiposApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IPrestamosApiService, StellarMinds.WebApp.Services.Api.PrestamosApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IAuditoriasApiService, StellarMinds.WebApp.Services.Api.AuditoriasApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IObservacionesApiService, StellarMinds.WebApp.Services.Api.ObservacionesApiService>();
builder.Services.AddScoped<StellarMinds.WebApp.Services.Api.IObjetosCelestesApiService, StellarMinds.WebApp.Services.Api.ObjetosCelestesApiService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.Name = ".StellarMinds.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment()
        ? CookieSecurePolicy.SameAsRequest
        : CookieSecurePolicy.Always;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
