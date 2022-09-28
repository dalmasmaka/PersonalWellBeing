using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWellBeing.Migrations
{
    public partial class publicIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__DAppointm__userI__4F7CD00D",
                table: "DAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK__Dfeedback__userI__6B24EA82",
                table: "Dfeedbacks");

            migrationBuilder.DropTable(
                name: "DUser");

            migrationBuilder.DropIndex(
                name: "IX_Dfeedbacks_userID",
                table: "Dfeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_DAppointments_userID",
                table: "DAppointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f978454-846c-49f1-852a-79e7c75bd3fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ab3dc6-eab6-41c1-a1ee-02db4c7f29ba");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "DDoctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aEmail",
                table: "DAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d146ec9a-9a9f-4f80-b91a-c722847dd8f3", "6b2a5655-fae9-40fd-9903-222a62addc61", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4b39677-9f75-4f62-b8c4-5113532a2700", "fd0c939b-b22c-4d13-a6fc-06362182b84b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d146ec9a-9a9f-4f80-b91a-c722847dd8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b39677-9f75-4f62-b8c4-5113532a2700");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DDoctors");

            migrationBuilder.DropColumn(
                name: "aEmail",
                table: "DAppointments");

            migrationBuilder.CreateTable(
                name: "DUser",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    userRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DUser__CB9A1CDF8AA8DA3C", x => x.userID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f978454-846c-49f1-852a-79e7c75bd3fe", "c806e27b-ab68-44ec-9677-e73caba8c94b", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0ab3dc6-eab6-41c1-a1ee-02db4c7f29ba", "ac85a870-3f7b-458e-bf86-42d9dfb43b8a", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Dfeedbacks_userID",
                table: "Dfeedbacks",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_DAppointments_userID",
                table: "DAppointments",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK__DAppointm__userI__4F7CD00D",
                table: "DAppointments",
                column: "userID",
                principalTable: "DUser",
                principalColumn: "userID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Dfeedback__userI__6B24EA82",
                table: "Dfeedbacks",
                column: "userID",
                principalTable: "DUser",
                principalColumn: "userID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
