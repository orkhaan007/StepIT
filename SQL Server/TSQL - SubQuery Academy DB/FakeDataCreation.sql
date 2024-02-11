USE [Subquery_Academy_DB]

----------------------------------------- Curators Data -----------------------------------------

insert into Curators ([Name], Surname) values ('Corabelle', 'Connock');
insert into Curators ([Name], Surname) values ('Arri', 'Verdun');
insert into Curators ([Name], Surname) values ('Gerome', 'Carlone');
insert into Curators ([Name], Surname) values ('Ruttger', 'Blinman');
insert into Curators ([Name], Surname) values ('Selby', 'Yakovich');
insert into Curators ([Name], Surname) values ('Kelley', 'McOrkil');
insert into Curators ([Name], Surname) values ('Madel', 'Greenrde');
insert into Curators ([Name], Surname) values ('Aksel', 'Kimmel');
insert into Curators ([Name], Surname) values ('Katee', 'Gounin');
insert into Curators ([Name], Surname) values ('Humfrid', 'McGucken');
insert into Curators ([Name], Surname) values ('Barnett', 'Camblin');
insert into Curators ([Name], Surname) values ('Chico', 'Swaddle');
insert into Curators ([Name], Surname) values ('Berkley', 'Hayball');
insert into Curators ([Name], Surname) values ('Luca', 'Strettell');
insert into Curators ([Name], Surname) values ('Dwight', 'Skyram');
insert into Curators ([Name], Surname) values ('Janessa', 'Dalyiel');
insert into Curators ([Name], Surname) values ('Sadye', 'Storr');
insert into Curators ([Name], Surname) values ('Ruy', 'Bitten');
insert into Curators ([Name], Surname) values ('Enrique', 'Overell');
insert into Curators ([Name], Surname) values ('Lanita', 'Luipold');
insert into Curators ([Name], Surname) values ('Yehudi', 'Johann');
insert into Curators ([Name], Surname) values ('Orly', 'Durber');
insert into Curators ([Name], Surname) values ('Marna', 'Valeri');
insert into Curators ([Name], Surname) values ('Fionnula', 'Gregory');
insert into Curators ([Name], Surname) values ('Di', 'Hryniewicz');

----------------------------------------- Faculties Data -----------------------------------------

INSERT INTO Faculties VALUES ('Physics');
INSERT INTO Faculties VALUES ('Chemistry');
INSERT INTO Faculties VALUES ('Biology');
INSERT INTO Faculties VALUES ('Computer Science');
INSERT INTO Faculties VALUES ('History');
INSERT INTO Faculties VALUES ('English');
INSERT INTO Faculties VALUES ('Economics');
INSERT INTO Faculties VALUES ('Psychology');
INSERT INTO Faculties VALUES ('Sociology');
INSERT INTO Faculties VALUES ('Political Science');
INSERT INTO Faculties VALUES ('Engineering');
INSERT INTO Faculties VALUES ('Medicine');
INSERT INTO Faculties VALUES ('Law');
INSERT INTO Faculties VALUES ('Business Administration');
INSERT INTO Faculties VALUES ('Art');
INSERT INTO Faculties VALUES ('Music');
INSERT INTO Faculties VALUES ('Philosophy');
INSERT INTO Faculties VALUES ('Geology');
INSERT INTO Faculties VALUES ('Astronomy');
INSERT INTO Faculties VALUES ('Education');
INSERT INTO Faculties VALUES ('Nursing');
INSERT INTO Faculties VALUES ('Agriculture');
INSERT INTO Faculties VALUES ('Environmental Science');
INSERT INTO Faculties VALUES ('Statistics');
INSERT INTO Faculties VALUES ('Communication');

----------------------------------------- Departments Data -----------------------------------------

