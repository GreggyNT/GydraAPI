using GydraAPI.Context;
using GydraAPI.Dtos;
using GydraAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GydraAPI.Services;

public abstract class AbstractRepository<T>(AppbContext context) where T : class
{
    protected AppbContext _context = context;
    
    public async Task AddAsync(T item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var res = await _context.FindAsync<T>(id);
        if (res != null)
            _context.Remove(res);
        await _context.SaveChangesAsync();

    }
    
    public async Task<T?> GetAsync(long id)
    {
        var res = await _context.FindAsync<T>(id);
        return res ?? null;
    }

    public async Task UpdateAsync(T item)
    {
        _context.Update(item);
        await _context.SaveChangesAsync();
    }
    
    public abstract List<PumpDto> GetAllPumpsFull();
    
    public abstract List<PumpSlimDto> GetAllPumpsSlim();
}