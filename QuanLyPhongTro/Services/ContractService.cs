using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
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
        public Contract GetActiveContractByRoom(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts
                        .AsNoTracking()
                        .Include(c => c.Renter) // Tải thông tin Người thuê
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
        /// Lấy hợp đồng (và phòng) mà người thuê đang ở
        /// </summary>
        /// <param name="renterId">ID của người thuê</param>
        /// <returns>Hợp đồng đang hoạt động</returns>
        public Contract GetActiveContractByRenter(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts
                        .Include(c => c.Room) // Lấy luôn thông tin Phòng
                        .FirstOrDefault(c => c.IdRenter == renterId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContract: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// (Dùng cho BillService) Lấy TẤT CẢ hợp đồng đang hoạt động của một chủ trọ
        /// </summary>
        public List<Contract> GetAllActiveContractsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts
                        .Include(c => c.Room)
                        .Include(c => c.Renter)
                        .Where(c => c.Status == "Active" && c.Room.IdOwner == ownerId)
                        .OrderBy(c => c.Room.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllActiveContracts: {ex.Message}");
                return new List<Contract>();
            }
        }

        /// <summary>
        /// Tạo hợp đồng MỚI (và cập nhật trạng thái phòng)
        /// </summary>
        public bool CreateContract(Contract contract)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Kiểm tra phòng
                            var room = context.Rooms.Find(contract.IdRoom);
                            if (room == null || room.Status != "Còn trống")
                            {
                                // Phòng đã bị thuê
                                return false;
                            }

                            // 2. Cập nhật phòng
                            room.Status = "Đã thuê";
                            context.Rooms.Update(room);

                            // 3. Tạo hợp đồng
                            contract.Status = "Active"; // Đặt là Active
                            context.Contracts.Add(contract);

                            // 4. Lưu cả 2 thay đổi
                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Lỗi CreateContract: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateContract (Outer): {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Kết thúc một hợp đồng (Cập nhật HĐ và Phòng)
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
                        return false;
                    }

                    // 1. Cập nhật trạng thái hợp đồng
                    contract.Status = "Expired";
                    contract.EndDate = DateTime.Now;
                    context.Contracts.Update(contract);

                    // 2. Cập nhật trạng thái phòng
                    if (contract.IdRoom.HasValue)
                    {
                        var room = context.Rooms.FirstOrDefault(r => r.Id == contract.IdRoom.Value);
                        if (room != null)
                        {
                            room.Status = "Trống";
                            context.Rooms.Update(room);
                        }
                    }

                    // 3. Lưu cả 2 thay đổi
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