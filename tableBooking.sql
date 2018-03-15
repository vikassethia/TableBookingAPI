create database TableBooking;

use TableBooking ;

CREATE TABLE Customer ( 
	CustomerId varchar(64) NOT NULL primary key,
	CompanyName nvarchar(255)  NULL,
	DisplayName nvarchar(255)  NULL, 
	Address nvarchar(500)  NULL ,
	IsActive bit NOT NULL default 1,
	AddeddOn datetime NOT NULL
) ;


CREATE TABLE UserRole ( 
	UserRoleID INT NOT NULL primary key auto_increment,
	UserRoleName varchar(50) NOT NULL
) ;


CREATE TABLE Users ( 
	UserId varchar(64) NOT NULL primary key,
	PasswordHash nvarchar(255) NOT NULL,
	Salt nvarchar(255) NOT NULL, 
	UserRoleID int NOT NULL ,
    FirstName varchar(50) ,
    LastName varchar(50) ,
    CustomerId varchar(64),
	IsActive bit NOT NULL default 1,
	AddeddOn datetime NOT NULL,
    KEY UserRoleID_idx (`UserRoleID`),
    CONSTRAINT UserRoleID FOREIGN KEY (`UserRoleID`) REFERENCES userrole (`UserRoleID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    KEY CustomerId_idx (`CustomerId`),
    CONSTRAINT CustomerId FOREIGN KEY (`CustomerId`) REFERENCES customer (`CustomerId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ;
  
  
  
  CREATE TABLE TableShape ( 
	ShapeId INT NOT NULL primary key auto_increment,
	ShapeName varchar(50) NOT NULL
) ;


CREATE TABLE TableInfo ( 
    TableId INT NOT NULL primary key auto_increment,
	TableNumber int NOT NULL ,
    TableName nvarchar(50),
    Capacity int NOT NULL ,
    ShapeId int ,
    CustomerId varchar(64),
	Xposition double, 
	Yposition double, 
    IsBookable bit NOT NULL default 1,
    IsDeleted bit NOT NULL default 0,
    KEY ShapeId_idx (`ShapeId` ASC),
    KEY CustomerId_idx (`CustomerId` ASC),
    CONSTRAINT ShapeId FOREIGN KEY (`ShapeId`) REFERENCES tableshape (`ShapeId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT TableCustomerId FOREIGN KEY (`CustomerId`) REFERENCES customer (`CustomerId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ;


CREATE TABLE Booking ( 
	BookingId varchar(64) NOT NULL primary key,
	FirstName varchar(50) ,
    LastName varchar(50) ,
    PhoneNumber varchar(15) ,
	NumberOfGuests int NOT NULL, 
    Email varchar(50) ,
	Notes nvarchar(255)  ,	
	BookingDate datetime NOT NULL,
    StartTime time NOT NULL,
    EndTime time,
    BookedBy varchar(64),
    CustomerId varchar(64),
    HasArrived bit not null,
    KEY CustomerId_idx (`CustomerId` ASC),
    CONSTRAINT BookingCustomerId FOREIGN KEY (`CustomerId`) REFERENCES customer (`CustomerId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ;


CREATE TABLE BookedTable ( 
	Id INT NOT NULL primary key auto_increment,
	BookingId varchar(64) NOT NULL,
	TableId int NOT NULL,
    KEY BookingId_idx (`BookingId` ASC),
    KEY TableId_idx (`TableId` ASC),
    CONSTRAINT BookingId FOREIGN KEY (`BookingId`) REFERENCES booking (`BookingId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT TableId FOREIGN KEY (`TableId`) REFERENCES tableinfo (`TableId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ;

  
create table Archivedbooking (
Id int not null primary key  auto_increment ,
BookingId varchar(64) ,
FirstName varchar(50) ,
LastName varchar(50) ,
PhoneNumber varchar(15) ,
NumberOfGuests int not null ,
Email varchar(50) ,
Notes varchar(255) ,
BookingDate datetime not null ,
StartTime time not null ,
EndTime time,
CustomerId varchar(64),
BookedBy varchar(64) ,
Bookedtables varchar(50) ,
HasArrived bit not null 
) ;


INSERT INTO Customer(`CustomerId`,`CompanyName`,`DisplayName`,`Address`,`IsActive`,`AddeddOn`) VALUES ('ricora','Ricora AB','Ricora','Stockholm, Sweden',1,'2018-03-08');

INSERT INTO UserRole(UserRoleName) VALUES('Admin');
INSERT INTO UserRole(UserRoleName) VALUES('Employee');
  
INSERT INTO TableShape(ShapeName) VALUES('Square');
INSERT INTO TableShape(ShapeName) VALUES('Round');
INSERT INTO TableShape(ShapeName) VALUES('Rektangel');
INSERT INTO TableShape(ShapeName) VALUES('Oval');

INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (1,2,1,null,null,1,0,'ricora');
INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (2,2,1,null,null,1,0,'ricora');
INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (3,2,1,null,null,1,0,'ricora');
INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (4,4,2,null,null,1,0,'ricora');
INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (5,4,3,null,null,1,0,'ricora');
INSERT INTO tableinfo(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`,`CustomerId`) VALUES (6,4,3,null,null,1,0,'ricora');



