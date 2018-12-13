CREATE TABLE [dbo].[SmartGrids] (
    [SmartGridID]           INT            IDENTITY (1, 1) NOT NULL,
    [SmartGridInfo]         NVARCHAR (MAX) NULL,
    [SmartGridRegistration] NVARCHAR (MAX) NULL,
    [TotalProsumersCount]   INT            NOT NULL,
    CONSTRAINT [PK_SmartGrids] PRIMARY KEY CLUSTERED ([SmartGridID] ASC)
);

CREATE TABLE [dbo].[SmartGridProsumers] (
    [SmartGridProsumerID] INT IDENTITY (1, 1) NOT NULL,
    [SmartGridID]         INT NOT NULL,
    [InstallationsID]     INT NOT NULL,
    [SmartMeterID]        INT NOT NULL,
    CONSTRAINT [PK_SmartGridProsumers] PRIMARY KEY CLUSTERED ([SmartGridProsumerID] ASC),
    CONSTRAINT [FK_SmartGridProsumers_SmartGrids_SmartGridID] FOREIGN KEY ([SmartGridID]) REFERENCES [dbo].[SmartGrids] ([SmartGridID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SmartGridProsumers_SmartGridID]
    ON [dbo].[SmartGridProsumers]([SmartGridID] ASC);

CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);

CREATE TABLE [dbo].[Prosumers] (
    [ProsumerID]                  INT           IDENTITY (1, 1) NOT NULL,
    [InstallationsID]             INT           NOT NULL,
    [KWhBlocksTotalProduction]    INT           NOT NULL,
    [KWhBlocksTotalConsumed]      INT           NOT NULL,
    [kWhBlocksLastMeterStamp]     DATETIME2 (7) NOT NULL,
    [ProsumerCurrencyNowInBlocks] INT           NOT NULL,
    [ProsumerLastUpdated]         DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Prosumers] PRIMARY KEY CLUSTERED ([ProsumerID] ASC)
);

CREATE TABLE [dbo].[ProsumerSmartMeterRecordsLogs] (
    [ProsumerSmartMeterRecordsID] INT IDENTITY (1, 1) NOT NULL,
    [ProsumerID]                  INT NOT NULL,
    [InstallationsID]             INT NOT NULL,
    [KWhBlocksProduced]           INT NOT NULL,
    [KWhBlocksConsumed]           INT NOT NULL,
    CONSTRAINT [PK_ProsumerSmartMeterRecordsLogs] PRIMARY KEY CLUSTERED ([ProsumerSmartMeterRecordsID] ASC),
    CONSTRAINT [FK_ProsumerSmartMeterRecordsLogs_Prosumers_ProsumerID] FOREIGN KEY ([ProsumerID]) REFERENCES [dbo].[Prosumers] ([ProsumerID]) ON DELETE CASCADE
);