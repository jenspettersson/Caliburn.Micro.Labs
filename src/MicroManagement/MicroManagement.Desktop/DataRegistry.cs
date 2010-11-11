using MicroManagement.Data;
using StructureMap.Configuration.DSL;

namespace MicroManagement.Desktop
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IEmployeeRepository>().Singleton().Use<FakeEmployeeRepository>();
        }
    }
}