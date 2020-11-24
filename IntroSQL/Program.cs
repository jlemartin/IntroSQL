using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace IntroSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Creating connection string using info from appsettings.json file
            string connString = config.GetConnectionString("DefaultConnection");

            // Using that string to make connection to database
            IDbConnection conn = new MySqlConnection(connString);

            var deptRepo = new DapperDepartmentRepository(conn);

            //Console.WriteLine("Type a new Department name");

            //var newDepartment = Console.ReadLine();

            //deptRepo.InsertDepartment(newDepartment);

            var departments = deptRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} : {dept.Name}");
            }
            Console.WriteLine();

            // Creating new Product Repository
            var prodRepo = new DapperProductRepository(conn);

            // Bringing in all Products from database
            var allProducts = prodRepo.GetAllProducts();

            // take a look
            //foreach (var prod in allProducts)
            //{
            //    Console.WriteLine($"{prod.ProductID} : {prod.Name} : {prod.Price} : {prod.CategoryID} : {prod.OnSale} : {prod.StockLevel}");
            //}

            // Adding a new item in the Products table
            //prodRepo.CreateProduct("MacBook Air", 1000.00, 1);

            //foreach (var prod in allProducts)
            //{
            //    Console.WriteLine($"{prod.ProductID} : {prod.Name} : {prod.Price} : {prod.CategoryID} : {prod.OnSale} : {prod.StockLevel}");
            //}

            //prodRepo.UpdateStockLevel(940, "100");

            prodRepo.DeleteProduct(941);
        }
    }
}
