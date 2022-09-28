using Microsoft.EntityFrameworkCore.Migrations;


namespace PersonalWellBeing.Migrations
{
    public partial class FinalPublicIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d146ec9a-9a9f-4f80-b91a-c722847dd8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b39677-9f75-4f62-b8c4-5113532a2700");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "DyogaItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "DSleepHygiene",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "DnutritionFooodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "DexercisesItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46d87f68-eaad-4d22-87df-16958fdd2a53", "bf6f1f5a-3950-4910-85d2-d2a93154453f", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "324df60c-1911-4f7d-ab42-3d173456f71e", "f8ad7ea7-915a-48b9-b8e4-d9b88240c4f4", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324df60c-1911-4f7d-ab42-3d173456f71e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d87f68-eaad-4d22-87df-16958fdd2a53");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DyogaItems");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DSleepHygiene");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DnutritionFooodItems");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DexercisesItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d146ec9a-9a9f-4f80-b91a-c722847dd8f3", "6b2a5655-fae9-40fd-9903-222a62addc61", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4b39677-9f75-4f62-b8c4-5113532a2700", "fd0c939b-b22c-4d13-a6fc-06362182b84b", "Admin", "ADMIN" });
        }
    }
}
