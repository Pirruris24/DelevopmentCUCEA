using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC.Models;

public partial class TestmvcdbContext : DbContext
{
    public TestmvcdbContext()
    {
    }

    public TestmvcdbContext(DbContextOptions<TestmvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:LocalhostConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Idform).HasName("PRIMARY");

            entity.ToTable("forms");

            entity.Property(e => e.Idform).HasColumnName("idform");
            entity.Property(e => e.FormsJson)
                .HasMaxLength(45)
                .HasColumnName("formsJSON");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PRIMARY");

            entity.ToTable("usuarios", tb => tb.HasComment("Create user"));

            entity.HasIndex(e => e.SUsername, "sUsername_UNIQUE").IsUnique();

            entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");
            entity.Property(e => e.SPassword)
                .HasMaxLength(64)
                .HasColumnName("sPassword");
            entity.Property(e => e.SUsername)
                .HasMaxLength(20)
                .HasColumnName("sUsername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
