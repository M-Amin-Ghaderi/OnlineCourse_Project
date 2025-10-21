using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_Order_Remove_CourseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourse_Courses_CourseId",
                table: "OrderCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourse_Orders_CourseId",
                table: "OrderCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_AspNetUsers_UserId",
                table: "StudentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderCourse",
                table: "OrderCourse");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "StudentProfile",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "OrderCourse",
                newName: "OrderCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfile_UserId",
                table: "Students",
                newName: "IX_Students_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCourse_CourseId",
                table: "OrderCourses",
                newName: "IX_OrderCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderCourses",
                table: "OrderCourses",
                columns: new[] { "OrderId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourses_Courses_CourseId",
                table: "OrderCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourses_Orders_CourseId",
                table: "OrderCourses",
                column: "CourseId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourses_Courses_CourseId",
                table: "OrderCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourses_Orders_CourseId",
                table: "OrderCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderCourses",
                table: "OrderCourses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentProfile");

            migrationBuilder.RenameTable(
                name: "OrderCourses",
                newName: "OrderCourse");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserId",
                table: "StudentProfile",
                newName: "IX_StudentProfile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCourses_CourseId",
                table: "OrderCourse",
                newName: "IX_OrderCourse_CourseId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderCourse",
                table: "OrderCourse",
                columns: new[] { "OrderId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourse_Courses_CourseId",
                table: "OrderCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourse_Orders_CourseId",
                table: "OrderCourse",
                column: "CourseId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_AspNetUsers_UserId",
                table: "StudentProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
