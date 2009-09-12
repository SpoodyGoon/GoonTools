CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE [tb_User] (
[UserID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[UserName] VARCHAR(50)  NOT NULL,
[DateAdded] DATE DEFAULT CURRENT_DATE NOT NULL,
[IsActive] BOOLEAN DEFAULT '''True''' NOT NULL
);
CREATE TABLE [tb_Doctor] (
[DoctorID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[DoctorName] VARCHAR(75)  NOT NULL,
[Location] VARCHAR(255)  NULL,
[PhoneNum] VARCHAR(50)  NULL,
[UserID] INTEGER  NOT NULL
);
CREATE TABLE [tb_Medicine] (
[MedicineID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[MedicineName] VARCHAR(75)  NOT NULL,
[Dosage] VARCHAR(255)  NULL,
[StartDate] DATE  NULL,
[EndDate] DATE  NULL,
[DoctorID] INTEGER  NULL,
[UserID] INTEGER  NULL
);
CREATE UNIQUE INDEX [IDX_tb_Doctor_UserID_DoctorID] ON [tb_Doctor](
[DoctorID]  DESC,
[UserID]  DESC
);
CREATE TABLE sqlite_stat1(tbl,idx,stat);
CREATE TABLE "tb_Entry" ("EntryID" INTEGER PRIMARY KEY  NOT NULL ,"EntryDateTime" DATETIME NOT NULL ,"Systolic" INTEGER NOT NULL ,"Diastolic" INTEGER NOT NULL ,"HeartRate" INTEGER NOT NULL ,"Notes" TEXT,"UserID" INTEGER NOT NULL );
CREATE UNIQUE INDEX "IX_tb_Entry_UserID_DateTime" on tb_entry (EntryID ASC, EntryDateTime ASC, UserID ASC);
CREATE UNIQUE INDEX "IX_tb_Medicine_DoctorID_UserID" on tb_medicine (MedicineID ASC, DoctorID ASC, UserID ASC);
CREATE UNIQUE INDEX "IX_tb_User_UserID_IsActive" on tb_user (UserID ASC, IsActive ASC);
