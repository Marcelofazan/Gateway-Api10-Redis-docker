using Dominio.Entidades;

namespace Dominio.Repositorios;

public interface IPessoaRepository
{
    Task<IEnumerable<PessoaItem>> GetAllPessoaAsync();
}
