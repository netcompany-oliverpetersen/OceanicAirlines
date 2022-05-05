CREATE PROCEDURE [DATA].[USP_LOAD__TYPE]
AS

TRUNCATE TABLE DATA.TYPE

INSERT INTO DATA.TYPE (Type, Factor, Active)

VALUES
('Recorded Delivery',1,0),
('Weapons',2,1),
('Livestock',1,0),
('Cautious',1.75,1),
('Refrigerated',1.1,1),
('Other',1,1)
RETURN 0;