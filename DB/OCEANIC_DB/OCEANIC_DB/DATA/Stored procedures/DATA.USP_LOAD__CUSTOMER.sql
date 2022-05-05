CREATE PROCEDURE [DATA].[USP_LOAD__CUSTOMER]
AS

TRUNCATE TABLE DATA.CUSTOMER

INSERT INTO DATA.CUSTOMER (FirstName, LastName, Address, ZipCode, City, Country)

VALUES 
('Dina', 'Mortensen', 'Tornskadestien 6', '2400', 'Copenhagen', 'Denmark'),
('Anders', 'And', 'Paradisæblevej 111', NULL, 'Andeby', 'Andeland'),
('Joe', 'Biden', 'Pennsylvania Avenue 1600', '20500', 'Washington D.C.', 'USA')
RETURN 0;