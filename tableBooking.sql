create database TableBooking;

use TableBooking ;

CREATE TABLE UserRole ( 
	UserRoleID INT NOT NULL primary key auto_increment,
	UserRoleName varchar(50) NOT NULL
) ;

insert into UserRole(UserRoleName) value('Admin');
insert into UserRole(UserRoleName) value('Employee');

CREATE TABLE Users ( 
	UserId varchar(64) NOT NULL primary key,
	PasswordHash nvarchar(255) NOT NULL,
	Salt nvarchar(255) NOT NULL, 
	UserRoleID int NOT NULL ,
	IsActive bit NOT NULL default 1,
	AddeddOn datetime NOT NULL
) ;
 
 
 ALTER TABLE `tablebooking`.`users` 
ADD INDEX `UserRoleID_idx` (`UserRoleID` ASC);
ALTER TABLE `tablebooking`.`users` 
ADD CONSTRAINT `UserRoleID`
  FOREIGN KEY (`UserRoleID`)
  REFERENCES `tablebooking`.`userrole` (`UserRoleID`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  
  
  CREATE TABLE TableShape ( 
	ShapeId INT NOT NULL primary key auto_increment,
	ShapeName varchar(50) NOT NULL
) ;

insert into TableShape(ShapeName) value('Square');
insert into TableShape(ShapeName) value('Round');
insert into TableShape(ShapeName) value('Rektangel');
insert into TableShape(ShapeName) value('Oval');

CREATE TABLE TableInfo ( 
	TableNumber int NOT NULL primary key ,
    Capacity int NOT NULL ,
    ShapeId int ,
	Xposition double, 
	Yposition double, 
    IsBookable bit NOT NULL default 1,
    IsDeleted bit NOT NULL default 0
) ;

ALTER TABLE `tablebooking`.`tableinfo` 
ADD INDEX `ShapeId_idx` (`ShapeId` ASC);
ALTER TABLE `tablebooking`.`tableinfo` 
ADD CONSTRAINT `ShapeId`
  FOREIGN KEY (`ShapeId`)
  REFERENCES `tablebooking`.`tableshape` (`ShapeId`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  

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
    BookedBy varchar(64) 
) ;

CREATE TABLE BookedTable ( 
	Id INT NOT NULL primary key auto_increment,
	BookingId varchar(64) NOT NULL,
	TableNumber int NOT NULL
) ;


ALTER TABLE `tablebooking`.`bookedtable` 
ADD INDEX `BookingId_idx` (`BookingId` ASC),
ADD INDEX `TableNumber_idx` (`TableNumber` ASC);
ALTER TABLE `tablebooking`.`bookedtable` 
ADD CONSTRAINT `BookingId`
  FOREIGN KEY (`BookingId`)
  REFERENCES `tablebooking`.`booking` (`BookingId`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `TableNumber`
  FOREIGN KEY (`TableNumber`)
  REFERENCES `tablebooking`.`tableinfo` (`TableNumber`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (1,2,1,null,null,1,0);
INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (2,2,1,null,null,1,0);
INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (3,2,1,null,null,1,0);
INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (4,4,2,null,null,1,0);
INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (5,4,3,null,null,1,0);
INSERT INTO `tablebooking`.`tableinfo`(`TableNumber`,`Capacity`,`ShapeId`,`Xposition`,`Yposition`,`IsBookable`,`IsDeleted`) VALUES (6,4,3,null,null,1,0);
