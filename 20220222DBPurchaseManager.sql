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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerinfo`
--

LOCK TABLES `customerinfo` WRITE;
/*!40000 ALTER TABLE `customerinfo` DISABLE KEYS */;
INSERT INTO `customerinfo` VALUES (1,'Nguyễn Văn A','0909123456','Hồ Chí Minh','2022-02-21 11:29:25',1),(2,'Nguyễn Văn Binh','0909123457','Bình Dương','2022-02-21 11:29:55',0),(3,'Nguyễn Văn C','0909123458','Bình Phước','2022-02-21 11:30:33',1),(4,'Nguyễn Văn B','0909123459','Bình Phước','2022-02-21 11:31:21',1),(5,'Nguyễn Văn Hùng','0934567899','Bình Long, Bình Phước','2022-02-21 11:49:13',1),(6,'Trần Văn Cảnh','0987655433','Dĩ An, Bình Dương','2022-02-23 21:22:15',1),(7,'Nguyễn Thị Tuyết','0909789654','Thủy Châu, Bình Phước','2022-02-23 21:26:27',1),(8,'ádfasdfsad','090889q','Bình Dương','2022-02-24 09:39:38',1),(9,'nguyen sdfasd','09089','Binh Duong','2022-02-24 11:13:19',1),(10,'ttt','9898','55','2022-02-24 11:16:13',0),(11,'dfsaf','dfsdf','asdfsadf','2022-02-24 11:52:00',1),(12,'aa','09091787666','Di An','2022-02-24 11:52:03',0),(13,'sdfdf','sfdsdf','dfsfdsdf','2022-02-28 08:27:44',1),(14,'Tran Van Teo','0331231239','HCM','2022-03-21 10:15:40',1),(15,'Tuấn','0909123456','BD','2022-03-21 11:53:07',1);
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
  `MuType` int(11) NOT NULL DEFAULT '0' COMMENT 'chỉ dùng cho mủ cao su\n\n0- mủ nước\n1- mủ chén\n2-mủ dây\n\n0-1 dùng chung giá\n2 dùng giá riêng',
  PRIMARY KEY (`id`,`MuType`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priceinfo`
--

