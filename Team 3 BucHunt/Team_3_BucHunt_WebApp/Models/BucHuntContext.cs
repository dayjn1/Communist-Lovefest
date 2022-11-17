/**
* --------------------------------------------------------------------------- 
* File name: BucHuntContext.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Oct 09, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 10, 2022
* --------------------------------------------------------------------------- 
*/

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Team_3_BucHunt_WebApp.Models;

namespace Team_3_BucHunt_WebApp.Models;

/**
* Class Name: BucHuntContext <br>
* Class Purpose: BucHunt context<br>
* <hr>
* Date created: Nov 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
*/
public partial class BucHuntContext : DbContext
{
    public BucHuntContext()
    {
    }

    public BucHuntContext(DbContextOptions<BucHuntContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hunt> Hunts { get; set; }

    public virtual DbSet<HuntCode> HuntCodes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=151.141.91.45; Database=BucHunt; User Id=dbaccess; Password=Password1!; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hunt>(entity =>
        {
            entity.Property(e => e.HuntId)
                .ValueGeneratedNever()
                .HasColumnName("HuntID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasMany(d => d.Locations).WithMany(p => p.Hunts)
                .UsingEntity<Dictionary<string, object>>(
                    "HuntLocation",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HuntLocations_Locations"),
                    l => l.HasOne<Hunt>().WithMany()
                        .HasForeignKey("HuntId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HuntLocations_Hunts"),
                    j =>
                    {
                        j.HasKey("HuntId", "LocationId");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.Hunts)
                .UsingEntity<Dictionary<string, object>>(
                    "HuntUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HuntUsers_Users"),
                    l => l.HasOne<Hunt>().WithMany()
                        .HasForeignKey("HuntId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HuntUsers_Hunts"),
                    j =>
                    {
                        j.HasKey("HuntId", "UserId");
                    });
        });

        modelBuilder.Entity<HuntCode>(entity =>
        {
            entity.HasKey(e => new { e.HuntId, e.Code }).HasName("PK_HuntCode");

            entity.Property(e => e.HuntId).HasColumnName("HuntID");
            entity.Property(e => e.Code).HasMaxLength(10);

            entity.HasOne(d => d.Hunt).WithMany(p => p.HuntCodes)
                .HasForeignKey(d => d.HuntId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HuntCodes_Hunts");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.Answer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.AccessCode).HasMaxLength(10);
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.HuntId).HasColumnName("HuntID");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Hunt).WithMany(p => p.UsersNavigation)
                .HasForeignKey(d => d.HuntId)
                .HasConstraintName("FK_Users_Hunts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Team_3_BucHunt_WebApp.Models.QRCodeModel> QRCodeModel { get; set; }
}
