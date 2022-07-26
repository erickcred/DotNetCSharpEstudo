﻿using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Introducao
{
    public class Program
    {
        const string connectionString = 
        @"Data Source=localhost\SQLEXPRESS;Database=Course;TrustServerCertificate=true;User ID=sa;Password=123";
        // @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Course;Integrated Security=SSPI;TrustServerCertificate=true";

        public static void Main(string[] args)
        {
            // using (SqlConnection connection = new SqlConnection(connectionString))
            // {
            //     connection.Open();
            //     Console.WriteLine("Conectado ao banco de dados.");

            //     using (SqlCommand cmd = new SqlCommand())
            //     {
            //         cmd.Connection = connection;
            //         cmd.CommandType = CommandType.Text;
            //         cmd.CommandText = "SELECT [Id], [Title] FROM [Category]";
                    
            //         SqlDataReader reader = cmd.ExecuteReader();

            //         while (reader.Read())
            //         {
            //             Console.WriteLine($"Id: {reader.GetGuid(0)} - {reader.GetString(1)}");
            //         }
            //     }            
            // }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Category]"))
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var cat = new Category();
                        cat.Id = reader.GetGuid(0);
                        cat.Title = reader.GetString(1);
                        cat.Url = reader.GetString(2);
                        
                        Console.WriteLine($"Id: {cat.Id} - {cat.Title} | url: {cat.Url}");
                    }                    
                }            
            }
        }
    }
}