namespace QuanLyPhongTro.src.DTO
{
    public class ServiceStatisticsDto
    {
        public int TotalServices { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
