namespace GydraAPI.Dtos;

public class PumpSlimDto
{
    public string Name { get; set; } = null!;
    
    public int NominalPressure { get; set; }
    
    public int MaxPressure { get; set; }
    
    public int Volume { get; set; }
}