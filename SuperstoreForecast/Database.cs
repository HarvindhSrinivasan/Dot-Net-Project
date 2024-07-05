using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

public class Database
{
    private readonly string connectionString;

    public Database(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public IEnumerable<dynamic> GetSalesData(int year)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT Orders.State, SUM(Products.Sales - Products.Returns) as TotalSales
                FROM Orders
                JOIN Products ON Orders.ProductId = Products.Id
                WHERE YEAR(Orders.OrderDate) = @Year
                GROUP BY Orders.State";
                
            return connection.Query(query, new { Year = year });
        }
    }
}