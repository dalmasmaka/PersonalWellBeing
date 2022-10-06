using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWellBeing.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDoctors",
                columns: table => new
                {
                    doctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    doctorSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    doctorSummary = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    doctorIMG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DDoctors__72248596E96C7FBC", x => x.doctorID);
                });

            migrationBuilder.CreateTable(
                name: "Dfeedbacks",
                columns: table => new
                {
                    feedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    feedbackText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dfeedbac__2613FDC4442F5FB1", x => x.feedbackID);
                });

            migrationBuilder.CreateTable(
                name: "DMenuList",
                columns: table => new
                {
                    menuListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuListItem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    menuListImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DMenuLis__D5EC925C92A9CDE6", x => x.menuListID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DAppointments",
                columns: table => new
                {
                    appointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorID = table.Column<int>(type: "int", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: true),
                    aName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    aSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    aPurpose = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    aDoneDate = table.Column<DateTime>(type: "date", nullable: true),
                    aDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    aEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DAppoint__D067651E69E82C47", x => x.appointmentID);
                    table.ForeignKey(
                        name: "FK_DAppointments_DDoctors_doctorID",
                        column: x => x.doctorID,
                        principalTable: "DDoctors",
                        principalColumn: "doctorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DExercises",
                columns: table => new
                {
                    exercisesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exercisesType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    menuListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DExercis__CEBDDBC1C658BF6F", x => x.exercisesID);
                    table.ForeignKey(
                        name: "FK__DExercise__menuL__267ABA7A",
                        column: x => x.menuListID,
                        principalTable: "DMenuList",
                        principalColumn: "menuListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DNutritionFood",
                columns: table => new
                {
                    nutritionFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuListID = table.Column<int>(type: "int", nullable: true),
                    nutritionFoodType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DNutriti__41A0D12F49DC017C", x => x.nutritionFoodID);
                    table.ForeignKey(
                        name: "FK__DNutritio__menuL__31EC6D26",
                        column: x => x.menuListID,
                        principalTable: "DMenuList",
                        principalColumn: "menuListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DSleepHygiene",
                columns: table => new
                {
                    sleepHygieneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuListID = table.Column<int>(type: "int", nullable: true),
                    sleepHygieneTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sleepHygieneDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sleepingHygieneIMG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DSleepHy__1CBFC5A8E21B391D", x => x.sleepHygieneID);
                    table.ForeignKey(
                        name: "FK__DSleepHyg__menuL__3A81B327",
                        column: x => x.menuListID,
                        principalTable: "DMenuList",
                        principalColumn: "menuListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DYoga",
                columns: table => new
                {
                    yogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuListID = table.Column<int>(type: "int", nullable: true),
                    yogaType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DYoga__4B5D0AB97D6D308F", x => x.yogaID);
                    table.ForeignKey(
                        name: "FK__DYoga__menuListI__3D5E1FD2",
                        column: x => x.menuListID,
                        principalTable: "DMenuList",
                        principalColumn: "menuListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMentalHealth",
                columns: table => new
                {
                    doctorID = table.Column<int>(type: "int", nullable: true),
                    appointmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__DMentalHe__appoi__534D60F1",
                        column: x => x.appointmentID,
                        principalTable: "DAppointments",
                        principalColumn: "appointmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DMentalHe__docto__52593CB8",
                        column: x => x.doctorID,
                        principalTable: "DDoctors",
                        principalColumn: "doctorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DexercisesItems",
                columns: table => new
                {
                    exerciseItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exercisesID = table.Column<int>(type: "int", nullable: true),
                    exerciseItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    exerciseItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exerciseItemIMG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dexercis__8C0C5190B7455C22", x => x.exerciseItemID);
                    table.ForeignKey(
                        name: "FK__Dexercise__exerc__628FA481",
                        column: x => x.exercisesID,
                        principalTable: "DExercises",
                        principalColumn: "exercisesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DnutritionFooodItems",
                columns: table => new
                {
                    nutritionFoodItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutritionFoodID = table.Column<int>(type: "int", nullable: true),
                    nutritionFoodItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nutritionFoodItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nutritionFoodItemIMG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dnutriti__89A788AA5D848B0C", x => x.nutritionFoodItemID);
                    table.ForeignKey(
                        name: "FK__Dnutritio__nutri__656C112C",
                        column: x => x.nutritionFoodID,
                        principalTable: "DNutritionFood",
                        principalColumn: "nutritionFoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DyogaItems",
                columns: table => new
                {
                    yogaItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yogaID = table.Column<int>(type: "int", nullable: true),
                    yogaItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    yogaItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YogaItemImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DyogaIte__8B2D9BBF50C3DD59", x => x.yogaItemID);
                    table.ForeignKey(
                        name: "FK__DyogaItem__yogaI__68487DD7",
                        column: x => x.yogaID,
                        principalTable: "DYoga",
                        principalColumn: "yogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61aefc30-7e28-4c49-93b3-186e0b41e15c", "7a147514-bfcd-461b-b959-3609cd3ee5b9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0082242a-eb2c-4142-a041-49a2fd2a86bf", "9278460f-9a67-4a8d-9615-29c79ed4d209", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DAppointments_doctorID",
                table: "DAppointments",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DExercises_menuListID",
                table: "DExercises",
                column: "menuListID");

            migrationBuilder.CreateIndex(
                name: "IX_DexercisesItems_exercisesID",
                table: "DexercisesItems",
                column: "exercisesID");

            migrationBuilder.CreateIndex(
                name: "IX_DMentalHealth_appointmentID",
                table: "DMentalHealth",
                column: "appointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DMentalHealth_doctorID",
                table: "DMentalHealth",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DNutritionFood_menuListID",
                table: "DNutritionFood",
                column: "menuListID");

            migrationBuilder.CreateIndex(
                name: "IX_DnutritionFooodItems_nutritionFoodID",
                table: "DnutritionFooodItems",
                column: "nutritionFoodID");

            migrationBuilder.CreateIndex(
                name: "IX_DSleepHygiene_menuListID",
                table: "DSleepHygiene",
                column: "menuListID");

            migrationBuilder.CreateIndex(
                name: "IX_DYoga_menuListID",
                table: "DYoga",
                column: "menuListID");

            migrationBuilder.CreateIndex(
                name: "IX_DyogaItems_yogaID",
                table: "DyogaItems",
                column: "yogaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DexercisesItems");

            migrationBuilder.DropTable(
                name: "Dfeedbacks");

            migrationBuilder.DropTable(
                name: "DMentalHealth");

            migrationBuilder.DropTable(
                name: "DnutritionFooodItems");

            migrationBuilder.DropTable(
                name: "DSleepHygiene");

            migrationBuilder.DropTable(
                name: "DyogaItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DExercises");

            migrationBuilder.DropTable(
                name: "DAppointments");

            migrationBuilder.DropTable(
                name: "DNutritionFood");

            migrationBuilder.DropTable(
                name: "DYoga");

            migrationBuilder.DropTable(
                name: "DDoctors");

            migrationBuilder.DropTable(
                name: "DMenuList");
        }
    }
}
