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

ALTER TABLE `tablebooking`.`users` 
ADD column FirstName varchar(50) ,
ADD column LastName varchar(50) ;


create table `archivedbooking` (`Id` int not null  auto_increment ,`BookingId` varchar(64) ,`FirstName` varchar(50) ,`LastName` varchar(50) ,`PhoneNumber` varchar(15) ,`NumberOfGuests` int not null ,`Email` varchar(50) ,`Notes` varchar(255) ,`BookingDate` datetime not null ,`StartTime` time not null ,`EndTime` time,`BookedBy` varchar(64) ,`bookedtables` varchar(50) ,`hasArrived` bit not null ,primary key ( `Id`) ) engine=InnoDb auto_increment=0;
alter table `booking` add column `hasArrived` bit not null  ;
alter table `tableinfo` add column `TableName` nvarchar(50)  ;
INSERT INTO `__MigrationHistory`(
`MigrationId`, 
`ContextKey`, 
`Model`, 
`ProductVersion`) VALUES (
'201802061352456_archivedBooking_UpdateTables', 
'DataAccess.Migrations.Configuration', 
0x1F8B0800000000000400ED5DDB6E2337127D5F20FFD0E8C7C091EC99CC666348093CBE648D1D5F30F204992783EAA6A446FAA2ED667B6D04FB65FBB09FB4BFB0645F796FB2D592EC40C88B874D1E168BC5AA62A98AF9DF7FFE3BF9F9390A9D27986641124FDD93D1B1EBC0D84BFC205E4EDD1C2DBEFB9BFBF34FDFFC6572E947CFCEAF75BFF7A41F1E1967537785D0FA743CCEBC158C40368A022F4DB26481465E128D819F8CDF1D1FFF383E3919430CE1622CC7997CCE631444B0F807FEE779127B708D7210DE243E0CB3AA1D7F9915A8CE2D8860B6061E9CBA17008133CF8359362A3ABBCE5918004CC70C860BD701719C20803095A75F32384369122F676BDC00C2879735C4FD1620CC6045FD69DBDD7421C7EFC842C6EDC01ACACB339444968027EF2BCE8CF9E1BDF8EB369CC3BCBBC43C462F64D505FFA62E48BD55F004FD7992FC8EF7D775F8394FCFC394F417B93CE2C61E396D8FA3462EB0F890FF8E9CF33C44790AA731CC510AC223E73E9F8781F70FF8F290FC0EE3699C87214D2BA6167F631A70D37D9AAC618A5E3EC345B5826BDF75C6ECB8313FB019468D2917751DA3F7EF5CE7164F0EE6216C448162C00C2529FC05C6300508FAF7002198C6040316CC1466E7E6FA5872A79D120B60C1E91BF0FC09C64BB49ABA7FFDDE75AE8267E8D70D15155FE2009FBB962AFD4C57419A21F2A766A60FC743CCF409EC68A2FB5512C3DB3C9AC35433D7C98721E62AA7B95BFC92C30C655D02A2C7BA8C40106E9D3BB70982996696771F06614C25C1F874371B4EFE7E08880058326686408ACA9125522F94CBD81731BA1701FD8F2F5B3F85F362224456A3DB9B61246005B2B334254AB89E0AAF338420EE60E964DC5A02AD7DA05663651BA87107BBA03B5583D805CBE3F340FAB25AD550CDDD82A760592C5F22F505F59F61587CCF56C1BA74C046D5B747F6645CA549F43909DBB1CCF7C707902E21C2E4259A4EB3244F3D0B2A8B6141BC48A474365F9594CA7B08B42ABAC9A8B53A88B60EDA7E1D334AC06DCFE11ECFC6C1893A385107274AB3889D38517DFD9A2E13D52AF5A1EC54ADD4B576AA3610BD343F65B42C747F336A4FDA9FF1316CF5BF8583D2ED90DD62ED67E6116DA88C519A774E740ED6C02BBCC34D34E36C05D6507056F5637E5B27595046912A9149F2C2ABD70FFBDA6FD875467445796DB03CC002D2050C21DAA926E8ED09F2DAA0C361B4F25B33B2E96A728BCF8FCD841272851E72C755ECB691E34AD36EABBF8A617B5260CD19B3555EF2C3B9C59B6431E1409E64EF33C508DE90322A3D526A51EE25A37906D334B10C71D483F6249F5FF0F48423D717F6224A8FDD9594D673EE5B50C9B6C945B4DED0C7AA4B2B9AEC174124B9CF1B8BA2B518EE5104FB68C87ADC9BBCDB9B7879435CED4DE6B90759F6AF24F5FF0EB2D51057585B371484680FD39A6BAF2ECFF2CC43F88EB9A9877AE6FBD0F7EF62FB7BBD5649950669133DC5BB770A3566A2A7CEB22CF18282123620C97AC8ECF22E63DF31B93A9702445DC1B118619515ACB192C2B44CDD1381731DD0CDCA59E8E6970C16FE5B011EEB389812BB06C273CC7BAC358318890A3188BD600D4283457263ED02A6645B9AC9F82F17700D6362830DF8B13115CD649CC6EFE2D7644C09905EAE14772FD5F6775DC45A01A0E228E6D2D515F1DFA57CE9976AB2B79AA08C958CE9B9320025BB9233F142A21504CDED8493B3EAC2CBCAC1F168D4296B9A4BBA81280F2969CAC59AECAFE2F66C2F654A7E6C48C50E248CB3D3AA6D575D2EDAED6EBD0173C5A5720558D42DC98F7C49263BA6BED55A898E7CF59B1330B8D494DE161E83F00898D2DAB132C45546A37023C4845697C2ACBA2CF0A240906710C933FDB0DFD87A7A954408C9808274B1906C705480632CA20194822A536A98B0928042A94C139C42ED28712AEDDE01540BA10CA63DD206202A0061302564026BB95036D555F7F3177F020C5DFA6615F4CE0AC7C9D089E7C0DA35F0710776F906AC51C5F945E69878A5367E29B526466E353CEA7045B7CC2549E856C1A50E9FCAC6ABE2B9549FCA2E2EA99D2833BEF760127F291799A373074C1C028A744AB36858A17001381C9BC5D7D181C65E35DF26E3322DBF6A988C15F9FB931BB05E1375D08EAC5A9C5999CC7FFEDDCC3ECF3D2A31C65E2649776FA86D6642490A9690FB8AA7C694163142124D9D0312B039F723A19B689D152ABC9E4F6180C59DAB757C3D90FC5D0EEE4ABE97F83615C8155E6A443CA3227E4F6D7E2782436A2D4008524996E47912E651ACCAB4D48DA6E20B348826ECA0C6A202BA3416D56C8ED5C66C69A8B6D51C89C9B7A2C1980FE6787C4E150DC97F3347ADB2AB68B0AAC982B232778A21A86CB2968732314A2211E507733C2A398A46A39A2D7854A748315CAA1BEDD658E64DF10B2C5BCD9158D34EA3E98CBE0E914EB5A2F1E876116D32E6D48B705512B4196764782D69A4433B9C2F0BFD495F4EEC75A776F4EBD79B4CF48D46D386E5F6BAEB9B5BCCFE96D2DA421E6CDCC1C61D6C5C5F1BF7A62C92FE9E6BA19EDA0095BD82D28C1DDA04E8F104DD42359B63B549B23454DB6A7150EA1F009863A2FA55408D4325CFD24854B339D65739D6D73E58749A2DE35A50ED36684DAA2D0BD634BFAE63578583363F76653CB7E7B9530CDEB64852599F0292EAC0ED69B3DA70D5465BD5C4CCED374A3D54C55EFA77209ABFBADF87BAD1C4FD62BFBCAA2D1B60BB7A6E95DD36F187499E96A84379A53E3693DDC738D9CC170B9D5124EC31EAA268B117E4618E459B81C7DA9BBAD51CA9CDC1A391DAD61D1F2C2150CE7769666F02E65C607C5205A9BB5FBF11A2D66517D7C12C7A0A7C12B1BE7999FD331C91EFA3E2CFF330C00B6E7BDC803858E0CB55990EEC7E18FDC03DA1F37A9EB31967991F4A82FC9A376DD86DDBC1E30101E16D67BABC6596A95013FD44D609522171BAC53549211672A265B02459D90E96CF801E065552C92C0326A5CC76C0F2B2E5621F37295A1E66D54C85B20CB248B4B6C3949423FBF86F545CFAEF53E805E5AB5EC79B17270F80C9952AEB114D974F17320F7396644FBF0C2302623DF43CE892CD5E6FBCFCD975A59046751DFBF079EAFE518C3C75AE7F7B6C061F397729368EA7CEB1F36F8D64F47D72A558B9013DD45096A2E176BFA7951CF2858FEE13D8AFC4E760CE0EE6EC60CE7A99B3AD1A1D45C87A3F8F4BF43919C29311F130C7837F21A20F6D5C09BAA9A5A986A9AC8C09F5C22B137EF55C841D8CF0EA443F18F1158A6E0996A1702F500C7D0C2411E4DDBE51B015274C7896A0FB7C6CC2497988771FB5F45BE1A6AC7C7EFB0CDD5F55F8B6FCC181B434EF100E042B2BE8367091ACABB587C25408BF81AD69475A5C6A64BA99ADE1EEA3DFF9FAED5E9EE3760BA78728926E4A71F65114BDE302687566DF9FA7E079F3E2E6FD49852ED9657B65CBB692F1868B9407AC483697B5C1AB8F775B6A6C2C8F6FAAAC78904AE25D170EEFBA56F8ED94068B354AFCBE69CB7E4DAA7ECBDF8FB11F3427E7BEF47836280DEEAA0C964DD7A374585739AC9AC2AAAC585F542C9BA24FCD7147C9B1721ABB92646D45B26C0EAB7A6565B9B20A59AC41DC4325B3AC6A5972D015EE93A23844B805BFCA1A65795DEC6B59FCB64B8F1575C6DAE55BB2EE7514144B6B88B5CBA44F739B9D67BE388B826131DF09DB4EEAFF0986ED76162C5B08F27F088BA1C758CDA6CF35DE83DA807314D55DB820C00D44C027298C290A16C043F833C9652C74C0AF20CC21F92D6C0EFDEBF82E47EB1CE125C3681E32D9E8C409D0CD5F5445B3344FEED6C5EB6E432C01931990D8C55DFC310F42BFA1FB4A12AD504010EFA20A5A92BD442478B97C6990C4A7B4554015FB1AA7E80146EB10836577F10C90708D3D6DD8FDFA0497C07BA9B3D6D420DD1BC1B27D721180650AA2ACC268C7E37F6219F6A3E79FFE0F392B6D741A6F0000, 
'6.2.0-61023');
