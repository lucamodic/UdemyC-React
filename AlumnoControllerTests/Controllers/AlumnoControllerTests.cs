using Moq;
using System.Collections.Generic;
using Xunit;
using WebApi.Controllers;
using AccesosDatos.Operaciones;
using AccesosDatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Tests.Controllers
{
    public class AlumnoControllerTests
    {
        private readonly AlumnoController _controller;
        private readonly Mock<AlumnoDAO> _mockAlumnoDAO;

        public AlumnoControllerTests()
        {
            _mockAlumnoDAO = new Mock<AlumnoDAO>();
            _controller = new AlumnoController
            {
                alumnoDAO = _mockAlumnoDAO.Object
            };
        }

        [Fact]
        public void GetAlumno_ReturnsAlumno_WhenAlumnoExists()
        {
            // Arrange
            int alumnoId = 1;
            var expectedAlumno = new Alumno { Id = alumnoId, Nombre = "Juan" };
            _mockAlumnoDAO.Setup(dao => dao.seleccionar(alumnoId)).Returns(expectedAlumno);

            // Act
            var result = _controller.getAlumno(alumnoId);

            // Assert
            Assert.Equal(expectedAlumno, result);
        }

        [Fact]
        public void AlumnosProfesor_ReturnsListOfAlumnoProfesor()
        {
            // Arrange
            string profesor = "profesor1";
            var expectedAlumnosProfesor = new List<AlumnoProfesor>
            {
                new AlumnoProfesor { Id = 1, Nombre = "Juan", Asignatura = "Math" }
            };
            _mockAlumnoDAO.Setup(dao => dao.seleccionarAlumnosProfesor(profesor)).Returns(expectedAlumnosProfesor);

            // Act
            var result = _controller.alumnosProfesor(profesor);

            // Assert
            Assert.Equal(expectedAlumnosProfesor, result);

        }
        [Fact]
        public void ActualizarAlumno_ReturnsTrue_WhenUpdateIsSuccessful()
        {
            // Arrange
            var alumno = new Alumno { Id = 1, Nombre = "Juan", Dni = "12345678" };
            _mockAlumnoDAO.Setup(dao => dao.actualizar(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email)).Returns(true);

            // Act
            var result = _controller.acutalizarAlumno(alumno);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void InsertarMatricular_ReturnsTrue_WhenInsertAndEnrollIsSuccessful()
        {
            // Arrange
            var alumno = new Alumno { Nombre = "Juan", Dni = "12345678" };
            int idAsig = 1;
            _mockAlumnoDAO.Setup(dao => dao.insertarYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, idAsig)).Returns(true);

            // Act
            var result = _controller.insertarMatricular(alumno, idAsig);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EliminarAlumno_ReturnsTrue_WhenDeleteIsSuccessful()
        {
            // Arrange
            int alumnoId = 1;
            _mockAlumnoDAO.Setup(dao => dao.eliminarAlumno(alumnoId)).Returns(true);

            // Act
            var result = _controller.eliminarAlumno(alumnoId);

            // Assert
            Assert.True(result);
        }
    }
}
