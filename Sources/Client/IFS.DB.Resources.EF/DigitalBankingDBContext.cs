using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFS.DB.Resources.EF
{
    public partial class DigitalBankingDBContext : DbContext
    {
        public DigitalBankingDBContext()
        {
        }

        public DigitalBankingDBContext(DbContextOptions<DigitalBankingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UILanguageResource> UilanguageResources { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database=DigitalBanking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UILanguageResource>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.ResourceKey });

                entity.ToTable("UILanguageResources");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceText)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
