DECLARE @i INT = 1;
DECLARE @sql NVARCHAR(MAX);
DECLARE @filePath NVARCHAR(1000);

WHILE @i <= 40
BEGIN
    SET @filePath = N'C:\Users\USER\Desktop\폴더\전국대회 강원 2025\채팅버전\데이터파일\이미지\userImage\profile\' 
                    + CAST(@i AS NVARCHAR(10)) + N'.jpg';
    SET @sql = N'UPDATE [user]
                 SET u_profile_image = (
                    SELECT BulkColumn
                    FROM OPENROWSET(BULK N''' + @filePath + N''', SINGLE_BLOB) AS ImageData
                 )
                 WHERE u_no = ' + CAST(@i AS NVARCHAR(10)) + N';';
    PRINT @sql;
    EXEC sp_executesql @sql;
    SET @i = @i + 1;
END;
