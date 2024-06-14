using GydraAPI.Dtos;
using GydraAPI.Entities;
using GydraAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace GydraAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PumpController(AbstractRepository<Pump> repository, IDistributedCache cache)
    : AbstractController<Pump>(repository)
{
    private readonly IDistributedCache _cache = cache;

    private readonly AbstractRepository<Pump> _repository = repository;

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public override async Task<ActionResult<Pump?>> Get(long id) => Ok(await _repository.GetPumpFull(id));

    [HttpGet]
    public ActionResult<IList<PumpDto>> GetAll() => Ok(_repository.GetAllPumpsFull());

    [HttpGet("slim")]
    public ActionResult<IList<PumpDto>> GetAllSlim() => Ok(_repository.GetAllPumpsSlim());

    [HttpGet("imgs/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<byte[]?>> GetImage(long id)
    {
        var img = await _cache.GetAsync($"{id}");
        if (img == null)
            _cache.SetAsync($"{id}",
                System.IO.File.ReadAllBytes(
                    $"/home/gregster/Документы/png.png"));
        else 
            return File(img, "image/png");
        return File( await _cache.GetAsync($"{id}"), "image/png");
    }
    
}