using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IntroSQL
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;").ToList();
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) " +
                "VALUES (@name, @price, @categoryID);",
                new { Name = name, Price = price, CategoryID = categoryID });
        }

        public void UpdateStockLevel(int productID, string stocklevel)
        {
            _connection.Execute("UPDATE Products SET StockLevel = @stocklevel WHERE ProductID = @productID;",
                new { ProductID = productID, StockLevel = stocklevel });
        }

        public void DeleteProduct(int productid)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productid;",
                new { ProductID = productid });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productid;",
                new { ProductID = productid });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productid;",
                new { ProductID = productid });
        }

        public IEnumerable<Product> GetComputers()
        {
            return _connection.Query<Product>("SELECT * FROM Products WHERE CategoryID = 1;").ToList();
        }

        public IEnumerable<Product> GetCategoryProducts(int categoryID)
        {
            return _connection.Query<Product>("SELECT * FROM Products WHERE CategoryID = @categoryID;",
                new { CategoryID = categoryID }).ToList();
        }

    }
}
