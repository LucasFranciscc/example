using System.Linq;

namespace example.Models.EntityModel.Produtos
{
    public static class produtosQuery
    {
        public static IQueryable<Produto> WhereId(this IQueryable<Produto> produto, int id)
        {
            return produto.Where(x => x.id == id);
        }

        public static IQueryable<Produto> WhereNotId(this IQueryable<Produto> produto, int id)
        {
            return produto.Where(x => x.id != id);
        }

        public static IQueryable<Produto> WhereNome(this IQueryable<Produto> produtos, string nome)
        {
            return produtos.Where(x => x.nome_produto == nome);
        }
    }
}
