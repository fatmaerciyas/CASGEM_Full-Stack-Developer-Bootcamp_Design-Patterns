using Microsoft.EntityFrameworkCore.Migrations;

namespace Cassgem.ChainOfResponsibility.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerProcesss",
                columns: table => new
                {
                    CustomerProcessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    Desciption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProcesss", x => x.CustomerProcessID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProcesss");
        }
    }
}
