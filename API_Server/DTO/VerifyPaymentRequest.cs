namespace API_Server.src.DTO
{
    public class VerifyPaymentRequest
    {
        public string BankBin { get; set; }
        public string AccountNo { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
