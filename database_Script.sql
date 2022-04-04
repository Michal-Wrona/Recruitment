CREATE DATABASE RecruitmentDbSQL
GO
USE RecruitmentDbSQL

CREATE TABLE dbo.Products(
	Id uniqueidentifier NOT NULL,
	Name varchar(100) NOT NULL,
	Number int NOT NULL,
	Quantity int NOT NULL,
	Description varchar(200) NOT NULL,
	Price decimal NOT NULL
)
