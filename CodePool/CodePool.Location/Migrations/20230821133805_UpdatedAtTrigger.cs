using CodePool.Sharp.Data.EntityFramework;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePool.Location.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAtTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
            => migrationBuilder.CreateUpdatedAtTrigger();

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
            => migrationBuilder.DropUpdatedAtTrigger();
    }
}
