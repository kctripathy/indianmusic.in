USE IndianMusic; 
GO


  
  
CREATE OR ALTER PROCEDURE [dbo].[_drop_all_tables]  
     
AS  
 BEGIN  
    SET NOCOUNT ON;  
    DECLARE @SQL NVARCHAR(MAX)  
 DECLARE @SQL_DROP_TABLES NVARCHAR(MAX)  
 DECLARE @TABLENAME SYSNAME  
 DECLARE @FK_NAME SYSNAME  
 DECLARE @OBJECT_ID BIGINT  
 DECLARE @PARENT_ID BIGINT  
  
 DECLARE cursor_tables CURSOR  
 FOR SELECT object_id, parent_object_id, name FROM sys.objects WHERE TYPE='U' and name not like 'Asp%' and name not like '%EFMig%'  
  
 OPEN cursor_tables;  
  
 FETCH NEXT FROM cursor_tables INTO @OBJECT_ID, @PARENT_ID, @TABLENAME  
  
 WHILE @@FETCH_STATUS = 0  
  BEGIN  
   PRINT 'DROPING TABLE ====> '  + CAST(@TABLENAME AS varchar) +  '@@PARENT_ID = '  + CAST(@PARENT_ID AS varchar) +  '@@@OBJECT_ID = '  + CAST(@OBJECT_ID AS varchar);  
     
  
   --REMOVE FOREIN KEYS BEFORE   
   DECLARE cursor_fkeys CURSOR  
   FOR SELECT name FROM sys.objects WHERE parent_object_id = @OBJECT_ID AND TYPE='F'   
  
   OPEN cursor_fkeys;  
   FETCH NEXT FROM cursor_fkeys INTO @FK_NAME  
   WHILE @@FETCH_STATUS = 0  
   BEGIN  
     SELECT @SQL = 'ALTER TABLE dbo.' + QUOTENAME(@TABLENAME) + ' DROP CONSTRAINT ' + @FK_NAME;  
     EXEC sp_executesql @SQL;  
     FETCH NEXT FROM cursor_fkeys INTO @FK_NAME;  
  
   END;  
     
   SELECT @SQL = 'DROP TABLE dbo.' + QUOTENAME(@TABLENAME) + '';  
   EXEC sp_executesql @SQL;  
  
   CLOSE cursor_fkeys;  
  
   DEALLOCATE cursor_fkeys;  
   PRINT 'DROPPED TABLE <=============================================================> '  
     
   --SELECT @SQL_DROP_TABLES = @SQL_DROP_TABLES + + CHAR(13)+CHAR(10) + 'DROP TABLE dbo.' + QUOTENAME(@TABLENAME) + '';  
  
   FETCH NEXT FROM cursor_tables INTO @OBJECT_ID, @PARENT_ID, @TABLENAME;  
  END;  
  
 CLOSE cursor_tables;  
  
 DEALLOCATE cursor_tables;  
  
  
    print @SQL_DROP_TABLES  
 END  