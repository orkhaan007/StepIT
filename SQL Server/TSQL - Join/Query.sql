SELECT Books.*
FROM Books
INNER JOIN Press ON Books.Id_Press = Press.Id
WHERE Pages = (SELECT MIN(Pages) FROM Books WHERE Id_Press = Press.Id AND Press.Name = 'Piter');

SELECT Press.Name
FROM Books
INNER JOIN Press ON Books.Id_Press = Press.Id
GROUP BY Press.Name
HAVING AVG(Books.Pages) > 100;

SELECT SUM(Books.Pages) AS TotalPages
FROM Books
INNER JOIN Press ON Books.Id_Press = Press.Id
WHERE Press.Name IN ('BHV', 'BINOM');

SELECT DISTINCT Students.FirstName
FROM Students
INNER JOIN S_Cards ON Students.Id = S_Cards.Id_Student
WHERE S_Cards.DateOut BETWEEN '2001-01-01' AND GETDATE();

SELECT DISTINCT Students.FirstName
FROM Students
INNER JOIN S_Cards ON Students.Id = S_Cards.Id_Student
INNER JOIN Books ON S_Cards.Id_Book = Books.Id
INNER JOIN Authors ON Books.Id_Author = Authors.Id
WHERE Books.Name = 'Windows 2000 Registry' AND Authors.FirstName = 'Olga' AND Authors.LastName = 'Kokoreva';

SELECT Authors.FirstName, AVG(Books.Pages) AS AvgPages
FROM Authors
INNER JOIN Books ON Authors.Id = Books.Id_Author
GROUP BY Authors.FirstName
HAVING AVG(Books.Pages) > 600;

SELECT Press.Name, SUM(Books.Pages) AS TotalPages
FROM Press
INNER JOIN Books ON Press.Id = Books.Id_Press
GROUP BY Press.Name
HAVING SUM(Books.Pages) > 700;

SELECT S.FirstName AS [Firstname] , S.LastName AS[Lastname] , B.[Name] AS [Taken book]
FROM Students AS S INNER JOIN S_Cards AS SC
ON S.Id = SC.Id_Student
INNER JOIN Books AS B
ON B.Id = SC.Id_Book

SELECT T.FirstName , T.LastName  , B.[Name] AS [Taken book]
FROM Teachers AS T INNER JOIN T_Cards AS TC
ON T.Id = TC.Id_Teacher
INNER JOIN Books AS B
ON B.Id = TC.Id_Book

SELECT COUNT(SC.Id_Book) AS [Maximum count of book(s) taken by students], A.Id AS [AUTHOR ID] , A.FirstName +' '  + A.LastName AS [Author's Fullname]
FROM Books AS B 
INNER JOIN S_Cards AS SC
ON B.Id = SC.Id_Book
INNER JOIN Authors AS A
ON A.Id = B.Id_Author
WHERE B.Id IN (
	SELECT SC.Id_Book
	FROM Books AS B
	INNER JOIN S_Cards AS SC
	ON B.Id = SC.Id_Book
	GROUP BY SC.Id_Book
	HAVING COUNT(SC.Id_Book) =(
		SELECT TOP 1 COUNT(SC.Id_Book)
		FROM S_Cards AS SC
		GROUP BY SC.Id_Book
		ORDER BY COUNT(SC.Id_Book) DESC
	)
)
SELECT * FROM Authors

SELECT COUNT(TC.Id_Book) AS [Maximum count of book(s) taken by students], A.Id AS [AUTHOR ID] , A.FirstName +' '  + A.LastName AS [Fullname]
FROM Books AS B 
INNER JOIN T_Cards AS TC
ON B.Id = TC.Id_Book
INNER JOIN Authors AS A
ON A.Id = B.Id_Author
WHERE B.Id IN (
	SELECT TC.Id_Book
	FROM Books AS B
	INNER JOIN T_Cards AS TC
	ON B.Id = TC.Id_Book
	GROUP BY TC.Id_Book
	HAVING COUNT(TC.Id_Book) =(
		SELECT TOP 1 COUNT(TC.Id_Book)
		FROM T_Cards AS TC
		GROUP BY TC.Id_Book
		ORDER BY COUNT(TC.Id_Book) DESC
	)
)
GROUP BY TC.Id_Book , A.Id,A.FirstName,A.LastName