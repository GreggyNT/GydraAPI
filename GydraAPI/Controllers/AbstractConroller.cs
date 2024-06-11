using GydraAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace GydraAPI.Controllers;


public class AbstractController<T>(AbstractRepository<T> repository) : ControllerBase
    where T : class
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] T item)
    {
        await repository.AddAsync(item);
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<T?>> Get(long id)
    {
        var res = await repository.GetAsync(id);
        
        if (res==null)
            return NotFound();
        return Ok(res);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromBody] T item)
    {
        await repository.UpdateAsync(item);
        return Ok();
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        if (await repository.GetAsync(id)==null)
            return NotFound();
        await repository.DeleteAsync(id);
        return NoContent();
    }
    
    
}
