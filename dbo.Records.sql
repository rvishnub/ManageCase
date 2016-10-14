CREATE TABLE [dbo].[Records] (
    [recordId]              INT            IDENTITY (1, 1) NOT NULL,
    [internalCaseId]        INT            NOT NULL,
    [sourceId]              INT            NOT NULL,
    [departmentId]          INT            NOT NULL,
    [documentId]            INT            NOT NULL,
    [facilityId]            INT            NULL,
    [recordReferenceNumber] NVARCHAR (MAX) NULL,
    [pageNumber]            NVARCHAR (MAX) NULL,
    [recordEntryDate]       DATETIME       NULL,
    [providerFirstName]     NVARCHAR (MAX) NULL,
    [providerLastName]      NVARCHAR (MAX) NULL,
    [memo]                  NVARCHAR (MAX) NULL,
    [serviceDate]           DATETIME       NULL,
    [noteSubjective]        NVARCHAR (MAX) NULL,
    [noteObjective]         NVARCHAR (MAX) NULL,
    [noteAssessment]        NVARCHAR (MAX) NULL,
    [notePlan]              NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Records] PRIMARY KEY CLUSTERED ([recordId] ASC),
    CONSTRAINT [FK_dbo.Records_dbo.Departments_departmentId] FOREIGN KEY ([departmentId]) REFERENCES [dbo].[Departments] ([departmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Records_dbo.DocumentSources_sourceId] FOREIGN KEY ([sourceId]) REFERENCES [dbo].[DocumentSources] ([sourceId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Records_dbo.DocumentTypes_documentId] FOREIGN KEY ([documentId]) REFERENCES [dbo].[DocumentTypes] ([documentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Records_dbo.Facilities_facilityId] FOREIGN KEY ([facilityId]) REFERENCES [dbo].[Facilities] ([facilityId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Records_dbo.InternalCaseNumbers_internalCaseId] FOREIGN KEY ([internalCaseId]) REFERENCES [dbo].[InternalCaseNumbers] ([internalCaseId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_internalCaseId]
    ON [dbo].[Records]([internalCaseId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_sourceId]
    ON [dbo].[Records]([sourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_departmentId]
    ON [dbo].[Records]([departmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_documentId]
    ON [dbo].[Records]([documentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_facilityId]
    ON [dbo].[Records]([facilityId] ASC);

