CREATE PROCEDURE [DATA].[USP_LOAD__TYPE]
AS

TRUNCATE TABLE DATA.TYPE

INSERT INTO DATA.TYPE (Type, Factor, Active)

VALUES
('Recorded Delivery',1,0),
('Weapons',2,1),
('Live animals',1,0),
('Cautious parcels',1.75,1),
('Refrigerated goods',1.1,1),
('Others',1,1)
RETURN 0;