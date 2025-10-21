using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_Order_ForeignKeyFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourses_Orders_CourseId",
                table: "OrderCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourses_Orders_OrderId",
                table: "OrderCourses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourses_Orders_OrderId",
                table: "OrderCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourses_Orders_CourseId",
                table: "OrderCourses",
                column: "CourseId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
