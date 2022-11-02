using example.Models;
using example.Models.EntityModel.Produtos;
using example.Models.ServiceModel.Produtos;
using example.Models.ViewModel.Produtos;
using example.Results.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace example.Controllers
{
    public class ProdutosController : Controller
    {
        private ExampleDbContext _dbContext;

        public ProdutosController(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ProdutosViewModel model = new ProdutosViewModel();

            model.produtos = await _dbContext.produto
                .ToListAsync();

            return View(model);
        }

        public IActionResult CadastrarProduto()
        {
            return View();
        }

        public async Task<IActionResult> EditarProduto(int id)
        {
            ProdutosViewModel model = new ProdutosViewModel();

            model.ListaProduto = await _dbContext.produto
                .WhereId(id)
                .FirstOrDefaultAsync();

            return View(model);
        }

        public async Task<IActionResult> Cadastrar(CadastrarProdutoModel model)
        {
            var produtoService = new ProdutoService(_dbContext);

            await produtoService.Cadastrar(model.Map());

            var resultado = new CadastrarProdutoErroJson(produtoService).ExecuteResultAsync(false, "/Produtos");

            return Json(resultado.Result, new System.Text.Json.JsonSerializerOptions());

        }

        public async Task<IActionResult> Editar(EditarProdutoModel model)
        {
            var produtoService = new ProdutoService(_dbContext);

            await produtoService.Editar(model.Map());

            var resultado = new EditarProdutoErroJson(produtoService).ExecuteResultAsync(false, "/Produtos");

            return Json(resultado.Result, new System.Text.Json.JsonSerializerOptions());
        }

    }
}
