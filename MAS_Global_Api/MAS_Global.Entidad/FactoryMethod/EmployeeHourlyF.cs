using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Global.Entidad.FactoryMethod
{
    class EmployeeHourlyF:EmployeeF
    {
        public double anualSalary { get { return 120 * this.hourlySalary * 12; } }
    }
}
