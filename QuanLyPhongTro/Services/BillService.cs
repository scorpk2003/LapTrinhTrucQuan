using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
// Cần cài NuGet 'QuestPDF'
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace QuanLyPhongTro.Services
{
    public class BillService
    {
        private readonly ContractService _contractService;

        public BillService()
        {
            _contractService = new ContractService();
        }

        // (CreateBill, GetBillWithDetails, PayBill, UpdateBillStatus...)
        // (Tất cả các hàm này giữ nguyên như code trước)

        #region Các hàm nghiệp vụ (Giữ nguyên)

        /// <summary>
        /// (Hàm Gốc) Tạo hóa đơn mới và các chi tiết của nó
        /// </summary>
        public bool CreateBill(Bill bill, List<BillDetail> details)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(bill.Status))
                            {
                                bill.Status = "Pending"; // "Chờ gửi"
                            }
                            context.Bills.Add(bill);
                            context.SaveChanges();

                            foreach (var detail in details)
                            {
                                detail.IdBill = bill.Id;
                                context.BillDetails.Add(detail);
                            }
                            context.SaveChanges();

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

        /// <summary>
        /// (Hàm Gốc) Lấy thông tin hóa đơn và tất cả chi tiết
        /// </summary>
        public Bill GetBillWithDetails(Guid billId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills
                        .AsNoTracking() // Dùng cho PDF (chỉ đọc)
                        .Include(b => b.Room)
                        .Include(b => b.Person) // Tải người thuê
                        .Include(b => b.BillDetails)
                            .ThenInclude(bd => bd.Service)
                        .Include(b => b.Payments)
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

        /// <summary>
        /// (Hàm Cải Tiến) Ghi nhận thanh toán VÀ cập nhật trạng thái
        /// </summary>
        public bool PayBill(Guid billId, decimal amount, string paymentMethod)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills.Include(b => b.Payments).FirstOrDefault(b => b.Id == billId);
                    if (bill == null) return false;

                    var payment = new Payment
                    {
                        IdBill = billId,
                        Amount = amount,
                        PaymentMethod = paymentMethod,
                        PaymentDate = DateTime.Now
                    };
                    context.Payments.Add(payment);

                    decimal totalPaid = bill.Payments.Sum(p => p.Amount) + amount;

                    if (totalPaid >= bill.TotalMoney)
                    {
                        bill.Status = "Paid";
                    }

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

        /// <summary>
        /// (Hàm Mới) Cập nhật trạng thái (Gửi Hóa đơn / Nhắc nợ)
        /// </summary>
        public bool UpdateBillStatus(Guid billId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills.Find(billId);
                    if (bill == null) return false;

                    if (newStatus == "Sent" || newStatus == "Paid" || newStatus == "Overdue")
                    {
                        bill.Status = newStatus;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateBillStatus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// (Hàm Mới) Lấy hóa đơn theo tháng/năm của Chủ trọ (để Lọc)
        /// </summary>
        public List<Bill> GetBillsByMonth(int month, int year, Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills
                        .Include(b => b.Room)
                        .Include(b => b.Person)
                        .Include(b => b.BillDetails)
                            .ThenInclude(bd => bd.Service)
                        .Where(b => b.Room.IdOwner == ownerId &&
                                    b.PaymentDate.Month == month &&
                                    b.PaymentDate.Year == year)
                        .OrderBy(b => b.Room.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillsByMonth: {ex.Message}");
                return new List<Bill>();
            }
        }

        /// <summary>
        /// (Hàm Mới) Lấy tất cả hóa đơn CHƯA THANH TOÁN (để Nhắc nợ)
        /// </summary>
        public List<Bill> GetUnpaidBills(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Bills
                        .Include(b => b.Room)
                        .Include(b => b.Person)
                        .Where(b => b.Room.IdOwner == ownerId &&
                                   (b.Status == "Sent" || b.Status == "Overdue" || b.Status == "Pending"))
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

        /// <summary>
        /// (Hàm Mới) Tự động tạo hóa đơn nháp (Pending)
        /// </summary>
        public bool GenerateMonthlyBills(Guid ownerId, int month, int year)
        {
            try
            {
                var activeContracts = _contractService.GetAllActiveContractsByOwner(ownerId);
                using (var context = new AppContextDB())
                {
                    foreach (var contract in activeContracts)
                    {
                        // TODO: Mở 1 Form/UI để nhập chi tiết (điện, nước,...)
                        var newBill = new Bill
                        {
                            IdRoom = contract.IdRoom,
                            IdPerson = contract.IdRenter,
                            PaymentDate = new DateTime(year, month, DateTime.DaysInMonth(year, month)),
                            TotalMoney = contract.Room.Price ?? 0,
                            Status = "Pending"
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

        #endregion

        /// <summary>
        /// (Hàm Mới - ĐÃ SỬA LỖI) Xuất hóa đơn ra file PDF
        /// </summary>
        public bool ExportBillToPDF(Guid billId)
        {
            Bill billToExport = GetBillWithDetails(billId);
            if (billToExport == null) return false;

            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "Bills");
                Directory.CreateDirectory(folderPath);
                string fileName = $"HoaDon_{billToExport.Room.Name}_{billToExport.PaymentDate:MM-yyyy}.pdf";
                string filePath = Path.Combine(folderPath, fileName);

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(50);
                        page.DefaultTextStyle(style => style.FontFamily(Fonts.Arial));

                        // Header
                        page.Header()
                            .Text("HOA DON TIEN NHA")
                            .SemiBold().FontSize(20).FontColor(Colors.Black);

                        // Content
                        page.Content()
                            .PaddingTop(1, Unit.Centimetre)
                            .Column(col =>
                            {
                                col.Spacing(10);
                                col.Item().Text($"Phong: {billToExport.Room.Name}");
                                col.Item().Text($"Nguoi thue: {billToExport.Person?.Username ?? "N/A"}");
                                col.Item().Text($"Ngay chot hoa don: {billToExport.PaymentDate:dd/MM/yyyy}");
                                col.Item().Text($"Trang thai: {billToExport.Status}");

                                // --- SỬA LỖI Ở ĐÂY ---
                                col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2); // Bỏ .Solid()

                                // Chi tiết
                                if (billToExport.BillDetails != null)
                                {
                                    foreach (var detail in billToExport.BillDetails)
                                    {
                                        string text = $"- {detail.Service?.Name ?? "Dich vu"}: {detail.Total:N0} VND";
                                        if (!string.IsNullOrEmpty(detail.Note))
                                        {
                                            text += $" (Ghi chu: {detail.Note})";
                                        }
                                        col.Item().Text(text);
                                    }
                                }

                                // --- SỬA LỖI Ở ĐÂY ---
                                col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2); // Bỏ .Solid()

                                // Tổng tiền
                                col.Item().Text($"TONG CONG: {billToExport.TotalMoney:N0} VND")
                                    .Bold().FontSize(16);
                            });

                        // Footer
                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Trang ");
                                x.CurrentPageNumber();
                            });
                    });
                }).GeneratePdf(filePath);

                // Mở file PDF
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExportPDF: {ex.Message}");
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}