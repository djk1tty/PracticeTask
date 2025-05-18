using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileExchangerAPI.Models;

public partial class FileExchangeDbContext : DbContext
{
    public FileExchangeDbContext()
    {
    }

    public FileExchangeDbContext(DbContextOptions<FileExchangeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=176.62.176.149;Database=FileExchangeDB; Integrated Security=False; TrustServerCertificate=True;user id=sa; password=123mgok2025...; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.MimeType).HasMaxLength(50);
            entity.Property(e => e.StoragePath).HasMaxLength(500);
            entity.Property(e => e.UploadedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Files)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC071B849416");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345E4597CF").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
