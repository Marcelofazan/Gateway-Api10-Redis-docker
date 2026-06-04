using Dominio.Entidades;

namespace Dominio.Repositorios;

public interface IProdutoRepository
{
    Task<IEnumerable<ProdutoItem>> GetAllProdutosAsync();
}
