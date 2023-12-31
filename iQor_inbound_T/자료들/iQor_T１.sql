/*
   Monday, September 25, 202311:06:00 AM
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
	DROP CONSTRAINT DF_iQor_outbound_T_qty
GO
ALTER TABLE dbo.iQor_T
	DROP CONSTRAINT DF_iQor_outbound_T_returnQty
GO
CREATE TABLE dbo.Tmp_iQor_T
	(
	idx int NOT NULL IDENTITY (1, 1),
	companyname varchar(50) NULL,
	fname varchar(20) NULL,
	lname varchar(20) NULL,
	street varchar(50) NULL,
	street2 varchar(50) NULL,
	city varchar(20) NULL,
	state varchar(10) NULL,
	zip varchar(10) NULL,
	country varchar(30) NULL,
	phone varchar(30) NULL,
	email varchar(50) NULL,
	domainID varchar(20) NULL,
	costcenter varchar(20) NULL,
	shipmethod varchar(15) NULL,
	returnLabel varchar(5) NULL,
	ordernumber varchar(30) NULL,
	lotnumber varchar(30) NOT NULL,
	typename varchar(50) NULL,
	brandname varchar(20) NULL,
	modelname varchar(50) NULL,
	pnum varchar(30) NULL,
	formfactor varchar(10) NULL,
	color varchar(10) NULL,
	cpu varchar(30) NULL,
	ramtype varchar(10) NULL,
	ramsize varchar(10) NULL,
	subtypehddname varchar(10) NULL,
	shellsize varchar(10) NULL,
	hdd varchar(10) NULL,
	cd varchar(5) NULL,
	wifi varchar(5) NULL,
	screensize varchar(5) NULL,
	webcam varchar(5) NULL,
	touch varchar(5) NULL,
	productsidx int NULL,
	jnum varchar(10) NULL,
	snum varchar(20) NULL,
	qty int NULL,
	trackingnumber varchar(50) NULL,
	shippedDate datetime NULL,
	returnQty int NULL,
	returnTracking varchar(50) NULL,
	returnedDate datetime NULL,
	condition varchar(50) NULL,
	repairable varchar(5) NULL,
	macAddress varchar(30) NULL,
	productKey varchar(30) NULL,
	image varchar(50) NULL,
	pcName varchar(50) NULL,
	lastEntered datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_iQor_T SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_iQor_T ADD CONSTRAINT
	DF_iQor_outbound_T_qty DEFAULT ((0)) FOR qty
GO
ALTER TABLE dbo.Tmp_iQor_T ADD CONSTRAINT
	DF_iQor_outbound_T_returnQty DEFAULT ((0)) FOR returnQty
GO
SET IDENTITY_INSERT dbo.Tmp_iQor_T ON
GO
IF EXISTS(SELECT * FROM dbo.iQor_T)
	 EXEC('INSERT INTO dbo.Tmp_iQor_T (idx, companyname, fname, lname, street, street2, city, state, zip, country, phone, email, domainID, costcenter, shipmethod, returnLabel, ordernumber, lotnumber, typename, brandname, modelname, pnum, formfactor, color, cpu, ramtype, ramsize, subtypehddname, shellsize, hdd, cd, wifi, screensize, webcam, touch, productsidx, jnum, snum, qty, trackingnumber, shippedDate, returnQty, returnTracking, returnedDate, condition, repairable, macAddress, productKey, image, pcName, lastEntered)
		SELECT idx, companyname, fname, lname, street, street2, city, state, zip, country, phone, email, domainID, costcenter, shipmethod, returnLabel, ordernumber, lotnumber, typename, brandname, modelname, pnum, formfactor, color, cpu, ramtype, ramsize, subtypehddname, shellsize, hdd, cd, wifi, screensize, webcam, touch, productsidx, jnum, snum, qty, trackingnumber, shippedDate, returnQty, returnTracking, returnedDate, condition, repairable, macAddress, productKey, image, pcName, lastEntered FROM dbo.iQor_T WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_iQor_T OFF
GO
DROP TABLE dbo.iQor_T
GO
EXECUTE sp_rename N'dbo.Tmp_iQor_T', N'iQor_T', 'OBJECT' 
GO
ALTER TABLE dbo.iQor_T ADD CONSTRAINT
	PK_iQor_outbound_T PRIMARY KEY CLUSTERED 
	(
	lotnumber
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
