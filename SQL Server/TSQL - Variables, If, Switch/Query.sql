USE [Library]

DECLARE @counter INT = 1;

WHILE @counter <= 100
BEGIN
    IF @counter % 2 = 0
        PRINT @counter;
    
    SET @counter = @counter + 1;
END

DECLARE @Authors INT;

SELECT @Authors = COUNT(*) FROM Authors;

PRINT 'Authors count: ' + CAST(@Authors * 5 AS NVARCHAR(10));

DECLARE @Number INT = 12221;
DECLARE @ReversedNumber INT;

SET @ReversedNumber = CAST(REVERSE(CAST(@Number AS NVARCHAR(10))) AS INT);

IF @Number = @ReversedNumber
    PRINT 'The number is a palindrome.';
ELSE
    PRINT 'The number is not a palindrome.';

DECLARE @StartRange BIGINT = 10;
DECLARE @EndRange BIGINT = 30;
DECLARE @SumOfEven BIGINT = 0;
DECLARE @ProductOfOdd BIGINT = 1;

DECLARE @CurrentNumber INT = @StartRange;

WHILE @CurrentNumber <= @EndRange
BEGIN
    IF @CurrentNumber % 2 = 0
        SET @SumOfEven = @SumOfEven + @CurrentNumber;
    ELSE
        SET @ProductOfOdd = @ProductOfOdd * @CurrentNumber;

    SET @CurrentNumber = @CurrentNumber + 1;
END

PRINT 'even numbers: ' + CAST(@SumOfEven AS NVARCHAR(20));
PRINT 'odd numbers: ' + CAST(@ProductOfOdd AS NVARCHAR(20));

DECLARE @FactorialNumber INT = 5;
DECLARE @FactorialResult BIGINT = 1;

WHILE @FactorialNumber > 0
BEGIN
    SET @FactorialResult = @FactorialResult * @FactorialNumber;
    SET @FactorialNumber = @FactorialNumber - 1;
END

PRINT 'Factorial: ' + CAST(@FactorialResult AS NVARCHAR(255));

DECLARE @UserNumber INT = 12345;
DECLARE @Divisor INT;

WHILE @UserNumber > 0
BEGIN
    SET @Divisor = @UserNumber % 10;
    PRINT 'Number: ' + CAST(@UserNumber AS NVARCHAR(10)) + '/' + CAST(@Divisor AS NVARCHAR(10));
    SET @UserNumber = @UserNumber / 10;
END

DECLARE @BaseNumber INT = 2;
DECLARE @Exponent INT = 3;
DECLARE @Result BIGINT = 1;
DECLARE @OriginalExponent INT = @Exponent;

WHILE @Exponent > 0
BEGIN
    SET @Result = @Result * @BaseNumber;
    SET @Exponent = @Exponent - 1;
END

PRINT 'Result: ' + CAST(@BaseNumber AS NVARCHAR(10)) + '^' + CAST(@OriginalExponent AS NVARCHAR(10)) + ' = ' + CAST(@Result AS NVARCHAR(20));