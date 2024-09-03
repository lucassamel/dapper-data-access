using System;
using Dapper;
using dapper_data_access.Models;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        
        

        using ( var connection = new SqlConnection(connectionString))
        {
            UpdateCategory(connection);

            ListCategories(connection);

            //CreateCategory(connection);           
            
        }

        Console.ReadKey();
    }

    static void ListCategories(SqlConnection connection)
    {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
        foreach (var item in categories)
        {
            Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }

    static void CreateCategory(SqlConnection connection)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Title = "Amazon AWS",
            Url = "amazon",
            Description = "Categoria destinada a serviços AWS",
            Order = 8,
            Summary = "AWS Cloud",
            Featured = false
        };

        var insertSql = @"INSERT INTO
            [Category]
        VALUES(
            @Id,
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured)";

        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        });

        Console.WriteLine($"{rows} linhas inseridas ");
    }

    static void UpdateCategory(SqlConnection connection)
    {
        var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";

        var rows = connection.Execute(updateQuery, new
        {
            id = new Guid("bd9eb6e2-7cad-4eae-8e4c-d75bdbfd1498"),
            title = "Dapper 2024"
        });

        Console.WriteLine($"{rows} registros atualizadas");
    }
}


