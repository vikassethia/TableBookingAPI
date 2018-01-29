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
INSERT INTO `__migrationhistory` VALUES ('201801291339429_initial','DataAccess.Migrations.Configuration','�\0\0\0\0\0\0\�\\[o\�~/\�� \�ȱ�\�n/�}�\�\�\�\�\�\��٧��hG�.�H�	���>�\'�/�ԕw��l\'E^��q8�\���\������\�\�\�Q��s�lr\�{0\r�0J7s��\��\���\�o3�&\�\�/͸�t�L\�\�\�x{>��\�&\0M�(\�3���$Ȓ)�\�\�\�?O\�Φ�@�\��f_�G	,�!�^fi\0��\0�u\�\�\�gY�z7 �h8��\0A\0���}\�\"�\0\�c	\�\�4\�0��\��o.q���\�4���eɸ5���?\�\�.\��]ȴ#l��\�,q<{_Kf*���\�J�\�\��1~��.\�7�WY�7b��\��\��\�/㜎�%<a\�N����\��6�\�Ļ,b\\\�p�\�\� >�\�U�/�\"��E�<.I\�@�\��ls���k\��\�My��Hؒ14Ղ)~�\��n\�\�t\r�\n0�_\�,�?\�\�\0\��`�b�R�\�\�\�\\��ȉ\�$�G���k����8���{\��=ði����F\�u\\Il����co�d��\n@7\�)ڔ\� W\�j|\�+�\�~�m�6���@d]y�|\�⎖\���b\�^f�̊<p\�$�\�u�\�\�\�r�!��\�v6\�\\\�A,\�x	͑ �\�\���g\�s�#L?\Z��pj7�y�/\�@\�=f�p\�s�}c�j�\��\�D9Z\�S�x\�ҹ\�0D�Y\�}E0�J��\�n8�|%\�:�\� \�e�4\�S\Z\����\�Ǘ��\�\�ҙ\�n�\�o�Ƭ�\�\�U\�`�[�#\�l\�3p�\�nE�uClV�:^\�ߗ�\�.ff��P��\�4�n3U.w��YQ�\�f�\�\�\���\��\�\��1��Z\�\nƐ\�\�h�\�V���\��rr\�t=�e�C;��]i�\���\�\�������\�Hv�=c�6E}8��,+\'\�-|�8\�SG�GJ�ʃt�@0\�3\�xACt$��F��Y\\��(K{(-m\�<��\�mS�h����N5�I%�\�U\�Y\r���C,dC�&\�8/�N��\� �,�\�\�\�AW7\��\�\�[�>\��\"�\�\�\�\�E\�0�M\�\�F#U]H�\�)ѽӘ1;u�PD%\'|t����\�\�g��y5\"&+\�#Ex��g�\�z�ە�\�\�\�<�\�$xb\�`N\�5_\���X6�Q\ZD[[,R�u�>\�mi\'{�\�����\�\�\\��	�O^�)�@f�Ҽ�t\�\��\��	o\�kW_����e^�\�\�\Zb%N:f�\��J\�\��Q�A\�\�/���I��\��<��ik���׳��i\�#\�0\�\�m�\�q\�mw\�\r\�.�+��\�I\�K�\�1��\�Iuԫߝ�ѵ��\r&0g�c}\�\�ҋ�0Z?\nQ�XU�\"/!V=;/Ou}IZ%C\�t0�\��ŀ$ƾ\�\��6B�S�\��FcT0\���\0\�HČFH�\�\�\�P\�WH��Z�\�\�*؝�t\�\�\���5�A~��\�\�e\�ظ�.N$�&No\r2\���,%E�U#�\�\��Ԝ\�>)\�=;������c��mno�uƲD����\�7O��ri�f\�*\�n�M5���k�\�Rs\�Q\�-޲JS��a\���T\�\0)�Znۙp��\rz\�Ԅ\�2�GC�+@�+�a\"\r��R�	o\�Sܖ�5��!��+BSZ�\��>�%&\�})�\�j\� S{4s\� W\�^fq����B5\0`Aq=�\�cь\�?���`$OL\�\�X��j�\�\����Sh\�n+)�WLt�\�b��\08յ\�#q�`,\�a�\'f{��b�=j��ł\�M�UY]CU��٭R�\ZQu\�\�1i[,\Z\�\� �&y��R\�\�\�*�K\\`\��j��٫r0(\�s\�ݤh\�6\�:�.\�\�ZԱ�\�pʨ�\�q�\\(�i�\���\��>�͚\�.p�\��͜\��\�\�\�uT\�\�\�G�z�<+\Z\�}�$�\�#!\�\�\�#mV��\�i�ڨ��F\�Iu\�e\�z�|M\�~4y���W�e#l\���r\�&�0��LL(�ԓ\�58W�\�q�e�g.\�wE\�Xt	�}Ӵ\�#u),R\�z\��%�R\�!\�\�mHE�\�\�0F\�ר��\�SҘ\��\��\���Oʏ�qD܍�i�&O�*�\��0��P>�zJ9���\"��\�\�\�\0E��ko\�cT+��\����i�\��?K\�so�\�CK|\�\�\�d�ϽS\�_R�\�\�\�\�\�-�aHy��,8\��1��\�\�M\�R�\n��v�C�\r\�AUᩀi���\�T�]\�\�\�Y5W\\��,\�\Z\�0�t!��\�\�\�]�����\�\�\�\�F��\�̈�\�gk����:��m�\���l�N�%bC0�\Z[[^�\�\�\�^Kefa]/\�#��\r��\�\�V��4��~�!\�Q�u�\"���9R]R��\�E�\��1�i�\"MU�\��z���}y\\\�~\\��`UN�s�\�X�\Z巸k:J�g�\�6�EC\�X�1\�7\�o\�\�Umz\�1�\"\\�ϸ���xؽ�\�xZa�Jsu���F,I�׵\�\�[k`��o��`�R�CW�X\�\�\�\�y�\�i���\���o\Z\�\�\�9�\�3�@�T\�;�S����8אZ��R���\�j�%	\�ɜ*���S\�i\�G(nP2�\�1\'Cʹ}e\�T�ײ�}W#hJ\�\�3\�D�:j�e�U\�~j\�/�\�\�\��\02�vQ�\� \�\�!�0\�.�v̂\�As�\n5C�7�5\� �9+9�\� ���&��6\��~Y��\�\"�-��d\�0Y\�\\�!�\�M�<ϳ\�m�\�c,��\�\�\�m���\�\���\"ؠ��\�As�{�i\�q�\�\"ɿP��\�\��4�0\�\�ݦK@�-\�\�\�܀\�ISЃ�o/�\�U69HP�\�ѓ��\���\�\�m\�\\\0\0','6.2.0-61023');
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
INSERT INTO `users` VALUES ('vikas.sethia21@gmail.com','^ID—hÁž.²¦9¼Ty6¸ufî€]¼Øfëã~¨ÔØßÓHã|”ôÄŸý²2¥þ£!Î\nµ­O[ù8','2ee6947d-ab56-4f97-90cf-de94a4d85ed5',1,'','2018-01-25 15:11:16','Vikas','Sethia');
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
