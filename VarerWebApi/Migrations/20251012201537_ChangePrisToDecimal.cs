using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VarerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrisToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Vare");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pris",
                table: "Vare",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Pris",
                table: "Vare",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Vare",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
