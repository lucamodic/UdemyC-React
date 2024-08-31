using Xunit;
using Moq;
using WebApi.Controllers;
using AccesosDatos.Models;
using AccesosDatos.Interfaces;
using System.Collections.Generic;

public class AlumnoControllerTests
{
    [Fact]
    public void GetAlumno_ReturnsAlumno()
    {
        // Arrange
        var mockAlumnoDAO = new Mock<IAlumnoDAO>();
        mockAlumnoDAO.Setup(dao => dao.seleccionar(1))
            .Returns(new Alumno { Id = 1, Nombre = "Juan" });

        var controller = new AlumnoController(mockAlumnoDAO.Object);

        // Act
        var result = controller.getAlumno(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Juan", result.Nombre);
    }

    [Fact]
    public void ActualizarAlumno_ReturnsTrue()
    {
        // Arrange
        var alumno = new Alumno
        {
            Id = 1,
            Dni = "12345678",
            Nombre = "Juan",
            Direccion = "Calle Falsa 123",
            Edad = 20,
            Email = "juan@mail.com"
        };
        var mockAlumnoDAO = new Mock<IAlumnoDAO>();
        mockAlumnoDAO.Setup(dao => dao.actualizar(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email))
            .Returns(true);

        var controller = new AlumnoController(mockAlumnoDAO.Object);

        // Act
        var result = controller.acutalizarAlumno(alumno);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void InsertarMatricular_ReturnsTrue()
    {
        // Arrange
        var alumno = new Alumno
        {
            Id = 1,
            Dni = "12345678",
            Nombre = "Juan",
            Direccion = "Calle Falsa 123",
            Edad = 20,
            Email = "juan@mail.com"
        };
        var mockAlumnoDAO = new Mock<IAlumnoDAO>();
        mockAlumnoDAO.Setup(dao => dao.insertarYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, 1))
            .Returns(true);

        var controller = new AlumnoController(mockAlumnoDAO.Object);

        // Act
        var result = controller.insertarMatricular(alumno, 1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EliminarAlumno_ReturnsTrue()
    {
        // Arrange
        var mockAlumnoDAO = new Mock<IAlumnoDAO>();
        mockAlumnoDAO.Setup(dao => dao.eliminarAlumno(1)).Returns(true);

        var controller = new AlumnoController(mockAlumnoDAO.Object);

        // Act
        var result = controller.eliminarAlumno(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AlumnosProfesor_ReturnsListOfAlumnoProfesor()
    {
        // Arrange
        var expectedList = new List<AlumnoProfesor>
        {
            new AlumnoProfesor
            {
                Id = 1,
                Dni = "12345678",
                Nombre = "Juan",
                Direccion = "Calle Falsa 123",
                Edad = 20,
                Email = "juan@mail.com",
                Asignatura = "Mathematics"
            }
        };
        var mockAlumnoDAO = new Mock<IAlumnoDAO>();
        mockAlumnoDAO.Setup(dao => dao.seleccionarAlumnosProfesor("profesor1"))
            .Returns(expectedList);

        var controller = new AlumnoController(mockAlumnoDAO.Object);

        // Act
        var result = controller.alumnosProfesor("profesor1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedList.Count, result.Count);
        Assert.Equal(expectedList[0].Nombre, result[0].Nombre);
        Assert.Equal(expectedList[0].Asignatura, result[0].Asignatura);
    }
}
