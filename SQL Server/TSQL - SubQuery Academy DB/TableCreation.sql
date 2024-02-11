use [Subquery_Academy_DB]

CREATE TABLE Curators
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Curators_Id 
	PRIMARY KEY (Id),

	[Name] NVARCHAR(MAX) NOT NULL ,
	CONSTRAINT CK_Curators_Name 
	CHECK (LEN([Name]) > 0),

	Surname NVARCHAR(MAX) NOT NULL ,
	CONSTRAINT CK_Curators_Surname 
	CHECK (LEN(Surname) > 0)
)

CREATE TABLE Faculties
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Faculties_Id
	PRIMARY KEY (Id),

	[Name] NVARCHAR(100) NOT NULL ,
	CONSTRAINT CK_Faculties_Name 
	CHECK (LEN([Name]) > 0),
	CONSTRAINT UK_Faculties_Name
	UNIQUE ([Name]),

)

CREATE TABLE Departments
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Departments_Id
	PRIMARY KEY (Id),

	Building INT NOT NULL ,
	CONSTRAINT CK_Departments_Building
	CHECK (Building BETWEEN 1 AND 5),

	Financing MONEY NOT NULL DEFAULT 0 ,
	CONSTRAINT CK_Departments_Financing
	CHECK (Financing > 0),

	[Name] NVARCHAR(100) NOT NULL ,
	CONSTRAINT CK_Departments_Name 
	CHECK (LEN([Name]) > 0),
	CONSTRAINT UK_Departments_Name
	UNIQUE ([Name]),

	FacultyId INT NOT NULL ,
	CONSTRAINT FK_Departments_FacultyId
	FOREIGN KEY (FacultyId) 
	REFERENCES Faculties(Id)
)

CREATE TABLE Groups 
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Groups_Id
	PRIMARY KEY (Id),

	[Name] NVARCHAR(15) NOT NULL ,
	CONSTRAINT CK_Groups_Name 
	CHECK (LEN([Name]) > 0),
	CONSTRAINT UK_Groups_Name
	UNIQUE ([Name]),

	[Year] INT NOT NULL ,
	CONSTRAINT CK_Groups_Year
	CHECK ([Year] BETWEEN 1 AND 5),

	DepartmentId INT NOT NULL ,
	CONSTRAINT FK_Groups_DepartmentId
	FOREIGN KEY (DepartmentId)
	REFERENCES Departments(Id)
)

CREATE TABLE Teachers
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Teachers_Id
	PRIMARY KEY (Id),

	IsProfessor BIT NOT NULL DEFAULT 0,

	[Name] NVARCHAR(MAX) NOT NULL ,
	CONSTRAINT CK_Teacher_Name 
	CHECK (LEN([Name]) > 0),

	Salary MONEY NOT NULL ,
	CONSTRAINT CK_Teachers_Salary
	CHECK(Salary>0),

	Surname NVARCHAR(MAX) NOT NULL ,
	CONSTRAINT CK_Teachers_Surname 
	CHECK (LEN(Surname) > 0)
)

CREATE TABLE Subjects
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Subjects_Id
	PRIMARY KEY (Id),

	[Name] NVARCHAR(100) NOT NULL ,
	CONSTRAINT CK_Subjects_Name 
	CHECK (LEN([Name]) > 0),
	CONSTRAINT UK_Subjects_Name
	UNIQUE ([Name])
)

CREATE TABLE Students
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Stuents_Id
	PRIMARY KEY (Id),

	[Name] NVARCHAR(100) NOT NULL ,
	CONSTRAINT CK_Students_Name 
	CHECK (LEN([Name]) > 0),

	Rating INT NOT NULL ,
	CONSTRAINT CK_Stuents_Rating
	CHECK (Rating BETWEEN 0 AND 5),

	Surname NVARCHAR(100) NOT NULL,
	CONSTRAINT CK_Students_Surname 
	CHECK (LEN([Surname]) > 0),
)

CREATE TABLE Lectures
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Lectures_Id
	PRIMARY KEY (Id),

	LectureDate DATE NOT NULL ,
	CONSTRAINT CK_Lectrues_LectureDate
	CHECK (LectureDate <= GETDATE()),

	SubjectId INT NOT NULL ,
	CONSTRAINT FK_Lectures_SubjectId
	FOREIGN KEY (SubjectId)
	REFERENCES Subjects(Id),

	TeacherId INT NOT NULL ,
	CONSTRAINT FK_Lectures_TeacherId
	FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id)


)

CREATE TABLE GroupsCurators
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_GroupsCurators_Id
	PRIMARY KEY (Id),

	CuratorId INT NOT NULL ,
	CONSTRAINT FK_GroupsCurators_CuratorId
	FOREIGN KEY (CuratorId)
	REFERENCES Curators(Id),

	GroupId INT NOT NULL,
	CONSTRAINT FK_GroupsCurators_GroupId
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id)
)

CREATE TABLE GroupsLectures
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_GroupsLectures_Id
	PRIMARY KEY (Id),

	GroupId INT NOT NULL ,
	CONSTRAINT FK_GroupsLectures_GroupId
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id),

	LectureId INT NOT NULL ,
	CONSTRAINT FK_GroupsLectures_LectureId
	FOREIGN KEY (LectureId)
	REFERENCES Lectures(Id)
)

CREATE TABLE GroupsStudents
(
	Id INT NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_GroupsStudents_Id
	PRIMARY KEY (Id),

	GroupId INT NOT NULL ,
	CONSTRAINT PK_GroupsStudents_GroupId
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id),

	StudentId INT NOT NULL ,
	CONSTRAINT PK_GroupsStudents_StudentId
	FOREIGN KEY (StudentId)
	REFERENCES Students(Id)
)