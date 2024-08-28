using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class PruebaController : ControllerBase
{
    [HttpGet("prueba")]
    public string pruebaApi()
    {
        return "Hola Mundo";
    }
}
