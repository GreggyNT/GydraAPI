using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GydraAPI.Entities;

[Index("PumpId", Name = "UQ_pump_fk", IsUnique = true)]
public partial class Characteristic
{

    public Characteristic(){}
    public Characteristic(long pumpId,int nominalPressure,int maxPressure,bool isChargingPump, int volume,string reglator, bool rotation, string shaftType, string flangeType
    , string details, string connectionType, string throughShaft, long id)
    {
        PumpId = pumpId;
        NominalPressure = nominalPressure;
        MaxPressure = maxPressure;
        IsChargingPump = isChargingPump;
        Volume = volume;
        Regulator = reglator;
        Rotation = rotation;
        ShaftType = shaftType;
        FlangeType = flangeType;
        Details = details;
        ConnectionType = connectionType;
        ThroughShaft = throughShaft;
        Id = id;
    }
    [Column("pump_id")]
    public long PumpId { get; set; }

    [Column("nominal_pressure")]
    public int NominalPressure { get; set; }

    [Column("max_pressure")]
    public int MaxPressure { get; set; }

    [Column("is_charging_pump")]
    public bool IsChargingPump { get; set; }

    [Column("volume")]
    public int Volume { get; set; }

    [Column("regulator")]
    public string Regulator { get; set; } = null!;

    [Column("rotation")]
    public bool Rotation { get; set; }

    [Column("shaft_type")]
    public string ShaftType { get; set; } = null!;

    [Column("flange_type")]
    public string FlangeType { get; set; } = null!;

    [Column("details")]
    public string Details { get; set; } = null!;

    [Column("connection_type")]
    public string ConnectionType { get; set; } = null!;

    [Column("through_shaft")]
    public string ThroughShaft { get; set; } = null!;

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [ForeignKey("PumpId")]
    [InverseProperty("Characteristic")]
    public virtual Pump? Pump { get; set; }
}
