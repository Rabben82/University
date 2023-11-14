using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentWithCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Enrollment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                columns: new[] { "StudentId", "CourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");
        }
    }
}
