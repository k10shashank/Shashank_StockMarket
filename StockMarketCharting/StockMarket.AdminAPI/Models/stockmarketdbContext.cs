using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockMarket.AdminAPI.Models
{
    public partial class stockmarketdbContext : DbContext
    {
        public stockmarketdbContext()
        {
        }

        public stockmarketdbContext(DbContextOptions<stockmarketdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<Stockexchange> Stockexchange { get; set; }
        public virtual DbSet<Stockprice> Stockprice { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-O2L7GG2;Initial Catalog=stockmarketdb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);

                entity.ToTable("company");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("companyCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoardDirector)
                    .HasColumnName("boardDirector")
                    .HasMaxLength(50);

                entity.Property(e => e.Ceo)
                    .HasColumnName("ceo")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(50);

                entity.Property(e => e.ListedStockExchange)
                    .HasColumnName("listedStockExchange")
                    .HasMaxLength(50);

                entity.Property(e => e.SectorId).HasColumnName("sectorID");

                entity.Property(e => e.Turnover).HasColumnName("turnover");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_company_sector");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("sector");

                entity.Property(e => e.SectorId)
                    .HasColumnName("sectorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Brief)
                    .HasColumnName("brief")
                    .HasMaxLength(50);

                entity.Property(e => e.SectorName)
                    .IsRequired()
                    .HasColumnName("sectorName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stockexchange>(entity =>
            {
                entity.ToTable("stockexchange");

                entity.Property(e => e.StockExchangeId)
                    .HasColumnName("stockExchangeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Brief)
                    .HasColumnName("brief")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(50);

                entity.Property(e => e.StockExchangeName)
                    .IsRequired()
                    .HasColumnName("stockExchangeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stockprice>(entity =>
            {
                entity.ToTable("stockprice");

                entity.Property(e => e.StockpriceId).HasColumnName("stockpriceID");

                entity.Property(e => e.CompanyCode).HasColumnName("companyCode");

                entity.Property(e => e.CurrentPrice).HasColumnName("currentPrice");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.StockExchangeId).HasColumnName("stockExchangeID");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.Stockprice)
                    .HasForeignKey(d => d.CompanyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stockprice_company");

                entity.HasOne(d => d.StockExchange)
                    .WithMany(p => p.Stockprice)
                    .HasForeignKey(d => d.StockExchangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stockprice_stockexchange");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Confirmed)
                    .HasColumnName("confirmed")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("userType")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
