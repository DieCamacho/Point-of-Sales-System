using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using POS.Data;

namespace POS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    C_City = table.Column<string>(maxLength: 50, nullable: false),
                    C_streetName = table.Column<string>(maxLength: 50, nullable: false),
                    C_streetNum = table.Column<int>(maxLength: 50, nullable: false),
                    C_zipCode = table.Column<int>(nullable: false),
                    FName = table.Column<string>(maxLength: 50, nullable: false),
                    LName = table.Column<string>(maxLength: 50, nullable: false),
                    MInit = table.Column<string>(maxLength: 50, nullable: false),
                    Phone_Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    I_productBrand = table.Column<string>(maxLength: 50, nullable: false),
                    I_productModel = table.Column<string>(maxLength: 50, nullable: false),
                    ModelNumber = table.Column<string>(nullable: true),
                    ProductCost = table.Column<double>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Inventory_PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    I_productBrand = table.Column<string>(maxLength: 50, nullable: false),
                    I_productModel = table.Column<string>(maxLength: 50, nullable: false),
                    I_productName = table.Column<string>(maxLength: 50, nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ProductOrdered = table.Column<int>(nullable: false),
                    ProductPID = table.Column<int>(nullable: true),
                    ProductQTY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Inventory_PID);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductPID",
                        column: x => x.ProductPID,
                        principalTable: "Product",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductPID",
                table: "Inventory",
                column: "ProductPID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Product");


            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
