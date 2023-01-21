using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StarWars.API.Models;

public partial class TtgStarwarsContext : DbContext
{
    public TtgStarwarsContext()
    {
    }

    public TtgStarwarsContext(DbContextOptions<TtgStarwarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Climate> Climates { get; set; }

    public virtual DbSet<Home> Homes { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Relation> Relations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ttg-test.database.windows.net;Database=ttg-starwars;Persist Security Info=False;User ID=ttgAdm;Password=Ch@nge123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Climate>(entity =>
        {
            entity.ToTable("Climate");

            entity.Property(e => e.ClimateId).HasColumnName("ClimateID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.ToTable("Home");

            entity.Property(e => e.HomeId).HasColumnName("HomeID");
            entity.Property(e => e.ClimateId).HasColumnName("ClimateID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Climate).WithMany(p => p.Homes)
                .HasForeignKey(d => d.ClimateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Home_Climate");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.RelatedId });

            entity.ToTable("Object");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.RelatedId).HasColumnName("RelatedID");
            entity.Property(e => e.RelationId).HasColumnName("RelationID");

            entity.HasOne(d => d.Person).WithMany(p => p.ObjectPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Object_Person");

            entity.HasOne(d => d.Related).WithMany(p => p.ObjectRelateds)
                .HasForeignKey(d => d.RelatedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Object_Person1");

            entity.HasOne(d => d.Relation).WithMany(p => p.Objects)
                .HasForeignKey(d => d.RelationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Object_Relation");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.HomeId).HasColumnName("HomeID");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Home).WithMany(p => p.People)
                .HasForeignKey(d => d.HomeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Home");

            entity.HasOne(d => d.Role).WithMany(p => p.People)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Role");
        });

        modelBuilder.Entity<Relation>(entity =>
        {
            entity.ToTable("Relation");

            entity.Property(e => e.RelationId).HasColumnName("RelationID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Roles)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Team");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
