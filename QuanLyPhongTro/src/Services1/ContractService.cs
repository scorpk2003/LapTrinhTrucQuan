using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Services1
{
    public class ContractService
    {
        public  async Task <Contract> GetActiveContractByRoomAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts 
                        .AsNoTracking()
                        .Include(c => c.IdRenterNavigation) 
                        .FirstOrDefaultAsync(c => c.IdRoom == roomId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContractByRoom: {ex.Message}");
                return null;
            }
        }

        public async Task< Contract> GetActiveContractByRenterAsync(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts 
                        .Include(c => c.IdRoomNavigation)
                        .FirstOrDefaultAsync(c => c.IdRenter == renterId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContractAsync: {ex.Message}");
                return null;
            }
        }

        public  async Task <List<Contract>> GetAllActiveContractsByOwnerAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return  await context.Contracts 
                        .Include(c => c.IdRoomNavigation) 
                        .Include(c => c.IdRenterNavigation) 
                        .Where(c => c.Status == "Active" && c.IdRoomNavigation.IdOwner == ownerId) 
                        .OrderBy(c => c.IdRoomNavigation.Name)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllActiveContracts: {ex.Message}");
                return new List<Contract>();
            }
        }

        public async Task< bool> CreateContractAsync(Contract contract)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await  context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            if (!contract.IdRoom.HasValue) return false;

                            var room = await context.Rooms.FindAsync(contract.IdRoom.Value);
                            if (room == null || room.Status != "Trống")
                            {
                                return false;
                            }

                            room.Status = "Đã thuê";
                            context.Rooms.Update(room);

                            contract.Status = "Active";
                           await context.Contracts.AddAsync(contract);

                             await context.SaveChangesAsync();
                             await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                             await transaction.RollbackAsync();
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

        public async Task <bool> EndContractAsync(Guid contractId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract =  await context.Contracts.FirstOrDefaultAsync(c => c.Id == contractId);
                    if (contract == null) return false;

                    contract.Status = "Expired";
                    contract.EndDate = DateOnly.FromDateTime(DateTime.Now); 
                    context.Contracts.Update(contract); 

                    if (contract.IdRoom.HasValue)
                    {
                        var room =  await context.Rooms.FirstOrDefaultAsync(r => r.Id == contract.IdRoom.Value);
                        if (room != null)
                        {
                            room.Status = "Trống";
                            context.Rooms.Update(room);
                        }
                    }

                     await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi EndContract: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RenewContractAsync(Guid roomId, int monthsToAdd)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract = await context.Contracts.FirstOrDefaultAsync(c => c.IdRoom == roomId && c.Status == "Active");
                    if (contract == null) return false;

                    if (!contract.EndDate.HasValue)
                        contract.EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(monthsToAdd));
                    else
                        contract.EndDate = contract.EndDate.Value.AddMonths(monthsToAdd);

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi RenewContract: {ex.Message}");
                return false;
            }
        }
           /// < summary >
        /// Lấy tất cả hợp đồng của một người thuê
        /// </summary>
        public async Task<List<Contract>> GetContractsByRenterAsync(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .Include(c => c.IdRoomNavigation)
                        .Where(c => c.IdRenter == renterId)
                        .OrderByDescending(c => c.StartDate)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetContractsByRenterAsync: {ex.Message}");
                return new List<Contract>();
            }
        }

        /// <summary>
        /// Lấy chi tiết hợp đồng theo ID
        /// </summary>
        public async Task<Contract> GetContractByIdAsync(Guid contractId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .Include(c => c.IdRoomNavigation)
                        .Include(c => c.IdRenterNavigation)
                            .ThenInclude(r => r.IdDetailNavigation)
                        .FirstOrDefaultAsync(c => c.Id == contractId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetContractByIdAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách hợp đồng sắp hết hạn
        /// </summary>
        public async Task<List<Contract>> GetExpiringContractsAsync(Guid ownerId, int daysBeforeExpiry = 30)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var thresholdDate = DateOnly.FromDateTime(DateTime.Now.AddDays(daysBeforeExpiry));
                    var today = DateOnly.FromDateTime(DateTime.Now);

                    return await context.Contracts
                        .Include(c => c.IdRoomNavigation)
                        .Include(c => c.IdRenterNavigation)
                        .Where(c => c.Status == "Active" &&
                                    c.IdRoomNavigation.IdOwner == ownerId &&
                                    c.EndDate.HasValue &&
                                    c.EndDate.Value >= today &&
                                    c.EndDate.Value <= thresholdDate)
                        .OrderBy(c => c.EndDate)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetExpiringContractsAsync: {ex.Message}");
                return new List<Contract>();
            }
        }

        /// <summary>
        /// Đếm số hợp đồng đang hoạt động của owner
        /// </summary>
        public async Task<int> CountActiveContractsAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .CountAsync(c => c.Status == "Active" && c.IdRoomNavigation.IdOwner == ownerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CountActiveContractsAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Kiểm tra xem phòng có hợp đồng đang hoạt động không
        /// </summary>
        public async Task<bool> HasActiveContractAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .AnyAsync(c => c.IdRoom == roomId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi HasActiveContractAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin hợp đồng
        /// </summary>
        public async Task<bool> UpdateContractAsync(Contract contract)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var exists = await context.Contracts.AnyAsync(c => c.Id == contract.Id);
                    if (!exists) return false;

                    context.Contracts.Update(contract);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateContractAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách hợp đồng theo trạng thái
        /// </summary>
        public async Task<List<Contract>> GetContractsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .Include(c => c.IdRoomNavigation)
                        .Include(c => c.IdRenterNavigation)
                        .Where(c => c.Status == status && c.IdRoomNavigation.IdOwner == ownerId)
                        .OrderByDescending(c => c.StartDate)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetContractsByStatusAsync: {ex.Message}");
                return new List<Contract>();
            }
        }

        /// <summary>
        /// Tính tổng tiền đặt cọc đang giữ
        /// </summary>
        public async Task<decimal> GetTotalDepositAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .Where(c => c.Status == "Active" &&
                                    c.IdRoomNavigation.IdOwner == ownerId &&
                                    c.Deposit.HasValue)
                        .SumAsync(c => c.Deposit.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalDepositAsync: {ex.Message}");
                return 0;
            }
        }
    }
}
        
    
