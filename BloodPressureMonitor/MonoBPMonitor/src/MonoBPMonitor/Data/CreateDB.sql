
-- creating the tables
CREATE TABLE [tb_Doctor] (
[DoctorID] INTEGER  PRIMARY KEY AUTOINCREMENT,
[DoctorName] VARCHAR(75)  NOT NULL,
[Location] VARCHAR(255)  NULL,
[PhoneNum] VARCHAR(50)  NULL
);

CREATE TABLE [tb_User] (
[UserID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[UserName] VARCHAR(50)  NOT NULL,
[DateAdded] DATE DEFAULT CURRENT_DATE NOT NULL,
[IsActive] BOOLEAN DEFAULT 'True' NOT NULL
);

CREATE TABLE [tb_DoctorUser](
[DoctorID] INTEGER  PRIMARY KEY,
[UserID] INTEGER  PRIMARY KEY,
);

CREATE TABLE [tb_Entry] (
[EntryID] INTEGER PRIMARY KEY,
[EntryDateTime] DATETIME NOT NULL ,
[Systolic] INTEGER NOT NULL ,
[Diastolic] INTEGER NOT NULL ,
[HeartRate] INTEGER NOT NULL ,
[Notes] TEXT,
[UserID] INTEGER NOT NULL 
);

CREATE TABLE [tb_Medicine] (
[MedicineID] INTEGER  PRIMARY KEY AUTOINCREMENT,
[MedicineName] VARCHAR(75)  NOT NULL,
[Dosage] VARCHAR(255)  NULL,
[StartDate] DATE  NULL,
[EndDate] DATE  NULL,
[DoctorID] INTEGER  NULL,
[UserID] INTEGER  NULL
);
-- creating the indexes
CREATE UNIQUE INDEX "IX_tb_Doctor_UserID_DoctorID" ON tb_Doctor(DoctorID ASC,UserID  ASC);
CREATE UNIQUE INDEX "IX_tb_Entry_UserID_DateTime" on tb_Entry (EntryID ASC, EntryDateTime ASC, UserID ASC);
CREATE UNIQUE INDEX "IX_tb_Medicine_DoctorID_UserID" on tb_Medicine (MedicineID ASC, DoctorID ASC, UserID ASC);
CREATE UNIQUE INDEX "IX_tb_User_UserID_IsActive" on tb_User (UserID ASC, IsActive ASC);

-- inserting the default user and doctor
INSERT INTO tb_User(UserName) VALUES ('Default');
INSERT INTO tb_Doctor(DoctorName, UserID) SELECT 'Default', UserID FROM tb_User WHERE UserName = 'Default';





