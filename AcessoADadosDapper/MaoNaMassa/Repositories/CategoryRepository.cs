using System;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using MaoNaMassa.Models;

namespace MaoNaMassa.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> GetAll()
        {
            return _connection.GetAll<Category>();
        }

        public Category Get(int id)
        {
            return _connection.Get<Category>(id);
        }

        public void Create(Category category)
        {
            _connection.Insert<Category>(category);
        }
    }
}