/*
   Wednesday, October 18, 202310:42:53 AM
   User: MSC
   Server: 192.168.1.21\MDOS
   Database: SmartClient_Test
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.ProductKey.ProductKeyID', N'Tmp_ProductKeyId', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.ProductKey.Tmp_ProductKeyId', N'ProductKeyId', 'COLUMN' 
GO
ALTER TABLE dbo.ProductKey SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ProductKey', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ProductKey', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ProductKey', 'Object', 'CONTROL') as Contr_Per 