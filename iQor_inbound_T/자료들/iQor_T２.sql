/*
   Monday, September 25, 202311:08:02 AM
   User: sa
   Server: 192.168.1.2
   Database: testJoy
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
ALTER TABLE dbo.iQor_T
	DROP CONSTRAINT PK_iQor_outbound_T
GO
ALTER TABLE dbo.iQor_T ADD CONSTRAINT
	PK_iQor_outbound_T PRIMARY KEY CLUSTERED 
	(
	idx
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.iQor_T SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.iQor_T', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.iQor_T', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.iQor_T', 'Object', 'CONTROL') as Contr_Per 