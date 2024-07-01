using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SaleCategories_SaleCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SaleProducts_SaleProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SaleCategories");

            migrationBuilder.DropTable(
                name: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StoreManagersPermissions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StoreManagers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ShippingCompaniesPermissions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "shippingCompanies");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "purchaseBills");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InvoiceOrders");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InvoiceOrderOnlineLines");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InvoiceOrderLines");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DetailsInvoices");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DeliverCarts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AdministratorsPermissions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "SaleProductId",
                table: "Products",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SaleProductId",
                table: "Products",
                newName: "IX_Products_SaleId");

            migrationBuilder.RenameColumn(
                name: "SaleCategoryId",
                table: "Categories",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_SaleCategoryId",
                table: "Categories",
                newName: "IX_Categories_SaleId");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartSale = table.Column<DateOnly>(type: "date", nullable: false),
                    EndSale = table.Column<DateOnly>(type: "date", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StoreId",
                table: "Sales",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Sales_SaleId",
                table: "Categories",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Sales_SaleId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Products",
                newName: "SaleProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SaleId",
                table: "Products",
                newName: "IX_Products_SaleProductId");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Categories",
                newName: "SaleCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_SaleId",
                table: "Categories",
                newName: "IX_Categories_SaleCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StoreManagersPermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StoreManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ShippingCompaniesPermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "shippingCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "purchaseBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InvoiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InvoiceOrderOnlineLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InvoiceOrderLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InvoiceLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DetailsInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DeliverCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AdministratorsPermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SaleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndSale = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartSale = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleCategories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndSale = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartSale = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleCategories_StoreId",
                table: "SaleCategories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_StoreId",
                table: "SaleProducts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SaleCategories_SaleCategoryId",
                table: "Categories",
                column: "SaleCategoryId",
                principalTable: "SaleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SaleProducts_SaleProductId",
                table: "Products",
                column: "SaleProductId",
                principalTable: "SaleProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
