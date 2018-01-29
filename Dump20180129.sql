CREATE DATABASE  IF NOT EXISTS `tablebooking` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `tablebooking`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tablebooking
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201801291339429_initial','DataAccess.Migrations.Configuration','‹\0\0\0\0\0\0\Ý\\[o\ãº~/\Ðÿ \è±È±“\Ýn/}²\É\î©\Ñ\Í\ë\ìÁÙ§€–hG¨.®H¥	Šþ²>ô\'õ/”Ô•w‘²l\'E^’óq8‡\ãÿ÷\ßÿ™ýôœ\Ä\Þ\ÌQ”¥sÿlr\ê{0\r²0J7s¿À\ëþ\äÿô\ão3û&\Ï\Þ/Í¸÷t¡L\Ñ\Ü\Äx{>¢\à&\0M’(\È3”­ñ$È’)³\é»\Ó\Ó?O\ÏÎ¦@ø\Ëóf_‹G	,ÿ!ÿ^fi\0·¸\0ñu\Â\Õ\í¤gY¢z7 h8÷¯\0A\0š”ƒ}\ï\"Ž\0\ác	\ãµ\ï4\Í0À„\Ëóo.qž¥›\å–4€øþeÉ¸5ˆ¬¹?\ï†\Û.\äô]È´#l ‚\á,q<{_Kf*’’¯\ßJŽ\È\î‘1~¡«.\å7÷WYö7b°Š\Éú\Åù\Î/ãœŽ•%<a\èN¼®÷¤\Õ¢6ô\ïÄ»,b\\\äpž\Â\ç >ñ\îŠU…/÷\"§E³<.I\×@š\îòlsüò®k\Î¡\ïMyº©HØ’14Õ‚)~ÿ\Î÷n\È\ät\r­\n0‹_\â,‡?\Ã\æ\0\Ãð`ó”bÀRˆ\Ò\ì\Â\\‰„È‰\é¦$ŠGþ÷½kðü¦ü8÷ÿð{\ßû=Ã°i¨¹ø–F\ä¼u\\Ilš§¾§coŠdó¾õ\n@7\à)Ú”\Ë W\Õj|\ï+Œ\Ë~ôm«6©û@d]y–|\ÍâŽ–\ë¸ùb\Â^f´ÌŠ<p\à²$‹\Òu¦\ä³\í\Õrª!ñª¦\âv6\íŽ\\\ïA,\ìx	Í‘ £\à®\çðˆg\ãs”#L?\Z¦þpj7µy¦/\à@\Ý=f©p\Üs}c®jš\Ûõ\ÏD9Z\ëS¢x\ïÒ¹\É0D†Y\Þ}E0µJ““\Øn8ý|%\î:º\Ä \Çe…4\åS\Z\Êý‹€\áÇ—Ž¥\Ë\ÅÒ™\â±n—\Æo—Æ¬²\×\ÌU\ã`±[ª#\Ùl\Î3pµ\ÚnE¿uClVŸ:^\âß—®\Ö.ffù¶Pòü\Ì4¿n3U.w½“YQº\Èf²\ï\Ã\Èˆ¼\Ê¯\è\Èÿ1©óZ\è\nÆ\È\Ùhø\ìV‰‡´\Çûrr\Ýt=»e÷C;¡‚]i„\Ú”‡\í\ä²¼»š•’\ìHv¥=c®6E}8÷ø,+\'\É-|¦8\ÅSG•GJ¯Êƒt´@0\Ï3\ÇxACt$ýüF¦§Y\\¹«(K{(-m\æ<¶¢\ÒmS«h³¡õN5ùI%…\îU\ÑY\r¨‚C,dC÷&\Ê8/òN¶™\ç ô,ÿ\Ð\ã\ïAW7\Äø\Ó\Ú[¯>\Ïò\"À\Ñ\Ó\Î\êE\Â0¼M\Ý\ÉF#U]H»\Ø)Ñ½Ó˜1;uPD%\'|t÷ù\å‘\çºgó¢­ˆy5\"&+\Ú#Ex™ûg’\äz Û•ó\Ð\í\×<ü\ï$xb\ã`N\ï5_\Ù«¥X6ˆQ\ZD[[,R u‹>\Òmi\'{®\à¦ô¶\Ç\Î\\´“	¿O^³)£@f½Ò¼½t\Û\ß÷\ë€	o\ØkW_øüúe^ª\Í\Þ\Zb%N:f–\ÊœJ\Ï\ä‰Q¯A\Ï\ê/¯§“I¯®\éª<¦¦ik³¿š×³»–i\å±#\Ð0\áž\Öm»\îq\Ñmw\ç\r\Ø.+À£\îI\ÔK²\Ù1ý«\ÖIuÔ«ßÑµ¦ò¶\r&0g­c}\×\éÒ‹0Z?\nQýXU\"/!V=;/Ou}IZ%C\Ît0¥\×ÁÅ€$Æ¾\Ù\à”6B‹S›\â FcT0\Ýù³\0\ÑHÄŒFH¢\â\Î\ÌP\ÓWH¢ºZú\ß\í*Ø•t\ß\Ò\ãÀº5ˆA~ù¢\Ñ\åe\áØ¸.N$³&No\r2\êñ÷,%EœU#¥\È\Å¥Ôœ\Ê>)\é=;¹’ø‚–…cº»mno†uÆ²D¡¹¯—\Å7Oùöriûf\Ó*\á°n˜M5™‰³k°\ÝRs\ÐQ\Ö-Þ²JS¼üa\éžÁ—T\Ó\0)ùZnÛ™p–ƒ\rz\ÉÔ„\Ó2 GCŸ+@£+—a\"\r“¯R	o\æSÜ–ò®5ö½!¢Ÿ+BSZ¡\Â©>“%&\Ô})ƒ\ìj\ë S{4s\Ä W\ä^fq‘¤º¼B5\0`Aq=÷\ÌcÑŒ\ï?ª’‚`$OL\Ú\áXˆûj½\ë\åõ·óŽSh\Øn+)±WLtœ\Åbší±º\08Õµ\Ú#q™`,\×a\'f{±bŸ=j÷Å‚\ÕMœUY]CU“óÙ­R¶\ZQu\Ø\ã1i[,\Z\Ó\ì £&y‹“R\Ó\è¶\Æ*£K\\`\Õúj¬‰Ù«r0(\Ýs\ÈÝ¤h\Ç6\Ú:¼.\ç‰\ëZÔ±‰\çpÊ¨ò\èq˜\\(‰i¶\Çú®\Æú>‹Íš\â.p¦\Ý­Íœ\âÁ\Ú\æ\×uT\ê\Ã\îG¥zñ<+\Z\â}«$“\Ä#!\é\î\Ì#mV÷ \Ùi«Ú¨ŠûF\éIu\âe\Ãz¬|M\á¾~4y¿øžWµe#l\×À­r\Û&ñ0©³LL(¯Ô“\å’58W–\ëq°eþg.\ÊwE\çXt	ü}Ó´\Ú#u),R\×z\àƒ%…R\Ä!\í\ìmHE\Ì\ê0F\å§×¨†ø\ÑSÒ˜\Æõ\Ëò\ïñ„öOÊ—qDÜ¸i´&O˜*»\Ëÿ0ù£P>úzJ9§…±\"¤©\ç\ä·\ì\0E••ko\æ£cÂT+öò\à¨òþiŸ\çþ?K\Êsoñ\ëCK|\â\Ý\æd³Ï½S\ï_Rö\Ü\î\å•\å\Ê-øaHyŽŒ,8\Øù1«ù\Ú\ÚM\ÎR¢\n—¦v¸Cò\r\ÇAUá©€iž°º\â®T¸]\ê\í\ÆY5W\\§‚,\Ó\Z\Ý0•t!ùŒ\Ë\È\Ç]ƒ¨úÁ\Ó\Ý\ë\êFÀª\ìÌˆ¶\Ëgkðú“Œ: Šm€\É»˜lˆN‹%bC0„\Z[[^“\é\ì¸\Í^Kefa]/\æ#•\rƒ‘\Ë\ÐV‘»4¥´~!\åQôu¬\"¥½¸9R]R¿\ÞE’\ê À1Šiö\"MUý\Ìþz¼²}y\\\é~\\®‘`UNˆs¹\ÆX˜\Zå·¸k:J‡gƒ\Ê6óEC\ì»XÀ1\È7\Ûo\å\ÄUmz\ß1ª\"\\¡Ï¸øÿ©xØ½º\áxZaúJsu®šñ†«F,I°×µ\Ñ\Ë[k`­oª®`”R‚CWºX\à\í\Ô\Èy\â¾ióþû\Òþ«o\Z\ê\Ã\Ð9•\Ë3 @ÀT\Ð;—S¹†À8×ZƒžRƒþù\ÜjŒ%	\ÆÉœ*´…½S\Èi\ÉG(nP2ô\Ö1\'CÊ¹}e\êTù×²ø}W#hJ\ì\ê3\ìD÷:j”e½U\Õ~j\ä/¸\É\Õ\Çü\02¹vQ´\é \è\Ï!§0\à.½vÌ‚\ìAsÿ\n5C„7ü5\Ä ¤9+9Ž\Ö À¤›&¯”6\à~Y´‚\á\"½-ð¶Àd\É0Y\Å\\ú!½\ÃMó—…<Ï³\Ûmù\ëc,°\Ñ\Ð\Ãmú±ˆ\â°\åû³\"Ø  \ÎAs¤{‰i\ìqó\Ò\"É¿P§ª\Å\×ú4÷0\Ù\ÆÝ¦K@£-\î¼\ï\éÜ€\à¥ISÐƒôo/ö\ÙU69HP\ÑÑ“‰‡\Éóÿ\Û\Ým\Ô\\\0\0','6.2.0-61023');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bookedtable`
--

DROP TABLE IF EXISTS `bookedtable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bookedtable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BookingId` varchar(64) NOT NULL,
  `TableNumber` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `BookingId_idx` (`BookingId`),
  KEY `TableNumber_idx` (`TableNumber`),
  CONSTRAINT `BookingId` FOREIGN KEY (`BookingId`) REFERENCES `booking` (`BookingId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TableNumber` FOREIGN KEY (`TableNumber`) REFERENCES `tableinfo` (`TableNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookedtable`
--

LOCK TABLES `bookedtable` WRITE;
/*!40000 ALTER TABLE `bookedtable` DISABLE KEYS */;
INSERT INTO `bookedtable` VALUES (1,'72eaf9be-5d1d-4eac-aea4-4dbd01fb14a3',2),(2,'72eaf9be-5d1d-4eac-aea4-4dbd01fb14a3',3),(3,'fd3bd4b4-3518-489c-ada9-8e0b1a1d0983',1),(4,'fd3bd4b4-3518-489c-ada9-8e0b1a1d0983',2),(5,'fd3bd4b4-3518-489c-ada9-8e0b1a1d0983',3),(6,'76c3c4bd-782d-4a31-9012-05b7cb39a03e',2),(7,'76c3c4bd-782d-4a31-9012-05b7cb39a03e',3);
/*!40000 ALTER TABLE `bookedtable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booking`
--

DROP TABLE IF EXISTS `booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `booking` (
  `BookingId` varchar(64) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `PhoneNumber` varchar(15) DEFAULT NULL,
  `NumberOfGuests` int(11) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `BookingDate` datetime NOT NULL,
  `StartTime` time NOT NULL,
  `EndTime` time DEFAULT NULL,
  `BookedBy` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`BookingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booking`
--

LOCK TABLES `booking` WRITE;
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking` VALUES ('72eaf9be-5d1d-4eac-aea4-4dbd01fb14a3','Vikas','Sethia','0123456789',4,NULL,'Veg','2018-01-26 00:00:00','18:00:00',NULL,'vikas.sethia21@gmail'),('76c3c4bd-782d-4a31-9012-05b7cb39a03e','Vikas','Sethia','0123456789',4,NULL,'Veg','2018-01-29 00:00:00','21:00:00',NULL,'vikas.sethia21@gmail'),('fd3bd4b4-3518-489c-ada9-8e0b1a1d0983','Vikas','Sethia','0789456125',6,NULL,'Looking for vegetarian food','2018-01-29 00:00:00','19:00:00',NULL,'vikas.sethia21@gmail');
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tableinfo`
--

DROP TABLE IF EXISTS `tableinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tableinfo` (
  `TableNumber` int(11) NOT NULL,
  `Capacity` int(11) NOT NULL,
  `ShapeId` int(11) DEFAULT NULL,
  `Xposition` double DEFAULT NULL,
  `Yposition` double DEFAULT NULL,
  `IsBookable` bit(1) NOT NULL DEFAULT b'1',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`TableNumber`),
  KEY `ShapeId_idx` (`ShapeId`),
  CONSTRAINT `ShapeId` FOREIGN KEY (`ShapeId`) REFERENCES `tableshape` (`ShapeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tableinfo`
--

LOCK TABLES `tableinfo` WRITE;
/*!40000 ALTER TABLE `tableinfo` DISABLE KEYS */;
INSERT INTO `tableinfo` VALUES (1,2,1,NULL,NULL,'','\0'),(2,2,1,NULL,NULL,'','\0'),(3,2,1,NULL,NULL,'','\0'),(4,4,2,NULL,NULL,'','\0'),(5,4,3,NULL,NULL,'','\0'),(6,4,3,NULL,NULL,'','\0'),(7,6,2,0,0,'','\0');
/*!40000 ALTER TABLE `tableinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tableshape`
--

DROP TABLE IF EXISTS `tableshape`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tableshape` (
  `ShapeId` int(11) NOT NULL AUTO_INCREMENT,
  `ShapeName` varchar(50) NOT NULL,
  PRIMARY KEY (`ShapeId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tableshape`
--

LOCK TABLES `tableshape` WRITE;
/*!40000 ALTER TABLE `tableshape` DISABLE KEYS */;
INSERT INTO `tableshape` VALUES (1,'Square'),(2,'Round'),(3,'Rektangel'),(4,'Oval');
/*!40000 ALTER TABLE `tableshape` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userrole` (
  `UserRoleID` int(11) NOT NULL AUTO_INCREMENT,
  `UserRoleName` varchar(50) NOT NULL,
  PRIMARY KEY (`UserRoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrole`
--

LOCK TABLES `userrole` WRITE;
/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole` VALUES (1,'Admin'),(2,'Employee');
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` varchar(64) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Salt` varchar(255) NOT NULL,
  `UserRoleID` int(11) NOT NULL,
  `IsActive` bit(1) NOT NULL DEFAULT b'1',
  `AddeddOn` datetime NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `UserRoleID_idx` (`UserRoleID`),
  CONSTRAINT `UserRoleID` FOREIGN KEY (`UserRoleID`) REFERENCES `userrole` (`UserRoleID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('vikas.sethia21@gmail.com','^IDâ€”hÃÅ¾.Â²Â¦9Â¼Ty6Â¸ufÃ®â‚¬]Â¼Ã˜fÃ«Ã£~ÂÂ¨Ã”Ã˜ÃŸÂÃ“HÃ£|â€Ã´Ã„Å¸Ã½Â²2Â¥Ã¾Â£!ÂÃŽ\nÂµÂ­O[Ã¹8','2ee6947d-ab56-4f97-90cf-de94a4d85ed5',1,'','2018-01-25 15:11:16','Vikas','Sethia');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'tablebooking'
--

--
-- Dumping routines for database 'tablebooking'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-29 15:17:32
