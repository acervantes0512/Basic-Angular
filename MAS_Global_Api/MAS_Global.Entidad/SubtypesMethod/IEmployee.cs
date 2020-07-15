using JsonSubTypes;
using Newtonsoft.Json;

namespace MAS_Global.Entidad
{
    [JsonConverter(typeof(JsonSubtypes), "contractTypeName")]
    [JsonSubtypes.KnownSubType(typeof(EmployeeMonth), "MonthlySalaryEmployee")]
    [JsonSubtypes.KnownSubType(typeof(EmployeeHourly), "HourlySalaryEmployee")]
    public interface IEmployee
    {
        string id { get; set; }
        string contractTypeName { get; set; }

        double anualSalary { get; }

    }
}