﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VVPSMS.Domain.Logger.Models;

public partial class VvpsmsdbLogsContext : DbContext
{
    public VvpsmsdbLogsContext()
    {
    }

    public VvpsmsdbLogsContext(DbContextOptions<VvpsmsdbLogsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.59.3;Initial Catalog=VVPSMSDB_LOGS;User Id=sa;Password=D#$q2023P@s;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logs__3214EC0703A7DDAF");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Level).HasMaxLength(10);
            entity.Property(e => e.Logger).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
