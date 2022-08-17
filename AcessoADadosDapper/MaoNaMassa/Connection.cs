using Microsoft.Data.SqlClient;

namespace MaoNaMassa
{
    public static class Connection
    {
        public static readonly string connectionString = 
            // @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=SSPI;TrustServerCertificate=True";
            @"Data Source=localhost\sqlserver,1433;Database=Blog;User ID=sa;Password=Jessica12@;TrustServerCertificate=True";
    }
}