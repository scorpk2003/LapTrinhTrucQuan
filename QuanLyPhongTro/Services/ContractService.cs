using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class ContractService
    {
        /// <summary>
        /// Lấy hợp đồng đang hoạt động (Active) của một phòng
        /// </summary>
        /// <param name="roomId">ID của phòng</param>
        /// <returns>Hợp đồng (đã bao gồm thông tin người thuê)</returns>
        public Contract? GetActiveContractByRoom(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts
                        .AsNoTracking()
                        .Include(c => c.Renter) // Tải thông tin Người thuê
                        .Include(c => c.Room)   // Tải thông tin Phòng (nếu cần hiển thị)
                        .FirstOrDefault(c => c.IdRoom == roomId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContractByRoom: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Kết thúc một hợp đồng (đặt Status = "Expired", cập nhật EndDate, và chuyển phòng về trạng thái "Trống")
        /// </summary>
        /// <param name="contractId">ID của hợp đồng</param>
        /// <returns>True nếu thành công</returns>
        public bool EndContract(Guid contractId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract = context.Contracts.FirstOrDefault(c => c.Id == contractId);
                    if (contract == null)
                    {
                        return false; // Không tìm thấy hợp đồng
                    }

                    // Cập nhật trạng thái hợp đồng
                    contract.Status = "Expired"; // Hoặc "Cancelled", "Ended"
                    contract.EndDate = DateTime.Now; // Cập nhật ngày kết thúc

                    // Optional: clear link renter nếu business muốn
                    // contract.IdRenter = null;

                    context.Contracts.Update(contract);

                    // Cập nhật trạng thái phòng nếu có IdRoom
                    if (contract.IdRoom.HasValue)
                    {
                        var room = context.Rooms.FirstOrDefault(r => r.Id == contract.IdRoom.Value);
                        if (room != null)
                        {
                            room.Status = "Trống";
                            context.Rooms.Update(room);
                        }
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi EndContract: {ex.Message}");
                return false;
            }
        }
    }
}