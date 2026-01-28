using QuanLyPhongTro.src.Services1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace API_Server.src.Controllers
{
    [ApiController]
    [Route("api/qr-payment")]
    public class QRPaymentController : ControllerBase
    {
        private readonly QRPaymentService _service;

        public QRPaymentController()
        {
            _service = new QRPaymentService();
        }

        // ======================================================
        // 1. TẠO QR VIETQR (TRẢ ẢNH PNG)
        // ======================================================
        [HttpPost("vietqr")]
        public async Task<IActionResult> GenerateVietQR([FromBody] VietQRRequest request)
        {
            var bitmap = await _service.GenerateVietQRAsync(
                request.BankBin,
                request.AccountNo,
                request.AccountName,
                request.Amount,
                request.Description
            );

            if (bitmap == null)
                return BadRequest("Không tạo được QR Code");

            return BitmapToImageResult(bitmap);
        }

        // ======================================================
        // 2. TẠO QR ĐƠN GIẢN
        // ======================================================
        [HttpPost("simple")]
        public async Task<IActionResult> GenerateSimpleQR([FromBody] SimpleQRRequest request)
        {
            var bitmap = await _service.GenerateSimpleQRAsync(request.Content);
            if (bitmap == null)
                return BadRequest("Không tạo được QR Code");

            return BitmapToImageResult(bitmap);
        }

        // ======================================================
        // 3. TẠO NỘI DUNG CHUYỂN KHOẢN
        // ======================================================
        [HttpGet("description")]
        public IActionResult GenerateDescription(Guid billId, string roomName)
        {
            var desc = _service.GeneratePaymentDescription(billId, roomName);
            return Ok(desc);
        }

        // ======================================================
        // 4. KIỂM TRA THANH TOÁN (DEMO)
        // ======================================================
        [HttpGet("verify-demo")]
        public async Task<IActionResult> VerifyPaymentDemo(string description, decimal amount)
        {
            var result = await _service.VerifyPaymentFromBankAsync(description, amount);
            return Ok(new { isPaid = result });
        }

        // ======================================================
        // 5. KIỂM TRA THANH TOÁN QUA API (TEMPLATE)
        // ======================================================
        [HttpPost("verify-api")]
        public async Task<IActionResult> VerifyPaymentViaApi([FromBody] VerifyPaymentRequest request)
        {
            var result = await _service.VerifyPaymentViaAPIAsync(
                request.BankBin,
                request.AccountNo,
                request.Description,
                request.Amount,
                request.FromDate,
                request.ToDate
            );

            return Ok(result);
        }

        // ======================================================
        // 6. DANH SÁCH NGÂN HÀNG HỖ TRỢ
        // ======================================================
        [HttpGet("banks")]
        public async Task<IActionResult> GetBanks()
        {
            List<BankInfo> banks = await _service.GetSupportedBanksAsync();
            return Ok(banks);
        }

        // ======================================================
        // 7. VALIDATE TÀI KHOẢN NGÂN HÀNG
        // ======================================================
        [HttpGet("validate-bank")]
        public async Task<IActionResult> ValidateBank(string bankBin, string accountNo)
        {
            var result = await _service.ValidateBankAccountAsync(bankBin, accountNo);
            return Ok(result);
        }

        // ======================================================
        // HELPER: BITMAP -> PNG
        // ======================================================
        private IActionResult BitmapToImageResult(Bitmap bitmap)
        {
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            var imageBytes = ms.ToArray();

            return File(imageBytes, "image/png");
        }
    }

    // ======================================================
    // DTO REQUESTS
    // ======================================================
    public class VietQRRequest
    {
        public string BankBin { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }

    public class SimpleQRRequest
    {
        public string Content { get; set; }
    }

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
