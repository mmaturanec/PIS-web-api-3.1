using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIS.DAL.DataModel
{
    public partial class PIS_DbContext : DbContext
    {
        public PIS_DbContext()
        {
        }

        public PIS_DbContext(DbContextOptions<PIS_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PisUsersMmaturanec> PisUsersMmaturanec { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=193.198.57.183;Database=PIS;User Id=student;Password=student;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PisUsersMmaturanec>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__PIS_USER__F3BEEBFFA75E78D4");

                entity.ToTable("PIS_USERS_MMATURANEC");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.Oib)
                    .HasColumnName("OIB")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserAddress)
                    .HasColumnName("USER_ADDRESS")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserApproved).HasColumnName("USER_APPROVED");

                entity.Property(e => e.UserBanned).HasColumnName("USER_BANNED");

                entity.Property(e => e.UserCountry)
                    .HasColumnName("USER_COUNTRY")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("USER_EMAIL")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserFax)
                    .HasColumnName("USER_FAX")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserImage)
                    .HasColumnName("USER_IMAGE")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserLevel).HasColumnName("USER_LEVEL");

                entity.Property(e => e.UserLoginName)
                    .HasColumnName("USER_LOGIN_NAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserSurname)
                    .HasColumnName("USER_SURNAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserTel)
                    .HasColumnName("USER_TEL")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
