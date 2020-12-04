using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApplicationCore.Entities
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<TblDepartamentet> TblDepartamentet { get; set; }
        public virtual DbSet<TblKerkesatAnkesat> TblKerkesatAnkesat { get; set; }
        public virtual DbSet<TblLlojetDepartamenteve> TblLlojetDepartamenteve { get; set; }
        public virtual DbSet<TblMenaxhimiKerkesave> TblMenaxhimiKerkesave { get; set; }
        public virtual DbSet<TblVeprimet> TblVeprimet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ARNIS;Initial Catalog=DigitalComplaintsDB2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<TblDepartamentet>(entity =>
            {
                entity.HasKey(e => e.DepartamentiId);

                entity.ToTable("tbl.Departamentet");

                entity.Property(e => e.DepartamentiId).HasColumnName("DepartamentiID");

                entity.Property(e => e.VeprimetId).HasColumnName("VeprimetID");
            });

            modelBuilder.Entity<TblKerkesatAnkesat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl.KerkesatAnkesat");

                entity.Property(e => e.AnonimId).HasColumnName("AnonimID");

                entity.Property(e => e.Departamenti).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.KerkesaAnkesaId).HasColumnName("KerkesaAnkesaID");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnName("LUD")
                    .HasColumnType("date");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Nenshkrimi).HasMaxLength(50);

                entity.Property(e => e.PershkrimiIkerkeses)
                    .HasColumnName("PershkrimiIKerkeses")
                    .HasMaxLength(500);

                entity.Property(e => e.RoliId).HasColumnName("RoliID");
            });

            modelBuilder.Entity<TblLlojetDepartamenteve>(entity =>
            {
                entity.HasKey(e => e.DepartamentiId);

                entity.ToTable("tbl.LlojetDepartamenteve");
            });

            modelBuilder.Entity<TblMenaxhimiKerkesave>(entity =>
            {
                entity.HasKey(e => e.MenaxhimiId);

                entity.ToTable("tbl.MenaxhimiKerkesave");

                entity.Property(e => e.MenaxhimiId).HasColumnName("MenaxhimiID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.LlojiIkerkeses)
                    .HasColumnName("LlojiIKerkeses")
                    .HasMaxLength(500);

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnName("LUD")
                    .HasColumnType("date");

                entity.Property(e => e.Lun).HasColumnName("LUN");
            });

            modelBuilder.Entity<TblVeprimet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl.Veprimet");

                entity.Property(e => e.Grupi).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.KerkesaId).HasColumnName("KerkesaID");

                entity.Property(e => e.LendetEmbetura)
                    .HasColumnName("LendetEMbetura")
                    .HasMaxLength(500);

                entity.Property(e => e.LendetEpranuara)
                    .HasColumnName("LendetEPranuara")
                    .HasMaxLength(500);

                entity.Property(e => e.LendetErefuzuara)
                    .HasColumnName("LendetERefuzuara")
                    .HasMaxLength(500);

                entity.Property(e => e.LlojiIkerkeses)
                    .HasColumnName("LlojiIKerkeses")
                    .HasMaxLength(50);

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnName("LUD")
                    .HasColumnType("date");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.MenaxhimiId).HasColumnName("MenaxhimiID");

                entity.Property(e => e.ObligimetEmbetura)
                    .HasColumnName("ObligimetEMbetura")
                    .HasMaxLength(500);

                entity.Property(e => e.Orari).HasMaxLength(50);

                entity.Property(e => e.PagesatEperfunduara)
                    .HasColumnName("PagesatEPerfunduara")
                    .HasMaxLength(500);

                entity.Property(e => e.RefuzimiTotalPerLende).HasMaxLength(50);

                entity.Property(e => e.VeprimiId).HasColumnName("VeprimiID");

                entity.Property(e => e.VitiAkademik).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
