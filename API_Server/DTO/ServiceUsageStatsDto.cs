namespace API_Server.src.DTO
{
    public class ServiceUsageStatsDto
    {
        public Guid ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public int UsageCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
