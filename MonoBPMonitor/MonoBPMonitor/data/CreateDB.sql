CREATE TABLE [tb_BPEntry] (
[BPEntryID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[EntryDate] DATE  NOT NULL,
[Systolic] INTEGER  NOT NULL,
[Diastolic] INTEGER  NOT NULL,
[HeartRate] INTEGER  NOT NULL,
[Notes] TEXT  NULL,
[PersonID] INTEGER  NOT NULL
);

CREATE TABLE [tb_Doctor] (
[DoctorID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[DoctorName] VARCHAR(75)  NOT NULL,
[Location] VARCHAR(255)  NULL,
[PhoneNum] VARCHAR(50)  NULL,
[PersonID] INTEGER  NOT NULL
);

CREATE TABLE [tb_Medicine] (
[MedicineID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[MedicineName] VARCHAR(75)  NOT NULL,
[Dosage] VARCHAR(255)  NULL,
[StartDate] DATE  NULL,
[EndDate] DATE  NULL,
[DoctorID] INTEGER  NULL
);

CREATE TABLE [tb_Person] (
[PersonID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[PersonName] VARCHAR(50)  NOT NULL
);

CREATE UNIQUE INDEX [IX_tb_BPEntry_BPEntryID_EntryDate] ON [tb_BPEntry](
[BPEntryID]  DESC,
[EntryDate]  DESC
);

CREATE UNIQUE INDEX [IX_tb_BPEntry_PBEntryID_PersonID] ON [tb_BPEntry](
[PersonID]  DESC,
[BPEntryID]  DESC
);

CREATE UNIQUE INDEX [IDX_tb_Doctor_PersonID_DoctorID] ON [tb_Doctor](
[PersonID]  DESC,
[DoctorID]  DESC
);
