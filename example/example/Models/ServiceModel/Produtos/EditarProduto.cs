using example.Models.EntityModel.Produtos;

namespace example.Models.ServiceModel.Produtos
{
    public class EditarProduto
    {
        private ExampleDbContext _dbContext;

        public EditarProduto(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Produto Produto { get; private set; }
    }
}
