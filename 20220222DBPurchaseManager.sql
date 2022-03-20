CREATE DATABASE  IF NOT EXISTS `dulieuthumua` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dulieuthumua`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: dulieuthumua
-- ------------------------------------------------------
-- Server version	5.6.16

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
-- Table structure for table `customerinfo`
--

DROP TABLE IF EXISTS `customerinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customerinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `IsActived` int(11) DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerinfo`
--

LOCK TABLES `customerinfo` WRITE;
/*!40000 ALTER TABLE `customerinfo` DISABLE KEYS */;
INSERT INTO `customerinfo` VALUES (1,'Nguyễn Văn A','0909123456','Hồ Chí Minh','2022-02-21 11:29:25',1),(2,'Nguyễn Văn B','0909123457','Bình Dương','2022-02-21 11:29:55',0),(3,'Nguyễn Văn C','0909123458','Bình Phước','2022-02-21 11:30:33',1),(4,'Nguyễn Văn B','0909123459','Bình Phước','2022-02-21 11:31:21',1),(5,'Nguyễn Văn Hùng','0934567899','Bình Long, Bình Phước','2022-02-21 11:49:13',1),(6,'Trần Văn Cảnh','0987655433','Dĩ An, Bình Dương','2022-02-23 21:22:15',1),(7,'Nguyễn Thị Tuyết','0909789654','Thủy Châu, Bình Phước','2022-02-23 21:26:27',1),(8,'ádfasdfsad','090889q','Bình Dương','2022-02-24 09:39:38',1),(9,'nguyen sdfasd','09089','Binh Duong','2022-02-24 11:13:19',1),(10,'ttt','9898','55','2022-02-24 11:16:13',0),(11,'dfsaf','dfsdf','asdfsadf','2022-02-24 11:52:00',1),(12,'aa','09091787666','Di An','2022-02-24 11:52:03',0),(13,'sdfdf','sfdsdf','dfsfdsdf','2022-02-28 08:27:44',1);
/*!40000 ALTER TABLE `customerinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `priceinfo`
--

DROP TABLE IF EXISTS `priceinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `priceinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP COMMENT 'số độ của mủ cao su, chỉ dùng choi trường hợp mủ cao su không phải mủ chén',
  `Type` varchar(45) NOT NULL COMMENT 'co 2 loai,  "Cao su" "Dieu"',
  `Price` float NOT NULL,
  `Note` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priceinfo`
--

LOCK TABLES `priceinfo` WRITE;
/*!40000 ALTER TABLE `priceinfo` DISABLE KEYS */;
INSERT INTO `priceinfo` VALUES (1,'2022-02-21 10:00:00','Cao su',100,'Test'),(2,'2022-02-21 10:01:00','Cao su',105,'Test'),(3,'2022-02-21 11:01:00','Điều',200,'Test'),(4,'2022-02-21 11:10:00','Điều',234,'Test'),(5,'2022-02-23 11:32:43','Cao su',150,'aaaaaaa'),(6,'2022-02-23 11:32:43','Điều',250,'Điều'),(7,'2022-02-24 21:57:28','Cao su',123,''),(8,'2022-02-24 21:57:28','Điều',234,''),(9,'2022-02-28 08:26:37','Cao su',2000,'qwqw'),(10,'2022-02-28 08:26:37','Điều',5000,'qwqw'),(11,'2022-03-15 22:26:16','Cao su',3000,''),(12,'2022-03-15 22:26:16','Dieu',4000,''),(13,'2022-03-16 09:01:39','Cao su',3500,''),(14,'2022-03-16 09:01:39','Dieu',5500,''),(15,'2022-03-16 09:02:00','Cao su',3500,''),(16,'2022-03-16 09:02:00','Dieu',5000,'');
/*!40000 ALTER TABLE `priceinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchaseinfo`
--

DROP TABLE IF EXISTS `purchaseinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchaseinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerId` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `Type` varchar(45) NOT NULL COMMENT 'Có 2 loại thu mua là: "Cao su"'' Điều"',
  `Weight` float DEFAULT NULL,
  `PriceId` int(11) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `PayNow` int(11) DEFAULT '0' COMMENT '1- Thanh toán ngay\\n0-Thanh toán cuối tháng\\nMặc định là 0',
  `MuType` int(11) DEFAULT '0' COMMENT 'Chỉ dùngcho đơn hàng là mủ cao su.\\n1- mủ chén\\n0- không phải mủ chén',
  `Degree` float DEFAULT NULL COMMENT 'Chỉ dùngcho đơn hàng là mủ cao su.\n1- mủ chén\nChỉ mủ loại này mới có số độ: 0- không phải mủ chén',
  `Note` varchar(500) DEFAULT NULL,
  `PaidDate` datetime DEFAULT NULL COMMENT 'ngày thanh toán, nếu trống là đơn thanh toán ngay',
  PRIMARY KEY (`Id`),
  KEY `fk_purchase_customer_idx` (`CustomerId`),
  CONSTRAINT `fk_purchase_customer` FOREIGN KEY (`CustomerId`) REFERENCES `customerinfo` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8 COMMENT='lưu thông tin tất cả các đơn hàng thu mua, lưu ý có đơn hàng trả tiên ngày và đơn hàng cuối tháng mới thanh toán';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseinfo`
