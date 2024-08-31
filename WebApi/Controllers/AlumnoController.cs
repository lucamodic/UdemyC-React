using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesosDatos.Interfaces;
using AccesosDatos.Models;
using AccesosDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api")]
public class AlumnoController : Controller
{
    private readonly IAlumnoDAO _alumnoDAO;


    public AlumnoController(IAlumnoDAO alumnoDAO)
    {
        _alumnoDAO = alumnoDAO;
    }

    [HttpGet("alumnosProfesor")]
    public List<AlumnoProfesor> alumnosProfesor(string usuario)
    {
        return _alumnoDAO.seleccionarAlumnosProfesor(usuario);
    }

    [HttpGet("alumno")]
    public Alumno getAlumno(int id)
    {
        return _alumnoDAO.seleccionar(id);
    }

    [HttpPut("alumno")]
    public bool acutalizarAlumno([FromBody]Alumno alumno)
    {
        return _alumnoDAO.actualizar(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
    }

    [HttpPost("alumno")]
    public bool insertarMatricular([FromBody]Alumno alumno, int idAsig)
    {
        return _alumnoDAO.insertarYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, idAsig);
    }

    [HttpDelete("alumno")]
    public bool eliminarAlumno(int id)
    {
        return _alumnoDAO.eliminarAlumno(id);
    }
}

