using QuanLyPhongTro.Models;
using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void Test()
        {
            // Run previously added BillDetail + BillService tests
            RunBillDetailAndBillServiceTests();

            // Run additional service tests
            RunServiceServicesTest();
            RunPersonServiceTest();
            RunContractServiceTest();
            RunRoomServiceTest();
            RunReportServiceTest();

            MessageBox.Show("All service tests finished. Check Output (Debug) for details.", "Tests complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- existing BillDetail + BillService tests consolidated
        private void RunBillDetailAndBillServiceTests()
        {
            var billDetailServices = new BillDetailServices();

            try
            {
                using var ctx = new AppContextDB();

                // Ensure a test Service exists (create if missing)
                var service = ctx.Services.FirstOrDefault(s => s.Name == "Test Service");
                var createdService = false;
                if (service == null)
                {
                    service = new Service
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Service",
                        PricePerUnit = 100m,
                        Unit = "unit"
                    };
                    ctx.Services.Add(service);
                    ctx.SaveChanges();
                    createdService = true;
                }

                // Create a Bill
                var bill = new Bill
                {
                    Id = Guid.NewGuid(),
                    PaymentDate = DateTime.Now,
                    TotalMoney = 0m
                };
                ctx.Bills.Add(bill);
                ctx.SaveChanges();

                // Prepare a BillDetail
                var detail = new BillDetail
                {
                    Id = Guid.NewGuid(),
                    IdBill = bill.Id,
                    IdService = service.Id,
                    Quantity = 2m,
                    Total = service.PricePerUnit * 2m
                };

                // Add via service
                var added = billDetailServices.AddBillDetails(new List<BillDetail> { detail });
                Debug.WriteLine($"AddBillDetails -> {added} (DetailId: {detail.Id})");

                // Read by bill id
                var details = billDetailServices.GetBillDetailsByBillId(bill.Id);
                Debug.WriteLine($"GetBillDetailsByBillId -> found {details.Count}");
                if (details.Any())
                {
                    Debug.WriteLine($"First detail total: {details[0].Total}, ServiceName (nav): {details[0].IdServiceNavigation?.Name ?? "<null>"}");
                }

                // Get Bill with details & payment
                var billWithDetails = billDetailServices.GetBillWithDetails(bill.Id);
                Debug.WriteLine($"GetBillWithDetails -> BillId: {billWithDetails?.Id}, BillDetailsCount: {billWithDetails?.BillDetails?.Count}");

                // Update the detail
                var toUpdate = details.FirstOrDefault();
                if (toUpdate != null)
                {
                    toUpdate.Quantity = 3m;
                    toUpdate.Total = service.PricePerUnit * 3m;
                    var updated = billDetailServices.UpdateBillDetail(toUpdate);
                    Debug.WriteLine($"UpdateBillDetail -> {updated}");

                    var afterUpdate = billDetailServices.GetBillDetailsByBillId(bill.Id).FirstOrDefault();
                    Debug.WriteLine($"After update -> Quantity: {afterUpdate?.Quantity}, Total: {afterUpdate?.Total}");
                }

                // Delete the detail
                var toDelete = billDetailServices.GetBillDetailsByBillId(bill.Id).FirstOrDefault();
                if (toDelete != null)
                {
                    var deleted = billDetailServices.DeleteBillDetail(toDelete.Id);
                    Debug.WriteLine($"DeleteBillDetail -> {deleted}");
                }

                // Optional cleanup: remove the created bill
                var persistedBill = ctx.Bills.Find(bill.Id);
                if (persistedBill != null)
                {
                    ctx.Bills.Remove(persistedBill);
                    ctx.SaveChanges();
                }

                // Optional: remove created service if we created it in this test
                if (createdService)
                {
                    var persistedService = ctx.Services.Find(service.Id);
                    if (persistedService != null)
                    {
                        ctx.Services.Remove(persistedService);
                        ctx.SaveChanges();
                    }
                }

                Debug.WriteLine("BillDetailServices test finished. Proceeding to BillService test...");

                // --- Run BillService test
                RunBillServiceTest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunBillDetailAndBillServiceTests() exception: {ex.Message}");
            }
        }

        // One-shot test for BillService: Create bill + details via service, verify, pay, cleanup.
        private void RunBillServiceTest()
        {
            var billService = new BillService();

            try
            {
                using var ctx = new AppContextDB();

                // Ensure a Service exists for details
                var svc = ctx.Services.FirstOrDefault(s => s.Name == "Svc for BillService Test");
                var createdSvc = false;
                if (svc == null)
                {
                    svc = new Service
                    {
                        Id = Guid.NewGuid(),
                        Name = "Svc for BillService Test",
                        PricePerUnit = 50m,
                        Unit = "u"
                    };
                    ctx.Services.Add(svc);
                    ctx.SaveChanges();
                    createdSvc = true;
                }

                // Prepare bill and details
                var bill = new Bill
                {
                    Id = Guid.NewGuid(), // BillService will assign a new Id internally
                    PaymentDate = DateTime.Now,
                    TotalMoney = 0m
                };

                var details = new List<BillDetail>
                {
                    new BillDetail
                    {
                        Id = Guid.NewGuid(),
                        IdService = svc.Id,
                        Quantity = 1m,
                        Total = svc.PricePerUnit * 1m
                    },
                    new BillDetail
                    {
                        Id = Guid.NewGuid(),
                        IdService = svc.Id,
                        Quantity = 2m,
                        Total = svc.PricePerUnit * 2m
                    }
                };

                // Sum totals into bill.TotalMoney
                bill.TotalMoney = details.Sum(d => d.Total);

                // Create bill via service (transactional inside)
                var created = billService.CreateBill(bill, details);
                Debug.WriteLine($"CreateBill -> {created} (BillId after create: {bill.Id})");

                // Retrieve created bill with details
                var fetched = billService.GetBillWithDetails(bill.Id);
                Debug.WriteLine($"GetBillWithDetails -> Found: {fetched != null}, DetailsCount: {fetched?.BillDetails?.Count}");

                // Pay the bill
                var paid = billService.PayBill(bill.Id, "Cash");
                Debug.WriteLine($"PayBill -> {paid}");

                // Verify payment exists
                var hasPayment = ctx.Payments.Any(p => p.IdBill == bill.Id);
                Debug.WriteLine($"Payment persisted -> {hasPayment}");

                // Cleanup: remove payment(s), bill details, bill, and optional service
                using (var cleanCtx = new AppContextDB())
                {
                    var payments = cleanCtx.Payments.Where(p => p.IdBill == bill.Id).ToList();
                    if (payments.Any())
                    {
                        cleanCtx.Payments.RemoveRange(payments);
                    }

                    var billDetails = cleanCtx.BillDetails.Where(d => d.IdBill == bill.Id).ToList();
                    if (billDetails.Any())
                    {
                        cleanCtx.BillDetails.RemoveRange(billDetails);
                    }

                    var persistedBill = cleanCtx.Bills.Find(bill.Id);
                    if (persistedBill != null)
                    {
                        cleanCtx.Bills.Remove(persistedBill);
                    }

                    if (createdSvc)
                    {
                        var persistedService = cleanCtx.Services.Find(svc.Id);
                        if (persistedService != null)
                        {
                            cleanCtx.Services.Remove(persistedService);
                        }
                    }

                    cleanCtx.SaveChanges();
                }

                Debug.WriteLine("RunBillServiceTest completed and cleaned up.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunBillServiceTest exception: {ex.Message}");
            }
        }

        // --- ServiceServices test
        private void RunServiceServicesTest()
        {
            var svcService = new ServiceServices();
            try
            {
                // Add a service
                var s = new Service { Name = "Tmp Service", Unit = "u", PricePerUnit = 10m };
                var added = svcService.AddService(s);
                Debug.WriteLine($"ServiceServices.AddService -> {added} (Id set by AddService)");

                // Get all / get by id
                var all = svcService.GetAllServices();
                Debug.WriteLine($"ServiceServices.GetAllServices -> Count: {all.Count}");

                var persisted = all.FirstOrDefault(a => a.Name == "Tmp Service");
                if (persisted != null)
                {
                    var fetched = svcService.GetServiceById(persisted.Id);
                    Debug.WriteLine($"ServiceServices.GetServiceById -> Found: {fetched != null}, Name: {fetched?.Name}");

                    // Update
                    fetched.Name = "Tmp Service Updated";
                    var updated = svcService.UpdateService(fetched);
                    Debug.WriteLine($"ServiceServices.UpdateService -> {updated}");

                    // Delete
                    var deleted = svcService.DeleteService(fetched.Id);
                    Debug.WriteLine($"ServiceServices.DeleteService -> {deleted}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunServiceServicesTest exception: {ex.Message}");
            }
        }

        // --- PersonService test
        private void RunPersonServiceTest()
        {
            var personService = new PersonService();
            try
            {
                // Create
                var p = new Person
                {
                    Id = Guid.NewGuid(),
                    Username = "test_user_" + Guid.NewGuid().ToString("N").Substring(0, 6),
                    Password = "pwd",
                    Role = "User"
                };
                var created = personService.Create(p);
                Debug.WriteLine($"PersonService.Create -> Id: {created?.Id}");

                // GetById
                var fetched = personService.GetById(created.Id);
                Debug.WriteLine($"PersonService.GetById -> Found: {fetched != null}, Username: {fetched?.Username}");

                // Update
                fetched.Username = fetched.Username + "_upd";
                personService.Update(fetched);
                var afterUpd = personService.GetById(fetched.Id);
                Debug.WriteLine($"PersonService.Update -> Username now: {afterUpd?.Username}");

                // Delete
                personService.Delete(fetched.Id);
                var afterDelete = personService.GetById(fetched.Id);
                Debug.WriteLine($"PersonService.Delete -> Exists after delete: {afterDelete != null}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunPersonServiceTest exception: {ex.Message}");
            }
        }

        // --- ContractService test
        private void RunContractServiceTest()
        {
            var contractService = new ContractService();

            try
            {
                using var ctx = new AppContextDB();

                // Create owner (Person) and Room to attach contract
                var renter = new Person
                {
                    Id = Guid.NewGuid(),
                    Username = "renter_" + Guid.NewGuid().ToString("N").Substring(0, 6),
                    Password = "pwd",
                    Role = "Renter"
                };
                ctx.People.Add(renter);

                var owner = new Person
                {
                    Id = Guid.NewGuid(),
                    Username = "owner_" + Guid.NewGuid().ToString("N").Substring(0, 6),
                    Password = "pwd",
                    Role = "Owner"
                };
                ctx.People.Add(owner);

                var room = new Room
                {
                    Id = Guid.NewGuid(),
                    Name = "Tmp Room " + Guid.NewGuid().ToString("N").Substring(0, 6),
                    Address = "Addr",
                    Status = "Occupied",
                    Price = 100m
                };
                ctx.Rooms.Add(room);
                ctx.SaveChanges();

                // Create active contract
                var contract = new Contract
                {
                    Id = Guid.NewGuid(),
                    IdRenter = renter.Id,
                    IdRoom = room.Id,

                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "Active",
                    Deposit = 0m
                };
                ctx.Contracts.Add(contract);
                ctx.SaveChanges();

                // GetActiveContractByRoom
                var active = contractService.GetActiveContractByRoom(room.Id);
                Debug.WriteLine($"ContractService.GetActiveContractByRoom -> Found: {active != null}, Id: {active?.Id}");

                // EndContract
                var ended = contractService.EndContract(contract.Id);
                Debug.WriteLine($"ContractService.EndContract -> {ended}");

                // verify room status updated
                var updatedRoom = ctx.Rooms.Find(room.Id);
                Debug.WriteLine($"Room status after EndContract -> {updatedRoom?.Status}");

                // Cleanup
                ctx.Contracts.RemoveRange(ctx.Contracts.Where(c => c.Id == contract.Id));
                ctx.Rooms.RemoveRange(ctx.Rooms.Where(r => r.Id == room.Id));
                ctx.People.RemoveRange(ctx.People.Where(p => p.Id == renter.Id || p.Id == owner.Id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunContractServiceTest exception: {ex.Message}");
            }
        }

        // --- RoomService test
        private void RunRoomServiceTest()
        {
            var roomService = new RoomService();
            try
            {
                using var ctx = new AppContextDB();

                // create a room
                var room = new Room
                {
                    Id = Guid.NewGuid(),
                    Name = "TestRoom_" + Guid.NewGuid().ToString("N").Substring(0, 6),
                    Address = "Address",
                    Status = "Available",
                    Price = 250m,
                    Area = 20m
                };

                var imageUrls = new List<string> { "RoomImages/test1.jpg", "RoomImages/test2.jpg" };
                var created = roomService.CreateRoom(room, imageUrls);
                Debug.WriteLine($"RoomService.CreateRoom -> {created} (RoomId: {room.Id})");

                // GetRoomWithDetails
                var fetched = roomService.GetRoomWithDetails(room.Id);
                Debug.WriteLine($"RoomService.GetRoomWithDetails -> Found: {fetched != null}, Images: {fetched?.RoomImages?.Count}");

                // Add image
                var newImg = roomService.AddImageToRoom(room.Id, "RoomImages/added.jpg");
                Debug.WriteLine($"RoomService.AddImageToRoom -> Created image id: {newImg?.Id}");

                // Delete one image (if exists)
                if (fetched?.RoomImages?.FirstOrDefault() is RoomImage firstImage)
                {
                    var del = roomService.DeleteRoomImage(firstImage.Id);
                    Debug.WriteLine($"RoomService.DeleteRoomImage -> {del}");
                }

                // Update room
                room.Name = room.Name + "_upd";
                room.Price = 300m;
                var upd = roomService.UpdateRoom(room);
                Debug.WriteLine($"RoomService.UpdateRoom -> {upd}");

                // Soft delete room
                var delRoom = roomService.DeleteRoom(room.Id);
                Debug.WriteLine($"RoomService.DeleteRoom (soft) -> {delRoom}");

                // Cleanup: hard remove created rows
                using (var clean = new AppContextDB())
                {
                    clean.RoomImages.RemoveRange(clean.RoomImages.Where(ri => ri.IdRoom == room.Id));
                    var persistedRoom = clean.Rooms.Find(room.Id);
                    if (persistedRoom != null) clean.Rooms.Remove(persistedRoom);
                    clean.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunRoomServiceTest exception: {ex.Message}");
            }
        }

        // --- ReportService test
        private void RunReportServiceTest()
        {
            var reportService = new ReportService();
            try
            {
                using var ctx = new AppContextDB();

                // ensure a reporter person and room exist
                var reporter = new Person { Id = Guid.NewGuid(), Username = "rep_" + Guid.NewGuid().ToString("N").Substring(0, 6), Password = "p", Role = "User" };
                ctx.People.Add(reporter);

                var room = new Room { Id = Guid.NewGuid(), Name = "R_for_report", Address = "addr", Status = "Available", Price = 100m };
                ctx.Rooms.Add(room);
                ctx.SaveChanges();

                var report = new Report
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    Description = "Test report description",
                    IdReporter = reporter.Id,
                    IdRoom = room.Id,
                    Status = "Open",
                    Title = "Test Report"
                };

                var created = reportService.CreateReport(report);
                Debug.WriteLine($"ReportService.CreateReport -> {created} (ReportId: {report.Id})");

                // Cleanup
                ctx.Reports.RemoveRange(ctx.Reports.Where(r => r.Id == report.Id));
                ctx.Rooms.RemoveRange(ctx.Rooms.Where(r => r.Id == room.Id));
                ctx.People.RemoveRange(ctx.People.Where(p => p.Id == reporter.Id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RunReportServiceTest exception: {ex.Message}");
            }
        }
    }
    }
    
