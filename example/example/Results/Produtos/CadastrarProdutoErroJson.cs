using example.Extensions;
using example.Models.ServiceModel.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace example.Results.Produtos
{
    public class CadastrarProdutoErroJson
    {
        private CadastrarProduto _cadastrarProduto;

        public CadastrarProdutoErroJson(CadastrarProduto cadastrarProduto)
        {
            _cadastrarProduto = cadastrarProduto;
        }

        public async Task<Erro> ExecuteResultAsync()
        {
            if (_cadastrarProduto.ProdutoDuplicado)
                return new Erro { status = "Erro", mensagem = "Produto duplicado" };

            return new Erro { status = "Sucesso", mensagem = "Cadastrado com sucesso" };
        }

    }
}
