using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public partial class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AppConnection"));
            }
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<TransferType> TransferTypes { get; set; }
        public virtual DbSet<TransferStatus> TransferStatuses { get; set; }
        public virtual DbSet<TransferInfo> TransferInfos { get; set; }
        public virtual DbSet<PaymentLog> PaymentLogs { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfos { get; set; }
        public virtual DbSet<ProfileInfo> ProfileInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_Country");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Code).HasColumnName("Code").IsRequired().HasMaxLength(20);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //Currency
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_Currency");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Shortcut).HasColumnName("Shortcut").IsRequired().HasMaxLength(5);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //ActionType
            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_ActionType");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //PaymentStatus
            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_PaymentStatus");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //PaymentType
            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_PaymentType");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            }); 

            //TransferStatus
            modelBuilder.Entity<TransferStatus>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_TransferStatus");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //TransferType
            modelBuilder.Entity<TransferType>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_TransferType");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //PaymentLog
            modelBuilder.Entity<PaymentLog>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_PaymentLog");

                entity.HasOne(f => f.ActionType)
                    .WithMany(p => p.PaymentLogs)
                    .HasForeignKey(f => f.ActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentLog_ActionType");

                entity.HasOne(f => f.ProfileInfo)
                    .WithMany(p => p.PaymentLogs)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentLog_ProfileInfo");

                entity.Property(e => e.ActionDate).HasColumnName("ActionDate").HasDefaultValueSql("getdate()");
                entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(2000);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //PaymentInfo
            modelBuilder.Entity<PaymentInfo>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_PaymentInfo");

                entity.HasOne(f => f.Currency)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(f => f.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentInfo_Currency");

                entity.HasOne(f => f.FileInfo)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(f => f.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentInfo_FileInfo");

                entity.HasOne(f => f.PaymentStatus)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(f => f.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentInfo_PaymentStatus");

                entity.HasOne(f => f.PaymentType)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(f => f.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentInfo_PaymentType");

                entity.Property(e => e.PaymentDate).HasColumnName("PaymentDate").IsRequired().HasDefaultValueSql("getdate()"); 
                entity.Property(e => e.Amount).HasColumnName("Amount").IsRequired();
                entity.Property(e => e.PayedFrom).HasColumnName("PayedFrom").IsRequired().HasMaxLength(150); 
                entity.Property(e => e.PayedTo).HasColumnName("PayedTo").IsRequired().HasMaxLength(150);
                entity.Property(e => e.Description).HasColumnName("Description").IsRequired().HasMaxLength(500);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //TransferInfo
            modelBuilder.Entity<TransferInfo>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_TransferInfo");

                entity.HasOne(f => f.FromCountry)
                    .WithMany(p => p.FromTransferInfos)
                    .HasForeignKey(f => f.FromCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInfo_Country");

                entity.HasOne(f => f.ToCountry)
                    .WithMany(p => p.ToTransferInfos)
                    .HasForeignKey(f => f.ToCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInfo_Country1");

                entity.HasOne(f => f.Currency)
                    .WithMany(p => p.TransferInfos)
                    .HasForeignKey(f => f.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInfo_Currency");

                entity.HasOne(f => f.TransferStatus)
                    .WithMany(p => p.TransferInfos)
                    .HasForeignKey(f => f.TransferStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInfo_TransferStatus");

                entity.HasOne(f => f.TransferType)
                    .WithMany(p => p.TransferInfos)
                    .HasForeignKey(f => f.TransferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInfo_TransferType");

                entity.Property(e => e.Amount).HasColumnName("Amount").IsRequired();
                entity.Property(e => e.TransferDate).HasColumnName("TransferDate").IsRequired().HasDefaultValueSql("getdate()");
                entity.Property(e => e.Description).HasColumnName("Description").IsRequired().HasMaxLength(500);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });

            //ProfileInfo
            modelBuilder.Entity<ProfileInfo>(entity =>
            {
                entity.Property(e => e.Id);
                entity.HasKey(e => e.Id)
                    .HasName("PK_ProfileInfo");

                entity.Property(e => e.NameAr).HasColumnName("NameAr").IsRequired().HasMaxLength(250);
                entity.Property(e => e.NameEn).HasColumnName("NameEn").IsRequired().HasMaxLength(250);
                entity.Property(e => e.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).HasColumnName("Password").IsRequired().HasMaxLength(250);
                entity.Property(e => e.Email).HasColumnName("Email").IsRequired().HasMaxLength(50);
                entity.Property(e => e.MobileNumber).HasColumnName("MobileNumber").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).HasColumnName("Status").IsRequired();
                entity.Property(e => e.Gender).HasColumnName("Gender").IsRequired();
                entity.Property(e => e.IsVerified).HasColumnName("IsVerified").HasDefaultValueSql("false");
                entity.Property(e => e.IsActive).HasColumnName("IsActive").HasDefaultValueSql("false");
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValueSql("false");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
