using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Entities;

namespace QuanLyPhongTro.Data;

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

    public virtual DbSet<BookingRequest> BookingRequests { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ListRoom> ListRooms { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonDetail> PersonDetails { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-79S96USJ\\MSSQLSERVER2022;Database=QLPT_Local;User ID=sa;Password=1234567;Trust Server Certificate=True;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bill__3214EC07971BEEA9");

            entity.ToTable("Bill");

            entity.HasIndex(e => e.IdPerson, "IX_Bill_IdPerson");

            entity.HasIndex(e => e.IdRoom, "IX_Bill_IdRoom");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue("");
            entity.Property(e => e.TotalMoney).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__Bill__IdPerson__5DCAEF64");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("FK__Bill__IdRoom__5CD6CB2B");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillDeta__3214EC073E2B9BA4");

            entity.ToTable("BillDetail");

            entity.HasIndex(e => e.IdBill, "IX_BillDetail_IdBill")
                .IsUnique()
                .HasFilter("([IdBill] IS NOT NULL)");

            entity.HasIndex(e => e.IdService, "IX_BillDetail_IdService");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Electricity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Water).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdBillNavigation).WithOne(p => p.BillDetail)
                .HasForeignKey<BillDetail>(d => d.IdBill)
                .HasConstraintName("FK__BillDetai__IdBil__619B8048");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.BillDetails)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("FK__BillDetai__IdSer__628FA481");
        });

        modelBuilder.Entity<BookingRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookingRequest__3214EC07");

            entity.ToTable("BookingRequest");

            entity.HasIndex(e => e.IdRenter, "IX_BookingRequest_IdRenter");

            entity.HasIndex(e => e.IdRoom, "IX_BookingRequest_IdRoom");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.IdRenterNavigation).WithMany(p => p.BookingRequests)
                .HasForeignKey(d => d.IdRenter)
                .HasConstraintName("FK__BookingRequest__IdRenter");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.BookingRequests)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("FK__BookingRequest__IdRoom");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC07A2341402");

            entity.ToTable("Contract");

            entity.HasIndex(e => e.IdRenter, "IX_Contract_IdRenter");

            entity.HasIndex(e => e.IdRoom, "IX_Contract_IdRoom");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Deposit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.IdRenterNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdRenter)
                .HasConstraintName("FK__Contract__IdRent__59063A47");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("FK__Contract__IdRoom__5812160E");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasIndex(e => e.IdOwner, "IX_Expenses_IdOwner");

            entity.HasIndex(e => e.IdRoom, "IX_Expenses_IdRoom");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Category).HasMaxLength(100);

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Expenses).HasForeignKey(d => d.IdOwner);

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Expenses).HasForeignKey(d => d.IdRoom);
        });

        modelBuilder.Entity<ListRoom>(entity =>
        {
            entity.ToTable("ListRoom");

            entity.HasIndex(e => e.IdOwner, "IX_ListRoom_IdOwner");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.ListRooms).HasForeignKey(d => d.IdOwner);
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notice__3214EC071255475A");

            entity.ToTable("Notice");

            entity.HasIndex(e => e.Idreport, "IX_Notice_IDReport")
                .IsUnique()
                .HasFilter("([IDReport] IS NOT NULL)");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Idreport).HasColumnName("IDReport");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.IdreportNavigation).WithOne(p => p.Notice)
                .HasForeignKey<Notice>(d => d.Idreport)
                .HasConstraintName("FK__Notice__IDReport__74AE54BC");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdBill).HasName("PK__Payment__24A2D64DE1749AF2");

            entity.ToTable("Payment");

            entity.Property(e => e.IdBill).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.IdBillNavigation).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__IdBill__778AC167");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC07FDB564BD");

            entity.ToTable("Person");

            entity.HasIndex(e => e.IdDetail, "IX_Person_IdDetail")
                .IsUnique()
                .HasFilter("([IdDetail] IS NOT NULL)");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdDetailNavigation).WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.IdDetail)
                .HasConstraintName("FK__Person__IdDetail__4D94879B");
        });

        modelBuilder.Entity<PersonDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonDe__3214EC074CE93A01");

            entity.ToTable("PersonDetail");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Gmail).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Report__3214EC073003D7A2");

            entity.ToTable("Report");

            entity.HasIndex(e => e.IdReporter, "IX_Report_IdReporter");

            entity.HasIndex(e => e.IdRoom, "IX_Report_IdRoom");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.IdReporterNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdReporter)
                .HasConstraintName("FK__Report__IdReport__6E01572D");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("FK__Report__IdRoom__6EF57B66");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC0720EB1BA5");

            entity.ToTable("Room");

            entity.HasIndex(e => e.IdListRoom, "IX_Room_IdListRoom");

            entity.HasIndex(e => e.IdOwner, "IX_Room_IdOwner");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Area).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.IdListRoomNavigation).WithMany(p => p.Rooms).HasForeignKey(d => d.IdListRoom);

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.IdOwner)
                .HasConstraintName("FK__Room__IdOwner__5165187F");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomImag__3214EC07E1465E24");

            entity.ToTable("RoomImage");

            entity.HasIndex(e => e.IdRoom, "IX_RoomImage_IdRoom");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.RoomImages)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("FK__RoomImage__IdRoo__6A30C649");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC0786630AD1");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
