using AccesosDatos.Models;
using AccesosDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        public ProfesorDAO profesorDAO = new ProfesorDAO();
        
        [HttpPost("autenticacion")]
        public string login([FromBody] Profesor profesor)
        {
            var prof = profesorDAO.login(profesor.Usuario, profesor.Pass);
            if (prof != null)
            {
                return "Bienvenido " + prof.Usuario;
            }
            else
            {
                return "Usuario o contraseña incorrectos";
            }
        }
    }
}
