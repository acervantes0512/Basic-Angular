using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System;
using System.Dynamic;
using MAS_Global.Control;

namespace MAS_Global.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Employees")]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Retorna la lista de todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllEmployees")]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult getAllEmployees()
        {
            try
            {
                //Control_Subtypes control = new Control_Subtypes(); // Habilitar si se desea instanciar por Subtypes del Json
                Control_Factory control = new Control_Factory(); // Habilitar si se desea instanciar usando el patrón Factory Method
                string ListEmployees = control.getAllEmployees();
                bool response = (ListEmployees != String.Empty) ? true : false;
                dynamic resp = new ExpandoObject();
                resp.message = (response) ?
                        "Lista de Empleados:" :
                        "No existen empleados";
                resp.Data = (response) ? ListEmployees : null;

                return Json(new
                {
                    status = (response) ? HttpStatusCode.OK : HttpStatusCode.NoContent,
                    data = resp
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = HttpStatusCode.NoContent,
                    data = new { message = ex.Message }
                });
            }
        }

        /// <summary>
        /// Retorna los empleados que coincidan con el id especificado
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getEmployee")]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult getEmployee(string idEmployee = null)
        {
            try
            {

                //Control_Subtypes control = new Control_Subtypes(); // Habilitar si se desea instanciar por Subtypes del Json
                Control_Factory control = new Control_Factory(); // Habilitar si se desea instanciar usando el patrón Factory Method
                string employee = control.getEmployee(idEmployee);
                bool response = (employee != "[]") ? true : false;
                dynamic resp = new ExpandoObject();
                resp.message = (response) ?
                        "Employee:" :
                        "No existe el empleado.";
                resp.Data = (response) ? employee : null;

                return Json(new
                {
                    status = (response) ? HttpStatusCode.OK : HttpStatusCode.NoContent,
                    data = resp
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = HttpStatusCode.NoContent,
                    data = new { message = ex.Message }
                });
            }
        }
        }
}