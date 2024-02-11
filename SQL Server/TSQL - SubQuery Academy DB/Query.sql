USE [Subquery_Academy_DB]

SELECT Building AS [Number of buildings]
FROM Departments
WHERE  Financing = (
	SELECT Financing 
	WHERE Financing > 100000)

SELECT[Name] 
FROM Groups
WHERE DepartmentId = (
	SELECT DepartmentId 
	FROM Departments
	WHERE Groups.DepartmentId = Departments.Id 
	AND [Name] = 'Mosciski, Harber and McKenzie')
AND [Year] = 5

SELECT G.[Name]
FROM Groups AS G
WHERE G.[Name] IN (
	SELECT G.[Name]
	FROM Groups AS G,Students AS S,GroupsStudents AS GS
	WHERE (GS.GroupId = G.Id AND GS.StudentId = S.Id)
	GROUP BY G.[Name]
	HAVING (AVG(S.Rating)>(
		SELECT AVG(S.Rating) 
		FROM Students AS S , Groups AS G,GroupsStudents AS GS
		WHERE (GS.GroupId = G.Id AND GS.StudentId = S.Id)
		AND G.[Name] ='FBAS_8_31_3_az'
		GROUP BY G.[Name])
		)
)

SELECT T.[Name] + ' ' + T.Surname AS [Full name] 
FROM Teachers AS T
WHERE T.Salary > (
	SELECT AVG(T.Salary)
	FROM Teachers as T
	WHERE T.IsProfessor = 1)

SELECT G.[Name] 
FROM Groups AS G 
WHERE G.[Name] IN (
	SELECT G.[Name]
	FROM Groups AS G , Curators AS C ,GroupsCurators AS GC
	WHERE (GC.GroupId = G.Id AND GC.CuratorId = C.Id)
	GROUP BY G.[Name]
	HAVING (COUNT(C.Id) > 1)
	)

SELECT G.[Name]
FROM Groups AS G
WHERE G.[Name] IN (
	SELECT G.[Name]
	FROM Groups AS G,Students AS S,GroupsStudents AS GS
	WHERE (GS.GroupId = G.Id AND GS.StudentId = S.Id)
	GROUP BY G.[Name]
	HAVING  AVG(S.Rating) < ANY (
		SELECT MIN(S.Rating) 
		FROM Curators AS C , Groups AS G , GroupsCurators AS GC 
		WHERE (GC.GroupId = G.Id AND GC.CuratorId=C.Id)
		AND G.[Year] = 5
		GROUP BY G.[Name]
		)	
	)

SELECT F.[Name]
FROM Faculties AS F
WHERE F.[Name] IN (
	SELECT F.[Name]
	FROM Faculties AS F ,Departments AS D
	WHERE (F.Id = D.FacultyId)
	GROUP BY F.[Name]
	HAVING (SUM(D.Financing) >
		(SELECT SUM(D.Financing) 
		FROM Departments AS D , Faculties AS F
		WHERE (D.[Name] = 'Computer Science')
		)
	)
)

SELECT S.[Name] as [subject name] , T.[Name] + ' ' + T.Surname AS [full name of teachers]
FROM Subjects AS S , Teachers AS T , Lectures AS L
WHERE (L.TeacherId = T.Id  AND L.SubjectId = S.Id) AND
	T.Id IN (
	SELECT L.TeacherId 
	FROM Lectures AS L
	GROUP BY L.TeacherId
	HAVING (COUNT(L.TeacherId) = (
		SELECT TOP 1 COUNT(L.TeacherId) 
		FROM Lectures AS L
		GROUP BY L.TeacherId
		ORDER BY (COUNT(L.TeacherId)) DESC
		)  
	)
)

SELECT S.[Name] AS [subject name] 
FROM Subjects AS S , Lectures AS L
WHERE (L.SubjectId = S.Id) AND
S.Id IN (
	SELECT L.SubjectId 
	FROM Lectures AS L
	GROUP BY L.SubjectId
	HAVING (COUNT(L.SubjectId) = (
		SELECT TOP 1 COUNT(L.SubjectId)
		FROM Lectures AS L 
		GROUP BY L.SubjectId
		ORDER BY (COUNT(L.SubjectId)) ASC 
		)
	)
)
GO
SELECT * FROM Departments
select * from Groups
SELECT * FROM GroupsStudents

SELECT(
	SELECT TOP 1 COUNT(S.Id) 
	FROM GroupsStudents AS GS , Groups AS G,Students AS S
	WHERE (G.Id = GS.GroupId AND GS.StudentId = S.Id)
	GROUP BY GS.GroupId 
	  ) AS [Student count],
	  (
	SELECT TOP 1 COUNT(L.Id) 
	FROM Lectures AS L , GroupsLectures AS GL , Groups AS G
	WHERE (L.Id = GL.LectureId AND G.Id = GL.GroupId)
	GROUP BY GL.GroupId
	  ) AS [Lecture count]
FROM Departments AS D
WHERE D.[Name] = 'Bartell Group'