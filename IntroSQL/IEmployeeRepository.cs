using System;
using System.Collections.Generic;

namespace IntroSQL
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
