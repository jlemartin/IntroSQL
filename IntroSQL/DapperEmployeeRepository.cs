using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IntroSQL
{
    public class DapperEmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _connection;

        public DapperEmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _connection.Query<Employee>("SELECT * FROM employees;").ToList();
        }
    }
}
