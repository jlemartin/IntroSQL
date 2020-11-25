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

        public void AddEmployee(string FirstName, string MiddleInitial, string LastName, string Title)
        {
            _connection.Execute("INSERT INTO employees (FirstName, MiddleInitial, LastName, Title) " +
                "VALUES (@FirstName, @MiddleInitial, @LastName, @Title);",
                new { FirstName = FirstName, MiddleInitial = MiddleInitial, LastName = LastName, Title = Title });
        }

        public void UpdateEmail(int employeeID, string emailAddress)
        {
            _connection.Execute("UPDATE Employees SET EmailAddress = @emailAddress WHERE EmployeeID = @employeeID;",
                new { EmployeeID = employeeID, EmailAddress = emailAddress });
        }
    }
}
