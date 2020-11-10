using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bank_DB.Models;

namespace Bank_DB.Data
{
    public partial class BankContext : DbContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Depositors> Depositors { get; set; }
        public virtual DbSet<Deposits> Deposits { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
             //   optionsBuilder.UseSqlite("Data Source=D:\\program files\\SQLiteStudio-3.2.1\\Bank\\Bank.db");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bank.db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExchangeRate).HasColumnType("INT");

                entity.Property(e => e.Name).HasColumnType("INT");
            });

            modelBuilder.Entity<Depositors>(entity =>
            {
                entity.HasKey(e => e.PassData);

                entity.Property(e => e.PassData)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress).HasColumnType("VARCHAR");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepRafMark).HasColumnType("INT");

                entity.Property(e => e.DeposDate).HasColumnType("DATETIME");

                entity.Property(e => e.FullName).HasColumnType("VARCHAR");

                entity.Property(e => e.PhoneNum).HasColumnType("INT");

                entity.Property(e => e.RefundDate).HasColumnType("DATETIME");

                entity.Property(e => e.SummAm).HasColumnType("INT");

                entity.Property(e => e.SummRef).HasColumnType("INT");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Depositors)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Deposits>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddCond).HasColumnType("INT");

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepName).HasColumnType("VARCHAR");

                entity.Property(e => e.MinDepAmount).HasColumnType("INT");

                entity.Property(e => e.MinDepTern).HasColumnType("INT");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.CurId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmId);

                entity.Property(e => e.EmId)
                    .HasColumnName("EmID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress).HasColumnType("VARCHAR");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_Name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Gender).HasColumnType("CHAR");

                entity.Property(e => e.PassData).HasColumnType("INT");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT");

                entity.Property(e => e.Telephone).HasColumnType("VARCHAR");

                entity.HasOne(d => d.PassDataNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PassData)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.ToTable("positions");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.PosName).HasColumnType("VARCHAR");

                entity.Property(e => e.Requirements).HasColumnType("INT");

                entity.Property(e => e.Responsibilities).HasColumnType("INT");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
