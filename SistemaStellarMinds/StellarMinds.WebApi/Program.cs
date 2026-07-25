using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StellarMinds.AccesoDatos;
using StellarMinds.AccesoDatos.Repositorios;
using StellarMinds.LogicaAplicacion.CasosUso;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;
using StellarMinds.WebApi.Servicios;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var connectionString = builder.Configuration.GetConnectionString("StellarMindsDb");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "ConnectionStrings:StellarMindsDb no está configurada. Use User Secrets en desarrollo o una variable de entorno en producción.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSection["Key"];
var jwtIssuer = jwtSection["Issuer"];
var jwtAudience = jwtSection["Audience"];

if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetByteCount(jwtKey) < 32)
{
    throw new InvalidOperationException(
        "Jwt:Key debe configurarse fuera del repositorio y contener al menos 32 bytes.");
}

if (string.IsNullOrWhiteSpace(jwtIssuer) || string.IsNullOrWhiteSpace(jwtAudience))
{
    throw new InvalidOperationException("Jwt:Issuer y Jwt:Audience son obligatorios.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddFixedWindowLimiter("login", limiter =>
    {
        limiter.PermitLimit = 5;
        limiter.Window = TimeSpan.FromMinutes(1);
        limiter.QueueLimit = 0;
        limiter.AutoReplenishment = true;
    });
});

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICUListadoUsuarios, CUListadoUsuarios>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<ICUAltaEquipo, CUAltaEquipo>();
builder.Services.AddScoped<ICUObtenerEquipos, CUObtenerEquipos>();
builder.Services.AddScoped<ICUObtenerEquipo, CUObtenerEquipo>();
builder.Services.AddScoped<ICUActualizarEquipo, CUActualizarEquipo>();
builder.Services.AddScoped<ICUBajaEquipo, CUBajaEquipo>();
builder.Services.AddScoped<ICUDisponibilidadEquipo, CUDisponibilidadEquipo>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioAuditoriaPrestamo, RepositorioAuditoriaPrestamo>();
builder.Services.AddScoped<ICUAltaPrestamo, CUAltaPrestamo>();
builder.Services.AddScoped<ICUDevolucionPrestamo, CUDevolucionPrestamo>();
builder.Services.AddScoped<ICUListadoPrestamosPorSocio, CUListadoPrestamosPorSocio>();
builder.Services.AddScoped<ICUListadoPrestamosEntreFechas, CUListadoPrestamosEntreFechas>();
builder.Services.AddScoped<ICUDetallePrestamo, CUDetallePrestamo>();
builder.Services.AddScoped<ICUListadoSociosPorTelescopio, CUListadoSociosPorTelescopio>();
builder.Services.AddScoped<ICUListadoAuditoriaPrestamos, CUListadoAuditoriaPrestamos>();
builder.Services.AddScoped<ICUDetalleAuditoriaPrestamo, CUDetalleAuditoriaPrestamo>();
builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCeleste>();
builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacion>();
builder.Services.AddScoped<IEvaluadorObservacionIA, GeminiEvaluadorObservacionIA>();
builder.Services.AddScoped<ICUAltaObservacion, CUAltaObservacion>();
builder.Services.AddScoped<ICURankingObjetosCelestes, CURankingObjetosCelestes>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
