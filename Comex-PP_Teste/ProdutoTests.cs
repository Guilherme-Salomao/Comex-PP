using Comex.Models;
using Xunit;
using Moq;

namespace Comex_PP_Teste
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_CriarProduto_Valido()
        {
            // Arrange
            var nome = "Notebook";
            var descricao = "Notebook Dell Inspiron";
            var precoUnitario = 3500.00;
            var quantidade = 10;

            // Act
            var produto = new Produto(nome)
            {
                Descricao = descricao,
                PrecoUnitario = precoUnitario,
                Quantidade = quantidade
            };

            // Assert
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(descricao, produto.Descricao);
            Assert.Equal(precoUnitario, produto.PrecoUnitario);
            Assert.Equal(quantidade, produto.Quantidade);
        }

        [Fact]
        public void Produto_CriarProduto_ConstrutorVazio()
        {
            // Arrange & Act
            var nome = "";
            var produto = new Produto(nome);

            // Assert
            Assert.Null(produto.Nome);
            Assert.Null(produto.Descricao);
            Assert.Equal(0.0, produto.PrecoUnitario);
            Assert.Equal(0, produto.Quantidade);
        }

        [Fact]
        public void Produto_CompararProdutos_DevolverTrue()
        {
            // Arrange
            var produto1 = new Produto("Notebook");
            var produto2 = new Produto("Notebook");

            // Act & Assert
            Assert.True(produto1.Equals(produto2));
            Assert.True(produto1 == produto2);
            Assert.Equal(produto1.GetHashCode(), produto2.GetHashCode());
        }

        // Exemplo de uso de Moq para mockar uma dependência externa
        [Fact]
        public void Produto_ValidarProduto_UsandoMoq()
        {
            // Arrange
            var nome = "Notebook";
            var descricao = "Notebook Dell Inspiron";
            var precoUnitario = 3500.00;
            var quantidade = 10;

            var mockServicoExterno = new Mock<IServicoExterno>();

            // Configurar o comportamento esperado do mock (opcional)
            mockServicoExterno.Setup(servico => servico.ValidarProduto(It.IsAny<Produto>())).Returns(true);

            var produto = new Produto(nome)
            {
                Descricao = descricao,
                PrecoUnitario = precoUnitario,
                Quantidade = quantidade
            };

            // Act
            var resultadoValidacao = mockServicoExterno.Object.ValidarProduto(produto);

            // Assert
            Assert.True(resultadoValidacao);
        }
    }

    // Exemplo de interface para demonstrar uso de Moq
    public interface IServicoExterno
    {
        bool ValidarProduto(Produto produto);
    }
}
