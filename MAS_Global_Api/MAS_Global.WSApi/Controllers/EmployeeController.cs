using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System;
using System.Dynamic;
using MAS_Global.Control;


namespace MAS_Global.WSApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Employees")]
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [Route("getAllEmployees")]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult getAllEmployees()
        {
            try
            {
                Control_Employee control = new Control_Employee();
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

    }
}