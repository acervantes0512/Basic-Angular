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
    /// Clase que utiliza el patrón Factory Method para la creación de los objetos.
    /// </summary>
    public class Control_Factory
    {
        Util_Employee util = new Util_Employee();
        List<EmployeeF> _listEmpF = new List<EmployeeF>();
        private IDatos_Employee datosRepo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Control_Factory()
            : this(new Datos_Employee())
        {
            Console.WriteLine("Control_Factory1");
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Control_Factory(IDatos_Employee datosRepo)
        {
            Console.WriteLine("Control_Factory2");
            this.datosRepo = datosRepo;
            this.CreateObjects();
        }

        /// <summary>
        /// Método encargado de crear los objetos haciendo uso del Factory Method
        /// </summary>
        private void CreateObjects()
        {
            Console.WriteLine("Entra CreateObjects");
            string jsonRta = this.datosRepo.getEmployees();

            Console.WriteLine("jsonrta:" + jsonRta);

            if (!jsonRta.Equals(String.Empty))
            {

                dynamic dynJson = JsonConvert.DeserializeObject(jsonRta);
                foreach (var item in dynJson)
                {
                    EmployeeF nEmp = Creator.CreatorEmployee(item);

                    if (nEmp != null)
                    {
                        this._listEmpF.Add(Creator.CreatorEmployee(item));
                    }
                }

                Console.WriteLine("count:"+this._listEmpF.Count);
            }


        }

        /// <summary>
        /// Obtiene el json con todos los Employees instanciados
        /// </summary>
        /// <returns></returns>
        public string getAllEmployees()
        {            
            return util.ListToJson(this._listEmpF);            
        }

        /// <summary>
        /// Consulta un empleado específico dado el Id
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <returns></returns>
        public string getEmployee(string idEmployee)
        {
            string listaResult = String.Empty;

            List<EmployeeF> emp = this._listEmpF.FindAll(e => e.id.Contains(idEmployee));

            listaResult = (emp != null) ? util.ListToJson(emp) : String.Empty;

            return listaResult;
        }


    }

}