insert into Departments (Building, Financing, [Name], FacultyId) values (2, 6458.0, 'Cassin, Schultz and Kshlerin', 7);
insert into Departments (Building, Financing, [Name], FacultyId) values (1, 9529.2, 'Lesch-Stark', 18);
insert into Departments (Building, Financing, [Name], FacultyId) values (5, 4262.7, 'Schimmel-Lubowitz', 25);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 7526.7, 'Goyette, Pacocha and Walker', 24);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 5937.6, 'Gleason Group', 6);
insert into Departments (Building, Financing, [Name], FacultyId) values (5, 9734.3, 'Christiansen Group', 21);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 2488.8, 'Mosciski, Harber and McKenzie', 10);
insert into Departments (Building, Financing, [Name], FacultyId) values (2, 7019.9, 'Bartell Group', 23);
insert into Departments (Building, Financing, [Name], FacultyId) values (3, 2777.8, 'Jenkins, Brakus and Hayes', 5);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 1226.3, 'Kilback Inc', 10);
insert into Departments (Building, Financing, [Name], FacultyId) values (5, 4373.1, 'Lueilwitz Inc', 19);
insert into Departments (Building, Financing, [Name], FacultyId) values (3, 2582.3, 'Friesen, Hermann and Kshlerin', 14);
insert into Departments (Building, Financing, [Name], FacultyId) values (3, 2384.3, 'Strosin-Kautzer', 21);
insert into Departments (Building, Financing, [Name], FacultyId) values (1, 9409.3, 'Kuphal and Sons', 14);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 2357.6, 'Jast-Dietrich', 13);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 6794.2, 'Rohan, Ernser and Schmidt', 18);
insert into Departments (Building, Financing, [Name], FacultyId) values (3, 3266.5, 'Gerlach, Carter and Bartoletti', 7);
insert into Departments (Building, Financing, [Name], FacultyId) values (1, 3323.7, 'Labadie, Harvey and Ward', 22);
insert into Departments (Building, Financing, [Name], FacultyId) values (3, 6750.3, 'Koepp-Rau', 2);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 2342.6, 'Kuvalis Inc', 16);
insert into Departments (Building, Financing, [Name], FacultyId) values (4, 5275.8, 'Monahan, Smitham and O''Kon', 11);
insert into Departments (Building, Financing, [Name], FacultyId) values (2, 1514.6, 'Hills LLC', 24);
insert into Departments (Building, Financing, [Name], FacultyId) values (2, 8132.8, 'Kshlerin, Dach and Waters', 11);
insert into Departments (Building, Financing, [Name], FacultyId) values (1, 5667.9, 'O''Conner, Cruickshank and Rosenbaum', 4);
insert into Departments (Building, Financing, [Name], FacultyId) values (1, 7280.0, 'Mayer-Pacocha', 4);

----------------------------------------- Groups Data -----------------------------------------

insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_7_02_4_az', 5, 19);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_5_98_1_az', 2, 15);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_7_25_4_az', 4, 4);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_3_03_0_az', 1, 8);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_3_30_0_az', 2, 21);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_4_04_8_az', 4, 16);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_7_32_6_az', 2, 4);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_4_37_8_az', 4, 23);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_4_78_6_az', 5, 13);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_3_72_3_az', 1, 7);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_3_97_5_az', 5, 2);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_8_31_3_az', 2, 14);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_4_84_3_az', 3, 11);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_1_35_1_az', 5, 13);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_0_59_1_az', 1, 21);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_5_22_7_az', 1, 24);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_8_12_8_az', 5, 9);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_8_13_7_az', 3, 2);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_6_64_6_az', 5, 13);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_1_17_1_az', 5, 7);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_5_40_8_az', 4, 6);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_8_61_7_az', 3, 24);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_5_05_5_az', 2, 21);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_8_97_2_az', 2, 14);
insert into Groups ([Name], [Year], DepartmentId) values ('FBAS_0_58_5_az', 4, 19);

----------------------------------------- Teachers Data -----------------------------------------

insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Taddeo', 2947, 'Roberto');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Skippy', 663, 'Bennen');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Bernardina', 1233, 'Barthelme');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Hobard', 3275, 'Nealon');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Melisse', 1496, 'Spurrior');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Gauthier', 3224, 'Wreiford');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Wake', 675, 'Heijnen');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Ivette', 566, 'Lafee');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Judi', 4370, 'Tuffs');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Hank', 3456, 'Lorentz');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Hamlin', 1610, 'Buzzing');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Althea', 787, 'Porrett');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Bobby', 3618, 'Stadden');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Monica', 2116, 'Labbe');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Evelyn', 4333, 'McGall');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Glennis', 916, 'Gedling');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Haskell', 4428, 'Densey');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Selby', 3487, 'Schapiro');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Gradeigh', 4293, 'Ruslen');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Jammal', 1644, 'Lendrem');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Reinold', 786, 'Vaisey');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Leodora', 3171, 'Rockcliffe');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Andria', 2596, 'Vere');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (1, 'Koralle', 2960, 'Etchingham');
insert into Teachers (IsProfessor, [Name], Salary, Surname) values (0, 'Tara', 1215, 'Hasser');

----------------------------------------- Students Data -----------------------------------------

insert into Students ([Name], Rating, Surname) values ('Ceciley', 5, 'Masterman');
insert into Students ([Name], Rating, Surname) values ('Verine', 0, 'Trimby');
insert into Students ([Name], Rating, Surname) values ('Veronique', 1, 'Blondelle');
insert into Students ([Name], Rating, Surname) values ('Fulton', 2, 'Commins');
insert into Students ([Name], Rating, Surname) values ('Demetrius', 0, 'Bethel');
insert into Students ([Name], Rating, Surname) values ('Briggs', 3, 'Tweede');
insert into Students ([Name], Rating, Surname) values ('Asher', 1, 'Du Plantier');
insert into Students ([Name], Rating, Surname) values ('Cobb', 3, 'Grinham');
insert into Students ([Name], Rating, Surname) values ('Perkin', 2, 'Louw');
insert into Students ([Name], Rating, Surname) values ('Ashil', 5, 'Warrillow');
insert into Students ([Name], Rating, Surname) values ('Jewelle', 3, 'McCrohon');
insert into Students ([Name], Rating, Surname) values ('Denna', 1, 'Tanslie');
insert into Students ([Name], Rating, Surname) values ('Georg', 5, 'Putten');
insert into Students ([Name], Rating, Surname) values ('Ilysa', 5, 'Geleman');
insert into Students ([Name], Rating, Surname) values ('Gerty', 3, 'Ingree');
insert into Students ([Name], Rating, Surname) values ('Farr', 4, 'Sloyan');
insert into Students ([Name], Rating, Surname) values ('Shelden', 2, 'Baldick');
insert into Students ([Name], Rating, Surname) values ('Sampson', 2, 'Bellanger');
insert into Students ([Name], Rating, Surname) values ('Zack', 5, 'Willicott');
insert into Students ([Name], Rating, Surname) values ('Florette', 4, 'Ciccarello');
insert into Students ([Name], Rating, Surname) values ('Charyl', 4, 'Waylen');
insert into Students ([Name], Rating, Surname) values ('Cindie', 5, 'Woodroof');
insert into Students ([Name], Rating, Surname) values ('Suzie', 5, 'McGuff');
insert into Students ([Name], Rating, Surname) values ('Bethany', 1, 'McCathie');
insert into Students ([Name], Rating, Surname) values ('Page', 1, 'Aveline');

----------------------------------------- Subjects Data -----------------------------------------

