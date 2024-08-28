using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesosDatos.Models;
using AccesosDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api")]
public class AlumnoController : Controller
{
    private AlumnoDAO alumnoDAO = new AlumnoDAO();

    [HttpGet("alumnosProfesor")]
    public List<AlumnoProfesor> alumnosProfesor(string usuario)
    {
        return alumnoDAO.seleccionarAlumnosProfesor(usuario);
    }

    [HttpGet("alumno")]
    public Alumno getAlumno(int id)
    {
        return alumnoDAO.seleccionar(id);
    }

    [HttpPut("alumno")]
    public bool acutalizarAlumno([FromBody]Alumno alumno)
    {
        return alumnoDAO.actualizar(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
    }

    [HttpPost("alumno")]
    public bool insertarMatricular([FromBody]Alumno alumno, int idAsig)
    {
        return alumnoDAO.insertarYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, idAsig);
    }
}

