IF NOT EXISTS (SELECT 1 FROM master.sys.databases WHERE name = N'WEBSHOP')
	BEGIN
		PRINT '1.----- CREATION DATABASE WEBSHOP-----'
		CREATE DATABASE WEBSHOP
END