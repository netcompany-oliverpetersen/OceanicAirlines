CREATE PROCEDURE [DATA].[USP_LOAD__CITY]
AS

TRUNCATE TABLE DATA.CITY

INSERT INTO DATA.CITY (CityName)

VALUES
('Addis Abeba'),
('Amatave'),
('Bahr El Ghazal'),
('Cairo'),
('Congo'),
('Darfur'),
('Dakar'),
('De Kanariske Øer'),
('Dragebjerget'),
('Guldkysten'),
('Hvalbugten'),
('Kabalo'),
('Kap Guardafui'),
('Kap St. Marie'),
('Kapstaden'),
('Luanda'),
('Marrakesh'),
('Mocambique'),
('Omdurman'),
('Sahara'),
('Sierra Leone'),
('Slavekysten'),
('St. Helena'),
('Suakin'),
('Tanger'),
('Timbuktu'),
('Tripoli'),
('Tunis'),
('Victoriafaldene'),
('Victoriasøen'),
('Wadai'),
('Zanzibar')
RETURN 0;