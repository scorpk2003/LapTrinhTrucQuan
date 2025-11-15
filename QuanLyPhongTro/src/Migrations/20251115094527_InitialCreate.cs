using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CccdImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PersonDe__3214EC074CE93A01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Service__3214EC0786630AD1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IdDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Person__3214EC07FDB564BD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Person__IdDetail__4D94879B",
                        column: x => x.IdDetail,
                        principalTable: "PersonDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Area = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__3214EC0720EB1BA5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Room__IdOwner__5165187F",
                        column: x => x.IdOwner,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bill__3214EC07971BEEA9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Bill__IdPerson__5DCAEF64",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Bill__IdRoom__5CD6CB2B",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesiredStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesiredDurationMonths = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequests_Person_IdRenter",
                        column: x => x.IdRenter,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRequests_Room_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdRenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Deposit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contract__3214EC07A2341402", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Contract__IdRent__59063A47",
                        column: x => x.IdRenter,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Contract__IdRoom__5812160E",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateIncurred = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Person_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Room_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdReporter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Report__3214EC073003D7A2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Report__IdReport__6E01572D",
                        column: x => x.IdReporter,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Report__IdRoom__6EF57B66",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomImag__3214EC07E1465E24", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RoomImage__IdRoo__6A30C649",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdService = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BillDeta__3214EC073E2B9BA4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__BillDetai__IdBil__619B8048",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__BillDetai__IdSer__628FA481",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__24A2D64DE1749AF2", x => x.IdBill);
                    table.ForeignKey(
                        name: "FK__Payment__IdBill__778AC167",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDReport = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notice__3214EC071255475A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Notice__IDReport__74AE54BC",
                        column: x => x.IDReport,
                        principalTable: "Report",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdPerson",
                table: "Bill",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdRoom",
                table: "Bill",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdService",
                table: "BillDetail",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_IdRenter",
                table: "BookingRequests",
                column: "IdRenter");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_IdRoom",
                table: "BookingRequests",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdRenter",
                table: "Contract",
                column: "IdRenter");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdRoom",
                table: "Contract",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IdOwner",
                table: "Expenses",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IdRoom",
                table: "Expenses",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Notice_IDReport",
                table: "Notice",
                column: "IDReport",
                unique: true,
                filter: "[IDReport] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdDetail",
                table: "Person",
                column: "IdDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Report_IdReporter",
                table: "Report",
                column: "IdReporter");

            migrationBuilder.CreateIndex(
                name: "IX_Report_IdRoom",
                table: "Report",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Room_IdOwner",
                table: "Room",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_IdRoom",
                table: "RoomImage",
                column: "IdRoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "BookingRequests");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Notice");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "RoomImage");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PersonDetail");
        }
    }
}
