using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Models;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Services
{
    public class BillService
    {
        // CreateBill(Bill) -> Bill, BillDetail
        /// <summary>
        /// Tạo hóa đơn mới và các chi tiết của nó
        /// </summary>
        /// <param name="bill">Đối tượng Bill (đã có IdRoom, IdPerson, TotalMoney)</param>
        /// <param name="details">Danh sách các chi tiết hóa đơn (BillDetail)</param>
        /// <returns>True nếu tạo thành công</returns>
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
                            // 1. Lưu Hóa đơn
                            context.Bills.Add(bill);
                            bill.Id = Guid.NewGuid(); // Đảm bảo có ID mới
                            context.SaveChanges();

                            // 2. Gán BillId cho các chi tiết và lưu
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

        // GetBill(IdBill) -> GetBillDetail
        /// <summary>
        /// Lấy thông tin hóa đơn và tất cả chi tiết
        /// </summary>
        /// <param name="billId">ID Hóa đơn</param>
        /// <returns>Đối tượng Bill (đã include chi tiết)</returns>
        public Bill GetBillWithDetails(Guid billId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills
                        .Include(b => b.BillDetails) // Tải chi tiết
                            .ThenInclude(bd => bd.IdServiceNavigation) // Tải tên dịch vụ
                        .Include(b => b.Payment) // Tải các lần thanh toán
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

        // PayBill(IdBill) -> State = Paid
        // Logic đúng: Tạo một record trong bảng Payment
        /// <summary>
        /// Ghi nhận một lần thanh toán cho hóa đơn
        /// </summary>
        /// <param name="billId">ID hóa đơn</param>
        /// <param name="amount">Số tiền thanh toán</param>
        /// <param name="paymentMethod">Phương thức (Tiền mặt, CK...)</param>
        /// <returns>True nếu thành công</returns>
        public bool PayBill(Guid billId, string paymentMethod)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var bill = context.Bills.Find(billId);
                    if (bill == null || context.Payments.Any(p => p.IdBill == billId))
                    {
                        System.Diagnostics.Debug.WriteLine("Không có Bill hoặc Bill đã thanh toán trước đó");
                        return false;
                    }


                    var payment = new Payment
                    {
                        IdBill = billId,
                        Amount = (decimal)bill!.TotalMoney,
                        PaymentMethod = paymentMethod,
                        PaymentDate = DateTime.Now
                    };

                    context.Payments.Add(payment);
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
    }
}