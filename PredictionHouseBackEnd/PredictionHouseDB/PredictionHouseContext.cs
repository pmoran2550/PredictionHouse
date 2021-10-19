using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PTM.PredictionHouseDB
{
    public partial class PredictionHouseContext : DbContext
    {
        public PredictionHouseContext()
        {
        }

        public PredictionHouseContext(DbContextOptions<PredictionHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RespondentLogin> RespondentLogin { get; set; }
        public virtual DbSet<Respondents> Respondents { get; set; }
        public virtual DbSet<Responses> Responses { get; set; }
        public virtual DbSet<Year> Year { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=PHConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DisplayName).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.CodeId).HasColumnName("CodeID");

                entity.Property(e => e.Code1)
                    .IsRequired()
                    .HasColumnName("Code")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            });

            modelBuilder.Entity<RespondentLogin>(entity =>
            {
                entity.Property(e => e.RespondentLoginId).HasColumnName("RespondentLoginID");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(128);

                entity.Property(e => e.RespondentId).HasColumnName("RespondentID");

                entity.Property(e => e.RespondentName).HasMaxLength(50);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.RespondentLogin)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RespondentLogin_AspNetUsers");

                entity.HasOne(d => d.Respondent)
                    .WithMany(p => p.RespondentLogin)
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RespondentLogin_Respondents");
            });

            modelBuilder.Entity<Respondents>(entity =>
            {
                entity.HasKey(e => e.RespondentId)
                    .HasName("PK_Respondent");

                entity.Property(e => e.RespondentId).HasColumnName("RespondentID");

                entity.Property(e => e.RespondentGroup).HasMaxLength(50);

                entity.Property(e => e.RespondentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Responses>(entity =>
            {
                entity.HasKey(e => e.ResponseId);

                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.RespondentId).HasColumnName("RespondentID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Responses");

                entity.HasOne(d => d.Respondent)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Respondent_Responses");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Year1)
                    .HasColumnName("Year")
                    .HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
