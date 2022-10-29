using System.ComponentModel.DataAnnotations;

namespace example.Models.EntityModel.Produtos
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string nome_produto { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public bool status { get; set; }
        public decimal valor { get; set; }
    }
}
