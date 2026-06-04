using Sistema.Agrupador.API.Models;
using Sistema.Infra.Redis.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Sistema.Agrupador.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AgrupadorController : Controller
{
    const string CACHE_NAME = "Pessoa_Agrupador";
    private readonly ICacheRepository _cacheRepository;
    public AgrupadorController(ICacheRepository cacheRepository)
    {
        _cacheRepository = cacheRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PessoaAgrupador), (int)HttpStatusCode.OK)]
    [Route("/api/v1/agrupador/pessoa/{pessoaId}")]
    public async Task<ActionResult<PessoaAgrupador>> GetBasketByPessoaIdAsync(Guid pessoaId)
    {
        var pessoaAgrupador = await _cacheRepository
            .GetItemWithCustomKeyAsync<PessoaAgrupador>(CACHE_NAME + "_" + pessoaId.ToString());

        return Ok(pessoaAgrupador);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PessoaAgrupador), (int)HttpStatusCode.OK)]
    [Route("/api/v1/agrupador")]
    public async Task<ActionResult<PessoaAgrupador>> AddBasketAsync(PessoaAgrupador pessoaAgrupador)
    {
        await _cacheRepository.SetItemAsync(
             pessoaAgrupador.PessoaId.ToString(), CACHE_NAME, pessoaAgrupador);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    [Route("/api/agrupador/{id}")]
    public async Task<ActionResult> DeleteByPessoaIdAsync(Guid id)
    {
        await _cacheRepository.RemoveAsync(id.ToString(), CACHE_NAME);
        return Ok();
    }
}