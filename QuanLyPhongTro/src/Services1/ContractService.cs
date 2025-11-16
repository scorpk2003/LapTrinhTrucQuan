using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Services1
{
    public class ContractService
    {
        public Contract GetActiveContractByRoom(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts 
                        .AsNoTracking()
                        .Include(c => c.IdRenterNavigation) 
                        .FirstOrDefault(c => c.IdRoom == roomId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContractByRoom: {ex.Message}");
                return null;
            }
        }

        public Contract GetActiveContractByRenter(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts 
                        .Include(c => c.IdRoomNavigation)
                        .FirstOrDefault(c => c.IdRenter == renterId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetActiveContract: {ex.Message}");
                return null;
            }
        }

        public List<Contract> GetAllActiveContractsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Contracts 
                        .Include(c => c.IdRoomNavigation) 
                        .Include(c => c.IdRenterNavigation) 
                        .Where(c => c.Status == "Active" && c.IdRoomNavigation.IdOwner == ownerId) 
                        .OrderBy(c => c.IdRoomNavigation.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllActiveContracts: {ex.Message}");
                return new List<Contract>();
            }
        }

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
                            if (!contract.IdRoom.HasValue) return false;

                            var room = context.Rooms.Find(contract.IdRoom.Value);
                            if (room == null || room.Status != "Trống")
                            {
                                return false;
                            }

                            room.Status = "Đã thuê";
                            context.Rooms.Update(room);

                            contract.Status = "Active";
                            context.Contracts.Add(contract);

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

        public bool EndContract(Guid contractId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract = context.Contracts.FirstOrDefault(c => c.Id == contractId);
                    if (contract == null) return false;

                    contract.Status = "Expired";
                    contract.EndDate = DateOnly.FromDateTime(DateTime.Now); 
                    context.Contracts.Update(contract); 

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

        public bool RenewContract(Guid roomId, int monthsToAdd)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var contract = context.Contracts.FirstOrDefault(c => c.IdRoom == roomId && c.Status == "Active");
                    if (contract == null) return false;

                    if (!contract.EndDate.HasValue)
                        contract.EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(monthsToAdd));
                    else
                        contract.EndDate = contract.EndDate.Value.AddMonths(monthsToAdd);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi RenewContract: {ex.Message}");
                return false;
            }
        }
    }
}