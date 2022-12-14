using example.Extensions;
using example.Models.ServiceModel.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace example.Results.Produtos
{
    public class CadastrarProdutoErroJson
    {
        private ProdutoService _produtoService;

        public CadastrarProdutoErroJson(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<StatusMessage> ExecuteResultAsync(bool reload, string redirect = "")
        {
            if (_produtoService.ProdutoDuplicado)
                return new StatusMessage { status = "Warning", mensagem = "Produto duplicado" };

            return new StatusMessage { status = "Sucesso", mensagem = "Cadastrado com sucesso", reload = reload, redirect = redirect };
        }

    }
}
