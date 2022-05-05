﻿CREATE TABLE [DATA].[ROUTE]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [StartPosID]INT NULL, 
    [EndPosID] INT NULL, 
    [DistanceInHours] DECIMAL(10, 2) NULL, 
    [Active] BIT NOT NULL

CONSTRAINT [PK_ROUTE] PRIMARY KEY (Id), 
    
)
