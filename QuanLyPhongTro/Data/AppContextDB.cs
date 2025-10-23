using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Model;



namespace QuanLyPhongTro.Data
{
    // Đặt tên là AppDbContext thay vì AppContextDB (chuẩn EF Core)
    public class AppContextDB : DbContext
    {
        // Các bảng (DbSet) trong cơ sở dữ liệu
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonDetailcs> PersonDetails { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        // Cấu hình kết nối đến SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(
                   @"Server=LAPTOP-79S96USJ\MSSQLSERVER2022;Database=QLPT;User Id=sa;Password=1234567;TrustServerCertificate=True;");


            }
        }
    }
}