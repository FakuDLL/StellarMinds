using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net.Http.Json;
using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.WebApi.Servicios
{
    public class GeminiEvaluadorObservacionIA : IEvaluadorObservacionIA
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GeminiEvaluadorObservacionIA(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public DTOEvaluacionObservacion Evaluar(Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            var apiKey = _configuration["Gemini:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("No está configurada la clave de Gemini.");

            var model = _configuration["Gemini:Model"];
            if (string.IsNullOrWhiteSpace(model))
                model = "gemini-3.6-flash";

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent";

            var prompt = CrearPrompt(prestamo, objetoCeleste);
            var request = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    responseMimeType = "application/json"
                }
            };

            var response = client.PostAsJsonAsync(url, request).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var texto = ExtraerTextoRespuesta(body);
            var json = LimpiarJson(texto);

            var evaluacion = JsonSerializer.Deserialize<DTOEvaluacionObservacion>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (evaluacion == null)
                throw new InvalidOperationException("Gemini no devolvió una evaluación válida.");

            return new DTOEvaluacionObservacion
            {
                Indicador = evaluacion.Indicador,
                Detalle = evaluacion.Detalle ?? string.Empty
            };
        }

        private static string CrearPrompt(Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            var datosEquipo = prestamo.Camara != null
                ? CrearDatosAstrofotografia(prestamo, objetoCeleste)
                : CrearDatosObservacionVisual(prestamo, objetoCeleste);

            return
                "Evalúa si el equipo astronómico es IDEAL, ADECUADO o NO RECOMENDABLE para observar o fotografiar el objeto celeste. " +
                "Responde únicamente JSON con las propiedades indicador y detalle. " +
                "El indicador debe ser exactamente IDEAL, ADECUADO o NO RECOMENDABLE. " +
                "El detalle debe estar vacío si es IDEAL y debe explicar el motivo en no más de 300 caracteres si no es IDEAL. " +
                $"Datos: {datosEquipo}";
        }

        private static string CrearDatosAstrofotografia(Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            return JsonSerializer.Serialize(new
            {
                telescopio = new
                {
                    apertura_mm = prestamo.Telescopio.AperturaMm,
                    focal_mm = prestamo.Telescopio.DistanciaFocalMm,
                    relacion_focal = prestamo.Telescopio.RelacionFocal
                },
                montura = new
                {
                    tipo = prestamo.Montura.TipoMontura,
                    carga_util_kg = prestamo.Montura.CargaUtilKg,
                    computarizada = prestamo.Montura.EsComputarizado
                },
                camara = new
                {
                    sensor = prestamo.Camara!.TipoSensor,
                    resolucion_px = prestamo.Camara.Resolucion,
                    pixel_size_um = prestamo.Camara.TamanoPixelMicras
                },
                objeto_celeste = new
                {
                    nombre = objetoCeleste.Nombre,
                    tipo = objetoCeleste.Tipo.ToString()
                }
            });
        }

        private static string CrearDatosObservacionVisual(Prestamo prestamo, ObjetoCeleste objetoCeleste)
        {
            return JsonSerializer.Serialize(new
            {
                telescopio = new
                {
                    apertura_mm = prestamo.Telescopio.AperturaMm,
                    focal_mm = prestamo.Telescopio.DistanciaFocalMm,
                    relacion_focal = prestamo.Telescopio.RelacionFocal
                },
                montura = new
                {
                    tipo = prestamo.Montura.TipoMontura,
                    carga_util_kg = prestamo.Montura.CargaUtilKg,
                    computarizada = prestamo.Montura.EsComputarizado
                },
                ocular = new
                {
                    ocular_focal_mm = prestamo.Ocular!.DiametroMm,
                    campo_aparente_grados = prestamo.Ocular.AnguloVisionGrados
                },
                objeto_celeste = new
                {
                    nombre = objetoCeleste.Nombre,
                    tipo = objetoCeleste.Tipo.ToString()
                }
            });
        }

        private static string ExtraerTextoRespuesta(string body)
        {
            using var document = JsonDocument.Parse(body);
            var root = document.RootElement;

            return root
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString() ?? string.Empty;
        }

        private static string LimpiarJson(string texto)
        {
            var limpio = texto.Trim();
            limpio = Regex.Replace(limpio, "^```json\\s*", string.Empty, RegexOptions.IgnoreCase);
            limpio = Regex.Replace(limpio, "^```\\s*", string.Empty);
            limpio = Regex.Replace(limpio, "\\s*```$", string.Empty);
            return limpio.Trim();
        }
    }
}
