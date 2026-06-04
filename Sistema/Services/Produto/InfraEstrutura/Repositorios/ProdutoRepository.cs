using Dominio.Entidades;
using Dominio.Repositorios;

namespace InfraEstrutura.Repositorios;

public class ProdutoRepository : IProdutoRepository
{
    public ProdutoRepository()
    {
    }

    public async Task<IEnumerable<ProdutoItem>> GetAllProdutosAsync()
    {
        return new List<ProdutoItem>
        {
            new ProdutoItem
            {
                Id = Guid.Parse("1673a9fd-191a-479c-a41f-3dc5611aa98e"),
                Descricao = "Abacaxi",
                Categoria = "Frutas",
                Valor = 5.50m
            },
            new ProdutoItem
            {
                Id = Guid.Parse("2673a9fd-191a-479c-a41f-3dc5611aa98e"),
                Descricao = "Banana",
                Categoria = "Frutas",
                Valor = 10.50m
            }
        };
    }
}
