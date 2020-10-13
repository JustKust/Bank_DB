using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank_DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<int>(type: "INT", nullable: false),
                    ExchangeRate = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurID);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PosID = table.Column<int>(type: "INT", nullable: false),
                    PosName = table.Column<string>(type: "VARCHAR", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<int>(type: "INT", nullable: false),
                    Requirements = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.PosID);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    DepID = table.Column<int>(type: "INT", nullable: false),
                    DepName = table.Column<string>(type: "VARCHAR", nullable: false),
                    MinDepTern = table.Column<int>(type: "INT", nullable: false),
                    MinDepAmount = table.Column<int>(type: "INT", nullable: false),
                    AddCond = table.Column<int>(type: "INT", nullable: false),
                    CurID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.DepID);
                    table.ForeignKey(
                        name: "FK_Deposits_Currency_CurID",
                        column: x => x.CurID,
                        principalTable: "Currency",
                        principalColumn: "CurID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    PassData = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR", nullable: false),
                    PhoneNum = table.Column<int>(type: "INT", nullable: false),
                    DeposDate = table.Column<long>(type: "DATE", nullable: false),
                    RefundDate = table.Column<long>(type: "DATE", nullable: false),
                    SummAm = table.Column<int>(type: "INT", nullable: false),
                    SummRef = table.Column<int>(type: "INT", nullable: false),
                    DepRafMark = table.Column<int>(type: "INT", nullable: false),
                    DepID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositors", x => x.PassData);
                    table.ForeignKey(
                        name: "FK_Depositors_Deposits_DepID",
                        column: x => x.DepID,
                        principalTable: "Deposits",
                        principalColumn: "DepID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmID = table.Column<int>(type: "INT", nullable: false),
                    Full_Name = table.Column<string>(type: "VARCHAR", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR", nullable: false),
                    Telephone = table.Column<string>(type: "VARCHAR", nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "CHAR", nullable: false),
                    PassData = table.Column<int>(type: "INT", nullable: false),
                    PosID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmID);
                    table.ForeignKey(
                        name: "FK_Employee_Depositors_PassData",
                        column: x => x.PassData,
                        principalTable: "Depositors",
                        principalColumn: "PassData",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_positions_PosID",
                        column: x => x.PosID,
                        principalTable: "positions",
                        principalColumn: "PosID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depositors_DepID",
                table: "Depositors",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_CurID",
                table: "Deposits",
                column: "CurID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PassData",
                table: "Employee",
                column: "PassData");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PosID",
                table: "Employee",
                column: "PosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
