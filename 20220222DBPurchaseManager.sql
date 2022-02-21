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
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerinfo`
--

LOCK TABLES `customerinfo` WRITE;
/*!40000 ALTER TABLE `customerinfo` DISABLE KEYS */;
INSERT INTO `customerinfo` VALUES (1,'Nguyễn Văn A','0909123456','Hồ Chí Minh','2022-02-21 11:29:25'),(2,'Nguyễn Văn B','0909123457','Bình Dương','2022-02-21 11:29:55'),(3,'Nguyễn Văn C','0909123458','Bình Phước','2022-02-21 11:30:33'),(4,'Nguyễn Văn B','0909123459','Bình Phước','2022-02-21 11:31:21'),(5,'Nguyễn Văn D','0909123459','Bình Phước','2022-02-21 11:49:13');
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
  `DateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT 'số độ của mủ cao su, chỉ dùng choi trường hợp mủ cao su không phải mủ chén',
  `Type` varchar(45) NOT NULL COMMENT 'co 2 loai,  "Cao su" "Dieu"',
  `Price` float NOT NULL,
  `Note` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priceinfo`
--

LOCK TABLES `priceinfo` WRITE;
/*!40000 ALTER TABLE `priceinfo` DISABLE KEYS */;
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
  `CustomerName` varchar(100) DEFAULT NULL,
  `CustomerPhone` varchar(45) DEFAULT NULL,
  `CustomerAdd` varchar(200) DEFAULT NULL,
  `Datetime` datetime DEFAULT CURRENT_TIMESTAMP,
  `PurchaseType` varchar(45) NOT NULL COMMENT 'Có 2 loại thu mua là: "Cao su"'' "Dieu"',
  `Weight` float DEFAULT NULL,
  `PriceId` int(11) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `PayNow` bit(1) DEFAULT b'0' COMMENT '1- Thanh toán ngay\n0-Thanh toán cuối tháng\nMặc định là 0',
  `MuType` bit(1) DEFAULT b'0' COMMENT 'Chỉ dùngcho đơn hàng là mủ cao su.\n1- mủ chén\n0- không phải mủ chén',
  `Degree` float DEFAULT NULL COMMENT 'Chỉ dùngcho đơn hàng là mủ cao su.\n1- mủ chén\nChỉ mủ loại này mới có số độ: 0- không phải mủ chén',
  `Note` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='lưu thông tin tất cả các đơn hàng thu mua, lưu ý có đơn hàng trả tiên ngày và đơn hàng cuối tháng mới thanh toán';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseinfo`
--

LOCK TABLES `purchaseinfo` WRITE;
/*!40000 ALTER TABLE `purchaseinfo` DISABLE KEYS */;
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
  `Datetime` datetime DEFAULT NULL,
  `CustomerId` int(11) DEFAULT NULL,
  `CustomerName` varchar(500) DEFAULT NULL,
  `CustomerPhone` varchar(45) DEFAULT NULL,
  `Money` float DEFAULT NULL,
  `Note` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Lưu thông tin các tạm ứng của khách, để cuối tháng tính tổng tiền, rồi trừ khoản tạm ứng này';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tamung`
--

LOCK TABLES `tamung` WRITE;
/*!40000 ALTER TABLE `tamung` DISABLE KEYS */;
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
INSERT INTO `useraccount` VALUES (1,'admin','admin','1'),(2,'operator','12345','2');
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-22  6:05:42
