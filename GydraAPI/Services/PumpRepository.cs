using System.Security.Cryptography.Xml;
using GydraAPI.Context;
using GydraAPI.Dtos;
using GydraAPI.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GydraAPI.Services;

public class PumpRepository(AppbContext context) :AbstractRepository<Pump>(context)
{
    public override List<PumpDto> GetAllPumpsFull()
    {
         var list = new List<PumpDto>();
         foreach (var item in _context.Pumps.ToList())
         {
             item.Characteristic = _context.Characteristics.FirstOrDefault(x => x.PumpId == item.Id);
             var res = item.Characteristic.Adapt<PumpDto>();
             res.Name = item.Name;
             res.Description = item.Description;
             list.Add(res);
         }
         return list;
    }

    public override List<PumpSlimDto> GetAllPumpsSlim()
    {
        var list = new List<PumpSlimDto>();
        foreach (var item in _context.Pumps.ToList())
        {
            item.Characteristic = _context.Characteristics.FirstOrDefault(x => x.PumpId == item.Id);
            var res = item.Characteristic.Adapt<PumpSlimDto>();
            res.Name = item.Name;
            list.Add(res);
        }
        return list;
    }

    public override async Task<PumpDto> GetPumpFull(long id)
    {
        PumpDto res;
        var characteristic = _context.Characteristics.FirstOrDefault(x => x.PumpId == id);
        res = characteristic.Adapt<PumpDto>();
        var main = await _context.Pumps.FirstOrDefaultAsync(x=>x.Id == id);
        res.Name = main.Name;
        res.Description = main.Description;
        return res;
    }
}