using Microsoft.Data.SqlClient;

namespace Comex.Data
{
    public class Connection
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=ComexT2;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;" +
            "Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False"; 

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
