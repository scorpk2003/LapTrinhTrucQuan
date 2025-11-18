using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Models;

public partial class AppContextDB : DbContext
{
    public AppContextDB()
    {
    }

    public AppContextDB(DbContextOptions<AppContextDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonDetail> PersonDetails { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<Service> Services { get; set; }
     public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<BookingRequest> BookingRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=database-1.cxcm0uk2un5e.ap-southeast-2.rds.amazonaws.com;Database=QLPT;Persist Security Info=True;User ID=admin;Password=6251071045;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bill__3214EC07971BEEA9");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Bills).HasConstraintName("FK__Bill__IdPerson__5DCAEF64");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Bills).HasConstraintName("FK__Bill__IdRoom__5CD6CB2B");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillDeta__3214EC073E2B9BA4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdBillNavigation).WithOne(p => p.BillDetails).HasConstraintName("FK__BillDetai__IdBil__619B8048");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.BillDetails).HasConstraintName("FK__BillDetai__IdSer__628FA481");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC07A2341402");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdRenterNavigation).WithMany(p => p.Contracts).HasConstraintName("FK__Contract__IdRent__59063A47");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Contracts).HasConstraintName("FK__Contract__IdRoom__5812160E");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notice__3214EC071255475A");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdreportNavigation)
                  .WithOne(r => r.Notice)      // 1–1, dùng WithOne()
                  .HasForeignKey<Notice>(d => d.Idreport)  // FK trong Notice
                  .HasConstraintName("FK__Notice__IDReport__74AE54BC");
        });


        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdBill).HasName("PK__Payment__24A2D64DE1749AF2");

            entity.Property(e => e.IdBill).ValueGeneratedNever();

            entity.HasOne(d => d.IdPaymentNavigation).WithOne(p => p.Payment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__IdBill__778AC167");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC07FDB564BD");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdDetailNavigation).WithOne(p => p.People).HasConstraintName("FK__Person__IdDetail__4D94879B");
        });

        modelBuilder.Entity<PersonDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonDe__3214EC074CE93A01");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Report__3214EC073003D7A2");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.IdReporterNavigation).WithMany(p => p.Reports).HasConstraintName("FK__Report__IdReport__6E01572D");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Reports).HasConstraintName("FK__Report__IdRoom__6EF57B66");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC0720EB1BA5");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Rooms).HasConstraintName("FK__Room__IdOwner__5165187F");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomImag__3214EC07E1465E24");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.RoomImages).HasConstraintName("FK__RoomImage__IdRoo__6A30C649");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC0786630AD1");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
