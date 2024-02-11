CREATE FUNCTION GetMinPagesBooksByPublisher(@PublisherId AS INT)
RETURNS TABLE
AS
RETURN (
    SELECT Name, MIN(Pages) AS MinPages
    FROM Books
    WHERE Id_Press = @PublisherId
    GROUP BY Name
);

CREATE FUNCTION GetPublishersByAvgPages(@N AS INT)
RETURNS TABLE
AS
RETURN (
    SELECT Press.Name
    FROM Press
    INNER JOIN Books ON Press.Id = Books.Id_Press
    GROUP BY Press.Name
    HAVING AVG(Pages) > @N
);

CREATE FUNCTION GetTotalPagesByPublisher(@PublisherId INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalPages INT;
    SELECT @TotalPages = SUM(Pages)
    FROM Books
    WHERE Id_Press = @PublisherId;
    RETURN @TotalPages;
END;

CREATE FUNCTION GetStudentsBetweenDates(@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS
RETURN (
    SELECT FirstName, LastName
    FROM Students
    INNER JOIN S_Cards ON Students.Id = S_Cards.Id_Student
    WHERE DateOut BETWEEN @StartDate AND @EndDate
);

CREATE FUNCTION GetCurrentStudentsByBookAndAuthor(@BookTitle NVARCHAR(255), @AuthorName NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT DISTINCT Students.FirstName, Students.LastName
    FROM Students
    INNER JOIN S_Cards ON Students.Id = S_Cards.Id_Student
    INNER JOIN Books ON S_Cards.Id_Book = Books.Id
    INNER JOIN Authors ON Books.Id_Author = Authors.Id
    WHERE Books.Name = @BookTitle AND Authors.FirstName = @AuthorName
);

CREATE FUNCTION GetPublishersByTotalPages(@N INT)
RETURNS TABLE
AS
RETURN (
    SELECT Press.Name, SUM(Pages) AS TotalPages
    FROM Press
    INNER JOIN Books ON Press.Id = Books.Id_Press
    GROUP BY Press.Name
    HAVING SUM(Pages) > @N
);

CREATE FUNCTION GetMostPopularAuthorAmongStudents()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 1 Authors.FirstName, COUNT(*) AS NumberOfBooks
    FROM Students
    INNER JOIN S_Cards ON Students.Id = S_Cards.Id_Student
    INNER JOIN Books ON S_Cards.Id_Book = Books.Id
    INNER JOIN Authors ON Books.Id_Author = Authors.Id
    GROUP BY Authors.FirstName
    ORDER BY NumberOfBooks DESC
);

CREATE FUNCTION GetBooksTakenByBoth()
RETURNS TABLE
AS
RETURN (
    SELECT DISTINCT Name
    FROM Books, S_Cards
    WHERE EXISTS (
        SELECT 1
        FROM Students
        WHERE Students.Id = S_Cards.Id_Student
    ) AND EXISTS (
        SELECT 1
        FROM Teachers
        WHERE Teachers.Id = S_Cards.Id_Lib
    )
);

CREATE FUNCTION GetNumberOfStudentsWithoutBooks()
RETURNS INT
AS
BEGIN
    DECLARE @Count INT;
    SELECT @Count = COUNT(*)
    FROM Students
    WHERE NOT EXISTS (
        SELECT 1
        FROM S_Cards
        WHERE S_Cards.Id_Student = Students.Id
    );
    RETURN @Count;
END;

CREATE FUNCTION GetLibrariansAndBookCounts()
RETURNS TABLE
AS
RETURN (
    SELECT FirstName, COUNT(*) AS NumberOfBooks
    FROM Libs
    INNER JOIN S_Cards ON Libs.Id = S_Cards.Id_Lib
    GROUP BY FirstName
);