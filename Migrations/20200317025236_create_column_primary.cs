using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class create_column_primary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    brand = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    production_year = table.Column<string>(nullable: true),
                    seat = table.Column<string>(nullable: true),
                    transmision = table.Column<string>(nullable: true),
                    ac = table.Column<string>(nullable: true),
                    fuel = table.Column<string>(nullable: true),
                    priceperday = table.Column<string>(nullable: true),
                    front_image = table.Column<string>(nullable: true),
                    back_image = table.Column<string>(nullable: true),
                    top_image = table.Column<string>(nullable: true),
                    left_image = table.Column<string>(nullable: true),
                    right_image = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction_Details",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_id = table.Column<string>(nullable: true),
                    merchant_id = table.Column<string>(nullable: true),
                    order_id = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    gross_amount = table.Column<string>(nullable: true),
                    transaction_time = table.Column<string>(nullable: true),
                    transaction_status = table.Column<string>(nullable: true),
                    status_code = table.Column<string>(nullable: true),
                    status_message = table.Column<string>(nullable: true),
                    fraud_status = table.Column<string>(nullable: true),
                    signature_key = table.Column<string>(nullable: true),
                    _account = table.Column<string>(nullable: true),
                    _actions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    cars_id = table.Column<Guid>(nullable: false),
                    nama_pemesan = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    driver = table.Column<int>(nullable: false),
                    used_at = table.Column<DateTime>(nullable: false),
                    returned_at = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    transaction_id = table.Column<int>(nullable: false),
                    User_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Transaction_Details_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "Transaction_Details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_User_id",
                table: "Transactions",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_transaction_id",
                table: "Transactions",
                column: "transaction_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Transaction_Details");
        }
    }
}
