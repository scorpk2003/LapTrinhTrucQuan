using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyPhongTro.src.Services1
{
    public class BillService
    {
        private readonly ContractService _contractService;

        public BillService()
        {
            _contractService = new ContractService();
        }

        public List<Bill> GetBillsByMonth(int month, int year, Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills
                        .Include(b => b.IdRoomNavigation) 
                        .Include(b => b.IdPersonNavigation) 
                        .Include(b => b.BillDetails)
                            .ThenInclude(bd => bd.IdServiceNavigation)
                        .Where(b => b.IdRoomNavigation.IdOwner == ownerId && 
                                    b.PaymentDate.HasValue && 
                                    b.PaymentDate.Value.Month == month && 
                                    b.PaymentDate.Value.Year == year) 
                        .OrderBy(b => b.IdRoomNavigation.Name) 
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillsByMonth: {ex.Message}");
                return new List<Bill>();
            }
        }

        public List<Bill> GetUnpaidBills(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills 
                        .Include(b => b.IdRoomNavigation)
                        .Include(b => b.IdPersonNavigation)
                        .Where(b => b.IdRoomNavigation.IdOwner == ownerId &&
                                   (b.Payment == null || b.Payment.Amount < b.TotalMoney))
                        .OrderBy(b => b.PaymentDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetUnpaidBills: {ex.Message}");
                return new List<Bill>();
            }
        }

        public List<Bill> GetBillsByRenter(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills 
                        .Include(b => b.IdRoomNavigation)
                        .Where(b => b.IdPerson == renterId)
                        .OrderByDescending(b => b.PaymentDate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillsByRenter: {ex.Message}");
                return new List<Bill>();
            }
        }

        public Bill GetBillWithDetails(Guid billId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills
                        .AsNoTracking()
                        .Include(b => b.IdRoomNavigation)
                        .Include(b => b.IdPersonNavigation)
                        .Include(b => b.BillDetails)
                            .ThenInclude(bd => bd.IdServiceNavigation)
                        .Include(b => b.Payment)
                        .FirstOrDefault(b => b.Id == billId);
                    return bill;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillWithDetails: {ex.Message}");
                return null;
            }
        }

        public bool CreateBill(Bill bill, List<BillDetail> details = null)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.Bills.Add(bill);
                            context.SaveChanges();

                            if (details != null)
                            {
                                foreach (var detail in details)
                                {
                                    detail.IdBill = bill.Id;
                                    context.BillDetails.Add(detail);
                                }
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Lỗi CreateBill: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateBill (Outer): {ex.Message}");
                return false;
            }
        }

        // public bool UpdateBillStatus(Guid billId, string newStatus) { ... }

        public bool PayBill(Guid billId, decimal amount, string paymentMethod)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills.Include(b => b.Payment).FirstOrDefault(b => b.Id == billId); // Sửa
                    if (bill == null) return false;

                    if (bill.Payment == null)
                    {
                        // 1. Tạo mới Payment
                        var payment = new Payment
                        {
                            IdBill = billId,
                            Amount = amount,
                            PaymentMethod = paymentMethod,
                            PaymentDate = DateTime.Now
                        };
                        context.Payments.Add(payment);
                    }
                    else
                    {
                        // 2. Cập nhật Payment đã có (trả góp)
                        bill.Payment.Amount = (bill.Payment.Amount ?? 0) + amount;
                        bill.Payment.PaymentDate = DateTime.Now;
                        bill.Payment.PaymentMethod = paymentMethod;
                    }

                    // decimal totalPaid = bill.Payment.Amount ?? 0;
                    // if (totalPaid >= bill.TotalMoney)
                    // {
                    //    // (ucMyRoom sẽ tự set status)
                    // }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi PayBill: {ex.Message}");
                return false;
            }
        }

        public bool GenerateMonthlyBills(Guid ownerId, int month, int year)
        {
            try
            {
                var activeContracts = _contractService.GetAllActiveContractsByOwner(ownerId);
                using (var context = new AppContextDB())
                {
                    foreach (var contract in activeContracts)
                    {
                        // Kiểm tra Nullable
                        if (!contract.IdRoom.HasValue || !contract.IdRenter.HasValue)
                            continue;

                        var newBill = new Bill
                        {
                            IdRoom = contract.IdRoom.Value,
                            IdPerson = contract.IdRenter.Value,
                            PaymentDate = new DateTime(year, month, DateTime.DaysInMonth(year, month)),
                            TotalMoney = contract.IdRoomNavigation.Price ?? 0,
                        };
                        context.Bills.Add(newBill);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GenerateBills: {ex.Message}");
                return false;
            }
        }

        public bool ExportBillToPDF(Guid billId)
        {
            // 1. Lấy dữ liệu
            Bill billToExport = GetBillWithDetails(billId);
            if (billToExport == null)
            {
                MessageBox.Show("Không thể tải chi tiết hóa đơn.");
                return false;
            }

            // 2. Hỏi người dùng muốn lưu file ở đâu
            string filePath = "";
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Document|*.pdf";
                // Tạo tên file mặc định
                string roomName = billToExport.IdRoomNavigation?.Name ?? "HoaDon";
                string monthYear = billToExport.PaymentDate.HasValue ? billToExport.PaymentDate.Value.ToString("MM_yyyy") : "Unknown";
                sfd.FileName = $"HoaDon_{roomName}_{monthYear}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                filePath = sfd.FileName;
            }

            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(50);

                        page.Header()
                            .AlignCenter()
                            .Text("HOA DON TIEN PHONG")
                            .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .PaddingVertical(20)
                            .Column(col =>
                            {
                                col.Spacing(10); 

                                col.Item().Text($"Phong: {billToExport.IdRoomNavigation?.Name ?? "N/A"}");
                                col.Item().Text($"Nguoi thue: {billToExport.IdPersonNavigation?.Username ?? "N/A"}");
                                col.Item().Text($"Ngay chot hoa don: {(billToExport.PaymentDate.HasValue ? billToExport.PaymentDate.Value.ToString("dd/MM/yyyy") : "N/A")}");

                                string statusText = "Chưa thanh toán";
                                if (billToExport.Payment != null && billToExport.Payment.Amount >= billToExport.TotalMoney)
                                {
                                    statusText = "Đã thanh toán";
                                }
                                else if (billToExport.Payment != null)
                                {
                                    statusText = $"Đã thanh toán một phần ({billToExport.Payment.Amount:N0} VND)";
                                }
                                col.Item().Text($"Trang thai: {statusText}");

                                col.Item().PaddingTop(15).Text("--- CHI TIET DICH VU ---").Bold();

                                // Thêm tiền phòng
                                decimal roomPrice = (billToExport.TotalMoney ?? 0) - billToExport.BillDetails.Sum(d => d.Total ?? 0);
                                col.Item().Text($"- Tien phong: {roomPrice:N0} VND");

                                if (billToExport.BillDetails != null)
                                {
                                    foreach (var detail in billToExport.BillDetails)
                                    {
                                        string text = $"- {detail.IdServiceNavigation?.Name ?? "Dich vu"}: {detail.Total:N0} VND";
                                        col.Item().Text(text);
                                    }
                                }

                                col.Item().PaddingTop(20).Text($"TONG CONG: {billToExport.TotalMoney:N0} VND").Bold().FontSize(14);
                               
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Trang ");
                                x.CurrentPageNumber();
                            });
                    });
                })
                .GeneratePdf(filePath);

                // 4. Tự động mở file PDF
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo(filePath)
                    {
                        UseShellExecute = true
                    }
                };
                p.Start(); 

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExportPDF: {ex.Message}");
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Bill GetLatestUnpaidBill(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills 
                        .Include(b => b.Payment)
                        .Where(b => b.IdPerson == renterId && (b.Payment == null || b.Payment.Amount < b.TotalMoney))
                        .OrderByDescending(b => b.PaymentDate)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetLatestUnpaidBill: {ex.Message}");
                return null;
            }
        }

        public Dictionary<string, decimal> GetMonthlySpending(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    DateTime oneYearAgo = DateTime.Now.AddYears(-1);

                    var paidBills = context.Bills 
                        .Include(b => b.Payment)
                        .Where(b => b.IdPerson == renterId &&
                                    b.Payment != null && 
                                    b.Payment.Amount >= b.TotalMoney &&
                                    b.PaymentDate.HasValue &&
                                    b.PaymentDate.Value >= oneYearAgo) 
                        .ToList();

                    var spendingData = paidBills
                        .GroupBy(b => new { b.PaymentDate.Value.Year, b.PaymentDate.Value.Month }) // Sửa
                        .Select(g => new
                        {
                            Key = $"{g.Key.Month}/{g.Key.Year}",
                            Total = g.Sum(b => b.TotalMoney.Value) 
                        })
                        .ToDictionary(x => x.Key, x => x.Total);

                    return spendingData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetMonthlySpending: {ex.Message}");
                return new Dictionary<string, decimal>();
            }
        }

        public bool UpdateBillAndDetails(Guid billId, List<BillDetail> details, decimal newTotalMoney)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var oldDetails = context.BillDetails.Where(d => d.IdBill == billId); // Sửa
                            context.BillDetails.RemoveRange(oldDetails); // Sửa

                            foreach (var detail in details)
                            {
                                detail.IdBill = billId;
                                context.BillDetails.Add(detail); // Sửa
                            }

                            var bill = context.Bills.Find(billId); // Sửa
                            if (bill != null)
                            {
                                bill.TotalMoney = newTotalMoney;
                            }

                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Lỗi UpdateBillAndDetails: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateBillAndDetails (Outer): {ex.Message}");
                return false;
            }
        }
    }
}