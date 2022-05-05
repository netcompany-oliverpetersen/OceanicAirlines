CREATE PROCEDURE [DATA].[USP_LOAD__TEMPLATE_BOOKINGLINE]
AS

TRUNCATE TABLE DATA.BOOKINGLINE

INSERT INTO DATA.BOOKINGLINE (ID, LIneID, SegmentID, StartPosID, EndPosID, TransportID, ParcelID, TypeID, Price, DistanceInHours)

VALUES
( 1, 1, 1, 15, 12, 1, 3, 5, 88.00, 8.00),
( 1, 1, 2, 12, 6, 1, 3, 5, 88.00, 8.00),
( 1, 1, 3, 6, 27, 1, 3, 5, 88.00, 8.00),
( 1, 1, 4, 27, 25, 1, 3, 5, 88.00, 8.00),
( 2, 1, 1, 10, 11, 1, 5, 4, 119.00, 8.00),
( 3, 1, 1, 14, 15, 1, 7, 2, 160.00, 8.00),
( 3, 1, 2, 15, 2, 1, 7, 2, 160.00, 8.00),
( 3, 1, 3, 2, 13, 1, 7, 2, 160.00, 8.00)
RETURN 0;