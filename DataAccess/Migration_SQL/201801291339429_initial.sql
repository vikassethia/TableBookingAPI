﻿create table `tablebooking.bookedtable` (`Id` int not null  auto_increment ,`BookingId` varchar(64)  not null ,`TableNumber` int not null ,primary key ( `Id`) ) engine=InnoDb auto_increment=0
CREATE index  `IX_BookingId` on `tablebooking.bookedtable` (`BookingId` DESC) using HASH
CREATE index  `IX_TableNumber` on `tablebooking.bookedtable` (`TableNumber` DESC) using HASH
create table `tablebooking.booking` (`BookingId` varchar(64)  not null ,`FirstName` varchar(50) ,`LastName` varchar(50) ,`PhoneNumber` varchar(15) ,`NumberOfGuests` int not null ,`Email` varchar(50) ,`Notes` varchar(255) ,`BookingDate` datetime not null ,`StartTime` time not null ,`EndTime` time,`BookedBy` varchar(64) ,primary key ( `BookingId`) ) engine=InnoDb auto_increment=0
create table `tablebooking.tableinfo` (`TableNumber` int not null ,`Capacity` int not null ,`ShapeId` int,`Xposition` double,`Yposition` double,`IsBookable` bit not null ,`IsDeleted` bit not null ,primary key ( `TableNumber`) ) engine=InnoDb auto_increment=0
CREATE index  `IX_ShapeId` on `tablebooking.tableinfo` (`ShapeId` DESC) using HASH
create table `tablebooking.tableshape` (`ShapeId` int not null  auto_increment ,`ShapeName` varchar(50)  not null ,primary key ( `ShapeId`) ) engine=InnoDb auto_increment=0
create table `tablebooking.userrole` (`UserRoleID` int not null  auto_increment ,`UserRoleName` varchar(50)  not null ,primary key ( `UserRoleID`) ) engine=InnoDb auto_increment=0
create table `tablebooking.users` (`UserId` varchar(64)  not null ,`FirstName` nvarchar(50) ,`LastName` nvarchar(50) ,`PasswordHash` varchar(255)  not null ,`Salt` varchar(255)  not null ,`UserRoleID` int not null ,`IsActive` bit not null ,`AddeddOn` datetime not null ,primary key ( `UserId`) ) engine=InnoDb auto_increment=0
CREATE index  `IX_UserRoleID` on `tablebooking.users` (`UserRoleID` DESC) using HASH
alter table `tablebooking.bookedtable` add constraint `FK_tablebooking.bookedtable_tablebooking.booking_BookingId`  foreign key (`BookingId`) references `tablebooking.booking` ( `BookingId`) 
alter table `tablebooking.bookedtable` add constraint `FK_tablebooking.bookedtable_tablebooking.tableinfo_TableNumber`  foreign key (`TableNumber`) references `tablebooking.tableinfo` ( `TableNumber`) 
alter table `tablebooking.tableinfo` add constraint `FK_tablebooking.tableinfo_tablebooking.tableshape_ShapeId`  foreign key (`ShapeId`) references `tablebooking.tableshape` ( `ShapeId`) 
alter table `tablebooking.users` add constraint `FK_tablebooking.users_tablebooking.userrole_UserRoleID`  foreign key (`UserRoleID`) references `tablebooking.userrole` ( `UserRoleID`) 
create table `__MigrationHistory` (`MigrationId` nvarchar(150)  not null ,`ContextKey` nvarchar(300)  not null ,`Model` longblob not null ,`ProductVersion` nvarchar(32)  not null ,primary key ( `MigrationId`,`ContextKey`) ) engine=InnoDb auto_increment=0
INSERT INTO `__MigrationHistory`(
`MigrationId`, 
`ContextKey`, 
`Model`, 
`ProductVersion`) VALUES (
'201801291339429_initial', 
'DataAccess.Migrations.Configuration', 
0x1F8B0800000000000400DD5C5B6FE3BA117E2FD0FF20E8B1C8B193DD6E2F817D0EB2C9EEA9D1CD05EBECC1D9A780966847A82EAE48A5098AFEB23EF427F52F94D4957791B26C27455E1C92F371381C0E87E319FFF7DFFF99FDF49CC4DE13CC5194A573FF6C72EA7B300DB2304A3773BFC0EB1FFEE4FFF4E36F7F33FB1426CFDE2FCDB8F7741CA14CD1DC7FC4787B3E9DA2E01126004D9228C83394ADF124C8922908B3E9BBD3D33F4FCFCEA69040F804CBF3665F8B1447092CFF21FF5E666900B7B800F17516C218D5EDA46759A27A372081680B0238F7AF0006174100119A94837DEF228E00E16309E3B5EF8134CD30C084CBF36F082E719EA59BE5963480F8FE650BC9B8358811ACB93FEF86DB2EE4F41D5DC8B4236CA08202E12C71043C7B5F4B662A920F92AFDF4A8EC8EE1391317EA1AB2EE537F75759F6371862B08AC9FAC5F9CE2FE39C8E95253C61E84EBCAEF7A4D507A236F4EFC4BB2C625CE4709EC202E7203EF1EE8A551C057F852FF704229DA7451CB33C122E491FD7409AEEF26C0B73FCF215AE6BCE17A1EF4D79BAA948D8923134D58216297EFFCEF76EC8E4740DAD0A308B5FE22C873FC314E600C3F00E600CF39462C05288D2ECC25C1F8984C889E9A6248A47FEF7BD6BF0FC05A61BFC38F7FFF07BDFFB1C3DC3B069A8B9F89646E4BC755C496C9AA7BEA7636F8A6405F3BEF50A4037E029DA94CB172057D56A7CEF2B8CCB7EF4186DAB0336A9FB1E189D40645D79967CCDE28E96EB7FB807F90662C25E6618B4CC8A3C70E0B2248BD275A6E4B3EDD572AA1E21F1AA19A6E27636ED8E5CEF412C05EC780809CD910E20A3E0AEE7F08867E37394234C3F1AA6FE706A37B579A62FE04013DD3D66A970DC15739D7D1863AE6A9ADBF5CF054418395A1701EB5302A278EFD2B9C930448659DE7D184530B54A9393D86E38FD7C1F25EE3ABAC420C71565853408E5531ACA18FD8B80E1C797118EA5CBC5D299E2B16E97C6141B6F97C6AC0FB2D7CC55E360B15BAA23D96CCE3370B5DA0E6E45BF1B75436C569F3A5E02E2DF97AED62E6666F908B650F2FCCC34BF6E3314552E77BD935951BAC866B2EFC3C816881EBCCA07AFE8C8FF3104A9F35A17E80AC690C8D91968F8011DEC568987B4C7FB72720211DD743DBB65F7433BA1825D6984DA0B9487EDE405B2BCBB9A9592EC4876A53D63AE36457D38F7F82C2B271CC92D1B7CA638C51B534795474AAFCA8374B44030CF33C77841437424FDFC46A6A712595CB9AB284B7B282D6DE63CB6A2D26D53AB68B3A10FF5904E35F91E492585EE9D55D1590D8FA882432C6443F7261FCA382F0EF24EB699E70E20F48F2C0FFF02D0E318EF41573714C4F808D3DA5BAF3ECFF222C0D1D3CE1EEA4518C230BC4DDD1FC94623555D48BBD829D1BDD398311B3B758150164425277C748FF790F9E591E7BA67F3A2AD14887919133522262BDA1223457899FB6792E47AA0DB95F3D0EDD7023CFCEF247862E3604EEF35105F12D913AB19A5583688511A445B105B2C52A0758B3ED26D6927137BAEE016A6F40EB690C7CE5CB4930916BF4F5EB329A34066BDD2BCBD74DBDFF710EB1480096FD86B575FF8FC90FA655EAACDDE1A62254E3A6696CA089C1C4ACFE4078951110CAF1341CFEA072FAF07A79349AFAE191EE916AA3CA6A669176BB3BF9AD7B3BB9669E5B1231707D030E19ED66DBBEE71D16D77E70DD81B2E9D2BC0A3EE497FD44BB2D931FDABD64975D4ABDF9D81D1B5A6F2B6080D26143067AD637D11D7E91FD28B90305A3F0A51FD58105581222F2156063D3B2F4F757D495A254311CE7430A503D703C1C5802414C6BED9E09436428B539BE21EA046635430DDF9B300D10148C48C4648A215E2CECC50D35748A2BA5AFADFED2AD89D9574DFD2E316C0BA358841027EF916A2D105E565E1D8B8902E4E24B3264E6F0D32EAF11BF72C25459C5523A51E07C8C50512A5D49CCA3E29E93D1E3BB90F1092F882968563BABB6D6E6F8675C6B21844A1B9AF051C97C5374FF9F67269FB66D32AE1B06E984D359989B36BB0DD5273D051D62DDEB24A53BCFC61E99EC1975418D3002912F95A6EDB997096830D147AC9D484D332A047439F2B40A32B9761220D93AF528D096FE653DC96F2AE35F6BD21A29F2B42535AA1C201A9013E932526D47D2983EC6AEB20537B347314C42057E4045E667191A4BABC421335130060410C71013D16F7CC63D18CEF3FAA928260244F4CDA03E15888FB6ABDEBE5F5B7F38E531F68D86E2B290FB1574C749CC5629AEDB1BA00380BD5B5DA237199602C18D7618F27667BB190629F3D6A9DF7C582D54D0E9C55595D1C435593F3D9AD52B6141A5175D8E331695B2C1AD3EC20A326798B9352D3E8B6C62AA34B5C60D5FA6AAC89D9AB723028DD73C8DDA41868C736DA3ABC2EE78905EB5A1DD4B189E770CAA80BF2E871985C28168969B6C7FAAEC6FA3E048BCD9AE22E70A6DD05ADCD9CE2C1DAE6D77554EA07C3EE47A57AF10F3C2B1AE27DAB2493C42321E9EECC236D56F7A0D969ABDAA88AFB46E94975E265C37AAC7C4DE1BE7E3479BFF89E57B565236CD7C0AD72DB26F130A9B34C4C28AFD493E59235385796EB71B01965FE05672ECA1677451EE758740915FC7DD3B4DA237529152C52D77AE083258552C421EDEC6D4845089DCCEA30467FE5A714D7A886F81E11D15314D298C6F5CBF2EFF184F64FCA8F97714416DC8DB80669B4264F982ABBCBFF30F9A3503EFA7A4A39A70885B1220CA4A9E7E4B7EC00459511956B6FE6A363C290542BF604F2E011A8F2FE1669089FE7FE3F4BCA736FF1EB434B7CE2DDE664B3CFBD53EF5F52F6DCEEE595E5CA2DF86148798E8C2C3817110ED8F931ABF9DA1DDA4DCE5206A20A97A60676B843F20DC7415514E1A98069159E1BB0BAE2AE54B85DEAEDC65935575CA7822CD31ADD3015957421F98CCBC8C75D0E83A8FAC181D3DDEBEA46C014AAECCC88B6CB676BF0FA0F938C3AA08A6D80C918BB986C884E8B25624330841A145B5B5E93E9ECB8CD5E4B6566615D2FE60623959D0D8391CBD05691BB34A512B47E9021E55103F475AC22A5BDB839525D52BF81DE4592EAA0C0318A69F6224D55FDCCFE057ABCB2907D795CE97E5CAE916055151D164E8873B9C658981AE5B7B86B3A4A876783CA36F3451C43ECBB58C031C837DB6FE5C41855126D7ADF31AA220E5C01A1CFB8F8FFA978D8BDBAE1785A61FA4A737F750BAE9AF186AB14462C49B0D7B5D1CB0F0E5B6B60AD8F6FAAAE6094528243570E1CBA58E0EDD406C8798FE2BE69F3FEFBD2FEAB6F1AEAC3D0391E95CB33A040C0541FD03B97531581B986C038D7905A839E5283FEF9DC6A128C2509C6C99C2A17B4850BBD53C869C947286E501532F4D631082743CAB97D1B650BEA54F9D7B2F87D5723684A0FECEA33EC44F73A6A0C946505BD550512D57E6A08E42FB8C9D5C7FC0032B97651B4E920E8CF21A730E02EBD76CC82EC4173FF0A1C35438437FC35C420A4392B398ED620C0A49B26AF9436E0171017907E59B482E122BD2DF0B6C064C93059C55CFA21BDC34DF39785123CCFB3DB6DF9EB0C632C81B019D1D0C36DFAB188E2B0E5FBB322D8A081A0CE411D73A47B8969EC71F3D222C9BF50A703AAC5D7FA34F730D9C6040CDDA64B40A32DEEBC11EFE90BDC80E0A54953D083F46F042FF6D95504363948508DD1D1937F890E87C9F38FFF03DBDD6DD4075C0000, 
'6.2.0-61023');
