use PersonalWellBeing

create table DUser(
	userID int primary key identity(1,1),
	name nvarchar(50),
	surname nvarchar(50),
	email nvarchar(100),
	phoneNumber nvarchar(50),
	password nvarchar(50)
);
alter table DUser add userRole nvarchar(100);
create table DMenuList(
	menuListID int primary key identity(1,1),
	menuListItem nvarchar(100)
);
create table DExercises(
	exercisesID int primary key identity(1,1),
	exercisesType nvarchar(100),
	menuListID int,
	FOREIGN KEY(menuListID)REFERENCES DMenuList(menuListID)
);


create table DStrength(
	exercisesID int,
	strengthID int primary key identity(1,1),
	strengthTitle nvarchar(50),
	strengthDescription nvarchar(250),
	strengthIMG nvarchar(500)
	FOREIGN KEY(exercisesID)REFERENCES DExercises(exercisesID)
);
create table DEndurance(
	exercisesID int,
	enduranceID int primary key identity(1,1),
	enduranceTitle nvarchar(50),
	enduranceDescription nvarchar(250),
	enduranceIMG nvarchar(500),
	FOREIGN KEY(exercisesID)REFERENCES DExercises(exercisesID)
);
create table DNutritionFood(
	menuListID int,
	nutritionFoodID int primary key identity(1,1),
	nutritionFoodType nvarchar (100),
	FOREIGN KEY(menuListID)REFERENCES DMenuList(menuListID)
);
create table DnutritionFooodItems(
	nutritionFoodID int,
	nutritionFoodItemID int primary key identity (1,1),
	nutritionFoodItemTitle nvarchar(50),
	nutritionFoodItemDescription nvarchar(250),
	nutritionFoodItemIMG nvarchar(500),
	FOREIGN KEY(nutritionFoodID)REFERENCES DNutritionFood(nutritionFoodID)
);
create table DProteins(
	nutritionFoodID int,
	proteinsID int primary key identity (1,1),
	proteinsTitle nvarchar(50),
	proteinsDescription nvarchar(250),
	proteinsIMG nvarchar(500),
	FOREIGN KEY(nutritionFoodID)REFERENCES DNutritionFood(nutritionFoodID)
);
create table DSleepHygiene(
	menuListID int,
	sleepHygieneID int primary key identity(1,1),
	sleepHygieneTitle nvarchar(50),
	sleepHygieneDescription nvarchar(500),
	sleepingHygieneIMG nvarchar(500),
	FOREIGN KEY(menuListID)REFERENCES DMenuLisT(menuListID)
);
create table DYoga(
	menuListID int, 
	yogaID int primary key identity(1,1),
	yogaType nvarchar(100),
	FOREIGN KEY(menuListID)REFERENCES DMenuList(menuListID)
);
create table DyogaItems(
	yogaID int,
	yogaItemID int primary key identity(1,1),
	yogaItemTitle nvarchar (50),
	yogaItemDescription nvarchar(250),
	FOREIGN KEY(yogaID)REFERENCES DYoga(yogaID)
);
create table DHatha(
	yogaID int, 
	hathaID int primary key identity(1,1),
	hathaTitle nvarchar(50),
	hathaDescription nvarchar(250),
	FOREIGN KEY(yogaID)REFERENCES DYoga(yogaID)
);
create table DDoctors(
	doctorID int primary key identity (1,1),
	doctorName nvarchar(50),
	doctorSurname nvarchar(50),
	doctorSummary nvarchar (250),
	doctorIMG nvarchar(500)
);
alter table DDoctors alter column doctorSummary nvarchar(500);
create table DAppointments(
	appointmentID int primary key identity(1,1),
	doctorID int,
	userID int,
	aName nvarchar(50),
	aSurname nvarchar(50),
	aPurpose nvarchar(250),
	aDoneDate date,
	aDate datetime,
	FOREIGN KEY(userID)REFERENCES DUser(userID),
	FOREIGN KEY(doctorID)REFERENCES DDoctors(doctorID)
);
create table DMentalHealth(
	doctorID int,
	appointmentID int,
	FOREIGN KEY(doctorID)REFERENCES DDoctors(doctorID),
	FOREIGN KEY(appointmentID)REFERENCES DAppointments(appointmentID)
);

drop table DMenuList
select * from DexercisesItems