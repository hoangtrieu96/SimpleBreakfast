using Microsoft.EntityFrameworkCore;
using SimpleBreakfast.Models.Entities;

namespace SimpleBreakfast.Models;

public partial class BreakfastContext : DbContext
{
    public BreakfastContext()
    {
    }

    public BreakfastContext(DbContextOptions<BreakfastContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Breakfast> Breakfasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Breakfast");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Breakfast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Breakfas__3214EC277AC962EC");

            entity.ToTable("Breakfast");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Savory)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Sweet)
                .HasMaxLength(4000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
