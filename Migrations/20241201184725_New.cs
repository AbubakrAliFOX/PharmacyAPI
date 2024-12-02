using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPI.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_People_PersonId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_People_PersonId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PersonId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PersonId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Customers",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Customers",
                newName: "PersonId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PersonId",
                table: "Suppliers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonId",
                table: "Customers",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_People_PersonId",
                table: "Customers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_People_PersonId",
                table: "Suppliers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
