using System;
using Microsoft.Data.SqlClient;
using MaoNaMassa.Repositories;
using MaoNaMassa.Models;

namespace MaoNaMassa
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                ReadUsers(connection);
                CreateUserWithRoles(connection);
                ReadUsers(connection);
                // CreateUser(connection);
                // ReadRoles(connection);
                // ReadRole(connection);
                // CreateRole(connection);
                // ReadRoles(connection);
                // UpdateRole(connection);
                // ReadRoles(connection);
                // CreateTag(connection);
                // ReadTags(connection);
            }          
        }

        public static void ReadRoles(SqlConnection connection)
        {
            Console.Clear();
            // Repository<Role> roles = new Repository<Role>(connection);
            foreach (Role item in new Repository<Role>(connection).GetAll())
                Console.WriteLine($"{item.Id}: {item.Name}, {item.Slug}");
        }

        public static void ReadRole(SqlConnection connection)
        {
            Console.Clear();
            Console.WriteLine("Enter from Id for search: ");
            int id = int.Parse(Console.ReadLine());

            Role role = new Repository<Role>(connection).Get(id);
            Console.WriteLine($"{role.Id}: {role.Name}, {role.Slug}");
        }

        public static void CreateRole(SqlConnection connection)
        {
            Console.Clear();
            Role role = new Role();

            Console.WriteLine("Insert Role: ");
            Console.Write("Name: ");
            role.Name = Console.ReadLine();
            Console.Write("Slug: ");
            role.Slug = Console.ReadLine();

            Repository<Role> create = new Repository<Role>(connection);
            create.Create(role);
        }

        public static void UpdateRole(SqlConnection connection)
        {
            Console.Write("Insert Id for Update: ");
            int id = int.Parse(Console.ReadLine());
            Role role = new Repository<Role>(connection).Get(id);

            // Role role = new Role();
            Console.Write($"Name: ({role.Name}) = ");
            role.Name = Console.ReadLine();
            Console.Write($"Slug: ({role.Slug}) = ");
            role.Slug = Console.ReadLine();

            new Repository<Role>(connection).Update(role);
        }

        public static void ReadTags(SqlConnection connection)
        {
            foreach (Tag tag in new Repository<Tag>(connection).GetAll())
                Console.WriteLine($"{tag.Id}: {tag.Name}, {tag.Slug}");
        }

        public static void CreateTag(SqlConnection connection)
        {
            Tag tag = new Tag();

            Console.WriteLine("Create Tag: ");
            Console.Write("Name: ");
            tag.Name = Console.ReadLine();
            Console.Write("Slug: ");
            tag.Slug = Console.ReadLine();

            new Repository<Tag>(connection).Create(tag);
        }

        public static void ReadUsers(SqlConnection connection)
        {
            foreach (User user in new UserRepository(connection).GetWithRolesAll())
            {
                Console.WriteLine($"{user.Id}: {user.Name}");
                foreach (var role in user.Roles)
                {
                    Console.Write($", {role.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            User user = new User();
            Console.Write("Name: ");
            user.Name = Console.ReadLine();
            Console.Write("Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Bio: ");
            user.Bio = Console.ReadLine();
            Console.Write("Image: ");
            user.Image = Console.ReadLine();
            Console.Write("Slug: ");
            user.Slug = Console.ReadLine();

            new Repository<User>(connection).Create(user);
        }

        public static void CreateUserWithRoles(SqlConnection connection)
        {
            User user = new User();
            Console.Write("Name: ");
            user.Name = Console.ReadLine();
            Console.Write("Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Bio: ");
            user.Bio = Console.ReadLine();
            Console.Write("Image: ");
            user.Image = Console.ReadLine();
            Console.Write("Slug: ");
            user.Slug = Console.ReadLine();

            Console.WriteLine("Select the Role for User");
            foreach (var role in new Repository<Role>(connection).GetAll())
            {
                Console.WriteLine($"{role.Id}: {role.Name}");
            }
            // int id = int.Parse(Console.ReadLine());

            new UserRepository(connection).CreateWithRoles(user, 1);
        }
        
    }
}