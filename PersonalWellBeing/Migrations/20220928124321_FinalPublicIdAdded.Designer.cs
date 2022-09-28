﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWellBeing.Models;

namespace PersonalWellBeing.Migrations
{
    [DbContext(typeof(PersonalWellBeingContext))]
    [Migration("20220928124321_FinalPublicIdAdded")]
    partial class FinalPublicIdAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "46d87f68-eaad-4d22-87df-16958fdd2a53",
                            ConcurrencyStamp = "bf6f1f5a-3950-4910-85d2-d2a93154453f",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "324df60c-1911-4f7d-ab42-3d173456f71e",
                            ConcurrencyStamp = "f8ad7ea7-915a-48b9-b8e4-d9b88240c4f4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dappointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("appointmentID")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("ADate")
                        .HasColumnType("datetime")
                        .HasColumnName("aDate");

                    b.Property<DateTime?>("ADoneDate")
                        .HasColumnType("date")
                        .HasColumnName("aDoneDate");

                    b.Property<string>("AName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("aName");

                    b.Property<string>("APurpose")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("aPurpose");

                    b.Property<string>("ASurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("aSurname");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("doctorID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.Property<string>("aEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId")
                        .HasName("PK__DAppoint__D067651E69E82C47");

                    b.HasIndex("DoctorId");

                    b.ToTable("DAppointments");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Ddoctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("doctorID")
                        .UseIdentityColumn();

                    b.Property<string>("DoctorImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("doctorIMG");

                    b.Property<string>("DoctorName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("doctorName");

                    b.Property<string>("DoctorSummary")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("doctorSummary");

                    b.Property<string>("DoctorSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("doctorSurname");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId")
                        .HasName("PK__DDoctors__72248596E96C7FBC");

                    b.ToTable("DDoctors");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dexercise", b =>
                {
                    b.Property<int>("ExercisesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("exercisesID")
                        .UseIdentityColumn();

                    b.Property<string>("ExercisesType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("exercisesType");

                    b.Property<int?>("MenuListId")
                        .HasColumnType("int")
                        .HasColumnName("menuListID");

                    b.HasKey("ExercisesId")
                        .HasName("PK__DExercis__CEBDDBC1C658BF6F");

                    b.HasIndex("MenuListId");

                    b.ToTable("DExercises");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DexercisesItem", b =>
                {
                    b.Property<int>("ExerciseItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("exerciseItemID")
                        .UseIdentityColumn();

                    b.Property<string>("ExerciseItemDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("exerciseItemDescription");

                    b.Property<string>("ExerciseItemImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("exerciseItemIMG");

                    b.Property<string>("ExerciseItemTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("exerciseItemTitle");

                    b.Property<int?>("ExercisesId")
                        .HasColumnType("int")
                        .HasColumnName("exercisesID");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseItemId")
                        .HasName("PK__Dexercis__8C0C5190B7455C22");

                    b.HasIndex("ExercisesId");

                    b.ToTable("DexercisesItems");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dfeedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("feedbackID")
                        .UseIdentityColumn();

                    b.Property<string>("FeedbackText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("feedbackText");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("FeedbackId")
                        .HasName("PK__Dfeedbac__2613FDC4442F5FB1");

                    b.ToTable("Dfeedbacks");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DmentalHealth", b =>
                {
                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int")
                        .HasColumnName("appointmentID");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("doctorID");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DMentalHealth");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DmenuList", b =>
                {
                    b.Property<int>("MenuListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("menuListID")
                        .UseIdentityColumn();

                    b.Property<string>("MenuListImg")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("menuListImg");

                    b.Property<string>("MenuListItem")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("menuListItem");

                    b.HasKey("MenuListId")
                        .HasName("PK__DMenuLis__D5EC925C92A9CDE6");

                    b.ToTable("DMenuList");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DnutritionFood", b =>
                {
                    b.Property<int>("NutritionFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nutritionFoodID")
                        .UseIdentityColumn();

                    b.Property<int?>("MenuListId")
                        .HasColumnType("int")
                        .HasColumnName("menuListID");

                    b.Property<string>("NutritionFoodType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nutritionFoodType");

                    b.HasKey("NutritionFoodId")
                        .HasName("PK__DNutriti__41A0D12F49DC017C");

                    b.HasIndex("MenuListId");

                    b.ToTable("DNutritionFood");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DnutritionFooodItem", b =>
                {
                    b.Property<int>("NutritionFoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nutritionFoodItemID")
                        .UseIdentityColumn();

                    b.Property<int?>("NutritionFoodId")
                        .HasColumnType("int")
                        .HasColumnName("nutritionFoodID");

                    b.Property<string>("NutritionFoodItemDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nutritionFoodItemDescription");

                    b.Property<string>("NutritionFoodItemImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("nutritionFoodItemIMG");

                    b.Property<string>("NutritionFoodItemTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nutritionFoodItemTitle");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NutritionFoodItemId")
                        .HasName("PK__Dnutriti__89A788AA5D848B0C");

                    b.HasIndex("NutritionFoodId");

                    b.ToTable("DnutritionFooodItems");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DsleepHygiene", b =>
                {
                    b.Property<int>("SleepHygieneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sleepHygieneID")
                        .UseIdentityColumn();

                    b.Property<int?>("MenuListId")
                        .HasColumnType("int")
                        .HasColumnName("menuListID");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SleepHygieneDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("sleepHygieneDescription");

                    b.Property<string>("SleepHygieneTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sleepHygieneTitle");

                    b.Property<string>("SleepingHygieneImg")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("sleepingHygieneIMG");

                    b.HasKey("SleepHygieneId")
                        .HasName("PK__DSleepHy__1CBFC5A8E21B391D");

                    b.HasIndex("MenuListId");

                    b.ToTable("DSleepHygiene");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dyoga", b =>
                {
                    b.Property<int>("YogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("yogaID")
                        .UseIdentityColumn();

                    b.Property<int?>("MenuListId")
                        .HasColumnType("int")
                        .HasColumnName("menuListID");

                    b.Property<string>("YogaType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("yogaType");

                    b.HasKey("YogaId")
                        .HasName("PK__DYoga__4B5D0AB97D6D308F");

                    b.HasIndex("MenuListId");

                    b.ToTable("DYoga");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DyogaItem", b =>
                {
                    b.Property<int>("YogaItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("yogaItemID")
                        .UseIdentityColumn();

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YogaId")
                        .HasColumnType("int")
                        .HasColumnName("yogaID");

                    b.Property<string>("YogaItemDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("yogaItemDescription");

                    b.Property<string>("YogaItemTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("yogaItemTitle");

                    b.HasKey("YogaItemId")
                        .HasName("PK__DyogaIte__8B2D9BBF50C3DD59");

                    b.HasIndex("YogaId");

                    b.ToTable("DyogaItems");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWellBeing.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dappointment", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.Ddoctor", "Doctor")
                        .WithMany("Dappointments")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK__DAppointm__docto__5070F446");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dexercise", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.DmenuList", "MenuList")
                        .WithMany("Dexercises")
                        .HasForeignKey("MenuListId")
                        .HasConstraintName("FK__DExercise__menuL__267ABA7A");

                    b.Navigation("MenuList");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DexercisesItem", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.Dexercise", "Exercises")
                        .WithMany("DexercisesItems")
                        .HasForeignKey("ExercisesId")
                        .HasConstraintName("FK__Dexercise__exerc__628FA481");

                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DmentalHealth", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.Dappointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .HasConstraintName("FK__DMentalHe__appoi__534D60F1");

                    b.HasOne("PersonalWellBeing.Models.Ddoctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK__DMentalHe__docto__52593CB8");

                    b.Navigation("Appointment");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DnutritionFood", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.DmenuList", "MenuList")
                        .WithMany("DnutritionFoods")
                        .HasForeignKey("MenuListId")
                        .HasConstraintName("FK__DNutritio__menuL__31EC6D26");

                    b.Navigation("MenuList");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DnutritionFooodItem", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.DnutritionFood", "NutritionFood")
                        .WithMany("DnutritionFooodItems")
                        .HasForeignKey("NutritionFoodId")
                        .HasConstraintName("FK__Dnutritio__nutri__656C112C");

                    b.Navigation("NutritionFood");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DsleepHygiene", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.DmenuList", "MenuList")
                        .WithMany("DsleepHygienes")
                        .HasForeignKey("MenuListId")
                        .HasConstraintName("FK__DSleepHyg__menuL__3A81B327");

                    b.Navigation("MenuList");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dyoga", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.DmenuList", "MenuList")
                        .WithMany("Dyogas")
                        .HasForeignKey("MenuListId")
                        .HasConstraintName("FK__DYoga__menuListI__3D5E1FD2");

                    b.Navigation("MenuList");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DyogaItem", b =>
                {
                    b.HasOne("PersonalWellBeing.Models.Dyoga", "Yoga")
                        .WithMany("DyogaItems")
                        .HasForeignKey("YogaId")
                        .HasConstraintName("FK__DyogaItem__yogaI__68487DD7");

                    b.Navigation("Yoga");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Ddoctor", b =>
                {
                    b.Navigation("Dappointments");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dexercise", b =>
                {
                    b.Navigation("DexercisesItems");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DmenuList", b =>
                {
                    b.Navigation("Dexercises");

                    b.Navigation("DnutritionFoods");

                    b.Navigation("DsleepHygienes");

                    b.Navigation("Dyogas");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.DnutritionFood", b =>
                {
                    b.Navigation("DnutritionFooodItems");
                });

            modelBuilder.Entity("PersonalWellBeing.Models.Dyoga", b =>
                {
                    b.Navigation("DyogaItems");
                });
#pragma warning restore 612, 618
        }
    }
}