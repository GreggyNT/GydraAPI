using GydraAPI.Dtos;
using GydraAPI.Entities;
using GydraAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GydraAPI.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class PumpController(AbstractRepository<Pump> repository) :AbstractController<Pump>(repository)
{
    
    private readonly AbstractRepository<Pump> _repository = repository;
    [HttpGet]
    
    public  ActionResult<IList<PumpDto>> GetAll() =>  Ok(_repository.GetAllPumpsFull());
    
    [HttpGet("slim")]
    public  ActionResult<IList<PumpDto>> GetAllSlim() =>  Ok(_repository.GetAllPumpsSlim());
    
}