INSERT INTO Subjects VALUES ('Physics');
INSERT INTO Subjects VALUES ('Chemistry');
INSERT INTO Subjects VALUES ('Biology');
INSERT INTO Subjects VALUES ('Computer Science');
INSERT INTO Subjects VALUES ('History');
INSERT INTO Subjects VALUES ('English');
INSERT INTO Subjects VALUES ('Economics');
INSERT INTO Subjects VALUES ('Psychology');
INSERT INTO Subjects VALUES ('Sociology');
INSERT INTO Subjects VALUES ('Political Science');
INSERT INTO Subjects VALUES ('Engineering');
INSERT INTO Subjects VALUES ('Medicine');
INSERT INTO Subjects VALUES ('Law');
INSERT INTO Subjects VALUES ('Business Administration');
INSERT INTO Subjects VALUES ('Art');
INSERT INTO Subjects VALUES ('Music');
INSERT INTO Subjects VALUES ('Philosophy');
INSERT INTO Subjects VALUES ('Geology');
INSERT INTO Subjects VALUES ('Astronomy');
INSERT INTO Subjects VALUES ('Education');
INSERT INTO Subjects VALUES ('Nursing');
INSERT INTO Subjects VALUES ('Agriculture');
INSERT INTO Subjects VALUES ('Environmental Science');
INSERT INTO Subjects VALUES ('Statistics');
INSERT INTO Subjects VALUES ('Communication');

----------------------------------------- Lectures Data -----------------------------------------

insert into Lectures (LectureDate, SubjectId, TeacherId) values ('5/27/2016', 8, 3);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('10/16/2003', 25, 15);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('5/2/2022', 22, 1);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('3/30/2008', 21, 10);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('4/29/2007', 1, 15);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('12/29/2006', 7, 19);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('8/2/2012', 15, 11);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('12/10/2012', 6, 13);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('9/16/2004', 17, 20);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('3/8/2016', 16, 3);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('12/21/2004', 12, 4);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('7/5/2017', 9, 13);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('4/6/2006', 11, 7);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('1/25/2021', 20, 3);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('5/26/2004', 20, 6);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('6/13/2013', 24, 10);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('1/18/2014', 17, 1);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('1/20/2008', 2, 7);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('3/22/2000', 23, 15);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('7/23/2014', 6, 22);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('12/8/2023', 24, 1);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('9/10/2017', 21, 7);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('6/15/2018', 25, 9);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('3/24/2019', 15, 24);
insert into Lectures (LectureDate, SubjectId, TeacherId) values ('11/3/2013', 11, 13);

----------------------------------------- GroupsCurators Data -----------------------------------------

insert into GroupsCurators (CuratorId, GroupId) values (25, 21);
insert into GroupsCurators (CuratorId, GroupId) values (1, 14);
insert into GroupsCurators (CuratorId, GroupId) values (15, 11);
insert into GroupsCurators (CuratorId, GroupId) values (21, 23);
insert into GroupsCurators (CuratorId, GroupId) values (5, 7);
insert into GroupsCurators (CuratorId, GroupId) values (2, 16);
insert into GroupsCurators (CuratorId, GroupId) values (16, 3);
insert into GroupsCurators (CuratorId, GroupId) values (15, 17);
insert into GroupsCurators (CuratorId, GroupId) values (24, 25);
insert into GroupsCurators (CuratorId, GroupId) values (5, 19);
insert into GroupsCurators (CuratorId, GroupId) values (2, 15);
insert into GroupsCurators (CuratorId, GroupId) values (13, 18);
insert into GroupsCurators (CuratorId, GroupId) values (4, 25);
insert into GroupsCurators (CuratorId, GroupId) values (17, 23);
insert into GroupsCurators (CuratorId, GroupId) values (16, 21);
insert into GroupsCurators (CuratorId, GroupId) values (5, 22);
insert into GroupsCurators (CuratorId, GroupId) values (19, 14);
insert into GroupsCurators (CuratorId, GroupId) values (10, 19);
insert into GroupsCurators (CuratorId, GroupId) values (17, 21);
insert into GroupsCurators (CuratorId, GroupId) values (23, 22);
insert into GroupsCurators (CuratorId, GroupId) values (1, 11);
insert into GroupsCurators (CuratorId, GroupId) values (2, 15);
insert into GroupsCurators (CuratorId, GroupId) values (6, 13);
insert into GroupsCurators (CuratorId, GroupId) values (16, 13);
insert into GroupsCurators (CuratorId, GroupId) values (20, 4);

