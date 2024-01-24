using System;
using System.Collections.Generic;
using DbScript.Database.Entities;
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

    public virtual DbSet<EventCategory> EventCategories { get; set; }

    public virtual DbSet<EventCondition> EventConditions { get; set; }

    public virtual DbSet<EventHistory> EventHistories { get; set; }

    public virtual DbSet<EventSubcondition> EventSubconditions { get; set; }

    public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<Nodehistoryview> Nodehistoryviews { get; set; }

    public virtual DbSet<NodesAttribute> NodesAttributes { get; set; }

    public virtual DbSet<NodesHistory> NodesHistories { get; set; }

    public virtual DbSet<NodesValue> NodesValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "adminpack")
            .HasPostgresExtension("rmap_fdw");

        modelBuilder.Entity<EventCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("event_categories");

            entity.Property(e => e.Eventtype).HasColumnName("eventtype");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<EventCondition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("event_conditions");

            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<EventHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("event_history");

            entity.Property(e => e.Ackcomment).HasColumnName("ackcomment");
            entity.Property(e => e.Activetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("activetime");
            entity.Property(e => e.Actorid).HasColumnName("actorid");
            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Changemask).HasColumnName("changemask");
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Cookie).HasColumnName("cookie");
            entity.Property(e => e.Eventtype).HasColumnName("eventtype");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Newstate).HasColumnName("newstate");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.Source).HasColumnName("source");
            entity.Property(e => e.Subcondition).HasColumnName("subcondition");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
        });

        modelBuilder.Entity<EventSubcondition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("event_subconditions");

            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nodes");

            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Tagname).HasColumnName("tagname");
            entity.Property(e => e.Unit).HasColumnName("unit");
        });

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

        modelBuilder.Entity<NodesAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nodes_attributes");

            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Propid).HasColumnName("propid");
            entity.Property(e => e.Valbool).HasColumnName("valbool");
            entity.Property(e => e.Valdouble).HasColumnName("valdouble");
            entity.Property(e => e.Valint).HasColumnName("valint");
            entity.Property(e => e.Valstring).HasColumnName("valstring");
            entity.Property(e => e.Valuint).HasColumnName("valuint");
        });

        modelBuilder.Entity<NodesHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nodes_history");

            entity.Property(e => e.Actualtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actualtime");
            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.Recordtype).HasColumnName("recordtype");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Valbool).HasColumnName("valbool");
            entity.Property(e => e.Valdouble).HasColumnName("valdouble");
            entity.Property(e => e.Valint).HasColumnName("valint");
            entity.Property(e => e.Valstring).HasColumnName("valstring");
            entity.Property(e => e.Valuint).HasColumnName("valuint");
        });

        modelBuilder.Entity<NodesValue>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nodes_values");

            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Valbool).HasColumnName("valbool");
            entity.Property(e => e.Valdouble).HasColumnName("valdouble");
            entity.Property(e => e.Valint).HasColumnName("valint");
            entity.Property(e => e.Valstring).HasColumnName("valstring");
            entity.Property(e => e.Valuint).HasColumnName("valuint");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
