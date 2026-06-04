using Dominio.Entidades;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.Pessoa.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/api/v1/pessoas")]
        public async Task<ActionResult<IEnumerable<PessoaItem>>> GetAllPessoas()
        {
            var pessoas = await _pessoaRepository.GetAllPessoaAsync();

            return Ok(pessoas);
        }
    }
}
