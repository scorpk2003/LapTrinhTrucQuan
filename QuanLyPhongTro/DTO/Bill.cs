using System;
using System.Collections.Generic;
using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.DTO
{
    public class AddBillDetailsRequest
    {
        public Guid BillId { get; set; }
        public List<BillDetail> Details { get; set; }

        public AddBillDetailsRequest()
        {
            Details = new List<BillDetail>();
        }
    }

    public class BillDetailListResponse
    {
        public List<BillDetail> Details { get; set; }
        public int Count { get; set; }
    }

    public class BillTotalResponse
    {
        public Guid BillId { get; set; }
        public decimal TotalAmount { get; set; }
        public string FormattedAmount { get; set; }
    }

    public class BillDetailStatisticsResponse
    {
        public Guid BillId { get; set; }
        public StatisticsData Statistics { get; set; }
    }

    public class StatisticsData
    {
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalElectricity { get; set; }
        public decimal TotalWater { get; set; }
        public decimal AverageAmount { get; set; }
        public List<DetailSummary> Details { get; set; }
    }

    public class DetailSummary
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Electricity { get; set; }
        public decimal? Water { get; set; }
        public decimal? Total { get; set; }
    }
}