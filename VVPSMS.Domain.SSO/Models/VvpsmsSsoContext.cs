using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VVPSMS.Domain.SSO.Models;

public partial class VvpsmsSsoContext : DbContext
{
    public VvpsmsSsoContext()
    {
    }

    public VvpsmsSsoContext(DbContextOptions<VvpsmsSsoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AzureBlobConfiguration> AzureBlobConfigurations { get; set; }

    public virtual DbSet<GoogleConfiguration> GoogleConfigurations { get; set; }

    public virtual DbSet<MicroSoftConfiguration> MicroSoftConfigurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Initial Catalog=VVPSMS_SSO;User Id=sa;Password=1992;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AzureBlobConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AzureBlobConfiguration");

            entity.Property(e => e.BlobContainerName).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DomainCode).HasMaxLength(200);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.UpdateBy).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GoogleConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GoogleConfiguration");

            entity.Property(e => e.ActiveYn).HasColumnName("ActiveYN");
            entity.Property(e => e.ApplicationName).HasMaxLength(500);
            entity.Property(e => e.ClientId).HasMaxLength(500);
            entity.Property(e => e.ClientSecretCode).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DomainCode).HasMaxLength(200);
            entity.Property(e => e.GrantType).HasMaxLength(100);
            entity.Property(e => e.GraphUrl).HasMaxLength(500);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Oauthurl).HasMaxLength(500);
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);
            entity.Property(e => e.Scopes).HasMaxLength(500);
            entity.Property(e => e.TokenUrl).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MicroSoftConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MicroSoftConfiguration");

            entity.Property(e => e.ActiveYn).HasColumnName("ActiveYN");
            entity.Property(e => e.ClientId).HasMaxLength(500);
            entity.Property(e => e.ClientSecretCode).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DomainCode).HasMaxLength(200);
            entity.Property(e => e.GrantType).HasMaxLength(100);
            entity.Property(e => e.GraphUrl).HasMaxLength(500);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);
            entity.Property(e => e.ScopeUrl).HasMaxLength(500);
            entity.Property(e => e.TokenUrl).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
