using example.Models.EntityModel.Produtos;
using System.ComponentModel.DataAnnotations;

namespace example.Models.ViewModel.Produtos
{
    public class CadastrarProdutoModel
    {
        [Display(Name = "nome")]
        public string NomeProduto { get; set; }

        [Display(Name = "descricao")]
        public string Descricao { get; set; }

        [Display(Name = "categoria")]
        public string Categoria { get; set; }

        [Display(Name = "valor")]
        public decimal Valor { get; set; }

        public Produto Map()
        {
            var produto = new Produto();

            produto.nome_produto = NomeProduto;
            produto.descricao = Descricao;
            produto.categoria = Categoria;
            produto.status = true;
            produto.valor = Valor;

            return produto;
        }
    }
}
