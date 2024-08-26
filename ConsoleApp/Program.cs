// See https://aka.ms/new-console-template for more information

using AccesosDatos.Models;
using AccesosDatos.Operaciones;



AlumnoDAO opAlumno = new AlumnoDAO();

// opAlumno.insertar("424242", "Jose Antonio Ruiz", "Calle Paraguay 6", 20, "jaruiz@gmail.com");

// opAlumno.actualizar(11, "424242", "Jose Pablo Ruiz", "Calle Argentina 6", 20, "joseruiz@gmail.com");

opAlumno.eliminar(11);

var alumnos = opAlumno.seleccionarTodos();


foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre);
}

Console.WriteLine("######################");
var alumno1 = opAlumno.seleccionar(1);
if (alumno1 != null) Console.WriteLine(alumno1.Nombre);

Console.WriteLine("######################");

var alumnosas = opAlumno.seleccionarAlumnosAsignaturas();
foreach (var alumno in alumnosas)
{
    Console.WriteLine(alumno.NombreAlumno + " ---> " + alumno.NombreAsignatura);
}
