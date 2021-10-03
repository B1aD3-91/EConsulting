USE [{0}];
GO
BEGIN
    DECLARE @Path nvarchar(100);
    SET @Path = '{1}'
    EXEC master.dbo.xp_create_subdir @Path
    SET @Path = @Path + '{0}.bak'
    BACKUP DATABASE [{0}]
        TO DISK = @Path
            WITH FORMAT,
        MEDIANAME = 'SQLServerBackups',
        NAME = 'Full Backup of SQLTestDB';
END;