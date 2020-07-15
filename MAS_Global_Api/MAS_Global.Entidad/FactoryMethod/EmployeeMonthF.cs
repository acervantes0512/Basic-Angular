using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Global.Entidad.FactoryMethod
{
    class EmployeeMonthF:EmployeeF
    {
        public double anualSalary { get { return this.monthlySalary * 12; } }
    }
}
