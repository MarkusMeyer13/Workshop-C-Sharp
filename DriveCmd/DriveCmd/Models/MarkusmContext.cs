using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DriveCmd.Models;

public partial class MarkusmContext : DbContext
{
    public MarkusmContext()
    {
    }

    public MarkusmContext(DbContextOptions<MarkusmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:workshop-csharp.database.windows.net,1433;Initial Catalog=markusm;Persist Security Info=False;User ID=workshop;Password=kveOxZEL!gzSWJoItmex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Car");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
