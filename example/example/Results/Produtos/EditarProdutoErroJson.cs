using example.Extensions;
using example.Models.ServiceModel.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace example.Results.Produtos
{
    public class EditarProdutoErroJson
    {
        private ProdutoService _produtoService;

        public EditarProdutoErroJson(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<StatusMessage> ExecuteResultAsync(bool reload, string redirect = "")
        {
            if (_produtoService.ProdutoDuplicado)
                return new StatusMessage { status = "Erro", mensagem = "Produto duplicado" };

            return new StatusMessage { status = "Sucesso", mensagem = "Alterado com sucesso", reload = reload, redirect = redirect };
        }

    }
}
