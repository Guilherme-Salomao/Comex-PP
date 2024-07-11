using System;
using System.Collections.Generic;
using Comex.Models;

namespace Comex.Services
{
    public class ProdutoService
    {
        private readonly List<Produto> _produtos;

        public ProdutoService()
        {
            _produtos = new List<Produto>();
        }

        public void CriarProduto(string nome, string descricao, double precoUnitario, int quantidade)
        {
            var produto = new Produto(nome)
            {
                Descricao = descricao,
                PrecoUnitario = precoUnitario,
                Quantidade = quantidade
            };

            _produtos.Add(produto);
        }

        public List<Produto> ListarProdutos()
        {
            return _produtos;
        }

        public Produto BuscarProdutoPorNome(string nome)
        {
            return _produtos.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        public void AtualizarProduto(string nome, string novaDescricao, double novoPrecoUnitario, int novaQuantidade)
        {
            var produto = BuscarProdutoPorNome(nome);

            if (produto != null)
            {
                produto.Descricao = novaDescricao;
                produto.PrecoUnitario = novoPrecoUnitario;
                produto.Quantidade = novaQuantidade;
            }
            else
            {
                throw new ArgumentException("Produto não encontrado.", nameof(nome));
            }
        }

        public void RemoverProduto(string nome)
        {
            var produto = BuscarProdutoPorNome(nome);

            if (produto != null)
            {
                _produtos.Remove(produto);
            }
            else
            {
                throw new ArgumentException("Produto não encontrado.", nameof(nome));
            }
        }
    }
}
