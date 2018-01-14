create database TableBooking;

use TableBooking ;

CREATE TABLE UserRole ( 
	UserRoleID INT NOT NULL primary key auto_increment,
	UserRoleName varchar(50) NOT NULL
) ;

CREATE TABLE Users ( 
	UserId varchar(50) NOT NULL primary key,
	PasswordHash nvarchar(255) NOT NULL,
	Salt nvarchar(255) NOT NULL, 
	UserRoleID int NOT NULL ,
	IsActive bit NOT NULL default 1,
	AddeddOn datetime NOT NULL
)