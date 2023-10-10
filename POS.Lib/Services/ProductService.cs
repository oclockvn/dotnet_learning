using Dapper;
using Microsoft.Data.SqlClient;
using POS.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Lib.Services
{
    public class ProductService
    {
        public List<Product> GetProductList()
        {
            var connection = GetConnection();
            var sql = """
                SELECT [ProductID] as Id, [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]
                FROM [Products]
                """;
            var products = connection.Query<Product>(sql).ToList();

            return products;
        }

        private SqlConnection GetConnection()
        {
            var connectionString = "Server=localhost;Database=northwind;User Id=sa; Password=Admin@123456;MultipleActiveResultSets=true;TrustServerCertificate=True";
            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
