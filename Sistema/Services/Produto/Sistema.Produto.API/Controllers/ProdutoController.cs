using Dominio.Entidades;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.Produto.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/api/v1/produtos")]
        public async Task<ActionResult<IEnumerable<ProdutoItem>>> GetAllProdutosAsyc()
        {
            var produtos = await _produtoRepository.GetAllProdutosAsync();

            return Ok(produtos);
        }
    }
}

