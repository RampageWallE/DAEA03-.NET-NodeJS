using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;

        public UserController(ILogger<UserController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient; // Inicializamos HttpClient
        }


        // Nuevo endpoint para obtener usuarios de la API externa
        [HttpGet("", Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            // URL de la API RandomUser
            var apiUrl = "https://randomuser.me/api/?results=1";

            try
            {
                // Realiza una solicitud GET a la API y obtiene el contenido como string
                var response = await _httpClient.GetStringAsync(apiUrl);

                // Devuelve el contenido JSON tal como fue recibido
                return Content(response, "application/json");
            }
            catch (HttpRequestException ex)
            {
                // Manejo de error en caso de fallo en la solicitud
                return Problem($"Error al conectar con la API externa: {ex.Message}");
            }
        }
    }
}
