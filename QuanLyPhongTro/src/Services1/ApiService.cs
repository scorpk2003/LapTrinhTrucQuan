using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Services1
{
    /// <summary>
    /// Service t?p trung ?? g?i API thay th? các Service local
    /// </summary>
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api-server-floral-shadow-5092.fly.dev";

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(BaseUrl);
            }
        }

        #region Room APIs

        /// <summary>
        /// L?y t?t c? phòng c?a owner
        /// </summary>
        public async Task<List<Room>> GetRoomsByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Rooms/owner/{ownerId}", cancellationToken);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Room>>(cancellationToken: cancellationToken) 
                    ?? new List<Room>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetRoomsByOwnerAsync Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// L?y phòng theo ID
        /// </summary>
        public async Task<Room?> GetRoomByIdAsync(Guid roomId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Room>($"/api/Rooms/{roomId}", cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetRoomByIdAsync Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// T?o phòng m?i
        /// </summary>
        public async Task<bool> CreateRoomAsync(Room room, List<string> imageUrls, CancellationToken cancellationToken = default)
        {
            try
            {
                var payload = new
                {
                    room = room,
                    imageUrls = imageUrls
                };

                var response = await _httpClient.PostAsJsonAsync("/api/Rooms", payload, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t phòng
        /// </summary>
        public async Task<bool> UpdateRoomAsync(Room room, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/Rooms/{room.Id}", room, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa phòng
        /// </summary>
        public async Task<bool> DeleteRoomAsync(Guid roomId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Rooms/{roomId}", cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y t?t c? phòng tr?ng
        /// </summary>
        public async Task<List<Room>> GetAvailableRoomsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Room>>("/api/Rooms/available", cancellationToken) 
                    ?? new List<Room>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAvailableRoomsAsync Error: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Thêm ?nh vào phòng
        /// </summary>
        public async Task<RoomImage?> AddImageToRoomAsync(Guid roomId, string imageUrl, CancellationToken cancellationToken = default)
        {
            try
            {
                var payload = new { roomId, imageUrl };
                var response = await _httpClient.PostAsJsonAsync("/api/Rooms/images", payload, cancellationToken);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RoomImage>(cancellationToken: cancellationToken);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddImageToRoomAsync Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xóa ?nh phòng
        /// </summary>
        public async Task<bool> DeleteRoomImageAsync(Guid imageId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Rooms/images/{imageId}", cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteRoomImageAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region ListRoom APIs

        /// <summary>
        /// L?y t?t c? dãy tr? c?a owner
        /// </summary>
        public async Task<List<ListRoom>> GetListRoomsByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ListRoom>>($"/api/ListRooms/owner/{ownerId}", cancellationToken) 
                    ?? new List<ListRoom>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetListRoomsByOwnerAsync Error: {ex.Message}");
                return new List<ListRoom>();
            }
        }

        /// <summary>
        /// T?o dãy tr? m?i
        /// </summary>
        public async Task<bool> CreateListRoomAsync(ListRoom listRoom, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/ListRooms", listRoom, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateListRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t dãy tr?
        /// </summary>
        public async Task<bool> UpdateListRoomAsync(ListRoom listRoom, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/ListRooms/{listRoom.Id}", listRoom, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateListRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa dãy tr?
        /// </summary>
        public async Task<bool> DeleteListRoomAsync(Guid listRoomId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/ListRooms/{listRoomId}", cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteListRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Contract APIs

        /// <summary>
        /// L?y h?p ??ng ?ang ho?t ??ng c?a renter
        /// </summary>
        public async Task<Contract?> GetActiveContractByRenterAsync(Guid renterId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Contract>($"/api/Contracts/renter/{renterId}/active", cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveContractByRenterAsync Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// L?y h?p ??ng ?ang ch? c?a renter
        /// </summary>
        public async Task<List<Contract>> GetPendingContractsByRenterAsync(Guid renterId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Contract>>($"/api/Contracts/renter/{renterId}/pending", cancellationToken) 
                    ?? new List<Contract>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetPendingContractsByRenterAsync Error: {ex.Message}");
                return new List<Contract>();
            }
        }

        /// <summary>
        /// L?y h?p ??ng ?ang ho?t ??ng theo Room ID
        /// </summary>
        public async Task<Contract?> GetActiveContractByRoomAsync(Guid roomId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Contract>($"/api/Contract/room/{roomId}/active", cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveContractByRoomAsync Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// T?o h?p ??ng m?i
        /// </summary>
        public async Task<bool> CreateContractAsync(Contract contract, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Contracts", contract, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateContractAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gia h?n h?p ??ng
        /// </summary>
        public async Task<bool> RenewContractAsync(Guid roomId, int monthsToAdd, CancellationToken cancellationToken = default)
        {
            try
            {
                var payload = new { monthsToAdd };
                var response = await _httpClient.PostAsJsonAsync($"/api/Contracts/room/{roomId}/renew", payload, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RenewContractAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Bill APIs

        /// <summary>
        /// L?y hóa ??n c?a owner
        /// </summary>
        public async Task<List<Bill>> GetBillsByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Bill>>($"/api/Bills/owner/{ownerId}", cancellationToken) 
                    ?? new List<Bill>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetBillsByOwnerAsync Error: {ex.Message}");
                return new List<Bill>();
            }
        }

        /// <summary>
        /// L?y hóa ??n c?a renter
        /// </summary>
        public async Task<List<Bill>> GetBillsByRenterAsync(Guid renterId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Bill>>($"/api/Bills/renter/{renterId}", cancellationToken) 
                    ?? new List<Bill>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetBillsByRenterAsync Error: {ex.Message}");
                return new List<Bill>();
            }
        }

        /// <summary>
        /// T?o hóa ??n m?i
        /// </summary>
        public async Task<bool> CreateBillAsync(Bill bill, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Bills", bill, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateBillAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xác nh?n thanh toán
        /// </summary>
        public async Task<bool> ConfirmPaymentAsync(Guid billId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/Bills/{billId}/confirm", null, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConfirmPaymentAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Report APIs

        /// <summary>
        /// L?y báo cáo c?a owner
        /// </summary>
        public async Task<List<Report>> GetReportsByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Report>>($"/api/Reports/owner/{ownerId}", cancellationToken) 
                    ?? new List<Report>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetReportsByOwnerAsync Error: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// T?o báo cáo m?i
        /// </summary>
        public async Task<bool> CreateReportAsync(Report report, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Reports", report, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateReportAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t tr?ng thái báo cáo
        /// </summary>
        public async Task<bool> UpdateReportStatusAsync(Guid reportId, string status, CancellationToken cancellationToken = default)
        {
            try
            {
                var payload = new { status };
                var response = await _httpClient.PutAsJsonAsync($"/api/Reports/{reportId}/status", payload, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateReportStatusAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region BookingRequest APIs

        /// <summary>
        /// L?y yêu c?u booking ?ang ch? c?a owner
        /// </summary>
        public async Task<List<BookingRequest>> GetPendingBookingRequestsByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<BookingRequest>>($"/api/BookingRequest/owner/{ownerId}/pending", cancellationToken) 
                    ?? new List<BookingRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetPendingBookingRequestsByOwnerAsync Error: {ex.Message}");
                return new List<BookingRequest>();
            }
        }

        /// <summary>
        /// T?o yêu c?u booking
        /// </summary>
        public async Task<bool> CreateBookingRequestAsync(BookingRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/BookingRequest", request, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateBookingRequestAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Ki?m tra renter ?ã g?i yêu c?u cho phòng ch?a
        /// </summary>
        public async Task<bool> HasPendingRequestForRoomAsync(Guid renterId, Guid roomId, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/BookingRequest/check?renterId={renterId}&roomId={roomId}", cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<bool>(cancellationToken: cancellationToken);
                    return result;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HasPendingRequestForRoomAsync Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y yêu c?u booking c?a renter
        /// </summary>
        public async Task<List<BookingRequest>> GetBookingRequestsByRenterAsync(Guid renterId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<BookingRequest>>($"/api/BookingRequest/renter/{renterId}", cancellationToken) 
                    ?? new List<BookingRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetBookingRequestsByRenterAsync Error: {ex.Message}");
                return new List<BookingRequest>();
            }
        }

        #endregion

        #region Person APIs

        /// <summary>
        /// L?y thông tin Person theo ID
        /// </summary>
        public async Task<Person?> GetPersonByIdAsync(Guid personId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Person>($"/api/Persons/{personId}", cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetPersonByIdAsync Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// C?p nh?t thông tin Person
        /// </summary>
        public async Task<bool> UpdatePersonAsync(Person person, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/Persons/{person.Id}", person, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdatePersonAsync Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Dispose HttpClient
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
