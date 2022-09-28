using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PersonalWellBeing.Models
{
    public partial class PersonalWellBeingContext : IdentityDbContext<User>
    {
        public PersonalWellBeingContext()
        {
        }

        public PersonalWellBeingContext(DbContextOptions<PersonalWellBeingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dappointment> Dappointments { get; set; }
        public virtual DbSet<Ddoctor> Ddoctors { get; set; }
        public virtual DbSet<Dexercise> Dexercises { get; set; }
        public virtual DbSet<DexercisesItem> DexercisesItems { get; set; }
        public virtual DbSet<Dfeedback> Dfeedbacks { get; set; }
        public virtual DbSet<DmentalHealth> DmentalHealths { get; set; }
        public virtual DbSet<DmenuList> DmenuLists { get; set; }
        public virtual DbSet<DnutritionFood> DnutritionFoods { get; set; }
        public virtual DbSet<DnutritionFooodItem> DnutritionFooodItems { get; set; }
        public virtual DbSet<DsleepHygiene> DsleepHygienes { get; set; }
        
        public virtual DbSet<Dyoga> Dyogas { get; set; }
        public virtual DbSet<DyogaItem> DyogaItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PersonalWellBeing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name="Member", NormalizedName = "MEMBER"},
                    new IdentityRole { Name="Admin", NormalizedName = "ADMIN"}
                );
            modelBuilder.Entity<Dappointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__DAppoint__D067651E69E82C47");

                entity.ToTable("DAppointments");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentID");

                entity.Property(e => e.ADate)
                    .HasColumnType("datetime")
                    .HasColumnName("aDate");

                entity.Property(e => e.ADoneDate)
                    .HasColumnType("date")
                    .HasColumnName("aDoneDate");

                entity.Property(e => e.AName)
                    .HasMaxLength(50)
                    .HasColumnName("aName");

                entity.Property(e => e.APurpose)
                    .HasMaxLength(250)
                    .HasColumnName("aPurpose");

                entity.Property(e => e.ASurname)
                    .HasMaxLength(50)
                    .HasColumnName("aSurname");

                entity.Property(e => e.DoctorId).HasColumnName("doctorID");

                entity.Property(e => e.UserId).HasColumnName("userID");

 //              entity.HasOne(d => d.Doctor)
   //             .WithMany(p => p.Dappointments)
     //               .HasForeignKey(d => d.DoctorId)
       //             .HasConstraintName("FK__DAppointm__docto__5070F446");

               
            });

            modelBuilder.Entity<Ddoctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__DDoctors__72248596E96C7FBC");

                entity.ToTable("DDoctors");

                entity.Property(e => e.DoctorId).HasColumnName("doctorID");

                entity.Property(e => e.DoctorImg)
                    .HasMaxLength(500)
                    .HasColumnName("doctorIMG");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .HasColumnName("doctorName");

                entity.Property(e => e.DoctorSummary)
                    .HasMaxLength(250)
                    .HasColumnName("doctorSummary");

                entity.Property(e => e.DoctorSurname)
                    .HasMaxLength(50)
                    .HasColumnName("doctorSurname");
            });

            modelBuilder.Entity<Dexercise>(entity =>
            {
                entity.HasKey(e => e.ExercisesId)
                    .HasName("PK__DExercis__CEBDDBC1C658BF6F");

                entity.ToTable("DExercises");

                entity.Property(e => e.ExercisesId).HasColumnName("exercisesID");

                entity.Property(e => e.ExercisesType)
                    .HasMaxLength(100)
                    .HasColumnName("exercisesType");

                entity.Property(e => e.MenuListId).HasColumnName("menuListID");

                entity.HasOne(d => d.MenuList)
                    .WithMany(p => p.Dexercises)
                    .HasForeignKey(d => d.MenuListId)
                    .HasConstraintName("FK__DExercise__menuL__267ABA7A");
            });

            modelBuilder.Entity<DexercisesItem>(entity =>
            {
                entity.HasKey(e => e.ExerciseItemId)
                    .HasName("PK__Dexercis__8C0C5190B7455C22");

                entity.Property(e => e.ExerciseItemId).HasColumnName("exerciseItemID");

                entity.Property(e => e.ExerciseItemDescription)
                    .HasMaxLength(250)
                    .HasColumnName("exerciseItemDescription");

                entity.Property(e => e.ExerciseItemImg)
                    .HasMaxLength(500)
                    .HasColumnName("exerciseItemIMG");

                entity.Property(e => e.ExerciseItemTitle)
                    .HasMaxLength(50)
                    .HasColumnName("exerciseItemTitle");

                entity.Property(e => e.ExercisesId).HasColumnName("exercisesID");

                entity.HasOne(d => d.Exercises)
                    .WithMany(p => p.DexercisesItems)
                    .HasForeignKey(d => d.ExercisesId)
                    .HasConstraintName("FK__Dexercise__exerc__628FA481");
            });

            modelBuilder.Entity<Dfeedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("PK__Dfeedbac__2613FDC4442F5FB1");

                entity.Property(e => e.FeedbackId).HasColumnName("feedbackID");

                entity.Property(e => e.FeedbackText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("feedbackText");

                entity.Property(e => e.UserId).HasColumnName("userID");

               
            });

            modelBuilder.Entity<DmentalHealth>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DMentalHealth");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentID");

                entity.Property(e => e.DoctorId).HasColumnName("doctorID");

                entity.HasOne(d => d.Appointment)
                    .WithMany()
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__DMentalHe__appoi__534D60F1");

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__DMentalHe__docto__52593CB8");
            });

            modelBuilder.Entity<DmenuList>(entity =>
            {
                entity.HasKey(e => e.MenuListId)
                    .HasName("PK__DMenuLis__D5EC925C92A9CDE6");

                entity.ToTable("DMenuList");

                entity.Property(e => e.MenuListId).HasColumnName("menuListID");

                entity.Property(e => e.MenuListImg)
                    .HasMaxLength(100)
                    .HasColumnName("menuListImg");

                entity.Property(e => e.MenuListItem)
                    .HasMaxLength(100)
                    .HasColumnName("menuListItem");
            });

            modelBuilder.Entity<DnutritionFood>(entity =>
            {
                entity.HasKey(e => e.NutritionFoodId)
                    .HasName("PK__DNutriti__41A0D12F49DC017C");

                entity.ToTable("DNutritionFood");

                entity.Property(e => e.NutritionFoodId).HasColumnName("nutritionFoodID");

                entity.Property(e => e.MenuListId).HasColumnName("menuListID");

                entity.Property(e => e.NutritionFoodType)
                    .HasMaxLength(100)
                    .HasColumnName("nutritionFoodType");

                entity.HasOne(d => d.MenuList)
                    .WithMany(p => p.DnutritionFoods)
                    .HasForeignKey(d => d.MenuListId)
                    .HasConstraintName("FK__DNutritio__menuL__31EC6D26");
            });

            modelBuilder.Entity<DnutritionFooodItem>(entity =>
            {
                entity.HasKey(e => e.NutritionFoodItemId)
                    .HasName("PK__Dnutriti__89A788AA5D848B0C");

                entity.Property(e => e.NutritionFoodItemId).HasColumnName("nutritionFoodItemID");

                entity.Property(e => e.NutritionFoodId).HasColumnName("nutritionFoodID");

                entity.Property(e => e.NutritionFoodItemDescription)
                    .HasMaxLength(250)
                    .HasColumnName("nutritionFoodItemDescription");

                entity.Property(e => e.NutritionFoodItemImg)
                    .HasMaxLength(500)
                    .HasColumnName("nutritionFoodItemIMG");

                entity.Property(e => e.NutritionFoodItemTitle)
                    .HasMaxLength(50)
                    .HasColumnName("nutritionFoodItemTitle");

                entity.HasOne(d => d.NutritionFood)
                    .WithMany(p => p.DnutritionFooodItems)
                    .HasForeignKey(d => d.NutritionFoodId)
                    .HasConstraintName("FK__Dnutritio__nutri__656C112C");
            });

            modelBuilder.Entity<DsleepHygiene>(entity =>
            {
                entity.HasKey(e => e.SleepHygieneId)
                    .HasName("PK__DSleepHy__1CBFC5A8E21B391D");

                entity.ToTable("DSleepHygiene");

                entity.Property(e => e.SleepHygieneId).HasColumnName("sleepHygieneID");

                entity.Property(e => e.MenuListId).HasColumnName("menuListID");

                entity.Property(e => e.SleepHygieneDescription)
                    .HasMaxLength(500)
                    .HasColumnName("sleepHygieneDescription");

                entity.Property(e => e.SleepHygieneTitle)
                    .HasMaxLength(50)
                    .HasColumnName("sleepHygieneTitle");

                entity.Property(e => e.SleepingHygieneImg)
                    .HasMaxLength(500)
                    .HasColumnName("sleepingHygieneIMG");

                entity.HasOne(d => d.MenuList)
                    .WithMany(p => p.DsleepHygienes)
                    .HasForeignKey(d => d.MenuListId)
                    .HasConstraintName("FK__DSleepHyg__menuL__3A81B327");
            });

  
            modelBuilder.Entity<Dyoga>(entity =>
            {
                entity.HasKey(e => e.YogaId)
                    .HasName("PK__DYoga__4B5D0AB97D6D308F");

                entity.ToTable("DYoga");

                entity.Property(e => e.YogaId).HasColumnName("yogaID");

                entity.Property(e => e.MenuListId).HasColumnName("menuListID");

                entity.Property(e => e.YogaType)
                    .HasMaxLength(100)
                    .HasColumnName("yogaType");

                entity.HasOne(d => d.MenuList)
                    .WithMany(p => p.Dyogas)
                    .HasForeignKey(d => d.MenuListId)
                    .HasConstraintName("FK__DYoga__menuListI__3D5E1FD2");
            });

            modelBuilder.Entity<DyogaItem>(entity =>
            {
                entity.HasKey(e => e.YogaItemId)
                    .HasName("PK__DyogaIte__8B2D9BBF50C3DD59");

                entity.Property(e => e.YogaItemId).HasColumnName("yogaItemID");

                entity.Property(e => e.YogaId).HasColumnName("yogaID");

                entity.Property(e => e.YogaItemDescription)
                    .HasMaxLength(250)
                    .HasColumnName("yogaItemDescription");

                entity.Property(e => e.YogaItemTitle)
                    .HasMaxLength(50)
                    .HasColumnName("yogaItemTitle");

                entity.HasOne(d => d.Yoga)
                    .WithMany(p => p.DyogaItems)
                    .HasForeignKey(d => d.YogaId)
                    .HasConstraintName("FK__DyogaItem__yogaI__68487DD7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
