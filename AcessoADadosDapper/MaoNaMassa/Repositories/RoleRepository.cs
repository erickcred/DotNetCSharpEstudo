using System;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using MaoNaMassa.Models;

namespace MaoNaMassa.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Role> GetAll()
        {
            return _connection.GetAll<Role>();
        }

        public Role Get(int id)
        {
            return _connection.Get<Role>(id);
        }

        public void Create(Role role)
        {
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            // var role = _connection.Get<Role>(id);
            _connection.Update<Role>(role);
        }

        public bool Delete(int id)
        {
            var role = _connection.Get<Role>(id);
            return _connection.Delete<Role>(role);
        }
    }
}