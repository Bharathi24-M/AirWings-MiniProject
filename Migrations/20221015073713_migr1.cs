using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirWings.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "citydetails",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__citydeta__B4BEB95E0D03CF77", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "flightdetails",
                columns: table => new
                {
                    flightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    economic = table.Column<bool>(type: "bit", nullable: true),
                    business = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__flightde__0E018642F21CDB2B", x => x.flightId);
                });

            migrationBuilder.CreateTable(
                name: "offer",
                columns: table => new
                {
                    offerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offername = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    offerprice = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offer", x => x.offerid);
                });

            migrationBuilder.CreateTable(
                name: "paymentmode",
                columns: table => new
                {
                    paymodeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paymentm__3C99DD269778A881", x => x.paymodeid);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    regid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    psword = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    emailId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__register__184A6B04B097D692", x => x.regid);
                });

            migrationBuilder.CreateTable(
                name: "tripdetails",
                columns: table => new
                {
                    tripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightId = table.Column<int>(type: "int", nullable: false),
                    origin = table.Column<int>(type: "int", nullable: false),
                    destination = table.Column<int>(type: "int", nullable: false),
                    arrivaltime = table.Column<DateTime>(type: "datetime", nullable: false),
                    departuretime = table.Column<DateTime>(type: "datetime", nullable: false),
                    availableseats = table.Column<int>(type: "int", nullable: false),
                    businessavailableseats = table.Column<int>(type: "int", nullable: false),
                    fare = table.Column<double>(type: "float", nullable: false),
                    businessfare = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tripdeta__303EBF8550DDB82E", x => x.tripId);
                    table.ForeignKey(
                        name: "FK__tripdetai__fligh__3A81B327",
                        column: x => x.flightId,
                        principalTable: "flightdetails",
                        principalColumn: "flightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticketdetails",
                columns: table => new
                {
                    pnr = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tripid = table.Column<int>(type: "int", nullable: true),
                    offerid = table.Column<int>(type: "int", nullable: true),
                    paymodeid = table.Column<int>(type: "int", nullable: true),
                    fare = table.Column<int>(type: "int", nullable: true),
                    discount = table.Column<int>(type: "int", nullable: true),
                    taxamount = table.Column<int>(type: "int", nullable: true),
                    netamount = table.Column<int>(type: "int", nullable: true),
                    ticketstatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ticketde__DD37C14C4BDCC355", x => x.pnr);
                    table.ForeignKey(
                        name: "FK__ticketdet__offer__46E78A0C",
                        column: x => x.offerid,
                        principalTable: "offer",
                        principalColumn: "offerid");
                    table.ForeignKey(
                        name: "FK__ticketdet__paymo__47DBAE45",
                        column: x => x.paymodeid,
                        principalTable: "paymentmode",
                        principalColumn: "paymodeid");
                    table.ForeignKey(
                        name: "FK__ticketdet__tripi__45F365D3",
                        column: x => x.tripid,
                        principalTable: "tripdetails",
                        principalColumn: "tripId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ticketdetails_offerid",
                table: "ticketdetails",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "IX_ticketdetails_paymodeid",
                table: "ticketdetails",
                column: "paymodeid");

            migrationBuilder.CreateIndex(
                name: "IX_ticketdetails_tripid",
                table: "ticketdetails",
                column: "tripid");

            migrationBuilder.CreateIndex(
                name: "IX_tripdetails_flightId",
                table: "tripdetails",
                column: "flightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citydetails");

            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.DropTable(
                name: "ticketdetails");

            migrationBuilder.DropTable(
                name: "offer");

            migrationBuilder.DropTable(
                name: "paymentmode");

            migrationBuilder.DropTable(
                name: "tripdetails");

            migrationBuilder.DropTable(
                name: "flightdetails");
        }
    }
}
