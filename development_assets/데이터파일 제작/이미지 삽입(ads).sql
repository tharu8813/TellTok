DECLARE @i INT = 1;
DECLARE @sql NVARCHAR(MAX);
DECLARE @filePath NVARCHAR(1000);

WHILE @i <= 10
BEGIN
    SET @filePath = N'C:\Users\USER\Desktop\폴더\전국대회 강원 2025\채팅버전\데이터파일\이미지\ads\' 
                    + CAST(@i AS NVARCHAR(10)) + N'.png';
    SET @sql = N'INSERT INTO [ads] (ad_image)
                 VALUES ( 
                 (SELECT BulkColumn
                  FROM OPENROWSET(BULK N''' + @filePath + N''', SINGLE_BLOB) AS ImageData))';
    PRINT @sql;
    EXEC sp_executesql @sql;
    SET @i = @i + 1;
END;
