using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Global.Entidad
{
    public class EmployeeHourly : Employee, IEmployee
    {

        public double anualSalary { get { return 120 * this.hourlySalary * 12; } }

    }
}
