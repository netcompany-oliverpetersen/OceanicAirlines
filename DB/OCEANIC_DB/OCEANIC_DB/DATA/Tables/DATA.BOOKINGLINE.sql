CREATE TABLE [DATA].[BOOKINGLINE]
(
	[Id] INT IDENTITY(1,1) NOT NULL , 
    [LineID] INT NOT NULL, 
    [SegmentID] INT NOT NULL, 
    [StartPosID] INT NOT NULL, 
    [EndPosID] INT NOT NULL, 
    [TransportID] INT NOT NULL, 
    [ParcelID] INT NOT NULL, 
    [TypeID] INT NOT NULL, 
    [Price] DECIMAL(17, 2) NULL, 
    [DistanceInHours] DECIMAL(10, 2) NULL, 
    [Currency] VARCHAR(3) NULL DEFAULT 'USD' 
CONSTRAINT [PK_DATA_BOOKINGLINE] PRIMARY KEY CLUSTERED
(
    [Id] ASC,
    [LineID] ASC,
    [SegmentID] ASC
)

)
