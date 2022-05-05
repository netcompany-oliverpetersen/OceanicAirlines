CREATE PROCEDURE [DATA].[USP_LOAD__USER]
AS

TRUNCATE TABLE DATA.[USER]

INSERT INTO DATA.[USER] (FirstName, LastName, Mail, Password, Type)

VALUES
( 'Lars', 'Larsen', 'lars@oceanic-airlines.com', 'EIKJU452FFDC865', 'User'),
( 'Gitte', 'Svendsen', 'gitte@oceanic-airlines.com', 'QINK5620PLOX764N', 'User'),
( 'Henning', 'Jensen', 'henning@oceanic-airlines.com', 'HNDD7109KOMN00SF', 'User')
RETURN 0;