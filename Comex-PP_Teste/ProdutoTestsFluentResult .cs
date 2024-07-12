using Comex.Models;
using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentResults;

namespace Comex_PP_Teste
{
    public class ProdutoTestsFluentResult
    {
        [Fact]
        public void Produto_CriarProduto_ComNomeValido_DeveSerSucesso()
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
            using (new AssertionScope())
            {
                produto.Nome.Should().Be(nome);
                produto.Descricao.Should().Be(descricao);
                produto.PrecoUnitario.Should().Be(precoUnitario);
                produto.Quantidade.Should().Be(quantidade);
                produto.Resultado.IsSuccess.Should().BeTrue();
            }
        }

        [Fact]
        public void Produto_CriarProduto_ComNomeVazio_DeveFalhar()
        {
            // Arrange
            var nome = "";

            // Act
            var produto = new Produto(nome);

            // Assert
            using (new AssertionScope())
            {
                produto.Nome.Should().BeNull();
                produto.Descricao.Should().BeNull();
                produto.PrecoUnitario.Should().Be(0.0);
                produto.Quantidade.Should().Be(0);
                produto.Resultado.IsFailed.Should().BeTrue();
                produto.Resultado.Errors.Should().ContainSingle()
                    .Which.Message.Should().Be("Nome do produto não pode ser vazio.");
            }
        }
    }
}
