using Dapper;
using Microsoft.Data.SqlClient;
using POS.Lib.Models;

namespace POS.Lib.Services
{
    public class ProductService
    {
        public List<Product> GetProductList(string? keyword = null)
        {
            var connection = GetConnection();
            var sql = """
                SELECT p.[ProductID] as Id, p.[ProductName], p.[SupplierID], p.[CategoryID], p.[QuantityPerUnit], p.[UnitPrice], p.[UnitsInStock], p.[UnitsOnOrder], p.[ReorderLevel], p.[Discontinued],
                c.CategoryName, s.CompanyName as SupplierName
                FROM [Products] as p
                join [Categories] as c on c.CategoryID = p.CategoryID
                join [Suppliers] as s on s.SupplierID = p.SupplierID
                """;

            var parameter = new
            {
                keyword = keyword,
            };

            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " where p.ProductName like @keyword";
            }

            var products = connection.Query<Product>(sql, parameter).ToList();

            return products;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost;Database=northwind;User Id=sa; Password=Admin@123456;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}
