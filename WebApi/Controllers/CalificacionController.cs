using AccesosDatos.Models;
using AccesosDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class CalificacionController : Controller
{
    public CalificacionDAO calificacionDAO = new CalificacionDAO();

    [HttpGet("calificaciones")]
    public List<Calificacion> getCalificaciones(int idMatricula)
    {
        return calificacionDAO.seleccionar(idMatricula);
    }

    [HttpPost("calificacion")]
    public bool agregar([FromBody] Calificacion calif)
    {
        return calificacionDAO.insertar(calif);
    }

    [HttpDelete("calificacion")]
    public bool eliminar(int id)
    {
        return calificacionDAO.eliminar(id);
    }
}
