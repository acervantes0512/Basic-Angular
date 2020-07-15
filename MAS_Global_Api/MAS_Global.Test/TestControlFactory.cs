using System;
using MAS_Global.Control;
using MAS_Global.Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MAS_Global.Test
{
    [TestClass]
    public class TestControlFactory
    {

        private Mock<IDatos_Employee> DataRepositoryMock = null;
        private Control_Factory controller = null;

        /// <summary>
        /// Prueba cuando no existen empleados en el repositorio
        /// </summary>
        [TestMethod]
        public void getAllEmployees_Vacío()
        {
            this.DataRepositoryMock = new Mock<IDatos_Employee>();
            this.DataRepositoryMock.Setup(gd => gd.getEmployees()).Returns("");
            this.controller = new Control_Factory(this.DataRepositoryMock.Object);

            string result = this.controller.getAllEmployees();

            Assert.AreEqual(result, "[]");
        }

        /// <summary>
        /// Prueba unitaria cuando existe solo un empleado en el repositorio
        /// </summary>
        [TestMethod]
        public void getAllEmployees_one_Employee()
        {
            this.DataRepositoryMock = new Mock<IDatos_Employee>();
            this.DataRepositoryMock.Setup(gd => gd.getEmployees()).Returns("[{\"id\": 1,\"name\": \"Juan\",\"contractTypeName\": \"HourlySalaryEmployee\",\"roleId\": 1,\"roleName\": \"Administrator\",\"roleDescription\": null,\"hourlySalary\": 60000,\"monthlySalary\": 80000}]");
            this.controller = new Control_Factory(this.DataRepositoryMock.Object);

            string result = this.controller.getAllEmployees();

            Console.WriteLine("Resultado:"+result);

            Assert.AreEqual(result, "[  {    \"anualSalary\": 86400000.0,    \"id\": \"1\",    \"name\": \"Juan\",    \"contractTypeName\": \"HourlySalaryEmployee\",    \"roleId\": 1,    \"roleName\": \"Administrator\",    \"roleDescription\": null,    \"hourlySalary\": 60000.0,    \"monthlySalary\": 80000.0  }]");
        }

        /// <summary>
        /// Ejecuta prueba cuando no existe el tipo de contrato
        /// </summary>
        [TestMethod]
        public void getAllEmployees_no_existe_tipoContrato()
        {
            this.DataRepositoryMock = new Mock<IDatos_Employee>();
            this.DataRepositoryMock.Setup(gd => gd.getEmployees()).Returns("[{\"id\": 1,\"name\": \"Juan\",\"contractTypeName\": \"Hourly\",\"roleId\": 1,\"roleName\": \"Administrator\",\"roleDescription\": null,\"hourlySalary\": 60000,\"monthlySalary\": 80000}]");
            this.controller = new Control_Factory(this.DataRepositoryMock.Object);

            string result = this.controller.getAllEmployees();

            Console.WriteLine("Resultado:" + result);

            Assert.AreEqual(result, "[]");
        }
    }
}
