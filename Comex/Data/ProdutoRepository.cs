using Comex.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Comex.Data
{
    public class ProdutoRepository
    {
        private ComexDbContext _dbContext;
        public ProdutoRepository(ComexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Produto> Listar()
        {
            return _dbContext.Produtos.ToList();
        }

        public void Adicionar(Produto produto)
        {
            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _dbContext.Entry(produto).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            var produto = _dbContext.Produtos.Find(id);
            if (produto != null)
            {
                _dbContext.Produtos.Remove(produto);
                _dbContext.SaveChanges();
            }
        }
    }
}
