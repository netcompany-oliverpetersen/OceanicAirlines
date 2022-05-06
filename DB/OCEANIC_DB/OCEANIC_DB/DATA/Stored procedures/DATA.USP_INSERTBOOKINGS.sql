CREATE PROCEDURE [DATA].[USP_INSERTBOOKINGS]


@FullRoute NVARCHAR(MAX) ,
@Type VARCHAR(255),
@Weight DECIMAL(10,2) ,
@Length DECIMAL(10,2) ,
@Width DECIMAL(10,2),
@Height DECIMAL(10,2) ,
@TotalPrices NVARCHAR(MAX) ,
@TotalTime DECIMAL(10,2),
@CustomerFirstName NVARCHAR(MAX),
@CustomerLastName NVARCHAR(MAX),
@CustomerAddress NVARCHAR(255),
@CustomerZipCode VARCHAR(12),
@CustomerCity NVARCHAR(255) ,
@CustomerCountry VARCHAR(255) ,
@UserEmail NVARCHAR(255) 

AS 
BEGIN
SET NOCOUNT ON

DECLARE @SQL NVARCHAR(255)
DECLARE @CreatedTime DATETIME = GETDATE()
DECLARE @ParcelID INT
DECLARE @BookingID INT
DECLARE @TypeID INT

	 IF OBJECT_ID('tempdb..##temp') IS NOT NULL
  BEGIN
    SET @SQL = N'DROP TABLE ##temp'
EXECUTE sp_executesql @SQL
    END

	 IF OBJECT_ID('tempdb..##temp2') IS NOT NULL
  BEGIN
    SET @SQL = N'DROP TABLE ##temp2'
EXECUTE sp_executesql @SQL
    END

DECLARE @CustomerID INT
DECLARE @StartCity NVARCHAR(255)
DECLARE @EndCity NVARCHAR(255)
DECLARE @NoOfSegments INT

INSERT INTO [DATA].[CUSTOMER] (FirstName, LastName, Address, ZipCode, City, Country)
VALUES (@CustomerFirstName, @CustomerLastName, @CustomerAddress, @CustomerZipCode, @CustomerCity, @CustomerCountry)


SELECT TOP 1 @CustomerID = ID
FROM [DATA].[CUSTOMER]
WHERE FirstName = @CustomerFirstName
AND LastName = @CustomerLastName
AND [Address] = @CustomerAddress
AND ZipCode = @CustomerZipCode
AND City = @CustomerCity
AND Country = @CustomerCountry



SELECT IDENTITY(INT, 1,1) AS ID,
firstname as cusid,
value AS CityName
INTO ##temp
from data.customer
CROSS JOIN string_split(@FullRoute,',')
where id = @CustomerID



SELECT TOP 1 @StartCity = CityName
FROM ##temp
ORDER BY ID ASC

SELECT TOP 1 @EndCity = CityName
FROM ##temp
ORDER BY ID DESC

INSERT INTO [DATA].[BOOKING] (StartPosID, EndPosID, CustomerID, UserID, [Timestamp])
SELECT StartCity.ID,
	EndCity.ID,
	@CustomerID,
	usr.Id,
	@CreatedTime
FROM [DATA].[CITY] StartCity
CROSS JOIN [DATA].[CITY] EndCity
CROSS JOIN [DATA].[USER] usr
WHERE StartCity.CityName = @StartCity
AND EndCity.CityName = @EndCity
AND usr.Mail = @UserEmail


SELECT TOP 1 @ParcelID = ID
FROM Data.Parcel
WHERE WeightInKg >= @Weight
AND HeightInCm >= @Height
AND WidthInCm >= @Width
AND LengthInCm >= @Length
ORDER BY Price ASC

SELECT @NoOfSegments = COUNT(*)
FROM ##temp

SELECT t1.ID AS ID,
	t1.CityName AS StartCity,
	t2.CityName AS EndCity,
	CAST(@TotalPrices AS decimal(10,2))/@NoOfSegments AS PricePrSegment,
	CAST(@TotalTime AS decimal(10,2))/@NoOfSegments AS TimePrSegment
INTO ##temp2
FROM ##temp t1
LEFT JOIN ##temp t2
ON t1.ID = t2.ID-1
WHERE t1.ID < @NoOfSegments


SELECT @BookingID = Id
FROM [DATA].[BOOKING]
WHERE [Timestamp] = @CreatedTime
--SELECT @BookingID

SELECT @TypeID = ID
FROM [DATA].[Type]
WHERE [Type] = @Type

INSERT INTO [DATA].[BOOKINGLINE] (Id, LineID, SegmentID, StartPosID, EndPosID, TransportID, ParcelID, TypeID, Price, DistanceInHours, Currency)

SELECT @BookingID, 
	1,
	t.ID,
	SC.ID,
	EC.ID,
	1,
	@ParcelID,
	@TypeID,
	t.PricePrSegment,
	t.TimePrSegment,
	'USD'
FROM ##temp2 t
LEFT JOIN [DATA].[CITY] SC
ON t.StartCity = SC.CityName
LEFT JOIN [DATA].[CITY] EC
ON t.EndCity = EC.CityName

END

