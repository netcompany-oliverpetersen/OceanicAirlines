﻿CREATE TABLE [DATA].[ROUTE]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [StartPosID]NVARCHAR(9) NULL, 
    [EndPosID] NVARCHAR(9) NULL, 
    [DistanceInHours] DECIMAL(10, 2) NULL, 
    [Active] BIT NOT NULL

CONSTRAINT [PK_ROUTE] PRIMARY KEY (Id), 
    
)