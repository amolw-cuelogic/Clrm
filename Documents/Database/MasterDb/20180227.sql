CREATE DATABASE  IF NOT EXISTS `CuelogicResourceManagement` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `CuelogicResourceManagement`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: CuelogicResourceManagement
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
-- Table structure for table `Allocation`
--

DROP TABLE IF EXISTS `Allocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Allocation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeId` int(11) NOT NULL,
  `ProjectRoleId` int(11) NOT NULL,
  `ProjectId` int(11) NOT NULL,
  `IsBillable` bit(1) NOT NULL,
  `PercentageAllocation` int(11) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ProjectRole_idx` (`ProjectRoleId`),
  KEY `Project_idx` (`ProjectId`),
  KEY `Employee_idx` (`EmployeeId`),
  KEY `AllocationCreatedBy_Employee` (`CreatedBy`),
  KEY `AllocationUpdatedBy_Employee` (`UpdatedBy`),
  CONSTRAINT `AllocationCreatedBy_Employee` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `AllocationUpdatedBy_Employee` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Employee` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Project` FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ProjectRole` FOREIGN KEY (`ProjectRoleId`) REFERENCES `MasterProjectRole` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Allocation`
--

LOCK TABLES `Allocation` WRITE;
/*!40000 ALTER TABLE `Allocation` DISABLE KEYS */;
/*!40000 ALTER TABLE `Allocation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employee`
--

DROP TABLE IF EXISTS `Employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Employee` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(150) NOT NULL,
  `MiddleName` varchar(150) DEFAULT NULL,
  `LastName` varchar(150) NOT NULL,
  `OrgEmpId` varchar(50) NOT NULL,
  `JoiningDate` date NOT NULL,
  `LeavingDate` date DEFAULT NULL,
  `ContactNum` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `EmployeeUpdatedBy_Employee` (`UpdatedBy`),
  KEY `EmployeeCreatedByBy_Employee` (`CreatedBy`),
  CONSTRAINT `EmployeeCreatedByBy_Employee` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `EmployeeUpdatedBy_Employee` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES (1,'John','H','Doe','CUE555','2018-02-27','2018-02-27','9876543210','john.doe@cuelogic.com','\0',1,'2018-02-02',1,'2018-02-27'),(2,'Vivek','','Phadke','CUE001','2018-02-02','2018-02-02','9595519028','amol.wabale@cuelogic.com','',1,'2018-02-03',2,'2018-02-26'),(3,'John','','doe','cue123','2018-02-01',NULL,'123','john@cuelogic.com','',1,'2018-02-02',1,'2018-02-23'),(4,'John f','','Doe','Cue123','2018-02-01',NULL,'12345678','john@cuelogic.com','',1,'2018-02-23',1,'2018-02-23'),(5,'tnhjfg','fghj','fghj','fghjfg','2018-02-23',NULL,'3476345','asdnkjas@wed.wed','',1,'2018-02-23',1,'2018-02-23'),(6,'Amol','Maruti','Wabale','CUE335','2018-01-02',NULL,'9595519028','amol.wabale@cuelogic.com','',1,'2018-02-23',1,'2018-02-23'),(7,'Amol','Maruti','Wabale','CUE335','2018-01-02',NULL,'9595519028','amol.wabale@cuelogic.com','',1,'2018-02-23',NULL,NULL),(8,'Dummy','Dummy','Dummy','Dummy','2018-02-16',NULL,'995454','amol.wabale@cuelogic.com','\0',1,'2018-02-23',1,'2018-02-23'),(9,'fgh','','fg','fgh','2018-02-01',NULL,'4545','gh@edgrf.er','\0',1,'2018-02-26',2,'2018-02-26'),(10,'John','H','Doe','CUE555','2018-02-27','2018-02-27','9876543210','john.doe@cuelogic.com','',1,'2018-02-27',NULL,NULL),(11,'John','H','Doe','CUE555','2018-02-27','2018-02-27','9876543210','john.doe@cuelogic.com','',1,'2018-02-27',NULL,NULL),(12,'John','H','Doe','CUE555','2018-02-27','2018-02-27','9876543210','john.doe@cuelogic.com','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `Employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmployeeDepartment`
--

DROP TABLE IF EXISTS `EmployeeDepartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EmployeeDepartment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentId` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_DepartmentId_idx` (`DepartmentId`),
  KEY `Id_EmployeeId_idx` (`EmployeeId`),
  KEY `Id_DepartmentId_idx1` (`DepartmentId`),
  KEY `EmployeeDepartmentCreatedBy_Employee` (`CreatedBy`),
  KEY `EmployeeDepartmentUpdatedBy_Employee` (`UpdatedBy`),
  CONSTRAINT `EmployeeDepartmentCreatedBy_Employee` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `EmployeeDepartmentUpdatedBy_Employee` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Id_DepartmentId_` FOREIGN KEY (`DepartmentId`) REFERENCES `MasterDepartment` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Id_EmployeeId1` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeDepartment`
--

LOCK TABLES `EmployeeDepartment` WRITE;
/*!40000 ALTER TABLE `EmployeeDepartment` DISABLE KEYS */;
INSERT INTO `EmployeeDepartment` VALUES (1,1,1,'',1,'2018-02-23',1,'2018-02-27'),(2,3,1,'',1,'2018-02-23',1,'2018-02-23'),(3,1,1,'',1,'2018-02-23',1,'2018-02-23'),(4,1,1,'',1,'2018-02-23',NULL,NULL),(5,2,1,'',1,'2018-02-23',1,'2018-02-23'),(6,3,1,'\0',1,'2018-02-23',1,'2018-02-23'),(7,4,1,'',1,'2018-02-23',NULL,NULL),(8,1,8,'',1,'2018-02-23',NULL,NULL),(9,2,8,'',1,'2018-02-23',NULL,NULL),(10,3,8,'',1,'2018-02-23',NULL,NULL),(11,1,10,'',1,'2018-02-27',NULL,NULL),(12,1,11,'',1,'2018-02-27',NULL,NULL),(13,1,12,'',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `EmployeeDepartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmployeeOrganizationRole`
--

DROP TABLE IF EXISTS `EmployeeOrganizationRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EmployeeOrganizationRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeId` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ID_RoleId_idx` (`RoleId`),
  KEY `Id_EmployeeId_idx` (`EmployeeId`),
  KEY `CreatedBy_Employee_Id` (`CreatedBy`),
  KEY `UpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `CreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Id_EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Id_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `MasterOrganizationRole` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeOrganizationRole`
--

LOCK TABLES `EmployeeOrganizationRole` WRITE;
/*!40000 ALTER TABLE `EmployeeOrganizationRole` DISABLE KEYS */;
INSERT INTO `EmployeeOrganizationRole` VALUES (1,1,1,'',1,'2018-02-23',1,'2018-02-27'),(2,1,2,'',1,'2018-02-23',1,'2018-02-23'),(3,1,3,'\0',1,'2018-02-23',1,'2018-02-23'),(4,1,5,'',1,'2018-02-23',NULL,NULL),(5,8,3,'',1,'2018-02-23',NULL,NULL),(6,8,4,'',1,'2018-02-23',NULL,NULL),(7,10,1,'',1,'2018-02-27',NULL,NULL),(8,11,1,'',1,'2018-02-27',NULL,NULL),(9,12,1,'',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `EmployeeOrganizationRole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmployeeSkill`
--

DROP TABLE IF EXISTS `EmployeeSkill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EmployeeSkill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeId` int(11) NOT NULL,
  `SkillId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Employee_idx` (`EmployeeId`),
  KEY `MasterSkill_EmployeeSkill` (`SkillId`),
  KEY `EmployeeSkillCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `EmployeeSkillUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `EmployeeSkillCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `EmployeeSkillUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Employee_EmployeeSkill` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterSkill_EmployeeSkill` FOREIGN KEY (`SkillId`) REFERENCES `MasterSkill` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeSkill`
--

