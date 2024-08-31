using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDatos.Models;

namespace AccesosDatos.Interfaces;

public interface IAlumnoDAO
{
    List<Alumno> seleccionarTodos();
    Alumno seleccionar(int id);
    bool insertar(string dni, string nombre, string direccion, int edad, string email);
    bool actualizar(int id, string dni, string nombre, string direccion, int edad, string email);
    bool eliminar(int id);
    List<AlumnosAsignatura> seleccionarAlumnosAsignaturas();
    List<AlumnoProfesor> seleccionarAlumnosProfesor(string usuario);
    Alumno seleccionarPorDni(string dni);
    bool insertarYMatricular(string dni, string nombre, string direccion, int edad, string email, int idAsig);
    bool eliminarAlumno(int id);
}

