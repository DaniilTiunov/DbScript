using System;
using System.Collections.Generic;
using DbScript.Database.Views;
using Microsoft.EntityFrameworkCore;

namespace DbScript.DBContext;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Nodehistoryview> Nodehistoryviews { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "adminpack")
            .HasPostgresExtension("rmap_fdw");

        modelBuilder.Entity<Nodehistoryview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("nodehistoryview");

            entity.Property(e => e.Actualtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actualtime");
            entity.Property(e => e.Tagname).HasColumnName("tagname");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Valdouble).HasColumnName("valdouble");
            entity.Property(e => e.Valint).HasColumnName("valint");
            entity.Property(e => e.Valuint).HasColumnName("valuint");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