LOCK TABLES `EmployeeSkill` WRITE;
/*!40000 ALTER TABLE `EmployeeSkill` DISABLE KEYS */;
INSERT INTO `EmployeeSkill` VALUES (1,1,1,'',1,'2018-02-23',2,'2018-02-26'),(2,1,2,'',1,'2018-02-23',NULL,NULL),(3,1,3,'',1,'2018-02-23',NULL,NULL),(4,1,9,'\0',1,'2018-02-23',1,'2018-02-23'),(7,8,1,'',1,'2018-02-23',NULL,NULL),(8,8,2,'',1,'2018-02-23',NULL,NULL),(9,8,3,'',1,'2018-02-23',NULL,NULL),(10,8,4,'',1,'2018-02-23',NULL,NULL),(11,8,5,'',1,'2018-02-23',NULL,NULL),(12,8,6,'\0',1,'2018-02-23',1,'2018-02-23'),(13,8,7,'',1,'2018-02-23',NULL,NULL),(14,8,8,'',1,'2018-02-23',NULL,NULL),(15,6,6,'',1,'2018-02-23',NULL,NULL),(16,4,1,'',1,'2018-02-23',NULL,NULL),(17,4,2,'',1,'2018-02-23',NULL,NULL),(18,4,3,'',1,'2018-02-23',NULL,NULL),(19,4,4,'',1,'2018-02-23',NULL,NULL),(20,4,5,'',1,'2018-02-23',NULL,NULL),(21,1,5,'',2,'2018-02-26',NULL,NULL),(22,1,6,'\0',2,'2018-02-26',2,'2018-02-26'),(23,10,1,'',1,'2018-02-27',NULL,NULL),(24,11,1,'',1,'2018-02-27',NULL,NULL),(25,12,1,'',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `EmployeeSkill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityEmployeeGroup`
--

DROP TABLE IF EXISTS `IdentityEmployeeGroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityEmployeeGroup` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeId` int(11) NOT NULL,
  `GroupId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdentityEmployeeGroup_Employee` (`EmployeeId`),
  KEY `IdentityEmployeeGroup_IdentityGroup` (`GroupId`),
  KEY `IdentityEmployeeGroupCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityEmployeeGroupUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityEmployeeGroupCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityEmployeeGroupUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityEmployeeGroup_Employee` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityEmployeeGroup_IdentityGroup` FOREIGN KEY (`GroupId`) REFERENCES `IdentityGroup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityEmployeeGroup`
--

LOCK TABLES `IdentityEmployeeGroup` WRITE;
/*!40000 ALTER TABLE `IdentityEmployeeGroup` DISABLE KEYS */;
INSERT INTO `IdentityEmployeeGroup` VALUES (1,1,1,'',1,'2018-02-23',1,'2018-02-27'),(2,1,65,'\0',1,'2018-02-23',1,'2018-02-23'),(3,1,74,'\0',1,'2018-02-23',1,'2018-02-23'),(4,1,66,'',1,'2018-02-23',NULL,NULL),(5,1,67,'\0',1,'2018-02-23',1,'2018-02-23'),(6,8,1,'',1,'2018-02-23',NULL,NULL),(7,8,70,'',1,'2018-02-23',NULL,NULL),(8,8,71,'',1,'2018-02-23',NULL,NULL),(9,10,1,'',1,'2018-02-27',NULL,NULL),(10,11,1,'',1,'2018-02-27',NULL,NULL),(11,12,1,'',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `IdentityEmployeeGroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityGroup`
--

DROP TABLE IF EXISTS `IdentityGroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityGroup` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(150) NOT NULL,
  `GroupDescription` varchar(500) DEFAULT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdentityGroupUpdatedBy_Employee_Id` (`UpdatedBy`),
  KEY `IdentityGroupCreatedBy_Employee_Id` (`CreatedBy`),
  CONSTRAINT `IdentityGroupCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroup`
--

LOCK TABLES `IdentityGroup` WRITE;
/*!40000 ALTER TABLE `IdentityGroup` DISABLE KEYS */;
INSERT INTO `IdentityGroup` VALUES (1,'Super Admin','Super Admin','\0',1,'2018-02-05',1,'2018-02-27'),(61,'Admin','admin','\0',1,'2018-02-14',1,'2018-02-19'),(62,'Admin','Admin','\0',1,'2018-02-06',1,'2018-02-19'),(63,'Staff','Staff','\0',1,'2018-03-06',NULL,NULL),(64,'User','User','\0',1,'2018-02-07',NULL,NULL),(65,'Employee','Employee','',1,'2018-02-08',NULL,NULL),(66,'Hr','Hr','',1,'2018-02-10',NULL,NULL),(67,'Sales','Sales','',1,'2018-02-12',NULL,NULL),(68,'Delivery','Delivery','\0',1,'2017-10-06',NULL,NULL),(69,'Non Technical','Non Technical','',1,'2018-03-14',NULL,NULL),(70,'Infrastructure','Infrastructure','',1,'2018-02-21',NULL,NULL),(71,'Hardware','Hardware','',1,'2018-02-28',NULL,NULL),(72,'Interior','Interior','',1,'2018-01-01',NULL,NULL),(73,'Admin','Admin','',1,'2018-02-06',NULL,NULL),(74,'Staff','Staff','',1,'2018-03-06',NULL,NULL),(75,'User','User','',1,'2018-02-07',NULL,NULL),(76,'Employee','Employee','',1,'2018-02-08',NULL,NULL),(77,'Hr','Hr','',1,'2018-02-10',NULL,NULL),(78,'Sales','Sales','',1,'2018-02-12',NULL,NULL),(79,'Delivery','Delivery','',1,'2017-10-06',NULL,NULL),(80,'Non Technical','Non Technical','',1,'2018-03-14',NULL,NULL),(81,'Infrastructure','Infrastructure','',1,'2018-02-21',NULL,NULL),(82,'Hardware','Hardware','',1,'2018-02-28',NULL,NULL),(83,'Interior','Interior','',1,'2018-01-01',NULL,NULL),(84,'adsas','asdasd','\0',1,'2018-02-15',NULL,NULL),(85,'we','we','\0',1,'2018-02-15',NULL,NULL),(86,'ty','ty','\0',1,'2018-02-19',NULL,NULL),(87,'hjkh','jhjkhj','',1,'2018-02-19',1,'2018-02-19'),(88,'DUMMY','DUMMY','',1,'2018-02-23',1,'2018-02-23'),(89,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(90,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(91,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(92,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(93,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(94,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(95,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(96,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(97,'Super Admin','Super Admin','',1,'2018-02-26',NULL,NULL),(98,'Super Admin','Super Admin','',1,'2018-02-27',NULL,NULL),(99,'Super Admin','Super Admin','',1,'2018-02-27',NULL,NULL),(100,'Super Admin','Super Admin','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `IdentityGroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityGroupRight`
--

DROP TABLE IF EXISTS `IdentityGroupRight`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityGroupRight` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupId` int(11) NOT NULL,
  `RightId` int(11) NOT NULL,
  `Action` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdentityGroupRight_IdentityRight` (`RightId`),
  KEY `IdentityGroupRight_IdentityGroup` (`GroupId`),
  KEY `IdentityGroupRightCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityGroupRightUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityGroupRightCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupRightUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupRight_IdentityGroup` FOREIGN KEY (`GroupId`) REFERENCES `IdentityGroup` (`Id`),
  CONSTRAINT `IdentityGroupRight_IdentityRight` FOREIGN KEY (`RightId`) REFERENCES `IdentityRight` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroupRight`
--

LOCK TABLES `IdentityGroupRight` WRITE;
/*!40000 ALTER TABLE `IdentityGroupRight` DISABLE KEYS */;
INSERT INTO `IdentityGroupRight` VALUES (1,1,1,7,'\0',1,'2018-02-02',1,'2018-02-27'),(14,1,2,7,'\0',1,'2018-02-02',1,'2018-02-27'),(15,1,3,7,'\0',1,'2018-02-02',1,'2018-02-27'),(28,61,1,6,'\0',1,'2018-02-14',1,'2018-02-19'),(29,61,2,6,'\0',1,'2018-02-14',1,'2018-02-19'),(30,61,3,6,'\0',1,'2018-02-14',1,'2018-02-19'),(31,84,1,6,'\0',1,'2018-02-15',NULL,NULL),(32,84,2,6,'\0',1,'2018-02-15',NULL,NULL),(33,84,3,4,'\0',1,'2018-02-15',NULL,NULL),(34,85,1,4,'\0',1,'2018-02-15',NULL,NULL),(35,85,2,4,'\0',1,'2018-02-15',NULL,NULL),(36,85,3,4,'\0',1,'2018-02-15',NULL,NULL),(37,86,1,4,'\0',1,'2018-02-19',NULL,NULL),(38,86,2,4,'\0',1,'2018-02-19',NULL,NULL),(39,86,3,6,'\0',1,'2018-02-19',NULL,NULL),(40,87,1,4,'\0',1,'2018-02-19',1,'2018-02-19'),(41,87,2,4,'\0',1,'2018-02-19',1,'2018-02-19'),(42,87,3,6,'\0',1,'2018-02-19',1,'2018-02-19'),(43,88,1,7,'\0',1,'2018-02-23',1,'2018-02-23'),(44,88,2,5,'\0',1,'2018-02-23',1,'2018-02-23'),(45,88,3,0,'\0',1,'2018-02-23',1,'2018-02-23'),(46,89,1,7,'\0',1,'2018-02-26',NULL,NULL),(47,89,2,7,'\0',1,'2018-02-26',NULL,NULL),(48,89,3,7,'\0',1,'2018-02-26',NULL,NULL),(49,90,1,7,'\0',1,'2018-02-26',NULL,NULL),(50,90,2,7,'\0',1,'2018-02-26',NULL,NULL),(51,90,3,7,'\0',1,'2018-02-26',NULL,NULL),(52,91,1,7,'\0',1,'2018-02-26',NULL,NULL),(53,91,2,7,'\0',1,'2018-02-26',NULL,NULL),(54,91,3,7,'\0',1,'2018-02-26',NULL,NULL),(55,92,1,7,'\0',1,'2018-02-26',NULL,NULL),(56,92,2,7,'\0',1,'2018-02-26',NULL,NULL),(57,92,3,7,'\0',1,'2018-02-26',NULL,NULL),(58,93,1,7,'\0',1,'2018-02-26',NULL,NULL),(59,93,2,7,'\0',1,'2018-02-26',NULL,NULL),(60,93,3,7,'\0',1,'2018-02-26',NULL,NULL),(61,94,1,7,'\0',1,'2018-02-26',NULL,NULL),(62,94,2,7,'\0',1,'2018-02-26',NULL,NULL),(63,94,3,7,'\0',1,'2018-02-26',NULL,NULL),(64,95,1,7,'\0',1,'2018-02-26',NULL,NULL),(65,95,2,7,'\0',1,'2018-02-26',NULL,NULL),(66,95,3,7,'\0',1,'2018-02-26',NULL,NULL),(67,96,1,7,'\0',1,'2018-02-26',NULL,NULL),(68,96,2,7,'\0',1,'2018-02-26',NULL,NULL),(69,96,3,7,'\0',1,'2018-02-26',NULL,NULL),(70,97,1,7,'\0',1,'2018-02-26',NULL,NULL),(71,97,2,7,'\0',1,'2018-02-26',NULL,NULL),(72,97,3,7,'\0',1,'2018-02-26',NULL,NULL),(73,98,1,7,'\0',1,'2018-02-27',NULL,NULL),(74,98,2,7,'\0',1,'2018-02-27',NULL,NULL),(75,98,3,7,'\0',1,'2018-02-27',NULL,NULL),(76,99,1,7,'\0',1,'2018-02-27',NULL,NULL),(77,99,2,7,'\0',1,'2018-02-27',NULL,NULL),(78,99,3,7,'\0',1,'2018-02-27',NULL,NULL),(79,100,1,7,'\0',1,'2018-02-27',NULL,NULL),(80,100,2,7,'\0',1,'2018-02-27',NULL,NULL),(81,100,3,7,'\0',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `IdentityGroupRight` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityRight`
--

DROP TABLE IF EXISTS `IdentityRight`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityRight` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RightTitle` varchar(150) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdentityRightCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityRightUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityRightCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityRightUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityRight`
--

LOCK TABLES `IdentityRight` WRITE;
/*!40000 ALTER TABLE `IdentityRight` DISABLE KEYS */;
INSERT INTO `IdentityRight` VALUES (1,'Group','',1,'2018-02-02',NULL,NULL),(2,'User Group','',1,'2018-02-03',NULL,NULL),(3,'Employee','',1,'2018-02-03',NULL,NULL);
/*!40000 ALTER TABLE `IdentityRight` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterClient`
--

DROP TABLE IF EXISTS `MasterClient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterClient` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClientName` varchar(200) NOT NULL,
  `ClientLocation` varchar(200) DEFAULT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterClientCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterClientUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterClientCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterClientUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterClient`
--

LOCK TABLES `MasterClient` WRITE;
/*!40000 ALTER TABLE `MasterClient` DISABLE KEYS */;
INSERT INTO `MasterClient` VALUES (1,'Microsoft','USA','\0',2,'2018-02-26',1,'2018-02-27'),(2,'Oracle','','',2,'2018-02-26',2,'2018-02-26'),(3,'Hadoop','','',2,'2018-02-26',2,'2018-02-26'),(4,'Microsoft','USA','',1,'2018-02-26',1,'2018-02-26'),(5,'Microsoft','USA','',1,'2018-02-27',1,'2018-02-27'),(6,'Microsoft','USA','',1,'2018-02-27',1,'2018-02-27'),(7,'Microsoft','USA','',1,'2018-02-27',1,'2018-02-27');
/*!40000 ALTER TABLE `MasterClient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterDepartment`
--

DROP TABLE IF EXISTS `MasterDepartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterDepartment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentName` varchar(150) NOT NULL,
  `DepartmentHead` varchar(150) DEFAULT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterDepartmentCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterDepartmentUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterDepartmentCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterDepartmentUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterDepartment`
--

LOCK TABLES `MasterDepartment` WRITE;
/*!40000 ALTER TABLE `MasterDepartment` DISABLE KEYS */;
INSERT INTO `MasterDepartment` VALUES (1,'Unit Test Department','Unit Test Department Head','\0',1,'2010-01-01',1,'2018-02-27'),(2,'HR','Uma Ramani','',1,'2018-02-16',1,'2018-02-23'),(3,'Sales','Neel Vartikar','',1,'2018-02-16',1,'2018-02-23'),(4,'Research & Development','Vikrant Labde','',1,'2018-02-19',1,'2018-02-23'),(5,'Accounts','Ganesh','\0',1,'2018-02-19',1,'2018-02-19'),(6,'SAa','aSa','\0',1,'2018-02-19',1,'2018-02-19'),(7,'78','78','\0',1,'2018-02-19',1,'2018-02-19'),(8,'Unit Test Department','Unit Test Department Head','',1,'2018-02-26',NULL,NULL),(9,'Unit Test Department','Unit Test Department Head','',1,'2018-02-26',NULL,NULL),(10,'Unit Test Department','Unit Test Department Head','',1,'2018-02-26',NULL,NULL),(11,'Unit Test Department','Unit Test Department Head','',1,'2018-02-26',NULL,NULL),(12,'Unit Test Department','Unit Test Department Head','',1,'2018-02-26',NULL,NULL),(13,'Unit Test Department','Unit Test Department Head','',1,'2018-02-27',NULL,NULL),(14,'Unit Test Department','Unit Test Department Head','',1,'2018-02-27',NULL,NULL),(15,'Unit Test Department','Unit Test Department Head','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `MasterDepartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterOrganizationRole`
--

DROP TABLE IF EXISTS `MasterOrganizationRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterOrganizationRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Role` varchar(150) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterOrganizationRoleCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterOrganizationRoleUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterOrganizationRoleCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterOrganizationRoleUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterOrganizationRole`
--

LOCK TABLES `MasterOrganizationRole` WRITE;
/*!40000 ALTER TABLE `MasterOrganizationRole` DISABLE KEYS */;
INSERT INTO `MasterOrganizationRole` VALUES (1,'Unit Test Engineer','\0',1,'2018-02-19',1,'2018-02-27'),(2,'Sr Principle Developer','',1,'2018-02-19',1,'2018-02-19'),(3,'Devops','',1,'2018-02-19',1,'2018-02-19'),(4,'Sr Software engineer','',1,'2018-02-19',1,'2018-02-19'),(5,'R&D Engineer','',1,'2018-02-19',1,'2018-02-19'),(6,'asa','',1,'2018-02-19',1,'2018-02-19'),(7,'Principle developer','',1,'2018-02-26',NULL,NULL),(8,'sd','',1,'2018-02-26',NULL,NULL),(9,'SDSD','',1,'2018-02-26',1,'2018-02-26'),(10,'Unit Test Engineer','',1,'2018-02-26',NULL,NULL),(11,'Unit Test Engineer','',1,'2018-02-26',NULL,NULL),(12,'Unit Test Engineer','',1,'2018-02-26',NULL,NULL),(13,'Unit Test Engineer','',1,'2018-02-26',NULL,NULL),(14,'Unit Test Engineer','',1,'2018-02-27',NULL,NULL),(15,'Unit Test Engineer','',1,'2018-02-27',NULL,NULL),(16,'Unit Test Engineer','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `MasterOrganizationRole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterProjectRole`
--

DROP TABLE IF EXISTS `MasterProjectRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterProjectRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Role` varchar(50) NOT NULL,
  `Costing` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterProjectRoleCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterProjectRoleUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterProjectRoleCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterProjectRoleUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectRole`
--

LOCK TABLES `MasterProjectRole` WRITE;
/*!40000 ALTER TABLE `MasterProjectRole` DISABLE KEYS */;
INSERT INTO `MasterProjectRole` VALUES (1,'Unit Test Engineer',0,'\0',1,'2018-02-26',1,'2018-02-27'),(2,'tyryry',56565656,'',2,'2018-02-26',2,'2018-02-26'),(3,'jk,k,',67,'',2,'2018-02-26',2,'2018-02-26'),(4,'Unit Test Engineer',0,'',1,'2018-02-26',1,'2018-02-26'),(5,'Unit Test Engineer',0,'',1,'2018-02-26',1,'2018-02-26'),(6,'Unit Test Engineer',0,'',1,'2018-02-26',1,'2018-02-26'),(7,'Unit Test Engineer',0,'',1,'2018-02-27',1,'2018-02-27'),(8,'Unit Test Engineer',0,'',1,'2018-02-27',1,'2018-02-27'),(9,'Unit Test Engineer',0,'',1,'2018-02-27',1,'2018-02-27');
/*!40000 ALTER TABLE `MasterProjectRole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterProjectType`
--

DROP TABLE IF EXISTS `MasterProjectType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterProjectType` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(150) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterProjectTypeCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterProjectTypeUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterProjectTypeCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterProjectTypeUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectType`
--

LOCK TABLES `MasterProjectType` WRITE;
/*!40000 ALTER TABLE `MasterProjectType` DISABLE KEYS */;
INSERT INTO `MasterProjectType` VALUES (1,'Unit Test Billable Project','\0',2,'2018-02-26',1,'2018-02-27'),(2,'gjgkh','',2,'2018-02-26',2,'2018-02-26'),(3,'Unit Test Billable Project','',1,'2018-02-26',1,'2018-02-26'),(4,'Unit Test Billable Project','',1,'2018-02-26',1,'2018-02-26'),(5,'Unit Test Billable Project','',1,'2018-02-27',1,'2018-02-27'),(6,'Unit Test Billable Project','',1,'2018-02-27',1,'2018-02-27'),(7,'Unit Test Billable Project','',1,'2018-02-27',1,'2018-02-27');
/*!40000 ALTER TABLE `MasterProjectType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterSkill`
--

DROP TABLE IF EXISTS `MasterSkill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterSkill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Skill` varchar(100) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterSkillCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `MasterSkillUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `MasterSkillCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `MasterSkillUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterSkill`
--

LOCK TABLES `MasterSkill` WRITE;
/*!40000 ALTER TABLE `MasterSkill` DISABLE KEYS */;
INSERT INTO `MasterSkill` VALUES (1,'Unit Test','\0',1,'2018-02-19',1,'2018-02-27'),(2,'c#','',1,'2018-02-19',1,'2018-02-20'),(3,'Html','',1,'2018-02-19',1,'2018-02-19'),(4,'Jquery','',1,'2018-02-21',NULL,NULL),(5,'LINQ','',1,'2018-02-21',NULL,NULL),(6,'SQL','',1,'2018-02-21',NULL,NULL),(7,'AngularJS','',1,'2018-02-21',NULL,NULL),(8,'Angular 2','',1,'2018-02-21',1,'2018-02-26'),(9,'Angular 4','',1,'2018-02-21',NULL,NULL),(10,'Entity Framework','',1,'2018-02-21',NULL,NULL),(11,'PHP','',1,'2018-02-21',NULL,NULL),(12,'Ruby On Rails','',1,'2018-02-21',NULL,NULL),(13,'Web Api','',1,'2018-02-21',NULL,NULL),(14,'Scala','',1,'2018-02-21',NULL,NULL),(15,'Unit Test','',1,'2018-02-26',NULL,NULL),(16,'Unit Test','',1,'2018-02-26',NULL,NULL),(17,'Unit Test','',1,'2018-02-26',NULL,NULL),(18,'Unit Test','',1,'2018-02-26',NULL,NULL),(19,'Unit Test','',1,'2018-02-26',NULL,NULL),(20,'Unit Test','',1,'2018-02-26',NULL,NULL),(21,'Unit Test','',1,'2018-02-26',NULL,NULL),(22,'Unit Test','',1,'2018-02-27',NULL,NULL),(23,'Unit Test','',1,'2018-02-27',NULL,NULL),(24,'Unit Test','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `MasterSkill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Project`
--

DROP TABLE IF EXISTS `Project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Project` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectName` varchar(500) NOT NULL,
  `ProjectTypeId` int(11) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `IsComplete` bit(1) DEFAULT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Project_MasterProjectType` (`ProjectTypeId`),
  KEY `ProjectCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `ProjectUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `ProjectCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `ProjectUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Project_MasterProjectType` FOREIGN KEY (`ProjectTypeId`) REFERENCES `MasterProjectType` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Project`
--

LOCK TABLES `Project` WRITE;
/*!40000 ALTER TABLE `Project` DISABLE KEYS */;
INSERT INTO `Project` VALUES (1,'Test Project',1,'2018-02-27',NULL,'Test Project Description','\0','\0',1,'2018-02-27',1,'2018-02-27'),(2,'Test Project',1,'2018-02-27',NULL,'Test Project Description','\0','',1,'2018-02-27',NULL,NULL),(3,'Test Project',1,'2018-02-27',NULL,'Test Project Description','\0','',1,'2018-02-27',NULL,NULL),(4,'Test Project',1,'2018-02-27',NULL,'Test Project Description','\0','',1,'2018-02-27',NULL,NULL),(5,'Test Project',1,'2018-02-27',NULL,'Test Project Description','\0','',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `Project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProjectClient`
--

DROP TABLE IF EXISTS `ProjectClient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ProjectClient` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClientId` int(11) NOT NULL,
  `ProjectId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ClientProject_Project` (`ProjectId`),
  KEY `ClientProject_MasterClient` (`ClientId`),
  KEY `ProjectClientCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `ProjectClientUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `ClientProject_MasterClient` FOREIGN KEY (`ClientId`) REFERENCES `MasterClient` (`Id`),
  CONSTRAINT `ClientProject_Project` FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`),
  CONSTRAINT `ProjectClientCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `ProjectClientUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProjectClient`
--

LOCK TABLES `ProjectClient` WRITE;
/*!40000 ALTER TABLE `ProjectClient` DISABLE KEYS */;
INSERT INTO `ProjectClient` VALUES (1,1,1,'',1,'2018-02-27',1,'2018-02-27'),(2,1,5,'',1,'2018-02-27',NULL,NULL);
/*!40000 ALTER TABLE `ProjectClient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'CuelogicResourceManagement'
--

--
-- Dumping routines for database 'CuelogicResourceManagement'
--
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeDepartment_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeDepartment_BulkAddOrUpdate`(
	IN xmlText text,
    IN userId int(11)
)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE employeeDepartmentId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterDepartmentId INT(11);
    DECLARE isDepartmentValid BIT;
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfEmployeeDepartment/EmployeeDepartment)');
		WHILE i <= nodeCount DO
		
			SET employeeDepartmentId = ExtractValue(xmlText, '/ArrayOfEmployeeDepartment/EmployeeDepartment[$i]/Id');
			SET masterEmployeeId = ExtractValue(xmlText, '/ArrayOfEmployeeDepartment/EmployeeDepartment[$i]/EmployeeId');
			SET masterDepartmentId = ExtractValue(xmlText, '/ArrayOfEmployeeDepartment/EmployeeDepartment[$i]/DepartmentId');
			SET isDepartmentValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfEmployeeDepartment/EmployeeDepartment[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
			
            INSERT INTO
				EmployeeDepartment
			(
				`Id`,
                `EmployeeId`,
                `DepartmentId`,
                `IsValid`,
                `CreatedBy`,
                `CreatedOn`
            )
            VALUES
            (
				employeeDepartmentId,
                masterEmployeeId,
                masterDepartmentId,
                isDepartmentValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d')
            )
            ON DUPLICATE KEY UPDATE
				
                UpdatedBy = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							DepartmentId <> masterDepartmentId OR
							IsValid <> isDepartmentValid )
							THEN userId 
							ELSE UpdatedBy 
							END,
                UpdatedOn = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							DepartmentId <> masterDepartmentId OR
							IsValid <> isDepartmentValid )
								
							THEN DATE_FORMAT(CURDATE(),'%Y-%m-%d') 
							ELSE UpdatedOn 
							END,
				EmployeeId = masterEmployeeId,
                DepartmentId = masterDepartmentId,
                IsValid = isDepartmentValid;
                      
		SET i = i+1;
		END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeGroup_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeGroup_BulkAddOrUpdate`(
	IN xmlText text,
    IN userId int(11)
)
BEGIN
DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE employeeGroupId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterGroupId INT(11);
    DECLARE isGroupValid BIT;
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup)');
		WHILE i <= nodeCount DO
		
			SET employeeGroupId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/Id');
			SET masterEmployeeId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/EmployeeId');
			SET masterGroupId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/GroupId');
			SET isGroupValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
			
            INSERT INTO
				IdentityEmployeeGroup
			(
				`Id`,
                `EmployeeId`,
                `GroupId`,
                `IsValid`,
                `CreatedBy`,
                `CreatedOn`
            )
            VALUES
            (
				employeeGroupId,
                masterEmployeeId,
                masterGroupId,
                isGroupValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d')
            )
            ON DUPLICATE KEY UPDATE
				
                UpdatedBy = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							GroupId <> masterGroupId OR
							IsValid <> isGroupValid )
							THEN userId 
							ELSE UpdatedBy 
							END,
                UpdatedOn = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							GroupId <> masterGroupId OR
							IsValid <> isGroupValid )
							THEN DATE_FORMAT(CURDATE(),'%Y-%m-%d') 
							ELSE UpdatedOn 
							END,
				EmployeeId = masterEmployeeId,
                GroupId = masterGroupId,
                IsValid = isGroupValid;
                      
		SET i = i+1;
		END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeOrganizationRole_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeOrganizationRole_BulkAddOrUpdate`(
	IN xmlText text,
    IN userId int(11)
)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE employeeOrgRoleId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterOrgRoleId INT(11);
    DECLARE isOrgRoleValid BIT;
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfEmployeeOrganizationRole/EmployeeOrganizationRole)');
	WHILE i <= nodeCount DO
	
		SET employeeOrgRoleId = ExtractValue(xmlText, '/ArrayOfEmployeeOrganizationRole/EmployeeOrganizationRole[$i]/Id');
		SET masterEmployeeId = ExtractValue(xmlText, '/ArrayOfEmployeeOrganizationRole/EmployeeOrganizationRole[$i]/EmployeeId');
		SET masterOrgRoleId = ExtractValue(xmlText, '/ArrayOfEmployeeOrganizationRole/EmployeeOrganizationRole[$i]/RoleId');
		SET isOrgRoleValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfEmployeeOrganizationRole/EmployeeOrganizationRole[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
		
		INSERT INTO
			EmployeeOrganizationRole
		(
			`Id`,
			`EmployeeId`,
			`RoleId`,
			`IsValid`,
			`CreatedBy`,
			`CreatedOn`
		)
		VALUES
		(
			employeeOrgRoleId,
			masterEmployeeId,
			masterOrgRoleId,
			isOrgRoleValid,
			userId,
			DATE_FORMAT(CURDATE(),'%Y-%m-%d')
		)
		ON DUPLICATE KEY UPDATE
			
			UpdatedBy = CASE WHEN 
						(EmployeeId <> masterEmployeeId OR
						RoleId <> masterOrgRoleId OR
						IsValid <> isOrgRoleValid )
						THEN userId 
						ELSE UpdatedBy 
						END,
			UpdatedOn = CASE WHEN 
						(EmployeeId <> masterEmployeeId OR
						RoleId <> masterOrgRoleId OR
						IsValid <> isOrgRoleValid )
						THEN DATE_FORMAT(CURDATE(),'%Y-%m-%d') 
						ELSE UpdatedOn 
						END,
			EmployeeId = masterEmployeeId,
			RoleId = masterOrgRoleId,
			IsValid = isOrgRoleValid;
								  
	
	SET i = i+1;
	END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeSkill_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeSkill_BulkAddOrUpdate`(
	IN xmlText text,
    IN userId int(11)
)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE employeeSkillId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterSkillId INT(11);
    DECLARE isSkillValid BIT;
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfEmployeeSkill/EmployeeSkill)');
		WHILE i <= nodeCount DO
		
			SET employeeSkillId = ExtractValue(xmlText, '/ArrayOfEmployeeSkill/EmployeeSkill[$i]/Id');
			SET masterEmployeeId = ExtractValue(xmlText, '/ArrayOfEmployeeSkill/EmployeeSkill[$i]/EmployeeId');
			SET masterSkillId = ExtractValue(xmlText, '/ArrayOfEmployeeSkill/EmployeeSkill[$i]/SkillId');
			SET isSkillValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfEmployeeSkill/EmployeeSkill[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
			
            INSERT INTO
				EmployeeSkill
			(
				`Id`,
                `EmployeeId`,
                `SkillId`,
                `IsValid`,
                `CreatedBy`,
                `CreatedOn`
            )
            VALUES
            (
				employeeSkillId,
                masterEmployeeId,
                masterSkillId,
                isSkillValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d')
            )
            ON DUPLICATE KEY UPDATE
				
                UpdatedBy = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							SkillId <> masterSkillId OR
							IsValid <> isSkillValid )
							THEN userId 
							ELSE UpdatedBy 
							END,
                UpdatedOn = CASE WHEN 
							(EmployeeId <> masterEmployeeId OR
							SkillId <> masterSkillId OR
							IsValid <> isSkillValid  )
								
							THEN DATE_FORMAT(CURDATE(),'%Y-%m-%d') 
							ELSE UpdatedOn 
							END,
				EmployeeId = masterEmployeeId,
                SkillId = masterSkillId,
                IsValid = isSkillValid;
                                      
		
		SET i = i+1;
		END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_AddOrUpdate`(
	IN employeeId int(11),
	IN firstName varchar(150),
    IN middleName varchar(150),
    IN lastName varchar(150),
    IN orgEmpId varchar(150),
    IN joiningDate varchar(50),
    IN leavingDate varchar(50),
    IN contactNum varchar(50),
    IN email varchar(50),
    IN isValid bit,
    IN updatedBy int(11),
    IN createdBy int(11),
    IN updatedOn varchar(50),
    IN createdOn varchar(50)
)
BEGIN
	INSERT INTO Employee 
    (
		`Id`,
		`FirstName`,
		`MiddleName`,
		`LastName`,
		`OrgEmpId`,
		`JoiningDate`,
		`LeavingDate`,
		`ContactNum`,
		`Email`,
		`IsValid`,
		`CreatedBy`,
        `CreatedOn`
	)
    VALUES
    (
		employeeId,
		firstName,
		middleName,
		lastName,
		orgEmpId,
		joiningDate,
		IF((leavingDate = ''), NULL,leavingDate),
		contactNum,
		email,
		isValid,
        createdBy,
        createdOn
    )
    ON DUPLICATE KEY UPDATE
		FirstName = firstName,
		MiddleName = middleName,
		LastName=lastName,
		OrgEmpId =orgEmpId,
		JoiningDate=joiningDate,
		LeavingDate = IF((leavingDate = ''), NULL,leavingDate),
		ContactNum = contactNum,
		Email =email,
		IsValid = isValid,
		UpdatedBy =updatedBy,
		UpdatedOn = updatedOn;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetByEmailId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetByEmailId`(IN EmailId varchar(100))
