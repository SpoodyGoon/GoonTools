BEGIN TRANSACTION;

CREATE TABLE [tb_Doctor] (
[DoctorID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[DoctorName] VARCHAR(75)  NOT NULL,
[Location] VARCHAR(255)  NULL,
[PhoneNum] VARCHAR(50)  NULL,
[UserID] INTEGER  NOT NULL
);
INSERT INTO "tb_Doctor" VALUES(1,'Default',NULL,NULL,1);

CREATE TABLE [tb_Medicine] (
[MedicineID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[MedicineName] VARCHAR(75)  NOT NULL,
[Dosage] VARCHAR(255)  NULL,
[StartDate] DATE  NULL,
[EndDate] DATE  NULL,
[DoctorID] INTEGER  NULL,
[UserID] INTEGER  NULL
);
CREATE TABLE [tb_Entry] (
[EntryID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[EntryDate] DATE  NOT NULL,
[Systolic] INTEGER  NOT NULL,
[Diastolic] INTEGER  NOT NULL,
[HeartRate] INTEGER  NOT NULL,
[Notes] TEXT  NULL,
[UserID] INTEGER  NOT NULL
);

CREATE TABLE [tb_User] (
[UserID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[UserName] VARCHAR(50)  NOT NULL,
[DateAdded] DATE DEFAULT CURRENT_DATE NOT NULL,
[IsActive] BOOLEAN DEFAULT 'True' NOT NULL
);
INSERT INTO "tb_User" VALUES(1,'Default', DATETIME('now','localtime') ,'True');

CREATE UNIQUE INDEX [IDX_tb_Doctor_UserID_DoctorID] ON [tb_Doctor](
[DoctorID]  DESC,
[UserID]  DESC
);

CREATE UNIQUE INDEX [IX_tb_Entry_EntryID_EntryDate] ON [tb_Entry](
[EntryID]  DESC,
[EntryDate]  DESC
);

CREATE UNIQUE INDEX [IX_tb_Entry_EntryID_UserID] ON [tb_Entry](
[EntryID]  DESC,
[UserID]  DESC
);

PRAGMA read_uncommitted = true;
PRAGMA case_sensitive_like = false;
PRAGMA full_column_names = false;
PRAGMA user_version = 3;
PRAGMA short_column_names = true;
PRAGMA temp_store = MEMORY;

COMMIT;
