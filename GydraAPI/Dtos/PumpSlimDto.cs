namespace GydraAPI.Dtos;

public class PumpSlimDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int NominalPressure { get; set; }
    
    public int MaxPressure { get; set; }
    
    public int Volume { get; set; }
}