using example.Models.EntityModel.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace example.Models.ViewModel.Produtos
{
    public class ProdutosViewModel : IActionResult
    {
        public ProdutosViewModel() { }

        public List<Produto> produtos { get; set; }
        public Produto ListaProduto { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
            => await new JsonResult(this).ExecuteResultAsync(context);
    }
}
