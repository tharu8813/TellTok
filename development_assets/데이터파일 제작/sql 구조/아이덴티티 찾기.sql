SELECT
    fk.name AS FK_name,
    tp.name AS Table_name
FROM
    sys.foreign_keys fk
    INNER JOIN sys.tables tp ON fk.parent_object_id = tp.object_id
WHERE
    tp.name = 'chat';


ALTER TABLE chat CHECK CONSTRAINT FK__chat__cg_no__4222D4EF;