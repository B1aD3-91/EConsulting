USE [master]
GO
BEGIN
    DECLARE @sourceDbName nvarchar(50) = '{0}';
    DECLARE @tmpFolder nvarchar(50) = 'C:\tmp\'
    DECLARE @sqlServerDbFolder nvarchar(100) = 'C:\mydatabases\'

    DECLARE @sourceDbFile nvarchar(50);
    DECLARE @sourceDbFileLog nvarchar(50);
    DECLARE @destinationDbName nvarchar(50) = '{1}'
    DECLARE @backupPath nvarchar(400) = @tmpFolder + @destinationDbName + '.bak'
    DECLARE @destMdf nvarchar(100) = @sqlServerDbFolder + @destinationDbName + '.mdf'
    DECLARE @destLdf nvarchar(100) = @sqlServerDbFolder + @destinationDbName + '_log' + '.ldf'

    SET @sourceDbFile = (SELECT top 1 files.name 
                    FROM sys.databases dbs 
                    INNER JOIN sys.master_files files 
                        ON dbs.database_id = files.database_id 
                    WHERE dbs.name = @sourceDbName
                        AND files.[type] = 0)

    SET @sourceDbFileLog = (SELECT top 1 files.name 
                    FROM sys.databases dbs 
                    INNER JOIN sys.master_files files 
                        ON dbs.database_id = files.database_id 
                    WHERE dbs.name = @sourceDbName
                        AND files.[type] = 1)

    EXEC master.dbo.xp_create_subdir @tmpFolder
    EXEC master.dbo.xp_create_subdir @sqlServerDbFolder

    BACKUP DATABASE @sourceDbName TO DISK = @backupPath

    RESTORE DATABASE @destinationDbName FROM DISK = @backupPath
    WITH REPLACE,
        MOVE @sourceDbFile     TO @destMdf,
        MOVE @sourceDbFileLog  TO @destLdf
END;