using example.Models.EntityModel.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace example.Models.ServiceModel.Produtos
{
    public class CadastrarProduto
    {
        private ExampleDbContext _dbContext;

        public CadastrarProduto(ExampleDbContext dbContext)
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

        public async Task<bool> Cadastrar(Produto produto)
        {
            Produto = produto;

            await VerificaProdutoDuplicado();
            if (ProdutoDuplicado) return false;

            _dbContext.produto.Add(Produto);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
