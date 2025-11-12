using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro.Services
{
    public class PaymentServices
    {
        /// <summary>
        /// Lấy danh sách thanh toán theo BillId
        /// </summary>
        public List<Payment> GetPaymentsByBillId(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();
                return context.Payments
                              .Where(p => p.IdBill == billId)
                              .OrderBy(p => p.PaymentDate)
                              .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPaymentsByBillId: {ex.Message}");
                return new List<Payment>();
            }
        }

        /// <summary>
        /// Thêm một thanh toán mới
        /// </summary>
        public bool AddPayment(Payment payment)
        {
            try
            {
                using var context = new AppContextDB();
                context.Payments.Add(payment);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddPayment: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thanh toán
        /// </summary>
        public bool UpdatePayment(Payment payment)
        {
            try
            {
                using var context = new AppContextDB();
                var existing = context.Payments.Find(payment.Id);
                if (existing == null) return false;

                existing.Amount = payment.Amount;
                existing.PaymentMethod = payment.PaymentMethod;
                existing.PaymentDate = payment.PaymentDate;
                existing.Note = payment.Note;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdatePayment: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa thanh toán theo Id
        /// </summary>
        public bool DeletePayment(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var payment = context.Payments.Find(id);
                if (payment == null) return false;

                context.Payments.Remove(payment);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeletePayment: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tính tổng tiền đã thanh toán cho một hóa đơn
        /// </summary>
        public decimal GetTotalPaid(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();
                return context.Payments
                              .Where(p => p.IdBill == billId)
                              .Sum(p => p.Amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalPaid: {ex.Message}");
                return 0;
            }
        }
    }
}
