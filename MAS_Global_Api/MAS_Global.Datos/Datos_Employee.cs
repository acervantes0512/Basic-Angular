using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MAS_Global.Datos
{
    public class Datos_Employee : IDatos_Employee
    {

        public string getEmployees()
        {
            WebRequest oRequest = WebRequest.Create("http://masglobaltestapi.azurewebsites.net/api/Employees");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            string nstring = (sr.ReadToEnd().Trim()).Replace(@"\", "");
            return nstring;
        }



    }
}
