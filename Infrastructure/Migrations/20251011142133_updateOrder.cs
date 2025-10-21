using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Orders_OrderId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Orders_OrderId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OrderId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OrderId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "OrderCourse",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCourse", x => new { x.OrderId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_OrderCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCourse_Orders_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCourse_CourseId",
                table: "OrderCourse",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCourse");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OrderId",
                table: "Courses",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OrderId1",
                table: "Courses",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Orders_OrderId",
                table: "Courses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Orders_OrderId1",
                table: "Courses",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
