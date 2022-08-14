using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using IniciandoDapper.Models;
using Microsoft.Data.SqlClient;

namespace IniciandoDapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = 
            // @"Data Source=localhost\SQLEXPRESS;Database=Course;TrustServerCertificate=True;User ID=sa;Password=123";
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Course;Integrated Security=SSPI;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Console.Clear();

                // ListCategories(conn);
                // InsertCategory(conn);
                // CreateManyCategory(conn);
                // UpdateCategory(conn);
                // DeleteCategory(conn);
                // DeleteProcedureStudent(conn);
                // ListCourseByCategory(conn);
                // CreateScalarCategory(conn);
                // ListCategories(conn);
                // ListViewCategory(conn);
                // ListOneToOneCareerItemCourse(conn);
                // ListOneToManyCareerItemCareer(conn);
                // ListManyToMany(conn);
                // SelectIn(conn);
                // Like(conn, "net");
                Transaction(conn);
                ListCategories(conn);
            }
            
        }

        static void ListCategories(SqlConnection connection)
        {
            IEnumerable<Category> categories = connection.Query<Category>("SELECT * FROM [Category] ORDER BY [Order]");

            foreach (Category item in categories)
                Console.WriteLine($"{item.Id} - {item.Title} - {item.Order}");
        }

        static void UpdateCategory(SqlConnection connection)
        {

            const string updateSql = @"
                UPDATE
                    [Category]
                SET
                    [Title] = @Title
                WHERE
                    [Id] = @Id";

            int rows = connection.Execute(updateSql, new {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2022"
            });

            if (rows > 0)
                Console.WriteLine($"Registros atualizados {rows}");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            int rows = connection.Execute("DELETE FROM [Category] WHERE Id=@Id", new {
                Id = new Guid("b2ef57ee-2d5f-48b3-baee-05d74df54eac")
            });

            if (rows > 0)
                Console.WriteLine($"Registros deletados {rows}");
        }

        // Execute Many
        static void CreateManyCategory(SqlConnection connection)
        {
            const string createSql = @"
                INSERT INTO
                    [Category]
                VALUES
                    (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

                Category category1 = new Category();
                category1.Id = Guid.NewGuid();
                category1.Title = "AWS Na Pratica";
                category1.Url = "aws-na-pratica";
                category1.Summary = "Aplicando AWS na pratica";
                category1.Order = 9;
                category1.Description = "Iniciando pratica com AWS";
                category1.Featured = false;

                Category category2 = new Category();
                category2.Id = Guid.NewGuid();
                category2.Title = "Fullstak C#";
                category2.Url = "fullstakcsharp";
                category2.Summary = "fullstakcsharp";
                category2.Order = 10;
                category2.Description = "Iniciando para ser um FullStak C#";
                category2.Featured = false;

                int rows = connection.Execute(createSql, new[] {
                    new
                    {
                        category1.Id,
                        category1.Title,
                        category1.Url,
                        category1.Summary,
                        category1.Order,
                        category1.Description,
                        category1.Featured
                    },
                    new
                    {
                        category2.Id,
                        category2.Title,
                        category2.Url,
                        category2.Summary,
                        category2.Order,
                        category2.Description,
                        category2.Featured
                    }
                });
                if (rows > 0)
                    Console.WriteLine($"Registros criados {rows}");                
        }

        static void DeleteProcedureStudent(SqlConnection connection)
        {
            var procedure = "spDeleteStudent";
            var studentParams = new { StudentId = "cc8cf1b7-7671-4595-a519-610e2a74b167" };

            int rows = connection.Execute(procedure, studentParams, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"Registros deletados: {rows}");
        }
    
        static void ListCourseByCategory(SqlConnection connection)
        {
            Console.Clear();

            string procedure = "[spGetCourseByCategory]";

            var categoryParams = new { @CategoryId = "af3407aa-11ae-4621-a2ef-2028b85507c4" };

            // Posso fazer como Dinamic
            var courses = connection.Query(procedure, categoryParams, commandType: CommandType.StoredProcedure);
            foreach(var item in courses)
            {
                Console.WriteLine($"CourseId: {item.Id} - {item.Title} |-> CategpryId: {item.CategoryId}");
            }

            // Ou Tipada
            // var courses = connection.Query<Course>(procedure, categoryParams, commandType: CommandType.StoredProcedure);
            // foreach(Course item in courses)
            // {
            //     Console.WriteLine($"{item.Id} - {item.Title}");
            // }
        }

        static void CreateScalarCategory(SqlConnection connection)
        {
            Category category = new Category();
            category.Title = "Nova Categoria";
            category.Url = "url-nova-categoria";
            category.Summary = "sumario para nova categoria";
            category.Order = 11;
            category.Description = "descrição para a nova categoria";
            category.Featured = false;

            string insertSql = @"
                INSERT INTO
                    [Category]
                    OUTPUT INSERTED.[Id]
                VALUES
                    (NEWID(), @Title, @Url, @Summary, @Order, @Description, @FEatured)";

            Guid id = connection.ExecuteScalar<Guid>(insertSql, new {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"Acategoria insetida: {id}");
        }
    
        static void ListViewCategory(SqlConnection connection)
        {
            string sqlView = "SELECT * FROM [vwListCategories]";

            var categories = connection.Query<Category>(sqlView);

            foreach (Category item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        /* One To One */
        static void ListOneToOneCareerItemCourse(SqlConnection connection)
        {
            string sql = @"
                SELECT
                    *
                FROM 
                    [CareerItem]
                    INNER JOIN [Course] ON [Course].[Id] = [CareerItem].[CourseId]";
            
            var careerItems = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) => {
                    careerItem.Course = course;
                    return careerItem;
            }, splitOn: "Id");

            foreach (CareerItem item in careerItems)
            {
                Console.WriteLine($"{item.Title} |-> {item.Course.Title}");
            }
        }

        /* On To Many */
        static void ListOneToManyCareerItemCareer(SqlConnection connection)
        {
            string sql = @"
                SELECT
                    *
                FROM
                    [Career]
                    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY
                    [Career].[Title]";

            var careers = new List<Career>();

            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) => {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car != null)
                    { // se car(career) já estiver na lista somente adicionamos o item
                        car.CareerItems.Add(item);
                    } else
                    { // se a career não exitir na lisra de careers 
                        car = career; // car vai ser igual a career
                        car.CareerItems.Add(item); // inserimos o item dentro de car(career)
                        careers.Add(car); // e adicionamos car(career) na lista de careers.
                    }
                    
                    return career;
                }, splitOn: "CareerId");

            foreach (Career career in careers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-- {career.Title} -- ");
                foreach (CareerItem item in career.CareerItems)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{item.Title}");
                }
                Console.WriteLine();
            }
        }

        // Query Multiple
        static void ListManyToMany(SqlConnection connection)
        {
            string sql = @"
                SELECT
                    *
                FROM
                    [Category];
                    SELECT
                        *
                    FROM
                        [Course]";

            var listCategories = new List<Category>();

            using (var multi = connection.QueryMultiple(sql))
            {
                IEnumerable<Category> categories = multi.Read<Category>();
                IEnumerable<Course> courses = multi.Read<Course>();


                foreach (var category in categories)
                {
                    foreach (var course in courses)
                    {
                        if (category.Id == course.CategoryId)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{category.Title} | -");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($" {course.Title}");
                        }
                    }
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            string sql = @"
                SELECT
                    *
                FROM
                    [Career]
                WHERE
                    [Id] IN @Id";

            var careerParams = new { Id = new[] {"01ae8a85-b4e8-4194-a0f1-1c6190af54cb", "e6730d1c-6870-4df3-ae68-438624e04c72"} };
            IEnumerable<Career> careers = connection.Query<Career>(sql, careerParams);

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Id} - {career.Title}");
            }
        }

        static void Like(SqlConnection connection, string textParam)
        {
            string sql = @"
                SELECT
                    *
                FROM
                    [Career]
                    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                WHERE
                    [Career].[Title] LIKE @Title";
            
            var courseParams = new { Title = $"%{textParam}%" };

            var careers = new List<Career>();
            connection.Query<Career, CareerItem, Career>(
                sql, 
                (career, item) => {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car != null)
                    {
                        car.CareerItems.Add(item);
                    } else
                    {
                        car = career;
                        car.CareerItems.Add(item);
                        careers.Add(car);
                    }

                    return career;
                }
                ,courseParams,
                splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.CareerItems)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{item.Title}");
                }
            }
        }

        // Transaction
        static void Transaction(SqlConnection connection)
        {
            string sql = @"
                INSERT INTO
                    [Category]
                VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Inserindo via Trnasaction";
            category.Url = "transaction";
            category.Summary = "Summary Transaction";
            category.Order = 0;
            category.Description = "Description Transaction";
            category.Featured = false;

            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                int rows = connection.Execute(sql, new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                }, transaction);

                // transaction.Commit();
                transaction.Rollback();

                Console.WriteLine($"Itens inseridos {rows}");
            }
        }


    }
}