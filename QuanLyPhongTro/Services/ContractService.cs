using QuanLyPhongTro.Data;
using System;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class ContractService
    {
        // EndContract(IdRenter) -> IdRenter = null, State = Empty
        // Logic đúng: Cập nhật Status của Contract
        /// <summary>
        /// Kết thúc một hợp đồng
        /// </summary>
        /// <param name="contractId">ID của hợp đồng</param>
        /// <returns>True nếu thành công</returns>
        public bool EndContract(Guid contractId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract = context.Contracts.Find(contractId);
                    if (contract == null)
                    {
                        return false; // Không tìm thấy hợp đồng
                    }

                    // Cập nhật trạng thái
                    contract.Status = "Expired"; // Hoặc "Cancelled", "Ended"
                    contract.EndDate = DateTime.Now; // Cập nhật ngày kết thúc

                    context.Contracts.Update(contract);

                    // Bạn cũng có thể muốn cập nhật trạng thái của phòng (Room.Status = "Trống")
                    var room = context.Rooms.Find(contract.IdRoom);
                    if (room != null)
                    {
                        room.Status = "Trống";
                        context.Rooms.Update(room);
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