LOCK TABLES `priceinfo` WRITE;
/*!40000 ALTER TABLE `priceinfo` DISABLE KEYS */;
INSERT INTO `priceinfo` VALUES (1,'2021-02-21 10:00:00','Cao su',100,'Test',0),(2,'2022-02-21 10:01:00','Cao su',105,'Test',0),(3,'2022-02-21 11:01:00','Điều',200,'Test',0),(4,'2022-02-21 11:10:00','Điều',234,'Test',0),(5,'2022-02-23 11:32:43','Cao su',150,'aaaaaaa',0),(6,'2022-02-23 11:32:43','Điều',250,'Điều',0),(7,'2022-02-24 21:57:28','Cao su',123,'',0),(8,'2022-02-24 21:57:28','Điều',234,'',0),(9,'2022-02-28 08:26:37','Cao su',2000,'qwqw',0),(10,'2022-02-28 08:26:37','Điều',5000,'qwqw',0),(11,'2022-03-15 22:26:16','Cao su',3000,'',0),(12,'2022-03-15 22:26:16','Dieu',4000,'',0),(13,'2022-03-16 09:01:39','Cao su',3500,'',0),(14,'2022-03-16 09:01:39','Dieu',5500,'',0),(15,'2022-03-16 09:02:00','Cao su',3500,'',0),(16,'2022-03-16 09:02:00','Dieu',5000,'',0),(17,'2022-03-21 10:20:53','Cao su',3600,'',0),(18,'2022-03-21 10:20:53','Dieu',5500,'',0),(19,'2022-03-21 10:21:27','Cao su',3600,'',0),(20,'2022-03-21 10:21:27','Dieu',5000,'',0),(21,'2022-03-21 11:47:41','Điều',6000,'',0),(22,'2022-03-21 11:52:08','Cao su',4000,'',0),(23,'2022-03-21 11:52:40','Điều',5500,'',0),(24,'2022-03-24 14:04:35','Cao su',4500,'abc',0),(25,'2022-03-24 14:04:49','Điều',6000,'dfggfg',0),(26,'2022-05-12 09:42:22','Cao su',5000,'mủ dây',2),(27,'2022-05-12 09:45:26','Cao su',5900,'[Mủ dây] abcd',2),(28,'2022-05-12 09:46:00','Cao su',6000,'',0),(29,'2022-05-12 09:46:15','Điều',6100,'',0),(30,'2022-05-12 10:37:49','Cao su',6500,'[Mủ dây] ',2),(31,'2022-05-13 13:46:49','Cao su',6300,'[Mủ dây] ',2);
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
  `Actived` int(11) DEFAULT '1' COMMENT '1-đang hoạt động\n0-đơn hàng đã xóa',
  PRIMARY KEY (`Id`),
  KEY `fk_purchase_customer_idx` (`CustomerId`),
  CONSTRAINT `fk_purchase_customer` FOREIGN KEY (`CustomerId`) REFERENCES `customerinfo` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8 COMMENT='lưu thông tin tất cả các đơn hàng thu mua, lưu ý có đơn hàng trả tiên ngày và đơn hàng cuối tháng mới thanh toán';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseinfo`
--

LOCK TABLES `purchaseinfo` WRITE;
/*!40000 ALTER TABLE `purchaseinfo` DISABLE KEYS */;
INSERT INTO `purchaseinfo` VALUES (1,3,'2022-02-28 09:40:26','Cao su',100,0,10000,1,1,0,'Test','2022-03-16 12:00:00',1),(2,3,'2022-02-28 09:41:55','Cao su',10,0,1000,1,1,0,'',NULL,1),(3,5,'2022-02-28 09:44:05','Điều',100,0,1000,1,1,0,'',NULL,1),(4,5,'2022-02-28 09:44:39','Điều',100,0,1000,1,1,0,'',NULL,1),(5,3,'2022-02-28 09:45:35','Cao su',123,0,333,1,1,0,'',NULL,1),(6,1,'2022-02-28 09:47:10','Cao su',1,0,1,1,1,0,'Test',NULL,1),(7,1,'2022-02-28 09:50:13','Cao su',10,0,10000,1,0,10,'',NULL,1),(8,3,'2022-02-28 09:54:51','Cao su',15,0,10000,1,0,10,'',NULL,1),(9,1,'2022-02-28 09:55:56','Cao su',10,9,2000,0,0,10,'',NULL,1),(10,1,'2022-02-28 09:56:07','Cao su',10,0,10000,1,0,10,'',NULL,1),(11,1,'2022-02-28 10:02:35','Cao su',250,0,5000,1,1,0,'',NULL,1),(12,1,'2022-02-28 10:20:35','Cao su',100,9,2000,0,1,0,'',NULL,1),(13,1,'2022-03-04 09:52:22','Cao su',1000,0,2000,1,0,12,'',NULL,1),(14,1,'2022-03-04 09:53:40','Cao su',1000,0,2000,1,0,50,'',NULL,1),(15,1,'2022-03-04 09:57:38','Cao su',100,0,1000,1,0,32,'',NULL,1),(16,1,'2022-03-04 11:44:29','Cao su',120,0,123,1,0,21,'Test',NULL,1),(17,1,'2022-03-04 11:45:23','Cao su',10,9,2000,0,0,10,'',NULL,1),(18,1,'2022-03-04 11:46:05','Cao su',10,9,2000,0,0,10,'',NULL,1),(19,1,'2022-03-04 11:46:10','Cao su',10,0,123,1,0,10,'',NULL,1),(20,1,'2022-03-04 11:51:55','Cao su',10,0,10000,1,0,10,'',NULL,1),(21,1,'2022-03-04 11:57:27','Cao su',10,0,10000,1,0,20,'',NULL,1),(22,1,'2022-03-04 12:58:05','Cao su',100,0,1000,1,0,10,'',NULL,1),(23,1,'2022-03-04 13:01:17','Cao su',100,0,1000,1,0,10,'',NULL,1),(24,7,'2022-03-04 13:03:57','Cao su',200,0,200,1,0,20,'',NULL,1),(25,5,'2022-03-04 13:04:46','Điều',5000,0,200,1,0,20,'',NULL,1),(26,6,'2022-03-04 13:05:40','Cao su',5000,0,200,1,1,20,'',NULL,1),(27,4,'2022-03-04 13:09:43','Cao su',200,0,1000,1,0,100,'',NULL,1),(28,5,'2022-03-04 13:10:07','Điều',200,0,1000,1,0,100,'',NULL,1),(29,1,'2022-03-04 21:16:05','Cao su',1000,0,5000,1,0,33,'',NULL,1),(30,7,'2022-03-04 21:21:35','Cao su',1000.93,0,1000,1,0,12,'',NULL,1),(32,4,'2022-03-05 07:37:17','Cao su',1000,0,2000,1,0,22,'',NULL,1),(33,1,'2022-03-07 06:51:10','Điều',1000,0,2000,1,0,0,'',NULL,1),(34,1,'2022-03-10 08:46:37','Cao su',100,0,123,1,0,20,'',NULL,1),(35,1,'2022-03-14 16:49:17','Điều',100,10,5000,0,0,0,'Điều',NULL,1),(36,1,'2022-03-15 09:36:31','Cao su',1000,9,2000,0,1,0,'Ts',NULL,1),(37,1,'2022-03-15 09:36:46','Cao su',1000,9,2000,0,0,10,'Ts',NULL,1),(38,1,'2022-03-15 09:38:36','Điều',1000,10,5000,0,0,0,'',NULL,1),(39,1,'2022-03-15 09:44:18','Điều',1000,10,5000,0,NULL,0,'',NULL,1),(40,1,'2022-03-15 09:44:35','Cao su',1000,9,2000,0,0,100,'',NULL,1),(41,1,'2022-03-15 13:35:02','Cao su',1000,9,2000,0,0,100,'',NULL,1),(42,1,'2022-03-15 13:35:15','Điều',2000,10,5000,0,NULL,100,'',NULL,1),(43,1,'2022-03-15 14:58:13','Cao su',500,9,2000,0,0,100,'',NULL,1),(44,1,'2022-03-15 22:27:07','Cao su',3000,11,3000,0,1,0,'',NULL,1),(45,1,'2022-03-15 22:27:15','Điều',2500,10,5000,0,NULL,0,'',NULL,1),(46,1,'2022-03-16 09:05:03','Cao su',1000,15,3500,1,1,0,'','2022-03-16 22:27:04',1),(47,1,'2022-03-16 09:05:10','Điều',500,10,5000,1,NULL,0,'','2022-03-16 22:27:04',1),(48,1,'2022-03-16 09:05:23','Cao su',200,15,3500,1,0,100,'','2022-03-16 22:27:04',1),(49,3,'2022-03-16 23:16:58','Cao su',100,15,3500,1,0,100,'','2022-03-16 23:17:59',1),(50,3,'2022-03-16 23:17:09','Điều',200,10,5000,1,NULL,100,'','2022-03-16 23:17:59',1),(51,1,'2022-03-20 11:28:40','Cao su',1000,15,3500,0,0,100,'',NULL,1),(52,1,'2022-03-21 09:45:35','Cao su',100,15,3500,0,0,10,'',NULL,1),(53,1,'2022-03-21 10:05:51','Cao su',100,0,3500,1,0,10,'',NULL,1),(54,15,'2022-03-21 11:53:31','Cao su',3000,22,4000,0,0,100,'',NULL,1),(55,15,'2022-03-24 09:57:06','Cao su',1000,22,4000,1,NULL,0,'1','2022-03-24 14:59:24',1),(56,15,'2022-03-24 09:59:36','Cao su',100,22,4000,1,0,100,'','2022-03-24 14:59:24',1),(57,15,'2022-03-24 10:00:00','Cao su',100,0,10000,1,NULL,0,'',NULL,1),(58,15,'2022-03-24 10:03:56','Cao su',100,0,4000,1,0,10,'',NULL,1),(59,15,'2022-03-24 10:04:24','Điều',100,0,5500,1,NULL,0,'',NULL,1),(60,15,'2022-03-24 10:08:47','Cao su',100,0,4000,1,0,100,'[Thanh toán ngay] ttt',NULL,1),(61,15,'2022-03-24 10:09:23','Điều',200,0,5500,1,NULL,0,'[Thanh toán ngay] fgfg',NULL,1),(62,15,'2022-03-28 11:32:57','Cao su',100,0,4500,1,0,100,'[Thanh toán ngay] ',NULL,1),(63,15,'2022-04-01 09:54:02','Cao su',100,0,5000,1,0,550,'[Thanh toán ngay] trả thẳng',NULL,1),(64,15,'2022-04-01 09:58:40','Cao su',200,0,4500,1,0,205,'[Thanh toán ngay] trả thẳng',NULL,1),(65,15,'2022-04-01 09:59:24','Cao su',150,0,6000,1,1,0,'[Thanh toán ngay] fgdgf',NULL,1),(66,15,'2022-04-01 10:01:14','Cao su',200,0,10000,1,1,0,'[Thanh toán ngay] ',NULL,1),(67,15,'2022-04-01 10:05:34','Cao su',50,0,4500,1,0,600,'[Thanh toán ngay] ',NULL,1),(68,15,'2022-04-01 10:07:19','Cao su',500,0,10000,1,1,0,'[Thanh toán ngay] ',NULL,1),(69,15,'2022-04-01 10:08:43','Cao su',100,24,4500,1,0,600,'','2022-04-01 10:27:04',1),(70,15,'2022-04-01 10:08:54','Cao su',200,24,4500,1,1,0,'','2022-04-01 10:27:04',1),(71,15,'2022-04-01 10:09:13','Điều',100,0,6000,1,NULL,0,'[Thanh toán ngay] ',NULL,1),(72,15,'2022-04-01 10:09:33','Điều',200,25,6000,1,NULL,0,'','2022-04-01 10:27:04',1),(73,15,'2022-04-01 10:36:34','Cao su',200,24,4500,1,0,500,'','2022-04-01 10:45:57',1),(74,15,'2022-04-01 10:36:43','Cao su',100,24,4500,1,0,400,'','2022-04-01 10:45:57',1),(75,15,'2022-04-01 10:56:59','Cao su',100,24,4500,1,0,600,'','2022-04-01 10:57:22',1),(76,15,'2022-04-01 10:57:06','Điều',100,25,6000,1,NULL,0,'','2022-04-01 10:57:22',1),(77,15,'2022-04-01 10:57:11','Cao su',500,24,4500,1,1,0,'','2022-04-01 10:57:22',1),(78,15,'2022-04-01 10:59:34','Cao su',400,24,4500,1,0,300,'','2022-04-01 10:59:58',1),(79,15,'2022-04-01 11:01:15','Điều',400,25,6000,1,NULL,0,'','2022-04-01 11:01:42',1),(80,15,'2022-04-01 13:02:55','Cao su',100,0,4500,1,0,300,'[Thanh toán ngay] ',NULL,1),(81,15,'2022-05-12 10:21:26','Cao su',100.5,28,6000,0,1,0,'mu day',NULL,1),(82,15,'2022-05-12 10:22:54','Cao su',100,28,6000,0,0,10,'',NULL,1),(83,15,'2022-05-12 10:23:05','Cao su',10,28,6000,0,1,0,'',NULL,1),(84,15,'2022-05-12 10:23:28','Cao su',100,28,6000,0,1,0,'',NULL,1),(85,15,'2022-05-12 10:23:42','Cao su',100,0,6000,1,1,0,'[Thanh toán ngay] ',NULL,1),(86,15,'2022-05-12 10:29:27','Cao su',100,0,5900,1,2,0,'[Thanh toán ngay] ',NULL,1),(87,15,'2022-05-12 10:33:53','Cao su',100,0,5900,1,2,0,'[Thanh toán ngay] ',NULL,1),(88,15,'2022-05-12 10:37:31','Cao su',2000.5,0,5900,1,2,0,'[Thanh toán ngay] ',NULL,1),(89,15,'2022-05-12 10:38:18','Cao su',5000,30,6500,0,2,0,'',NULL,1),(90,15,'2022-05-13 09:50:53','Cao su',200.6,28,6000,0,0,90,'',NULL,0),(91,15,'2022-05-13 10:51:33','Cao su',200.3,28,6000,0,1,0,'',NULL,0),(92,15,'2022-05-13 10:51:43','Cao su',150.3,30,6500,0,2,0,'',NULL,0),(93,15,'2022-05-13 10:51:59','Điều',400,29,6100,1,NULL,0,'','2022-05-13 13:48:35',1),(94,15,'2022-05-13 11:16:36','Cao su',232,30,6500,0,2,0,'',NULL,0),(95,15,'2022-05-13 13:46:22','Cao su',252.5,30,6500,1,2,0,'','2022-05-13 13:48:35',1),(96,15,'2022-05-13 13:46:33','Điều',242.3,29,6100,1,NULL,0,'','2022-05-13 13:48:35',1),(97,15,'2022-05-13 13:47:24','Cao su',222,0,6300,1,2,0,'[Thanh toán ngay] ',NULL,1),(98,4,'2022-05-19 09:29:24','Cao su',500,28,6000,1,0,100,'','2022-05-19 09:46:40',1),(99,15,'2022-05-19 09:29:35','Cao su',200,31,6300,1,2,0,'','2022-05-19 09:51:18',1),(100,4,'2022-05-19 09:29:52','Điều',300,29,6100,1,NULL,0,'','2022-05-19 09:46:40',1),(101,15,'2022-05-19 09:30:19','Cao su',400,28,6000,1,1,0,'','2022-05-19 09:51:18',1),(102,3,'2022-05-19 09:32:54','Cao su',100,28,6000,0,0,1000,'',NULL,1),(103,15,'2022-05-19 10:10:03','Cao su',300,28,6000,1,0,300,'','2022-05-19 10:10:38',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='Lưu thông tin các tạm ứng của khách, để cuối tháng tính tổng tiền, rồi trừ khoản tạm ứng này';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tamung`
--

