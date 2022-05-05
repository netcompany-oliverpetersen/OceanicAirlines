CREATE PROCEDURE [Data].[GetRoutePriceTable]
@Height DECIMAL,
@Width DECIMAL,
@Length DECIMAL,
@Weight DECIMAL,
@Type VARCHAR(255)

AS
BEGIN

WITH ParcelCTE AS (
SELECT *
FROM Data.Parcel
WHERE WeightInKg >= @Weight
AND HeightInCm >= @Height
AND WidthInCm >= @Width
AND LengthInCm >= @Length
),

MinParcelCTE AS (
SELECT TOP 1 *
FROM ParcelCTE
ORDER BY Price ASC
),

TypeCTE AS (
SELECT *
FROM [Data].[Type] 
WHERE [Type] = @Type
)


SELECT 
StartC.CityName AS Source,
EndC.CityName AS Destination,
R.DistanceInHours AS [Time],
MinParcelCTE.Price * TypeCTE.Factor AS Price
FROM [Data].[Route] R
LEFT JOIN [Data].[City] StartC
ON StartC.ID = R.StartPosID
LEFT JOIN [Data].[City] EndC
ON EndC.ID = R.EndPosID

CROSS JOIN MinParcelCTE
CROSS JOIN TypeCTE

WHERE R.Active = 1
AND 
TypeCTE.Active = 1

END

