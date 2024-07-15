using Comex.Modelos;
using Microsoft.Data.SqlClient;

namespace Comex.Data
{
    public class ProdutoDAL
    {
        public IEnumerable<Produto> Listar()
        {
            var lista = new List<Produto>();
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "SELECT * FROM Produtos";
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string nomeProduto = Convert.ToString(dataReader["Nome"]);
                string descricaoProduto = Convert.ToString(dataReader["Descricao"]);
                double precoUnitario = Convert.ToDouble(dataReader["PrecoUnitario"]);
                int quantidadeProduto = Convert.ToInt32(dataReader["Quantidade"]);
                Produto produto = new Produto(nomeProduto)
                {
                    Descricao = descricaoProduto,
                    PrecoUnitario = precoUnitario,
                    Quantidade = quantidadeProduto
                };
                lista.Add(produto);
            }
            return lista;
        }

        public void Adicionar(Produto produto)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "INSERT INTO Produtos (Nome, Descricao, PrecoUnitario, Quantidade) VALUES (@nome, @descricao, @preco, @quantidade)";
            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", produto.Nome);
            command.Parameters.AddWithValue("@descricao", produto.Descricao);
            command.Parameters.AddWithValue("@preco", produto.PrecoUnitario);
            command.Parameters.AddWithValue("@quantidade", produto.Quantidade);

            int linhasAfetadas = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {linhasAfetadas}");
        }

        public void Atualizar(Produto produto)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "UPDATE Produtos SET Nome = @nome, Descricao = @descricao, PrecoUnitario = @preco, Quantidade = @quantidade WHERE Id = @id";
            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", produto.Nome);
            command.Parameters.AddWithValue("@descricao", produto.Descricao);
            command.Parameters.AddWithValue("@preco", produto.PrecoUnitario);
            command.Parameters.AddWithValue("@quantidade", produto.Quantidade);
            command.Parameters.AddWithValue("@id", produto.Id);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {rowsAffected}");
        }

        public void Deletar(Produto produto)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "DELETE FROM Produtos WHERE Id = @id";
            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", produto.Id);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {rowsAffected}");
        }
    }
}
