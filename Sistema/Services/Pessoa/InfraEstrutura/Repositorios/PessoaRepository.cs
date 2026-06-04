using Dominio.Entidades;
using Dominio.Repositorios;

namespace InfraEstrutura.Repositorios;

public class PessoaRepository : IPessoaRepository
{
    public PessoaRepository()
    {
    }
    public async Task<IEnumerable<PessoaItem>> GetAllPessoaAsync()
    {
        return new List<PessoaItem>()
        {
            new PessoaItem
            {
                Id = Guid.Parse("3673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Nome = "João da Silva",
                Email = "joao.one@domain.com"
            },
            new PessoaItem
            {
                Id = Guid.Parse("4673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Nome = "Maria Alves",
                Email = "maria.two@domain.com"
            },
            new PessoaItem
            {
                Id = Guid.Parse("5673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Nome = "José da Costa",
                Email = "jose.three@domain.com"
            }
        };
    }
}
