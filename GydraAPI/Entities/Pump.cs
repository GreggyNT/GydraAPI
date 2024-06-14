using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GydraAPI.Entities;

public partial class Pump
{
    
    public Pump(){}                                                                 
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [InverseProperty("Pump")]
    public virtual Characteristic? Characteristic { get; set; }
}
