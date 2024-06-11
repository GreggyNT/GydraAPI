using System;
using System.Collections.Generic;
using GydraAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GydraAPI.Context;

public partial class AppbContext : DbContext
{
    public AppbContext(DbContextOptions<AppbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<Pump> Pumps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("characteristics_PK");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PumpId).HasDefaultValueSql("'-1'::integer");

            entity.HasOne(d => d.Pump).WithOne(p => p.Characteristic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pumps_id_FK");
        });

        modelBuilder.Entity<Pump>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pumps_PK");

            entity.Property(e => e.Id).HasDefaultValueSql("'-1'::integer");
        });
    }
}
