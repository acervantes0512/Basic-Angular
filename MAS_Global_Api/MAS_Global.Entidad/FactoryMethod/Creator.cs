using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Global.Entidad.FactoryMethod
{
    public class Creator
    {
        public const string EMPLOYEE_HOURLY = "HourlySalaryEmployee";
        public const string EMPLOYEE_MONTH = "MonthlySalaryEmployee";

        /// <summary>
        /// Médodo de creación, crea la instancia dependiendo de la propiedad contractTypeName
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        public static  EmployeeF CreatorEmployee(dynamic jsonObj)
        {
            switch (Convert.ToString(jsonObj.contractTypeName))
            {
                case EMPLOYEE_HOURLY:
                    string js = Convert.ToString(jsonObj);
                    return JsonConvert.DeserializeObject<EmployeeHourlyF>(Convert.ToString(jsonObj));                    
                case EMPLOYEE_MONTH:
                    return JsonConvert.DeserializeObject<EmployeeMonthF>(Convert.ToString(jsonObj));                    
                default: return null;
            }
        }
    }
}
