CREATE TABLE [DATA].[BOOKING]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [StartPosID] INT NOT NULL, 
    [EndPosID] INT NOT NULL, 
    [CustomerID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL 

CONSTRAINT [PK_BOOKING] PRIMARY KEY (Id)
)
