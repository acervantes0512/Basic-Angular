using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MAS_Global.Util
{
    public class Util_Employee
    {

        public String ListToJson(Object list)
        {
            var json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
            return json.Trim().Replace("\r", "").Replace("\n", "");
        }

    }
}
