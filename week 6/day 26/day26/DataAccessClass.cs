using Microsoft.Data.SqlClient;
using System.Data;

public class ProductData
{
    private readonly string connectionString;

    public ProductData(string conn)
    {
        connectionString = conn;
    }

    public void InsertProduct(Product product)
    {
        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
        cmd.Parameters.AddWithValue("@Category", product.Category);
        cmd.Parameters.AddWithValue("@Price", product.Price);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void GetAllProducts()
    {
        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["ProductId"]} - {reader["ProductName"]} - {reader["Category"]} - {reader["Price"]}");
        }
    }

    public void GetProductById(int id)
{
    using SqlConnection conn = new SqlConnection(connectionString);
    using SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);

    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@ProductId", id);

    conn.Open();

    using SqlDataReader reader = cmd.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine("Product Found:");
        Console.WriteLine($"ID: {reader["ProductId"]}");
        Console.WriteLine($"Name: {reader["ProductName"]}");
        Console.WriteLine($"Category: {reader["Category"]}");
        Console.WriteLine($"Price: {reader["Price"]}");
    }
    else
    {
        Console.WriteLine("Product not found!");
    }
}

    public void UpdateProduct(Product product)
    {
        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
        cmd.Parameters.AddWithValue("@Category", product.Category);
        cmd.Parameters.AddWithValue("@Price", product.Price);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteProduct(int id)
    {
        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ProductId", id);

        conn.Open();
        cmd.ExecuteNonQuery();
    }
}