LOCK TABLES `tamung` WRITE;
/*!40000 ALTER TABLE `tamung` DISABLE KEYS */;
INSERT INTO `tamung` VALUES (2,'2022-03-10 08:28:07',1,2000000,'Tạm ứng trước',0,NULL),(3,'2022-03-15 14:59:58',1,350000000,'tạm ứng trước',0,NULL),(4,'2022-03-16 21:47:34',1,10000000,'Ứng  trước',1,'2022-03-16 22:27:04'),(5,'2022-03-16 23:17:33',3,50000000,'Ung truoc',1,'2022-03-16 23:17:59'),(6,'2022-04-01 10:59:43',15,10000000,'',1,'2022-04-01 10:59:58'),(7,'2022-04-01 11:01:21',15,1000000,'',1,'2022-04-01 11:01:42'),(8,'2022-05-19 09:28:57',1,1000000,'',0,NULL),(9,'2022-05-19 09:30:05',4,2000000,'',1,'2022-05-19 09:46:40'),(10,'2022-05-19 09:33:06',3,10000000,'',0,NULL),(11,'2022-05-19 09:50:55',15,1000000,'',1,'2022-05-19 09:51:18'),(12,'2022-05-19 10:10:18',15,1500000,'',1,'2022-05-19 10:10:38');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,'admin','ALy+BCmEhR4=','1'),(2,'operator','ZdLzpGoY6XI=','2'),(3,'operator1','Z+qPmosQ0GQ=','2'),(4,'operator2','Z+qPmosQ0GQ=','2');
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
select * from customerinfo where IsActived = 1 order by Id desc;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceGetLatestPrice`(in _type nvarchar(45), _mutype int)
BEGIN
select * from priceinfo where Type = _type and MuType =_mutype order by CreatedDate desc limit 1;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPriceInsert`(in _createdDate datetime,in _type nvarchar(45), in _price float, in _note nvarchar(500), in _muType int)
BEGIN
insert into priceinfo (`CreatedDate`,`Type`,`Price`,`Note`,`MuType`) values (_createdDate,_type,_price,_note,_muType);
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
select * from priceinfo where year(CreatedDate) = year(curdate())  order by Id desc;
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
		in muType int,
		in degree float,
		in note nvarchar(500)
	 )
BEGIN
insert into purchaseinfo (
`CustomerId`,`Type`,`Weight`,`PriceId`,`Price`,`PayNow`,`MuType`,`Degree`,`Note`)
 values (customerId,_type, weight, priceId, price, payNow, muType, degree,
		CASE 
			WHEN payNow = 1 THEN concat('[Thanh toán ngay] ',note)
			ELSE note
		END
		);
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
	case 
	when pur.MuType = 2
	 then "Mủ dây"
	when pur.MuType = 1
	 then "Mủ chén"
	when pur.MuType = 0
	 then "Mủ nước"
	else ""
	end MuTypeName,
	pur.Degree,
	pur.Note,
	pur.PaidDate
 from purchaseinfo pur inner join customerinfo cus on pur.CustomerId = cus.Id 
where Date(pur.CreatedDate) = curdate() and Actived = 1
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

-- Dump completed on 2022-05-19 10:14:30
