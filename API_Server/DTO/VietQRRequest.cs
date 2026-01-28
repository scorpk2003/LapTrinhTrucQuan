namespace API_Server.src.DTO
{
    public class VietQRRequest
    {
        public string BankBin { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
