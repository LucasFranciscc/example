using example.Models.EntityModel.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace example.Models.ServiceModel.Produtos
{
    public class ProdutoService
    {
        private ExampleDbContext _dbContext;

        public ProdutoService(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Produto Produto { get; private set; }
        public bool ProdutoDuplicado { get; private set; }

        private async Task VerificaProdutoDuplicado()
        {
            ProdutoDuplicado = await _dbContext.produto
                .WhereNome(Produto.nome_produto)
                .AnyAsync();
        }

        private async Task VerificaProdutoDuplicadoEditar()
        {
            ProdutoDuplicado = await _dbContext.produto
                .WhereNome(Produto.nome_produto)
                .WhereNotId(Produto.id)
                .AnyAsync();
        }

        public async Task<bool> Cadastrar(Produto produto)
        {
            Produto = produto;

            await VerificaProdutoDuplicado();
            if (ProdutoDuplicado) return false;

            _dbContext.produto.Add(Produto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Editar(Produto produto)
        {
            Produto = produto;

            await VerificaProdutoDuplicadoEditar();
            if (ProdutoDuplicado) return false;

            _dbContext.produto.Update(Produto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
