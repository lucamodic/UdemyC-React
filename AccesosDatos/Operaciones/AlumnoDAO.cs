using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDatos.Context;
using AccesosDatos.Models;

namespace AccesosDatos.Operaciones;

public class AlumnoDAO
{
    public ProyectoContext contexto = new ProyectoContext();

    public List<Alumno> seleccionarTodos()
    {
        var alumnos = contexto.Alumnos.ToList();
        return alumnos;
    }
    public Alumno seleccionar(int id)
    {
        var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();
        return alumno;
    }

    public bool insertar(string dni, string nombre, string direccion, int edad, string email)
    {
        Alumno alumno = new Alumno
        {
            Dni = dni,
            Nombre = nombre,
            Direccion = direccion,
            Edad = edad,
            Email = email
        };
        contexto.Alumnos.Add(alumno);
        contexto.SaveChanges();
        return true;
    }
    public bool actualizar(int id, string dni, string nombre, string direccion, int edad, string email)
    {
        var alumno = seleccionar(id);
        if (alumno != null)
        {
            alumno.Dni = dni;
            alumno.Nombre = nombre;
            alumno.Direccion = direccion;
            alumno.Edad = edad;
            alumno.Email = email;
            contexto.SaveChanges();
            return true;
        }
        return false;
    }

    public bool eliminar(int id)
    {
        var alumno = seleccionar(id);
        if (alumno != null)
        {
            contexto.Alumnos.Remove(alumno);
            contexto.SaveChanges();
            return true;
        }
        return false;
    }

    public List<AlumnosAsignatura> seleccionarAlumnosAsignaturas()
    {
        var query = from a in contexto.Alumnos
                    join m in contexto.Matriculas on a.Id equals m.AlumnoId
                    join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                    select new AlumnosAsignatura
                    {
                        NombreAlumno = a.Nombre,
                        NombreAsignatura = asig.Nombre
                    };
        return query.ToList();
    }
}