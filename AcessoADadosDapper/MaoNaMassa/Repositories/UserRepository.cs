using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using MaoNaMassa.Models;

namespace MaoNaMassa.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetWithRolesAll()
        {
            List<User> users = new List<User>();

            string listSql = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";
            
            _connection.Query<User, Role, User>(
                listSql,
                (user, role) => 
                {
                    var us = users.FirstOrDefault(x => x.Id == user.Id);
                    if (us == null)
                    {
                        us = user;
                        if (role != null)
                            us.Roles.Add(role);
                        users.Add(us);
                    } else
                    {
                        us.Roles.Add(role);
                    }
                    return user;
                }, splitOn: "Id"
            );
            return users;
        }

        public void CreateWithRoles(User user, int RoleId)
        {
            string userSql = @"
                INSERT INTO
                    [User]
                VALUES (@Name, @Email, @Password, @Bio, @Image, @Slug)";
            string roleSql = @"
                INSERT INTO
                    [UserRole]
                VALUES (@UserId, @RoleId)";

            _connection.Query(userSql, new 
            { 
                user.Name, user.Email, user.Password, user.Bio, user.Image, user.Slug 
            });

            var idUser = new Repository<User>(_connection).GetAll().FirstOrDefault(x => x.Name == user.Name);
            // Console.WriteLine($"{idUser.Name} - {idUser.Id}");

            _connection.Query(roleSql, new { UserId = idUser.Id, RoleId });
        }
    }
}