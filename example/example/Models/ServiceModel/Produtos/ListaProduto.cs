using example.Models.ViewModel.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace example.Models.ServiceModel.Produtos
{
    public class ListaProduto
    {
        private ExampleDbContext _dbContext;

        public ListaProduto(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ListarProdutos()
        {
            ProdutosViewModel model = new ProdutosViewModel();

            model.produtos = await _dbContext.produto
                .ToListAsync();
        }
    }
}