----------------------------------------- GroupsLectures Data -----------------------------------------

insert into GroupsLectures (GroupId, LectureId) values (8, 7);
insert into GroupsLectures (GroupId, LectureId) values (25, 3);
insert into GroupsLectures (GroupId, LectureId) values (20, 14);
insert into GroupsLectures (GroupId, LectureId) values (11, 22);
insert into GroupsLectures (GroupId, LectureId) values (17, 15);
insert into GroupsLectures (GroupId, LectureId) values (3, 1);
insert into GroupsLectures (GroupId, LectureId) values (20, 20);
insert into GroupsLectures (GroupId, LectureId) values (3, 23);
insert into GroupsLectures (GroupId, LectureId) values (22, 23);
insert into GroupsLectures (GroupId, LectureId) values (11, 9);
insert into GroupsLectures (GroupId, LectureId) values (5, 17);
insert into GroupsLectures (GroupId, LectureId) values (8, 3);
insert into GroupsLectures (GroupId, LectureId) values (18, 10);
insert into GroupsLectures (GroupId, LectureId) values (1, 6);
insert into GroupsLectures (GroupId, LectureId) values (18, 12);
insert into GroupsLectures (GroupId, LectureId) values (20, 18);
insert into GroupsLectures (GroupId, LectureId) values (16, 1);
insert into GroupsLectures (GroupId, LectureId) values (8, 20);
insert into GroupsLectures (GroupId, LectureId) values (23, 12);
insert into GroupsLectures (GroupId, LectureId) values (4, 23);
insert into GroupsLectures (GroupId, LectureId) values (14, 23);
insert into GroupsLectures (GroupId, LectureId) values (4, 7);
insert into GroupsLectures (GroupId, LectureId) values (12, 21);
insert into GroupsLectures (GroupId, LectureId) values (12, 9);
insert into GroupsLectures (GroupId, LectureId) values (10, 6);

----------------------------------------- GroupsStudents Data -----------------------------------------

insert into GroupsStudents (GroupId, StudentId) values (19, 19);
insert into GroupsStudents (GroupId, StudentId) values (8, 22);
insert into GroupsStudents (GroupId, StudentId) values (20, 5);
insert into GroupsStudents (GroupId, StudentId) values (9, 9);
insert into GroupsStudents (GroupId, StudentId) values (21, 3);
insert into GroupsStudents (GroupId, StudentId) values (3, 1);
insert into GroupsStudents (GroupId, StudentId) values (12, 5);
insert into GroupsStudents (GroupId, StudentId) values (5, 10);
insert into GroupsStudents (GroupId, StudentId) values (23, 12);
insert into GroupsStudents (GroupId, StudentId) values (7, 2);
insert into GroupsStudents (GroupId, StudentId) values (7, 16);
insert into GroupsStudents (GroupId, StudentId) values (17, 14);
insert into GroupsStudents (GroupId, StudentId) values (1, 9);
insert into GroupsStudents (GroupId, StudentId) values (15, 23);
insert into GroupsStudents (GroupId, StudentId) values (22, 1);
insert into GroupsStudents (GroupId, StudentId) values (7, 22);
insert into GroupsStudents (GroupId, StudentId) values (16, 20);
insert into GroupsStudents (GroupId, StudentId) values (16, 5);
insert into GroupsStudents (GroupId, StudentId) values (22, 13);
insert into GroupsStudents (GroupId, StudentId) values (9, 10);
insert into GroupsStudents (GroupId, StudentId) values (9, 3);
insert into GroupsStudents (GroupId, StudentId) values (7, 21);
insert into GroupsStudents (GroupId, StudentId) values (2, 20);
insert into GroupsStudents (GroupId, StudentId) values (23, 1);
insert into GroupsStudents (GroupId, StudentId) values (5, 19);