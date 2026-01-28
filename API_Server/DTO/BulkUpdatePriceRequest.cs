namespace API_Server.src.DTO
{
    public class BulkUpdatePriceRequest
    {
        public List<Guid> ServiceIds { get; set; } = new();
        public decimal NewPrice { get; set; }
    }
}
