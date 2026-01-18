Delete [user];

DBCC CHECKIDENT ([user], RESEED, 0);