--

LOCK TABLES `purchaseinfo` WRITE;
/*!40000 ALTER TABLE `purchaseinfo` DISABLE KEYS */;
INSERT INTO `purchaseinfo` VALUES (1,3,'2022-02-28 09:40:26','Cao su',100,0,10000,1,1,0,'Test','2022-03-16 12:00:00'),(2,3,'2022-02-28 09:41:55','Cao su',10,0,1000,1,1,0,'',NULL),(3,5,'2022-02-28 09:44:05','Điều',100,0,1000,1,1,0,'',NULL),(4,5,'2022-02-28 09:44:39','Điều',100,0,1000,1,1,0,'',NULL),(5,3,'2022-02-28 09:45:35','Cao su',123,0,333,1,1,0,'',NULL),(6,1,'2022-02-28 09:47:10','Cao su',1,0,1,1,1,0,'Test',NULL),(7,1,'2022-02-28 09:50:13','Cao su',10,0,10000,1,0,10,'',NULL),(8,3,'2022-02-28 09:54:51','Cao su',15,0,10000,1,0,10,'',NULL),(9,1,'2022-02-28 09:55:56','Cao su',10,9,2000,0,0,10,'',NULL),(10,1,'2022-02-28 09:56:07','Cao su',10,0,10000,1,0,10,'',NULL),(11,1,'2022-02-28 10:02:35','Cao su',250,0,5000,1,1,0,'',NULL),(12,1,'2022-02-28 10:20:35','Cao su',100,9,2000,0,1,0,'',NULL),(13,1,'2022-03-04 09:52:22','Cao su',1000,0,2000,1,0,12,'',NULL),(14,1,'2022-03-04 09:53:40','Cao su',1000,0,2000,1,0,50,'',NULL),(15,1,'2022-03-04 09:57:38','Cao su',100,0,1000,1,0,32,'',NULL),(16,1,'2022-03-04 11:44:29','Cao su',120,0,123,1,0,21,'Test',NULL),(17,1,'2022-03-04 11:45:23','Cao su',10,9,2000,0,0,10,'',NULL),(18,1,'2022-03-04 11:46:05','Cao su',10,9,2000,0,0,10,'',NULL),(19,1,'2022-03-04 11:46:10','Cao su',10,0,123,1,0,10,'',NULL),(20,1,'2022-03-04 11:51:55','Cao su',10,0,10000,1,0,10,'',NULL),(21,1,'2022-03-04 11:57:27','Cao su',10,0,10000,1,0,20,'',NULL),(22,1,'2022-03-04 12:58:05','Cao su',100,0,1000,1,0,10,'',NULL),(23,1,'2022-03-04 13:01:17','Cao su',100,0,1000,1,0,10,'',NULL),(24,7,'2022-03-04 13:03:57','Cao su',200,0,200,1,0,20,'',NULL),(25,5,'2022-03-04 13:04:46','Điều',5000,0,200,1,0,20,'',NULL),(26,6,'2022-03-04 13:05:40','Cao su',5000,0,200,1,1,20,'',NULL),(27,4,'2022-03-04 13:09:43','Cao su',200,0,1000,1,0,100,'',NULL),(28,5,'2022-03-04 13:10:07','Điều',200,0,1000,1,0,100,'',NULL),(29,1,'2022-03-04 21:16:05','Cao su',1000,0,5000,1,0,33,'',NULL),(30,7,'2022-03-04 21:21:35','Cao su',1000.93,0,1000,1,0,12,'',NULL),(32,4,'2022-03-05 07:37:17','Cao su',1000,0,2000,1,0,22,'',NULL),(33,1,'2022-03-07 06:51:10','Điều',1000,0,2000,1,0,0,'',NULL),(34,1,'2022-03-10 08:46:37','Cao su',100,0,123,1,0,20,'',NULL),(35,1,'2022-03-14 16:49:17','Điều',100,10,5000,0,0,0,'Điều',NULL),(36,1,'2022-03-15 09:36:31','Cao su',1000,9,2000,0,1,0,'Ts',NULL),(37,1,'2022-03-15 09:36:46','Cao su',1000,9,2000,0,0,10,'Ts',NULL),(38,1,'2022-03-15 09:38:36','Điều',1000,10,5000,0,0,0,'',NULL),(39,1,'2022-03-15 09:44:18','Điều',1000,10,5000,0,NULL,0,'',NULL),(40,1,'2022-03-15 09:44:35','Cao su',1000,9,2000,0,0,100,'',NULL),(41,1,'2022-03-15 13:35:02','Cao su',1000,9,2000,0,0,100,'',NULL),(42,1,'2022-03-15 13:35:15','Điều',2000,10,5000,0,NULL,100,'',NULL),(43,1,'2022-03-15 14:58:13','Cao su',500,9,2000,0,0,100,'',NULL),(44,1,'2022-03-15 22:27:07','Cao su',3000,11,3000,0,1,0,'',NULL),(45,1,'2022-03-15 22:27:15','Điều',2500,10,5000,0,NULL,0,'',NULL),(46,1,'2022-03-16 09:05:03','Cao su',1000,15,3500,1,1,0,'','2022-03-16 22:27:04'),(47,1,'2022-03-16 09:05:10','Điều',500,10,5000,1,NULL,0,'','2022-03-16 22:27:04'),(48,1,'2022-03-16 09:05:23','Cao su',200,15,3500,1,0,100,'','2022-03-16 22:27:04'),(49,3,'2022-03-16 23:16:58','Cao su',100,15,3500,1,0,100,'','2022-03-16 23:17:59'),(50,3,'2022-03-16 23:17:09','Điều',200,10,5000,1,NULL,100,'','2022-03-16 23:17:59');
/*!40000 ALTER TABLE `purchaseinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tamung`
--

DROP TABLE IF EXISTS `tamung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tamung` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `CustomerId` int(11) DEFAULT NULL,
  `Money` float DEFAULT NULL,
  `Note` varchar(500) DEFAULT NULL,
  `Payed` int(11) DEFAULT '0' COMMENT '0: chưa trả; 1: đã trả',
  `PaidDate` datetime DEFAULT NULL COMMENT 'Ngày thu hồi nợ',
  PRIMARY KEY (`Id`),
  KEY `fk_tamung_khachhang_idx` (`CustomerId`),
  CONSTRAINT `fk_tamung_khachhang` FOREIGN KEY (`CustomerId`) REFERENCES `customerinfo` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='Lưu thông tin các tạm ứng của khách, để cuối tháng tính tổng tiền, rồi trừ khoản tạm ứng này';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tamung`
--

LOCK TABLES `tamung` WRITE;
/*!40000 ALTER TABLE `tamung` DISABLE KEYS */;
INSERT INTO `tamung` VALUES (2,'2022-03-10 08:28:07',1,2000000,'Tạm ứng trước',0,NULL),(3,'2022-03-15 14:59:58',1,350000000,'tạm ứng trước',0,NULL),(4,'2022-03-16 21:47:34',1,10000000,'Ứng  trước',1,'2022-03-16 22:27:04'),(5,'2022-03-16 23:17:33',3,50000000,'Ung truoc',1,'2022-03-16 23:17:59');
/*!40000 ALTER TABLE `tamung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `useraccount` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(500) DEFAULT NULL,
  `Password` varchar(500) DEFAULT NULL,
  `Role` varchar(45) DEFAULT '2' COMMENT '1-Admin\n2-Operator',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,'admin','ALy+BCmEhR4=','1'),(2,'operator','ZdLzpGoY6XI=','2');
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'dulieuthumua'
--
/*!50003 DROP PROCEDURE IF EXISTS `spCustomerInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spCustomerInsert`(in _name nvarchar(200), in phone nvarchar(20), in address nvarchar(500))
BEGIN
insert into customerinfo (`Name`,`Phone`,`Address`) values(_name,phone,address);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCustomerSelectAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spCustomerSelectAll`()
BEGIN
select * from customerinfo where IsActived = 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCustomerSelectById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spCustomerSelectById`(in _id int)
BEGIN
select * from customerinfo where Id = _id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCustomerUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spCustomerUpdate`(in _id int, in _name nvarchar(200),in _phone nvarchar(20),in _address nvarchar(500),in _isActived int)
BEGIN
update customerinfo set Name = _name,Phone=_phone,Address=_address,IsActived = _isActived where Id=_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPriceGetLatestPrice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceGetLatestPrice`(in _type nvarchar(45))
BEGIN
select * from priceinfo where Type = _type order by CreatedDate desc limit 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPriceInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceInsert`(in _createdDate datetime,in _type nvarchar(45), in _price float, in _note nvarchar(500))
BEGIN
insert into priceinfo (`CreatedDate`,`Type`,`Price`,`Note`) values (_createdDate,_type,_price,_note);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPriceSelectAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceSelectAll`()
BEGIN
select * from priceinfo order by Id desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPriceSelectById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceSelectById`(in _id int)
BEGIN
select * from priceinfo where Id = _id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPriceUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceUpdate`(in _id int, in _createdDate datetime, in __price float, in _note nvarchar(500))
BEGIN
update priceinfo set CreatedDate = _createdDate, Price = _price, Note = _note where Id = _id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPurchaseInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPurchaseInsert`(
		in customerId int,
		in _type nvarchar(20), 
		in weight float,
		in priceId int,
		in price float,
		in payNow bit,
		in muType bit,
		in degree float,
		in note nvarchar(500)
	 )
BEGIN
insert into purchaseinfo (
`CustomerId`,`Type`,`Weight`,`PriceId`,`Price`,`PayNow`,`MuType`,`Degree`,`Note`)
 values (customerId,_type, weight, priceId, price, payNow, muType, degree,note);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPurchaseSelectAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPurchaseSelectAll`()
BEGIN
select 
	pur.Id Id,
	pur.CustomerId ,
	cus.Phone ,
	cus.Address,
	cus.Name,
	pur.CreatedDate,
	pur.Type,
	pur.Weight,
	pur.PriceId,
	pur.Price,
	pur.PayNow,
	pur.MuType,
	case when pur.MuType = 1
	then "Mủ chén"
	when pur.MuType = 0
	then "Không phải mủ chén"
	else ""
	end MuTypeName,
	pur.Degree,
	pur.Note,
	pur.PaidDate
 from purchaseinfo pur inner join customerinfo cus on pur.CustomerId = cus.Id 
where Date(pur.CreatedDate) = curdate()
order by pur.Id desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPurchaseUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPurchaseUpdate`(in _id int, _sodo int)
BEGIN
	update purchaseinfo set Degree = _sodo where id = _id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spTamUngInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTamUngInsert`(in _customerId int, in _money float,in _note nvarchar(500))
BEGIN
insert into tamung (`CustomerId`,`Money`,`Note`) values (_customerId,_money,_note);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-16 23:25:09
