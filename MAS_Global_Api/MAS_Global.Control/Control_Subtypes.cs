using MAS_Global.Entidad;
using MAS_Global.Datos;
using MAS_Global.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAS_Global.Entidad.FactoryMethod;

namespace MAS_Global.Control
{
    /// <summary>
    /// Esta clase contiene la lógica de creación de objetos usando subtypes de JSON,
    /// es decir al realizar la deserialización automáticamente retornará la instalancia del objeto
    /// hijo al cual corresponde dependiendo del contractTypeName.
    /// </summary>
    public class Control_Subtypes
    {
        Util_Employee util = new Util_Employee();
        Employees _listEmp = null;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Control_Subtypes()
        {
            this.createEmployees();
        }

        /// <summary>
        /// Método encargado de crear las instancias
        /// </summary>
        private void createEmployees()
        {
            if (this._listEmp == null)
            {
                _listEmp = new Employees();
                Datos_Employee DataObject = new Datos_Employee();
                string jsonRta = DataObject.getEmployees();
                _listEmp.listEmployees = JsonConvert.DeserializeObject<List<IEmployee>>(jsonRta);
            }
        }

        /// <summary>
        /// Obtiene todos los objetos Employees instanciados
        /// </summary>
        /// <returns></returns>
        public string getAllEmployees()
        {
            string listaResult = String.Empty;
            listaResult = util.ListToJson(_listEmp.listEmployees);
            return listaResult;
        }

        /// <summary>
        /// Consulta un empleado específico dado el Id
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <returns></returns>
        public string getEmployee(string idEmployee)
        {
            string listaResult = String.Empty;
            List<IEmployee> emp =_listEmp.listEmployees.FindAll(e => e.id.Contains(idEmployee));
            listaResult = (emp != null) ? util.ListToJson(emp) : String.Empty;
            return listaResult;
        }


    }

}