BEGIN
select * from Employee where Email = EmailId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetById`(IN employeeId int(11))
BEGIN

	SELECT
		a.Id,
		a.FirstName, 
		a.MiddleName,
		a.LastName,
		a.OrgEmpId,
		DATE_FORMAT(a.JoiningDate,'%Y/%m/%d') as JoiningDate,
		DATE_FORMAT(a.LeavingDate,'%Y/%m/%d') as LeavingDate,
		a.ContactNum,
		a.Email,
		a.IsValid,
		a.CreatedBy,
		a.CreatedOn,
		a.UpdatedBy,
		a.UpdatedOn,
        CONCAT(b.FirstName,' ',b.LastName) as CreatedByName,
        CONCAT(c.FirstName,' ',c.LastName) as UpdatedByName
	FROM
		Employee a
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id
	WHERE
		a.Id = employeeId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetChildValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetChildValidList`(
	IN masterEmployeeId INT(11)
)
BEGIN

	SELECT a.Id, a.EmployeeId, a.GroupId, a.IsValid, a.CreatedBy, 
    a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.GroupName 
    FROM IdentityEmployeeGroup a
    INNER JOIN
		IdentityGroup b ON a.GroupId = b.Id
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId;
    
	SELECT a.Id, a.EmployeeId, a.DepartmentId, a.IsValid, a.CreatedBy, 
    a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.DepartmentName  
    FROM EmployeeDepartment a
    INNER JOIN
		MasterDepartment b ON a.DepartmentId = b. Id
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId;
    
	SELECT a.Id, a.EmployeeId, a.SkillId, a.IsValid, a.CreatedBy, a.CreatedOn,
    a.UpdatedBy, a.UpdatedOn, b.Skill AS SkillName FROM EmployeeSkill  a 
    INNER JOIN
		MasterSkill b ON a.SkillId = b. Id
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId;
    
    SELECT a.Id, a.EmployeeId, a.RoleId, a.IsValid, a.CreatedBy, 
    a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.Role AS RoleName
    FROM EmployeeOrganizationRole a 
    INNER JOIN
		MasterOrganizationRole b ON a.RoleId = b. Id
	WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetLatestId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetLatestId`()
BEGIN
	SELECT MAX(Id) from Employee;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetList`(
IN filterText varchar(200), 
IN recordFrom int(4), 
IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		concat(a.FirstName, ' ',a.MiddleName, ' ',a.LastName) as FullName,
        a.OrgEmpId,
        DATE_FORMAT(a.JoiningDate,'%Y/%m/%d') as JoiningDate,
        a.Email,
		if(a.IsValid,'Yes','No') as IsValid,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		Employee a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.MiddleName like concat('%', filterText,'%') or
		a.FirstName like concat('%', filterText,'%') or
		a.LastName like concat('%', filterText,'%') or
        a.OrgEmpId like concat('%', filterText,'%') or
        a.JoiningDate like concat('%', filterText,'%') or
        a.Email like concat('%', filterText,'%') or
        a.IsValid = if(filterText = 'yes',true,false) or
		a.CreatedOn like concat('%', filterText,'%')
	limit 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetMasterValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetMasterValidList`()
BEGIN
	select * from IdentityGroup  where IsValid = true;
    select * from MasterDepartment where IsValid = true;
    select * from MasterSkill  where IsValid = true;
    select * from MasterOrganizationRole  where IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_MarkInvalid`(
	IN masterEmployeeId int(11)
)
BEGIN
	UPDATE Employee SET
		IsValid = false
	WHERE
		Id = masterEmployeeId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroupRight_BulkInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroupRight_BulkInsert`(IN xmltext text)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
	SET nodeCount = ExtractValue(xmltext, 'count(/ArrayOfIdentityGroupRight/IdentityGroupRight)');
	WHILE i <= nodeCount DO
		INSERT INTO IdentityGroupRight 
        (`GroupId`,`RightId`,`Action`,`IsValid`,`CreatedBy`,`CreatedOn`)
        VALUES
        (
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/GroupId'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/RightId'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Action'),
			IF(ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/IsValid') = 'true',1,0),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedBy'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedOn')
		);
        SET i = i+1;
	END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroupRight_BulkUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroupRight_BulkUpdate`(
	IN xmltext text
)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE identityGroupId INT(11);
    DECLARE identityGroupRightId INT(11);
    DECLARE identityGroupAction INT(11);
    DECLARE identityGroupIsValid BIT;
    DECLARE identityGroupUpdatedBy INT(11);
    
	SET nodeCount = ExtractValue(xmltext, 'count(/ArrayOfIdentityGroupRight/IdentityGroupRight)');
	WHILE i <= nodeCount DO
		
		SET identityGroupId = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Id');
		SET identityGroupRightId = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/RightId');
		SET identityGroupAction = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Action');
		SET identityGroupIsValid = CASE WHEN (ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
        SET identityGroupUpdatedBy = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/UpdatedBy');
        
		UPDATE IdentityGroupRight 
        SET
			RightId = identityGroupRightId,
            Action = identityGroupAction,
            IsValid = identityGroupIsValid,
            UpdatedBy = identityGroupUpdatedBy,
            UpdatedOn = DATE_FORMAT(CURDATE(),'%Y-%m-%d')
		WHERE 
			Id = identityGroupId 
        AND
			( 
				RightId <> identityGroupRightId OR
				Action <> identityGroupAction OR
				IsValid <> identityGroupIsValid 
            );
        SET i = i+1;
	END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroupRight_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroupRight_Get`(IN GroupId int(4))
BEGIN
select b.Id, b.GroupId, b.RightId, b.Action, b.IsValid, b.CreatedOn,
b.CreatedBy, b.UpdatedBy, b.UpdatedOn, a.RightTitle,
concat(c.FirstName, ' ', c.LastName) as CreatedByName,
concat(d.FirstName, ' ', d.LastName) as UpdatedByName from IdentityGroupRight b 
inner join IdentityRight a on a.Id = b.RightId
left join Employee c on b.CreatedBy = c.Id 
left join Employee d on b.UpdatedBy = d.Id 
where b.GroupId = GroupId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroup_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroup_Get`(IN GroupId int(4))
BEGIN
select a.Id, a.GroupName, a.GroupDescription,a.IsValid, a.CreatedOn, a.UpdatedOn, a.CreatedBy, a.UpdatedBy,
concat(b.FirstName, ' ', b.LastName) as CreatedByName,
concat(c.FirstName, ' ', c.LastName) as UpdatedByName
from IdentityGroup a 
inner join Employee b on a.CreatedBy = b.Id 
left join Employee c on a.UpdatedBy = c.Id 
where a.Id = GroupId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroup_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroup_GetList`(
IN FilterText varchar(200), 
IN RecordFrom int(4), 
IN RecordTill int(4)
)
BEGIN

SELECT a.Id, a.GroupName,a.GroupDescription,if(a.IsValid,'Yes','No') as IsValid,
concat(b.FirstName ,' ', b.LastName) as Name, 
DATE_FORMAT(a.CreatedOn,'%d/%m/%Y') as CreatedOn

FROM CuelogicResourceManagement.IdentityGroup a

inner join Employee b on a.CreatedBy = b.Id

where a.IsValid = if(FilterText = 'yes',true,false) or
a.GroupName like concat('%', FilterText,'%') or
a.GroupDescription like concat('%', FilterText,'%') or
b.FirstName like concat('%', FilterText,'%') or
b.LastName like concat('%', FilterText,'%') or
a.CreatedOn like concat('%', FilterText,'%')

limit RecordFrom, RecordTill;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroup_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroup_Insert`(
IN groupName VARCHAR(150),
IN groupDesc VARCHAR(500),
IN isValid BOOL,
IN createdBy INT(11),
IN createdOn VARCHAR(150)
)
BEGIN
	INSERT INTO IdentityGroup
    (`GroupName`,`GroupDescription`,`IsValid`,`CreatedBy`,`CreatedOn`)
    VALUES
    (groupName,groupDesc,isValid,createdBy,createdOn);
    select MAX(Id) as Id from IdentityGroup;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroup_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroup_MarkInvalid`(IN groupId int(11))
BEGIN

	UPDATE IdentityGroupRight SET
	IsValid = false
	WHERE GroupId = groupId;
    
	UPDATE IdentityGroup SET
	IsValid = false
	WHERE Id = groupId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroup_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroup_Update`(
IN GroupId int(11),
IN grpname VARCHAR(150),
IN groupdesc VARCHAR(500),
IN valid bit,
IN updatedby int(11),
IN updatedon date
)
BEGIN
update IdentityGroup set 
GroupName = grpname ,
`GroupDescription` = groupdesc,
`IsValid` = valid,
`UpdatedBy` = updatedby,
`UpdatedOn` = updatedon
where 
`Id` = GroupId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityRight_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityRight_Get`()
BEGIN
	SELECT * FROM IdentityRight;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_AddOrUpdate`(
	IN mcId int(11),
	IN mcClientName varchar(150),
    IN mcClientLocation varchar(150),
    IN mcIsValid bit,
    IN mcUpdatedBy int(11),
    IN mcCreatedBy int(11),
    IN mcUpdatedOn varchar(50),
    IN mcCreatedOn varchar(50)
)
BEGIN
INSERT INTO MasterClient
    (
		`Id`,
		`ClientName`,
        `ClientLocation`,
		`IsValid`,
		`CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
    (
		mcId,
		mcClientName,
        mcClientLocation,
		mcIsValid,
		mcCreatedBy,
        mcCreatedOn,
		mcCreatedBy, 
        mcCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		ClientName = mcClientName,
        ClientLocation = mcClientLocation,
		IsValid = mcIsValid,
		UpdatedBy = mcUpdatedBy,
		UpdatedOn = mcUpdatedOn;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_Get`(
	IN mcId int(11)
)
BEGIN
	SELECT 
		a.Id, 
		a.ClientName,
        a.ClientLocation,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterClient a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mcId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_GetList`(
	IN filterText varchar(200), 
	IN recordFrom int(4), 
	IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.ClientName,
        a.ClientLocation,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterClient a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(filterText = 'yes',true,false) or
		a.ClientName like concat('%', filterText,'%') or
        a.ClientLocation like concat('%', filterText,'%') or
        a.IsValid like concat('%', filterText,'%') or
		b.FirstName like concat('%', filterText,'%') or
		b.LastName like concat('%', filterText,'%') or
		a.CreatedOn like concat('%', filterText,'%')
	limit 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_MarkInvalid`(
	IN mcId int(11)
)
BEGIN
	
	UPDATE MasterClient SET
	IsValid = false
	WHERE Id = mcId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartment_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartment_Get`(IN MasterDepartmentId int(11))
BEGIN
	SELECT 
		a.Id, 
		a.DepartmentName, 
		a.DepartmentHead,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterDepartment a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = MasterDepartmentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartment_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartment_GetList`(
IN FilterText varchar(200), 
IN RecordFrom int(4), 
IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.DepartmentName,
		a.DepartmentHead,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterDepartment a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(FilterText = 'yes',true,false) or
		a.DepartmentName like concat('%', FilterText,'%') or
		a.DepartmentHead like concat('%', FilterText,'%') or
		b.FirstName like concat('%', FilterText,'%') or
		b.LastName like concat('%', FilterText,'%') or
		a.CreatedOn like concat('%', FilterText,'%')
	limit 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartment_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartment_Insert`(
	IN departmentName VARCHAR(150),
	IN departmentHead VARCHAR(500),
	IN isValid bit,
	IN createdBy int(11),
	IN createdOn date
)
BEGIN
	INSERT INTO MasterDepartment
		(`DepartmentName`,`DepartmentHead`,`IsValid`,`CreatedBy`,`CreatedOn`)
    VALUES
		(departmentName,departmentHead,isValid,createdBy,createdOn);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartment_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartment_MarkInvalid`(IN MasterDepartmentId int(11))
BEGIN

	UPDATE MasterDepartment SET
	IsValid = false
	WHERE Id = MasterDepartmentId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartment_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartment_Update`(
IN departmentId int(11),
IN departmentName VARCHAR(150),
IN departmentHead VARCHAR(500),
IN isValid bit,
IN updatedby int(11),
IN updatedon date
)
BEGIN

	UPDATE MasterDepartment 
    SET
		`DepartmentName` = departmentName,
		`DepartmentHead` = departmentHead,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = departmentId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterOrganizationRole_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterOrganizationRole_Get`(IN Id int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterOrganizationRole a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterOrganizationRole_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterOrganizationRole_GetList`(
IN FilterText varchar(200), 
IN RecordFrom int(4), 
IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterOrganizationRole a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(FilterText = 'yes',true,false) or
		a.Role like concat('%', FilterText,'%') or
		b.FirstName like concat('%', FilterText,'%') or
		b.LastName like concat('%', FilterText,'%') or
		a.CreatedOn like concat('%', FilterText,'%')
	limit 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterOrganizationRole_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterOrganizationRole_Insert`(	
	IN role VARCHAR(150),
	IN isValid bit,
	IN createdBy int(11),
	IN createdOn date
)
BEGIN
	INSERT INTO MasterOrganizationRole
		(`Role`,`IsValid`,`CreatedBy`,`CreatedOn`)
    VALUES
		(role,isValid,createdBy,createdOn);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterOrganizationRole_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterOrganizationRole_MarkInvalid`(
	IN MasterOrganizationRoleId int(11)
)
BEGIN
	
	UPDATE MasterOrganizationRole SET
	IsValid = false
	WHERE Id = MasterOrganizationRoleId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterOrganizationRole_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterOrganizationRole_Update`(
IN masterOrganizationRoleId int(11),
IN role VARCHAR(150),
IN isValid bit,
IN updatedby int(11),
IN updatedon date
)
BEGIN

	UPDATE MasterOrganizationRole 
    SET
		`Role` = role,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = masterOrganizationRoleId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectRole_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectRole_AddOrUpdate`(
	IN mpId int(11),
	IN mpRole varchar(150),
    IN mpCosting varchar(150),
    IN mpIsValid bit,
    IN mpUpdatedBy int(11),
    IN mpCreatedBy int(11),
    IN mpUpdatedOn varchar(50),
    IN mpCreatedOn varchar(50)
)
BEGIN
INSERT INTO MasterProjectRole 
    (
		`Id`,
		`Role`,
		`Costing`,
		`IsValid`,
		`CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
    (
		mpId,
		mpRole,
		mpCosting,
		mpIsValid,
		mpCreatedBy,
        mpCreatedOn,
		mpCreatedBy, 
        mpCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		Role = mpRole,
		Costing = mpCosting,
		IsValid = mpIsValid,
		UpdatedBy = mpUpdatedBy,
		UpdatedOn = mpUpdatedOn;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectRole_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectRole_Get`(IN mpId int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Role,
        a.Costing,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterProjectRole a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mpId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectRole_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectRole_GetList`(
IN filterText varchar(200), 
IN recordFrom int(4), 
IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Role,
        a.costing,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterProjectRole a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(filterText = 'yes',true,false) or
		a.Role like concat('%', filterText,'%') or
		b.FirstName like concat('%', filterText,'%') or
		b.LastName like concat('%', filterText,'%') or
		a.CreatedOn like concat('%', filterText,'%')
	limit 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectRole_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectRole_MarkInvalid`(
	IN masterProjectRoleId int(11)
)
BEGIN
	
	UPDATE MasterProjectRole SET
	IsValid = false
	WHERE Id = masterProjectRoleId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectType_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectType_AddOrUpdate`(
	IN mptId int(11),
	IN mptType varchar(150),
    IN mptIsValid bit,
    IN mptUpdatedBy int(11),
    IN mptCreatedBy int(11),
    IN mptUpdatedOn varchar(50),
    IN mptCreatedOn varchar(50)
)
BEGIN
INSERT INTO MasterProjectType 
    (
		`Id`,
		`Type`,
		`IsValid`,
		`CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
    (
		mptId,
		mptType,
		mptIsValid,
		mptCreatedBy,
        mptCreatedOn,
		mptCreatedBy, 
        mptCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		Type = mptType,
		IsValid = mptIsValid,
		UpdatedBy = mptUpdatedBy,
		UpdatedOn = mptUpdatedOn;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectType_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectType_Get`(
	IN mptId int(11)
)
BEGIN
	SELECT 
		a.Id, 
		a.Type,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterProjectType a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mptId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectType_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectType_GetList`(
	IN filterText varchar(200), 
	IN recordFrom int(4), 
	IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Type,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterProjectType a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(filterText = 'yes',true,false) or
		a.Type like concat('%', filterText,'%') or
		b.FirstName like concat('%', filterText,'%') or
		b.LastName like concat('%', filterText,'%') or
		a.CreatedOn like concat('%', filterText,'%')
	limit 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectType_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectType_MarkInvalid`(
	IN mptId int(11)
)
BEGIN
	
	UPDATE MasterProjectType SET
	IsValid = false
	WHERE Id = mptId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterSkill_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterSkill_Get`(IN MasterSkillId int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Skill,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) as CreatedByName,
		concat(c.FirstName, ' ', c.LastName) as UpdatedByName
	FROM 
		MasterSkill a 
	LEFT JOIN 
		Employee b on a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c on a.UpdatedBy = c.Id 
	WHERE 
		a.Id = MasterSkillId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterSkill_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterSkill_GetList`(
IN FilterText varchar(200), 
IN RecordFrom int(4), 
IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Skill,
		if(a.IsValid,'Yes','No') as IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') as CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') as UpdatedBy,
		concat(b.FirstName ,' ', b.LastName) as CreatedByName
	FROM 
		CuelogicResourceManagement.MasterSkill a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = if(FilterText = 'yes',true,false) or
		a.Skill like concat('%', FilterText,'%') or
		b.FirstName like concat('%', FilterText,'%') or
		b.LastName like concat('%', FilterText,'%') or
		a.CreatedOn like concat('%', FilterText,'%')
	limit 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterSkill_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterSkill_Insert`(	
	IN skill VARCHAR(150),
	IN isValid bit,
	IN createdBy int(11),
	IN createdOn date
)
BEGIN
	INSERT INTO MasterSkill
		(`Skill`,`IsValid`,`CreatedBy`,`CreatedOn`)
    VALUES
		(skill,isValid,createdBy,createdOn);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterSkill_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterSkill_MarkInvalid`(
	IN MasterSkillId int(11)
)
BEGIN
	
	UPDATE MasterSkill SET
	IsValid = false
	WHERE Id = MasterSkillId;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterSkill_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterSkill_Update`(
IN masterSkillId int(11),
IN skill VARCHAR(150),
IN isValid bit,
IN updatedby int(11),
IN updatedon date
)
BEGIN

	UPDATE MasterSkill 
    SET
		`Skill` = skill,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = masterSkillId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProjectClient_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProjectClient_BulkAddOrUpdate`(
	IN xmlText text,
    IN userId int(11)
)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE pcId INT(11);
    DECLARE pcProjectId INT(11);
    DECLARE pcClientId INT(11);
    DECLARE pcIsValid BIT;
    
    DECLARE nodePath VARCHAR(500);
    
    SET nodePath = '/ArrayOfProjectClient/ProjectClient';
    
	SET nodeCount = ExtractValue(xmlText, CONCAT('count(', nodePath ,')'));
		WHILE i <= nodeCount DO
		
			SET pcId = ExtractValue(xmlText, CONCAT(nodePath, '[$i]/Id'));
			SET pcProjectId = ExtractValue(xmlText, CONCAT(nodePath, '[$i]/ProjectId'));
			SET pcClientId = ExtractValue(xmlText, CONCAT(nodePath, '[$i]/ClientId'));
			SET pcIsValid = CASE WHEN (ExtractValue(xmlText, CONCAT(nodePath, '[$i]/IsValid')) = 'true') THEN 1 ELSE 0 END;
			
            INSERT INTO
				ProjectClient
			(
				`Id`,
                `ProjectId`,
                `ClientId`,
                `IsValid`,
                `CreatedBy`,
                `CreatedOn`
            )
            VALUES
            (
				pcId,
                pcProjectId,
                pcClientId,
                pcIsValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d')
            )
            ON DUPLICATE KEY UPDATE
				
                UpdatedBy = CASE WHEN 
							(ProjectId <> pcProjectId OR
							ClientId <> pcClientId OR
							IsValid <> pcIsValid  )
							THEN userId 
							ELSE UpdatedBy 
							END,
                UpdatedOn = CASE WHEN 
							(ProjectId <> pcProjectId OR
							ClientId <> pcClientId OR
							IsValid <> pcIsValid  )
								
							THEN DATE_FORMAT(CURDATE(),'%Y-%m-%d') 
							ELSE UpdatedOn 
							END,
				ProjectId = pcProjectId,
                ClientId = pcClientId,
                IsValid = pcIsValid;
                                      
		
		SET i = i+1;
		END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_AddOrUpdate`(
	IN pId INT(11),
    IN pProjectName VARCHAR(500),
    IN pProjectTypeId INT(11),
    IN pStartDate VARCHAR(50),
    IN pEndDate VARCHAR(50),
    IN pDescription VARCHAR(500),
    IN pIsComplete BIT,
    IN pIsValid BIT,
    IN pCreatedBy INT(11),
    IN pCreatedOn VARCHAR(50),
    IN pUpdatedBy INT(11),
    IN pUpdatedOn VARCHAR(50)
)
BEGIN
INSERT INTO Project 
    (
		`Id`,
		`ProjectName`,
		`ProjectTypeId`,
		`StartDate`,
        `EndDate`,
        `Description`,
        `IsComplete`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`
	)
    VALUES
    (
		pId,
		pProjectName,
		pProjectTypeId,
		pStartDate,
        IF((pEndDate = ''), NULL,pEndDate),
		pDescription, 
        pIsComplete,
        pIsValid,
        pCreatedBy,
        pCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		ProjectName = pProjectName,
		ProjectTypeId = pProjectTypeId,
		StartDate = IF((pStartDate = ''), NULL,pStartDate),
        EndDate = IF((pEndDate = ''), NULL,pEndDate),
        Description = pDescription,
        IsComplete = pIsComplete,
        IsValid = pIsValid,
        UpdatedBy = pUpdatedBy,
        UpdatedOn = pUpdatedOn;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_Get`(
	IN pId INT(11)
)
BEGIN
	SELECT
		a.Id,
        a.ProjectName,
        a.ProjectTypeId,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate,
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        a.Description,
        a.IsComplete,
        a.IsValid,
        a.CreatedBy,
        a.CreatedOn,
        a.UpdatedBy,
        a.UpdatedOn,
        CONCAT(b.FirstName,' ',b.LastName) as CreatedByName,
        CONCAT(c.FirstName,' ',c.LastName) as UpdatedByName
	FROM
		Project a
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_GetChildList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_GetChildList`(
	IN pId INT(11)
)
BEGIN
	SELECT a.Id, a.ClientId, a.ProjectId, a.IsValid, a. CreatedBy,
		a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.ClientName
	FROM 
		ProjectClient a
    INNER JOIN
		MasterClient b ON a.ClientId = b.Id
	WHERE 
		a.ProjectId = pProjectIdId;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_GetLatestId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_GetLatestId`()
BEGIN
	SELECT MAX(Id) from Project;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_GetList`(
IN filterText varchar(200), 
IN recordFrom int(4), 
IN recordTill int(4)
)
BEGIN
	SELECT
		a.Id, a.ProjectName, b.Type, d.ClientName, a.StartDate, a.EndDate,
        if(a.IsComplete,'Yes','No') as IsComplete,
        if(a.IsValid,'Yes','No') as IsValid
	FROM
		Project a
	INNER JOIN MasterProjectType b ON  a.ProjectTypeId = b.Id
    INNER JOIN ProjectClient c ON  a.Id = c.ProjectId
    INNER JOIN MasterClient d ON c.ClientId = d.Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_GetMasterList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_GetMasterList`()
BEGIN
	SELECT * FROM MasterClient WHERE IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_MarkInvalid`(
	IN pId INT(11)
)
BEGIN
	UPDATE Project SET
		IsValid = false
	WHERE
		Id = pId;
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

-- Dump completed on 2018-02-27 14:21:19
