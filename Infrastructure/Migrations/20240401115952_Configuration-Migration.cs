using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Customers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Configuration",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Configuration",
                table: "Customers");
        }
    }
}
