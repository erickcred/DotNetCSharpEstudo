using Microsoft.Data.SqlClient;

namespace MaoNaMassa
{
    public static class Connection
    {
        public static readonly string connectionString = 
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=SSPI;TrustServerCertificate=True";
    }
}