using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePool.Location.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryNativeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "native_name",
                table: "country",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "native_name",
                table: "country");
        }
    }
}
