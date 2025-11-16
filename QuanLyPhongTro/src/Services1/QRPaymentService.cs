using QRCoder;
using System;
using System.Drawing;
using System.Text;

namespace QuanLyPhongTro.src.Services1
{
    public class QRPaymentService
    {
        /// <summary>
        /// Tạo QR Code theo chuẩn VietQR (EMVCo)
        /// </summary>
        /// <param name="bankBin">Mã BIN ngân hàng (VD: "970422" = MB Bank)</param>
        /// <param name="accountNo">Số tài khoản</param>
        /// <param name="accountName">Tên chủ tài khoản</param>
        /// <param name="amount">Số tiền (ĐÚNG = _bill.TotalMoney)</param>
        /// <param name="description">Nội dung chuyển khoản</param>
        /// <returns>Bitmap QR Code chuẩn VietQR</returns>
        public Bitmap GenerateVietQR(string bankBin, string accountNo, string accountName, 
            decimal amount, string description)
        {
            try
            {
                // --- TẠO QR THEO CHUẨN EMVCo (VietQR) ---
                string qrContent = BuildVietQRContent(bankBin, accountNo, accountName, amount, description);

                // Log để kiểm tra
                System.Diagnostics.Debug.WriteLine($"=== QR Content ===");
                System.Diagnostics.Debug.WriteLine(qrContent);
                System.Diagnostics.Debug.WriteLine($"Số tiền: {amount:N0} VND");

                // Tạo QR Code
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.M);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(10);
                        return new Bitmap(qrCodeImage);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GenerateVietQR: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xây dựng nội dung QR theo chuẩn VietQR (EMVCo)
        /// </summary>
        private string BuildVietQRContent(string bankBin, string accountNo, string accountName,
            decimal amount, string description)
        {
            StringBuilder qr = new StringBuilder();

            // 00: Payload Format Indicator
            qr.Append(BuildTLV("00", "01"));

            // 01: Point of Initiation Method (12 = QR tĩnh có số tiền)
            qr.Append(BuildTLV("01", "12"));

            // 38: Merchant Account Information (VietQR)
            string merchantInfo = BuildVietQRMerchantInfo(bankBin, accountNo);
            qr.Append(BuildTLV("38", merchantInfo));

            // 52: Merchant Category Code
            qr.Append(BuildTLV("52", "0000"));

            // 53: Transaction Currency (704 = VND)
            qr.Append(BuildTLV("53", "704"));

            // 54: Transaction Amount (Số tiền - QUAN TRỌNG!)
            qr.Append(BuildTLV("54", amount.ToString("0.00"))); // Format: 1000000.00

            // 58: Country Code
            qr.Append(BuildTLV("58", "VN"));

            // 59: Merchant Name (Tên người nhận)
            qr.Append(BuildTLV("59", NormalizeVietnamese(accountName)));

            // 60: Merchant City
            qr.Append(BuildTLV("60", "HO CHI MINH"));

            // 62: Additional Data (Nội dung chuyển khoản)
            string additionalData = BuildTLV("08", description); // 08 = Purpose of Transaction
            qr.Append(BuildTLV("62", additionalData));

            // 63: CRC (tính sau)
            string crc = CalculateCRC(qr.ToString() + "6304");
            qr.Append("6304").Append(crc);

            return qr.ToString();
        }

        /// <summary>
        /// Xây dựng Merchant Account Info (Tag 38)
        /// </summary>
        private string BuildVietQRMerchantInfo(string bankBin, string accountNo)
        {
            StringBuilder merchant = new StringBuilder();
            
            // 00: GUID (VietQR)
            merchant.Append(BuildTLV("00", "A000000727"));
            
            // 01: Beneficiary Organization (Bank BIN + Account Number)
            string beneficiary = bankBin + accountNo;
            merchant.Append(BuildTLV("01", beneficiary));

            // 02: Service Code (QRIBFTTA = Chuyển khoản nhanh)
            merchant.Append(BuildTLV("02", "QRIBFTTA"));

            return merchant.ToString();
        }

        /// <summary>
        /// Xây dựng TLV (Tag-Length-Value)
        /// </summary>
        private string BuildTLV(string tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            int length = Encoding.UTF8.GetByteCount(value);
            return $"{tag}{length:D2}{value}";
        }

        /// <summary>
        /// Tính CRC-16/CCITT-FALSE
        /// </summary>
        private string CalculateCRC(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            ushort crc = 0xFFFF;

            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                        crc = (ushort)(crc << 1 ^ 0x1021);
                    else
                        crc <<= 1;
                }
            }

            return (crc & 0xFFFF).ToString("X4");
        }

        /// <summary>
        /// Chuẩn hóa tiếng Việt (bỏ dấu) cho QR
        /// </summary>
        private string NormalizeVietnamese(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Bảng chuyển đổi
            string[] vietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâẤẦẬẨẪăẮẰẶẲẴ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôỐỒỘỔỖơỚỜỢỞỠ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                {
                    text = text.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
                }
            }

            return text.ToUpper();
        }

        /// <summary>
        /// Tạo mô tả giao dịch
        /// </summary>
        public string GeneratePaymentDescription(Guid billId, string roomName)
        {
            // Giới hạn 25 ký tự (chuẩn VietQR)
            string shortId = billId.ToString().Substring(0, 8).ToUpper();
            string desc = $"THANHTOAN {roomName} {shortId}";
            
            // Bỏ dấu và giới hạn độ dài
            desc = NormalizeVietnamese(desc);
            if (desc.Length > 25)
                desc = desc.Substring(0, 25);

            return desc;
        }

        /// <summary>
        /// Kiểm tra thanh toán qua Bank API (TODO: Tích hợp thực tế)
        /// </summary>
        public bool VerifyPaymentFromBank(string transactionDescription, decimal expectedAmount)
        {
            // ==========================================
            // ⚠️ ĐÂY LÀ DEMO - KHÔNG HOẠT ĐỘNG THẬT
            // ==========================================
            // Để kiểm tra thanh toán THẬT, bạn cần:
            // 1. Đăng ký API với ngân hàng (MB Bank, VietcomBank, VietQR API...)
            // 2. Lấy Access Token
            // 3. Gọi API lấy lịch sử giao dịch
            // 4. So sánh Description và Amount
            // 5. Trả về true nếu tìm thấy

            System.Diagnostics.Debug.WriteLine($"[TODO] Verify payment: {transactionDescription} - {expectedAmount:N0} VND");
            
            return false; // Mặc định: chưa thanh toán
        }
    }
}