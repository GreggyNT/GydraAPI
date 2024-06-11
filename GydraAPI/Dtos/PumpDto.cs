namespace GydraAPI.Dtos;

public class PumpDto
{
    public long Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public int NominalPressure { get; set; }

    public int MaxPressure { get; set; }

    public bool IsChargingPump { get; set; }

    public int Volume { get; set; }

    public string Regulator { get; set; } = null!;

    public bool Rotation { get; set; }

    public string ShaftType { get; set; } = null!;

    public string FlangeType { get; set; } = null!;

    public string Details { get; set; } = null!;

    public string ConnectionType { get; set; } = null!;

    public string ThroughShaft { get; set; } = null!;

}