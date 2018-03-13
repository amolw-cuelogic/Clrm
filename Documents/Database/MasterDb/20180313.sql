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
  KEY `Project_idx` (`ProjectId`),
  KEY `Employee_idx` (`EmployeeId`),
  KEY `AllocationCreatedBy_Employee` (`CreatedBy`),
  KEY `AllocationUpdatedBy_Employee` (`UpdatedBy`),
  KEY `projectrole_id` (`ProjectRoleId`),
  CONSTRAINT `AllocationCreatedBy_Employee` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `AllocationUpdatedBy_Employee` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `Employee` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Project` FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `projectrole_id` FOREIGN KEY (`ProjectRoleId`) REFERENCES `ProjectRole` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Allocation`
--

LOCK TABLES `Allocation` WRITE;
/*!40000 ALTER TABLE `Allocation` DISABLE KEYS */;
INSERT INTO `Allocation` VALUES (1,1,23,22,'',10,'2018-03-02',NULL,'',1,'2018-03-12',1,'2018-03-13'),(2,1,26,18,'',25,'2018-03-02',NULL,'\0',1,'2018-03-12',1,'2018-03-12'),(3,1,27,17,'',25,'2018-03-02',NULL,'',1,'2018-03-12',1,'2018-03-12'),(4,1,22,17,'\0',25,'2018-03-12',NULL,'',1,'2018-03-12',1,'2018-03-12'),(5,1,27,17,'',25,'2018-03-01',NULL,'',1,'2018-03-12',1,'2018-03-12'),(6,19,27,17,'',12,'2018-03-03',NULL,'',1,'2018-03-12',1,'2018-03-12'),(7,20,27,17,'',100,'2018-03-01',NULL,'',1,'2018-03-13',1,'2018-03-13');
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
  `LastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `EmployeeUpdatedBy_Employee` (`UpdatedBy`),
  KEY `EmployeeCreatedByBy_Employee` (`CreatedBy`),
  CONSTRAINT `EmployeeCreatedByBy_Employee` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `EmployeeUpdatedBy_Employee` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES (1,'Amol','Maruti','Wabale','CUE355','2018-02-28',NULL,'9876543210','amol.wabale@cuelogic.com','',1,'2018-02-02',1,'2018-03-13','2018-03-13 14:18:04'),(17,'Vivek','','Phadke','CUE238','2018-03-15',NULL,'987654321','vivek.phadke@cuelogic.co.in','',1,'2018-03-06',17,'2018-03-08',NULL),(18,'Pranav','Ravindra','Shinde','CUE672','2018-01-05',NULL,'7854123698','pranav.shinde@cuelogic.com','',1,'2018-03-06',1,'2018-03-09',NULL),(19,'Debujit','Shrikant','Suryavanshi','CUE295','2017-08-04',NULL,'8541235698','debujit.suryavanshi@cuelogic.com','',1,'2018-03-06',1,'2018-03-08',NULL),(20,'Pandurang','Tukaram','Deshpande','CUE674','2017-08-04',NULL,'8745121385784','panduranf.tukaram@cuelogic.com','',1,'2018-03-06',1,'2018-03-08',NULL),(21,'Bharat','','Puranik','CUE456','2018-02-21',NULL,'1234567895','bharat.puranik@cuelogic.com','',1,'2018-03-07',1,'2018-03-08',NULL),(27,'Amit','','Govil','CUE333','2018-03-08',NULL,'987654321','amit.govil@cuelogic.co.in','',1,'2018-03-08',1,'2018-03-08',NULL),(28,'Nikhil','','Babur','CUE0012','2018-03-08',NULL,'123456789','nikhil.babar@cuelogic.co.in','',1,'2018-03-08',1,'2018-03-12',NULL),(29,'gaurav','','mothe kadam','cue250','2016-08-17',NULL,'7848578544','gaurav.mothekadam@cuelogic.co.in','',17,'2018-03-08',17,'2018-03-08',NULL),(30,'Rythma ','','Nanaware','CUE343','2018-03-13',NULL,'987654321','rythma@cuelogic.com','',1,'2018-03-13',1,'2018-03-13',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeDepartment`
--

LOCK TABLES `EmployeeDepartment` WRITE;
/*!40000 ALTER TABLE `EmployeeDepartment` DISABLE KEYS */;
INSERT INTO `EmployeeDepartment` VALUES (1,20,17,'',1,'2018-03-06',NULL,NULL),(2,20,18,'',1,'2018-03-06',NULL,NULL),(3,20,19,'',1,'2018-03-06',NULL,NULL),(4,22,1,'\0',1,'2018-03-06',1,'2018-03-08'),(5,23,1,'',1,'2018-03-06',NULL,NULL),(6,20,20,'',1,'2018-03-06',1,'2018-03-06'),(7,21,20,'',1,'2018-03-06',1,'2018-03-06'),(8,22,20,'',1,'2018-03-06',1,'2018-03-06'),(9,23,20,'',1,'2018-03-06',1,'2018-03-06'),(10,20,21,'',1,'2018-03-07',1,'2018-03-07'),(17,20,27,'',1,'2018-03-08',1,'2018-03-08'),(18,20,28,'',1,'2018-03-08',1,'2018-03-08'),(19,20,29,'',17,'2018-03-08',17,'2018-03-08'),(20,24,1,'',1,'2018-03-12',1,'2018-03-12'),(21,20,30,'',1,'2018-03-13',1,'2018-03-13');
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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeOrganizationRole`
--

LOCK TABLES `EmployeeOrganizationRole` WRITE;
/*!40000 ALTER TABLE `EmployeeOrganizationRole` DISABLE KEYS */;
INSERT INTO `EmployeeOrganizationRole` VALUES (1,17,21,'',1,'2018-03-06',NULL,NULL),(2,18,20,'',1,'2018-03-06',NULL,NULL),(3,19,25,'',1,'2018-03-06',NULL,NULL),(4,1,22,'\0',1,'2018-03-06',1,'2018-03-08'),(5,1,23,'',1,'2018-03-06',NULL,NULL),(6,20,23,'',1,'2018-03-06',1,'2018-03-06'),(7,20,24,'',1,'2018-03-06',1,'2018-03-06'),(8,20,25,'',1,'2018-03-06',1,'2018-03-06'),(9,20,26,'',1,'2018-03-06',1,'2018-03-06'),(10,21,22,'',1,'2018-03-07',1,'2018-03-07'),(11,21,23,'',1,'2018-03-07',1,'2018-03-07'),(18,27,26,'',1,'2018-03-08',1,'2018-03-08'),(19,28,21,'',1,'2018-03-08',1,'2018-03-08'),(20,29,21,'',17,'2018-03-08',17,'2018-03-08'),(21,1,25,'',1,'2018-03-12',1,'2018-03-12'),(22,30,22,'',1,'2018-03-13',1,'2018-03-13');
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
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeSkill`
--

LOCK TABLES `EmployeeSkill` WRITE;
/*!40000 ALTER TABLE `EmployeeSkill` DISABLE KEYS */;
INSERT INTO `EmployeeSkill` VALUES (1,17,28,'',1,'2018-03-06',NULL,NULL),(2,17,29,'\0',1,'2018-03-06',17,'2018-03-08'),(3,17,31,'',1,'2018-03-06',NULL,NULL),(4,17,33,'',1,'2018-03-06',NULL,NULL),(5,17,35,'',1,'2018-03-06',NULL,NULL),(6,17,37,'',1,'2018-03-06',NULL,NULL),(7,17,38,'',1,'2018-03-06',NULL,NULL),(8,18,32,'',1,'2018-03-06',NULL,NULL),(9,18,33,'',1,'2018-03-06',NULL,NULL),(10,18,34,'',1,'2018-03-06',NULL,NULL),(11,18,35,'',1,'2018-03-06',NULL,NULL),(12,18,36,'',1,'2018-03-06',NULL,NULL),(13,18,37,'',1,'2018-03-06',NULL,NULL),(14,18,38,'',1,'2018-03-06',NULL,NULL),(15,19,28,'',1,'2018-03-06',NULL,NULL),(16,19,29,'',1,'2018-03-06',NULL,NULL),(17,19,30,'',1,'2018-03-06',NULL,NULL),(18,19,31,'',1,'2018-03-06',NULL,NULL),(19,19,32,'',1,'2018-03-06',NULL,NULL),(20,19,33,'',1,'2018-03-06',NULL,NULL),(21,19,34,'',1,'2018-03-06',NULL,NULL),(22,1,28,'\0',1,'2018-03-06',1,'2018-03-13'),(23,1,29,'\0',1,'2018-03-06',1,'2018-03-08'),(24,1,30,'\0',1,'2018-03-06',1,'2018-03-13'),(25,1,31,'',1,'2018-03-06',NULL,NULL),(26,1,32,'',1,'2018-03-06',NULL,NULL),(27,1,33,'',1,'2018-03-06',NULL,NULL),(28,1,34,'',1,'2018-03-06',NULL,NULL),(29,20,30,'',1,'2018-03-06',1,'2018-03-06'),(30,20,31,'',1,'2018-03-06',1,'2018-03-06'),(31,20,32,'',1,'2018-03-06',1,'2018-03-06'),(32,20,33,'',1,'2018-03-06',1,'2018-03-06'),(33,20,34,'',1,'2018-03-06',1,'2018-03-06'),(34,20,35,'',1,'2018-03-06',1,'2018-03-06'),(35,20,36,'',1,'2018-03-06',1,'2018-03-06'),(36,21,28,'',1,'2018-03-07',1,'2018-03-07'),(37,21,29,'',1,'2018-03-07',1,'2018-03-07'),(38,21,30,'',1,'2018-03-07',1,'2018-03-07'),(39,21,31,'',1,'2018-03-07',1,'2018-03-07'),(40,21,32,'',1,'2018-03-07',1,'2018-03-07'),(41,21,33,'',1,'2018-03-07',1,'2018-03-07'),(42,21,34,'',1,'2018-03-07',1,'2018-03-07'),(43,21,35,'',1,'2018-03-07',1,'2018-03-07'),(50,27,32,'',1,'2018-03-08',1,'2018-03-08'),(51,28,28,'',1,'2018-03-08',1,'2018-03-08'),(52,28,29,'',1,'2018-03-08',1,'2018-03-08'),(53,28,30,'',1,'2018-03-08',1,'2018-03-08'),(54,28,31,'',1,'2018-03-08',1,'2018-03-08'),(55,28,32,'',1,'2018-03-08',1,'2018-03-08'),(56,29,42,'',17,'2018-03-08',17,'2018-03-08'),(57,1,40,'',1,'2018-03-13',1,'2018-03-13'),(58,30,28,'',1,'2018-03-13',1,'2018-03-13'),(59,30,29,'',1,'2018-03-13',1,'2018-03-13'),(60,30,30,'',1,'2018-03-13',1,'2018-03-13'),(61,30,31,'',1,'2018-03-13',1,'2018-03-13'),(62,30,32,'',1,'2018-03-13',1,'2018-03-13');
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
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityEmployeeGroup`
--

LOCK TABLES `IdentityEmployeeGroup` WRITE;
/*!40000 ALTER TABLE `IdentityEmployeeGroup` DISABLE KEYS */;
INSERT INTO `IdentityEmployeeGroup` VALUES (31,21,117,'',1,'2018-03-09',1,'2018-03-09'),(32,19,117,'',1,'2018-03-09',1,'2018-03-09'),(33,28,117,'',1,'2018-03-09',1,'2018-03-09'),(34,20,117,'',1,'2018-03-09',1,'2018-03-09'),(35,18,117,'\0',1,'2018-03-09',1,'2018-03-09'),(36,1,117,'',1,'2018-03-12',1,'2018-03-12'),(37,30,117,'',1,'2018-03-13',1,'2018-03-13'),(38,27,116,'',1,'2018-03-13',1,'2018-03-13'),(45,27,115,'',1,'2018-03-13',1,'2018-03-13'),(46,1,115,'',1,'2018-03-13',1,'2018-03-13'),(47,17,115,'',1,'2018-03-13',1,'2018-03-13');
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
) ENGINE=InnoDB AUTO_INCREMENT=120 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroup`
--

LOCK TABLES `IdentityGroup` WRITE;
/*!40000 ALTER TABLE `IdentityGroup` DISABLE KEYS */;
INSERT INTO `IdentityGroup` VALUES (115,'Super Admin','Super Admin','',1,'2018-03-09',1,'2018-03-09'),(116,'Manager','Manager','',1,'2018-03-09',1,'2018-03-13'),(117,'Employee','Employee','',1,'2018-03-09',1,'2018-03-09'),(119,'Admin','Admin','',1,'2018-03-13',1,'2018-03-13');
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
  KEY `IdentityGroupRight_IdentityGroup` (`GroupId`),
  KEY `IdentityGroupRightCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityGroupRightUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityGroupRightCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupRightUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupRight_IdentityGroup` FOREIGN KEY (`GroupId`) REFERENCES `IdentityGroup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroupRight`
--

LOCK TABLES `IdentityGroupRight` WRITE;
/*!40000 ALTER TABLE `IdentityGroupRight` DISABLE KEYS */;
INSERT INTO `IdentityGroupRight` VALUES (1,115,202,7,'\0',1,'2018-03-09',1,'2018-03-09'),(2,115,200,7,'\0',1,'2018-03-09',1,'2018-03-09'),(3,115,201,7,'\0',1,'2018-03-09',1,'2018-03-09'),(4,115,403,7,'\0',1,'2018-03-09',1,'2018-03-09'),(5,115,400,7,'\0',1,'2018-03-09',1,'2018-03-09'),(6,115,305,7,'\0',1,'2018-03-09',1,'2018-03-09'),(7,115,301,7,'\0',1,'2018-03-09',1,'2018-03-09'),(8,115,302,7,'\0',1,'2018-03-09',1,'2018-03-09'),(9,115,303,7,'\0',1,'2018-03-09',1,'2018-03-09'),(10,115,304,7,'\0',1,'2018-03-09',1,'2018-03-09'),(11,115,300,7,'\0',1,'2018-03-09',1,'2018-03-09'),(12,115,401,7,'\0',1,'2018-03-09',1,'2018-03-09'),(13,115,402,7,'\0',1,'2018-03-09',1,'2018-03-09'),(14,116,202,0,'\0',1,'2018-03-09',1,'2018-03-09'),(15,116,200,0,'\0',1,'2018-03-09',1,'2018-03-09'),(16,116,201,0,'\0',1,'2018-03-09',1,'2018-03-09'),(17,116,403,6,'\0',1,'2018-03-09',1,'2018-03-13'),(18,116,400,6,'\0',1,'2018-03-09',1,'2018-03-13'),(19,116,305,0,'\0',1,'2018-03-09',1,'2018-03-09'),(20,116,301,0,'\0',1,'2018-03-09',1,'2018-03-09'),(21,116,302,0,'\0',1,'2018-03-09',1,'2018-03-09'),(22,116,303,0,'\0',1,'2018-03-09',1,'2018-03-09'),(23,116,304,0,'\0',1,'2018-03-09',1,'2018-03-09'),(24,116,300,0,'\0',1,'2018-03-09',1,'2018-03-09'),(25,116,401,4,'\0',1,'2018-03-09',1,'2018-03-09'),(26,116,402,4,'\0',1,'2018-03-09',1,'2018-03-09'),(27,117,202,0,'\0',1,'2018-03-09',1,'2018-03-09'),(28,117,200,0,'\0',1,'2018-03-09',1,'2018-03-09'),(29,117,201,0,'\0',1,'2018-03-09',1,'2018-03-09'),(30,117,403,0,'\0',1,'2018-03-09',1,'2018-03-09'),(31,117,400,0,'\0',1,'2018-03-09',1,'2018-03-09'),(32,117,305,0,'\0',1,'2018-03-09',1,'2018-03-09'),(33,117,301,0,'\0',1,'2018-03-09',1,'2018-03-09'),(34,117,302,0,'\0',1,'2018-03-09',1,'2018-03-09'),(35,117,303,0,'\0',1,'2018-03-09',1,'2018-03-09'),(36,117,304,0,'\0',1,'2018-03-09',1,'2018-03-09'),(37,117,300,0,'\0',1,'2018-03-09',1,'2018-03-09'),(38,117,401,4,'\0',1,'2018-03-09',1,'2018-03-09'),(39,117,402,0,'\0',1,'2018-03-09',1,'2018-03-09'),(53,119,202,7,'\0',1,'2018-03-13',1,'2018-03-13'),(54,119,200,7,'\0',1,'2018-03-13',1,'2018-03-13'),(55,119,201,7,'\0',1,'2018-03-13',1,'2018-03-13'),(56,119,403,0,'\0',1,'2018-03-13',1,'2018-03-13'),(57,119,400,0,'\0',1,'2018-03-13',1,'2018-03-13'),(58,119,305,0,'\0',1,'2018-03-13',1,'2018-03-13'),(59,119,301,0,'\0',1,'2018-03-13',1,'2018-03-13'),(60,119,302,0,'\0',1,'2018-03-13',1,'2018-03-13'),(61,119,303,0,'\0',1,'2018-03-13',1,'2018-03-13'),(62,119,304,0,'\0',1,'2018-03-13',1,'2018-03-13'),(63,119,300,0,'\0',1,'2018-03-13',1,'2018-03-13'),(64,119,401,0,'\0',1,'2018-03-13',1,'2018-03-13'),(65,119,402,0,'\0',1,'2018-03-13',1,'2018-03-13');
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
  `RightId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`,`RightId`),
  KEY `IdentityRightCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityRightUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityRightCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityRightUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityRight`
--

LOCK TABLES `IdentityRight` WRITE;
/*!40000 ALTER TABLE `IdentityRight` DISABLE KEYS */;
INSERT INTO `IdentityRight` VALUES (1,'Dashboard',400,'',1,'2018-02-02',NULL,NULL),(2,'MyProfile',401,'',1,'2018-02-02',NULL,NULL),(3,'Project',402,'',1,'2018-02-02',NULL,NULL),(4,'Allocation',403,'',1,'2018-02-02',NULL,NULL),(5,'Admin Group',200,'',1,'2018-02-02',NULL,NULL),(6,'Admin UserGroup',201,'',1,'2018-02-02',NULL,NULL),(7,'Admin Employee',202,'',1,'2018-02-02',NULL,NULL),(8,'Master Skill',300,'',1,'2018-02-02',NULL,NULL),(9,'Master Department',301,'',1,'2018-02-02',NULL,NULL),(10,'Master Organization Role',302,'',1,'2018-02-02',NULL,NULL),(11,'Master Project Role',303,'',1,'2018-02-02',NULL,NULL),(12,'Master Project Type',304,'',1,'2018-02-02',NULL,NULL),(13,'Master Client',305,'',1,'2018-02-02',NULL,NULL);
/*!40000 ALTER TABLE `IdentityRight` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterCity`
--

DROP TABLE IF EXISTS `MasterCity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterCity` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CountryId` int(11) NOT NULL,
  `CityName` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Country_City` (`CountryId`),
  CONSTRAINT `FK_Country_City` FOREIGN KEY (`CountryId`) REFERENCES `MasterCountry` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterCity`
--

LOCK TABLES `MasterCity` WRITE;
/*!40000 ALTER TABLE `MasterCity` DISABLE KEYS */;
INSERT INTO `MasterCity` VALUES (1,1,'Pune'),(2,1,'Mumbai'),(3,1,'Chennai'),(4,1,'Kolkata'),(5,1,'Surat'),(6,2,'New York'),(7,2,'Washington D.C.'),(8,2,'Chicago'),(9,2,'Los Angeles'),(10,3,'Rome'),(11,3,'Venice'),(12,3,'Florence'),(13,3,'Milan'),(14,4,'Barcelona'),(15,4,'Madrid'),(16,5,'Amsterdam'),(17,5,'Rotterdam');
/*!40000 ALTER TABLE `MasterCity` ENABLE KEYS */;
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
  `CountryId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterClient`
--

LOCK TABLES `MasterClient` WRITE;
/*!40000 ALTER TABLE `MasterClient` DISABLE KEYS */;
INSERT INTO `MasterClient` VALUES (15,'Abbott Laboratories',2,6,'',1,'2018-01-01',NULL,NULL),(16,'Aarons, Inc',2,6,'',1,'2018-01-01',NULL,NULL),(17,'Walmart',2,6,'',1,'2018-01-01',1,'2018-03-13'),(18,'ExxonMobil',2,6,'',1,'2018-01-01',NULL,NULL),(19,'Jumbo Jet',1,1,'',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `MasterClient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterCountry`
--

DROP TABLE IF EXISTS `MasterCountry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterCountry` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CountryName` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterCountry`
--

LOCK TABLES `MasterCountry` WRITE;
/*!40000 ALTER TABLE `MasterCountry` DISABLE KEYS */;
INSERT INTO `MasterCountry` VALUES (1,'India'),(2,'USA'),(3,'Italy'),(4,'Spain'),(5,'Netherlands');
/*!40000 ALTER TABLE `MasterCountry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterCurrency`
--

DROP TABLE IF EXISTS `MasterCurrency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterCurrency` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CountryId` int(11) NOT NULL,
  `Currency` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_currency_country` (`CountryId`),
  CONSTRAINT `fk_currency_country` FOREIGN KEY (`CountryId`) REFERENCES `MasterCountry` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterCurrency`
--

LOCK TABLES `MasterCurrency` WRITE;
/*!40000 ALTER TABLE `MasterCurrency` DISABLE KEYS */;
INSERT INTO `MasterCurrency` VALUES (1,1,'Rupee(₹)'),(2,2,'Dollar($)'),(3,3,'Euro(€)'),(4,4,'Euro(€)'),(5,5,'Euro(€)'),(6,5,'Dollar($)');
/*!40000 ALTER TABLE `MasterCurrency` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterDepartment`
--

LOCK TABLES `MasterDepartment` WRITE;
/*!40000 ALTER TABLE `MasterDepartment` DISABLE KEYS */;
INSERT INTO `MasterDepartment` VALUES (20,'Delivery','Vivek Phadke','',1,'2018-01-01',1,'2018-03-13'),(21,'HR','Uma Ramani','',1,'2018-01-01',NULL,NULL),(22,'Sales','Neel Vartikar','',1,'2018-01-01',NULL,NULL),(23,'Management','Nikhil Ambekar','',1,'2018-01-01',NULL,NULL),(24,'Technical','Vikrant Labde','',1,'2018-01-01',NULL,NULL),(25,'Admin','Admin','',1,'2018-03-06',1,'2018-03-06'),(26,'Cafeteria','Kaka','',1,'2018-03-13',1,'2018-03-13');
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterOrganizationRole`
--

LOCK TABLES `MasterOrganizationRole` WRITE;
/*!40000 ALTER TABLE `MasterOrganizationRole` DISABLE KEYS */;
INSERT INTO `MasterOrganizationRole` VALUES (20,'Software Engineer','',1,'2018-01-01',NULL,NULL),(21,'Sr. Software Engineer','',1,'2018-01-01',1,'2018-03-13'),(22,'Devops','',1,'2018-01-01',NULL,NULL),(23,'Trainee Software Engineer','',1,'2018-01-01',NULL,NULL),(24,'Principle Engineer','',1,'2018-01-01',NULL,NULL),(25,'Project Manager','',1,'2018-01-01',NULL,NULL),(26,'Sr. Project Manager','',1,'2018-01-01',NULL,NULL),(27,'Rails Developer','',1,'2018-03-06',1,'2018-03-06'),(28,'Desktop Engineer','',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `MasterOrganizationRole` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectType`
--

LOCK TABLES `MasterProjectType` WRITE;
/*!40000 ALTER TABLE `MasterProjectType` DISABLE KEYS */;
INSERT INTO `MasterProjectType` VALUES (11,'Billable','',1,'2018-01-01',NULL,NULL),(12,'Non Billable','',1,'2018-01-01',1,'2018-03-13'),(13,'In House','',1,'2018-01-01',NULL,NULL),(14,'R & D','\0',1,'2018-01-01',NULL,NULL),(15,'Client','',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `MasterProjectType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MasterRole`
--

DROP TABLE IF EXISTS `MasterRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MasterRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Role` varchar(50) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterRole`
--

LOCK TABLES `MasterRole` WRITE;
/*!40000 ALTER TABLE `MasterRole` DISABLE KEYS */;
INSERT INTO `MasterRole` VALUES (13,'Developer','',1,'2018-01-01',1,'2018-03-12'),(14,'Product Developer','',1,'2018-01-01',NULL,NULL),(15,'Technical Analyst','',1,'2018-01-01',1,'2018-03-12'),(16,'Ui Engineer','',1,'2018-01-01',NULL,NULL),(17,'Backend Developer','',1,'2018-01-01',1,'2018-03-12'),(18,'Trainee Develop','',1,'2018-03-12',1,'2018-03-13'),(19,'Angular Developer','',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `MasterRole` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterSkill`
--

LOCK TABLES `MasterSkill` WRITE;
/*!40000 ALTER TABLE `MasterSkill` DISABLE KEYS */;
INSERT INTO `MasterSkill` VALUES (28,'C#','',1,'2018-01-01',1,'2018-03-13'),(29,'Html','',1,'2018-01-01',NULL,NULL),(30,'Jquery','',1,'2018-01-01',NULL,NULL),(31,'Javascript','',1,'2018-01-01',NULL,NULL),(32,'SQL','',1,'2018-01-01',NULL,NULL),(33,'AngularJS 1','',1,'2018-01-01',NULL,NULL),(34,'Angular 4','',1,'2018-01-01',NULL,NULL),(35,'LINQ','',1,'2018-01-01',NULL,NULL),(36,'Entity Framework','',1,'2018-01-01',NULL,NULL),(37,'Ionic Cordova','',1,'2018-01-01',NULL,NULL),(38,'Scala','',1,'2018-01-01',NULL,NULL),(39,'Swift','',1,'2018-01-01',NULL,NULL),(40,'Python','',1,'2018-01-01',NULL,NULL),(41,'NodeJS','',1,'2018-01-01',NULL,NULL),(42,'Ruby On Rails','',1,'2018-03-06',1,'2018-03-06'),(43,'SCSS','',1,'2018-03-13',1,'2018-03-13');
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
  `ClientId` int(11) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Project`
--

LOCK TABLES `Project` WRITE;
/*!40000 ALTER TABLE `Project` DISABLE KEYS */;
INSERT INTO `Project` VALUES (15,'Kantar',11,'2017-07-01','2018-03-02','Kantar',16,'','',1,'2018-03-06',1,'2018-03-13'),(16,'Tiny Torch',11,'2017-01-01',NULL,'Tiny Torch',15,'\0','',1,'2018-03-06',1,'2018-03-12'),(17,'Cuelogic Resource Management',13,'2018-01-15',NULL,'Cuelogic Resource Management',15,'','',1,'2018-03-06',1,'2018-03-12'),(18,'Big Data Charting System',11,'2018-03-01',NULL,'Big Data Charting System',18,'\0','',1,'2018-03-06',1,'2018-03-12'),(21,'Micro Launch',11,'2018-03-12',NULL,'Alpha1',16,'','',1,'2018-03-12',1,'2018-03-12'),(22,'Alpha1',11,'2018-03-12',NULL,'Alpha1',16,'','',1,'2018-03-12',1,'2018-03-12'),(23,'E Learning System',11,'2018-03-13',NULL,'E Learning System',16,'\0','',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `Project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProjectRole`
--

DROP TABLE IF EXISTS `ProjectRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ProjectRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
  `BillingRate` int(11) NOT NULL,
  `CurrencyId` int(11) NOT NULL,
  `IsValid` bit(1) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedOn` date NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `project_Id` (`ProjectId`),
  KEY `role_Id` (`RoleId`),
  KEY `currency_Id` (`CurrencyId`),
  KEY `createdby_Id` (`CreatedBy`),
  KEY `updatedby_Id` (`UpdatedBy`),
  CONSTRAINT `createdby_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `currency_Id` FOREIGN KEY (`CurrencyId`) REFERENCES `MasterCurrency` (`Id`),
  CONSTRAINT `project_Id` FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`),
  CONSTRAINT `role_Id` FOREIGN KEY (`RoleId`) REFERENCES `MasterRole` (`Id`),
  CONSTRAINT `updatedby_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProjectRole`
--

LOCK TABLES `ProjectRole` WRITE;
/*!40000 ALTER TABLE `ProjectRole` DISABLE KEYS */;
INSERT INTO `ProjectRole` VALUES (22,17,18,123,6,'',1,'2018-03-12',1,'2018-03-12'),(23,22,18,89,6,'',1,'2018-03-12',1,'2018-03-12'),(24,22,17,90,5,'',1,'2018-03-12',1,'2018-03-12'),(25,21,18,121212,5,'\0',1,'2018-03-12',1,'2018-03-12'),(26,18,17,123,6,'',1,'2018-03-12',1,'2018-03-12'),(27,17,17,677,6,'',1,'2018-03-12',NULL,NULL),(28,15,16,899,6,'',1,'2018-03-12',1,'2018-03-13'),(29,15,16,23,6,'',1,'2018-03-12',1,'2018-03-13'),(30,23,18,100,6,'',1,'2018-03-13',1,'2018-03-13'),(31,23,19,1200,6,'',1,'2018-03-13',1,'2018-03-13');
/*!40000 ALTER TABLE `ProjectRole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'CuelogicResourceManagement'
--

--
-- Dumping routines for database 'CuelogicResourceManagement'
--
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_AddOrUpdate`(
	IN aId INT(11),
    IN aEmployeeId INT(11),
    IN aProjectRoleId INT(11), 
    IN aProjectId INT(11), 
    IN aIsBillable BIT, 
    IN aPercentageAllocation INT(11), 
    IN aStartDate VARCHAR(50),
    IN aEndDate VARCHAR(50),
	IN aIsValid bit,
    IN aUpdatedBy int(11),
    IN aCreatedBy int(11),
    IN aUpdatedOn varchar(50),
    IN aCreatedOn varchar(50)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 

		INSERT INTO Allocation
		(
			`Id`,
			`EmployeeId`,
			`ProjectRoleId`,
			`ProjectId`,
			`IsBillable`,
			`PercentageAllocation`,
			`StartDate`,
			`EndDate`,
			`IsValid`,
			`CreatedBy`,
			`CreatedOn`,
			`UpdatedBy`,
			`UpdatedOn`
		)
		VALUES
		(
			aId,
			aEmployeeId,
			aProjectRoleId,
			aProjectId,
			aIsBillable,
			aPercentageAllocation,
			IF((aStartDate = ''), NULL,aStartDate), 
			IF((aEndDate = ''), NULL,aEndDate),
			aIsValid,
			aCreatedBy,
			aCreatedOn,
			aCreatedBy,
			aCreatedOn
		)
		ON DUPLICATE KEY UPDATE
			EmployeeId = aEmployeeId,
			ProjectRoleId = aProjectRoleId,
			ProjectId = aProjectId,
			IsBillable = aIsBillable,
			PercentageAllocation= aPercentageAllocation,
			StartDate= IF((aStartDate = ''), NULL,aStartDate), 
			EndDate = IF((aEndDate = ''), NULL,aEndDate),
			IsValid = aIsValid,
			UpdatedBy= aUpdatedBy,
			UpdatedOn = aUpdatedOn;
			
	COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_Get`(
	IN aId INT(11)
)
BEGIN

	SELECT
		a.Id,
        a.EmployeeId,
        a.ProjectRoleId,
        a.ProjectId,
        a.IsBillable,
        a.PercentageAllocation,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') AS StartDate,
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') AS EndDate,
        a.IsValid,
		a.CreatedBy,
		a.CreatedOn,
		a.UpdatedBy,
		a.UpdatedOn,
        CONCAT(b.FirstName,' ',b.LastName) AS CreatedByName,
        CONCAT(c.FirstName,' ',c.LastName) AS UpdatedByName
	FROM
		Allocation a
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id
	WHERE
		a.Id = aId
	GROUP BY a.EmployeeId;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_GetAllocationSum` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_GetAllocationSum`(
	IN aId INT(11)
)
BEGIN
	SELECT 
		SUM(PercentageAllocation) 
	FROM 
		Allocation 
	WHERE 
		EmployeeId = aId AND 
        IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_GetList`(
IN filterText VARCHAR(200), 
IN recordFrom INT(4), 
IN recordTill INT(4)
)
BEGIN
	SELECT
		a.Id,
        CONCAT(b.FirstName,' ', b.MiddleName ,' ',b.LastName) AS FullName,
        x.Role,
        d.ProjectName,
        IF(a.IsBillable,'Yes','No') AS IsBillable,
        a.PercentageAllocation,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') AS StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') AS EndDate,
        IF(a.IsValid,'Yes','No') AS IsValid
	FROM 
		Allocation a
	INNER JOIN Employee b ON a.EmployeeId = b.Id
    INNER JOIN ProjectRole c ON a.ProjectRoleId = c.Id
    INNER JOIN MasterRole x ON c.RoleId = x.Id
    INNER JOIN Project d ON a.ProjectId = d.Id
    WHERE
		b.FirstName LIKE concat('%', filterText,'%') OR
		b.MiddleName LIKE concat('%', filterText,'%') OR
		b.LastName LIKE concat('%', filterText,'%') OR
		x.Role LIKE concat('%', filterText,'%') OR
		d.ProjectName LIKE concat('%', filterText,'%') OR
		a.StartDate LIKE concat('%', filterText,'%') OR
		a.EndDate LIKE concat('%', filterText,'%') OR
		a.PercentageAllocation LIKE concat('%', filterText,'%') OR
		a.IsBillable = IF(filterText = 'yes',true,false) OR
        a.IsValid = IF(filterText = 'yes',true,false)
	ORDER BY 
		a. EmployeeId ASC
	LIMIT 
		recordFrom, recordTill;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_GetRoleByProject` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_GetRoleByProject`(
	IN aProjectId INT(11)
)
BEGIN
	SELECT 
		b.Id,
        c.Role
	FROM
		Project a
	INNER JOIN 
		ProjectRole b ON b.ProjectId = a.Id
	INNER JOIN
		MasterRole c ON c.Id = b.RoleId
	WHERE 
		a.Id = aProjectId AND
		b.IsValid = true AND
        c.IsValid = true;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_GetSelectList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_GetSelectList`()
BEGIN

	SELECT 
		Id, 
		CONCAT(FirstName,' ',MiddleName,' ',LastName) AS FullName 
	FROM Employee 
	WHERE IsValid = true;
        
    SELECT 
		Id, 
        ProjectName 
	FROM Project  
    WHERE IsValid = true;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Allocation_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Allocation_MarkInvalid`(
	IN aId INT(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE Allocation 
    SET IsValid = CASE 
					  WHEN IsValid = 1 THEN 0 
					  WHEN IsValid = 0 THEN 1 
                  END
	WHERE
		Id = aId;
	
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Common_LogLoginTime` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Common_LogLoginTime`(
	IN employeeId INT(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE Employee SET LastLogin = NOW() WHERE Id = employeeId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeAllocation_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeAllocation_GetList`(
	IN employeeId INT(11)
)
BEGIN
	
	SELECT
		a.Id,
        CONCAT(b.FirstName,' ', b.MiddleName ,' ',b.LastName) as FullName,
        x.Role,
        d.ProjectName,
        if(a.IsBillable,'Yes','No') as IsBillable,
        a.PercentageAllocation,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        if(a.IsValid,'Yes','No') as IsValid
	FROM 
		Allocation a
	INNER JOIN Employee b ON a.EmployeeId = b.Id
    INNER JOIN ProjectRole c ON a.ProjectRoleId = c.Id
    INNER JOIN MasterRole x ON c.RoleId = x.Id
    INNER JOIN Project d ON a.ProjectId = d.Id
    WHERE
		a.EmployeeId = employeeId AND
        a.IsValid = true;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeDepartment_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeDepartment_BulkAddOrUpdate`(
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
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
                `CreatedOn`,
                `UpdatedBy`,
                `UpdatedOn`
            )
            VALUES
            (
				employeeDepartmentId,
                masterEmployeeId,
                masterDepartmentId,
                isDepartmentValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
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
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeGroup_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeGroup_BulkAddOrUpdate`(
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
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
                `CreatedOn`,
                `UpdatedBy`,
                `UpdatedOn`
            )
            VALUES
            (
				employeeGroupId,
                masterEmployeeId,
                masterGroupId,
                isGroupValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
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
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeOrganizationRole_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeOrganizationRole_BulkAddOrUpdate`(
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
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
			`CreatedOn`,
            `UpdatedBy`,
            `UpdatedOn`
		)
		VALUES
		(
			employeeOrgRoleId,
			masterEmployeeId,
			masterOrgRoleId,
			isOrgRoleValid,
			userId,
			DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
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
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeRights_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeRights_Get`(
	IN employeeId INT(11)
)
BEGIN
	SELECT 
		d.Id,
        d.GroupId, 
        d.RightId,
        d.Action,
        d.IsValid,
        d.CreatedBy,
        d.CreatedOn,
        d.UpdatedBy,
        d.UpdatedOn
    FROM 
		Employee a
	INNER JOIN IdentityEmployeeGroup b on a.Id = b.EmployeeId 
	INNER JOIN IdentityGroup c on b.GroupId = c.Id
	INNER JOIN IdentityGroupRight d ON c.Id = d.GroupId
	WHERE 
		a.Id = employeeId AND
        b.IsValid = true AND
        c.IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `EmployeeSkill_BulkAddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmployeeSkill_BulkAddOrUpdate`(
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
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
                `CreatedOn`,
                `UpdatedBy`,
                `UpdatedOn`
            )
            VALUES
            (
				employeeSkillId,
                masterEmployeeId,
                masterSkillId,
                isSkillValid,
                userId,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
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
        
        COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_AddOrUpdate`(
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

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION;
    
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
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
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
        createdOn,
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
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetByEmailId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetByEmailId`(
	IN EmailId varchar(100)
)
BEGIN
	SELECT * FROM Employee WHERE Email = EmailId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetById`(
	IN employeeId int(11)
)
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
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetByOrgEmpId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetByOrgEmpId`(
	IN eOrgEmpId varchar(150)
)
BEGIN
	SELECT * FROM Employee WHERE OrgEmpId = eOrgEmpId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetChildValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetChildValidList`(
	IN masterEmployeeId INT(11)
)
BEGIN

	SELECT 
		a.Id, 
        a.EmployeeId, 
        a.GroupId, 
        a.IsValid, 
        a.CreatedBy, 
		a.CreatedOn, 
        a.UpdatedBy, 
        a.UpdatedOn, 
        b.GroupName 
    FROM 
		IdentityEmployeeGroup a
    INNER JOIN
		IdentityGroup b ON a.GroupId = b.Id
    WHERE 
		b.IsValid = true AND 
		a.EmployeeId = masterEmployeeId
    ORDER BY 
		a.IsValid = true DESC;
    
	SELECT 
		a.Id, 
        a.EmployeeId, 
        a.DepartmentId, 
        a.IsValid, 
        a.CreatedBy, 
		a.CreatedOn, 
        a.UpdatedBy, 
        a.UpdatedOn, 
        b.DepartmentName  
    FROM 
		EmployeeDepartment a
    INNER JOIN
		MasterDepartment b ON a.DepartmentId = b. Id
    WHERE 
		b.IsValid = true AND 
        a.EmployeeId = masterEmployeeId
    ORDER BY 
		a.IsValid = true DESC;
    
	SELECT 
		a.Id, 
        a.EmployeeId, 
        a.SkillId, 
        a.IsValid, 
        a.CreatedBy, 
        a.CreatedOn,
		a.UpdatedBy, 
        a.UpdatedOn, 
        b.Skill AS SkillName 
	FROM 
		EmployeeSkill  a 
    INNER JOIN
		MasterSkill b ON a.SkillId = b. Id
    WHERE 
		b.IsValid = true AND 
        a.EmployeeId = masterEmployeeId
    ORDER BY 
		a.IsValid = true DESC;
    
    SELECT 
		a.Id, 
        a.EmployeeId, 
        a.RoleId, 
        a.IsValid, 
        a.CreatedBy, 
		a.CreatedOn, 
        a.UpdatedBy, 
        a.UpdatedOn, 
        b.Role AS RoleName
    FROM 
		EmployeeOrganizationRole a 
    INNER JOIN
		MasterOrganizationRole b ON a.RoleId = b. Id
	WHERE 
		b.IsValid = true AND 
        a.EmployeeId = masterEmployeeId
    ORDER BY 
		a.IsValid = true DESC;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetLatestId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetLatestId`()
BEGIN
	SELECT MAX(Id) FROM Employee;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetList`(
	IN filterText varchar(200), 
	IN recordFrom int(4), 
	IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		concat(a.FirstName, ' ',a.MiddleName, ' ',a.LastName) AS FullName,
        a.OrgEmpId,
        DATE_FORMAT(a.JoiningDate,'%Y/%m/%d') AS JoiningDate,
        a.Email,
		IF(a.IsValid,'Yes','No') AS IsValid,
		concat(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		Employee a
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id
	WHERE 
		a.MiddleName LIKE concat('%', filterText,'%') OR
		a.FirstName LIKE concat('%', filterText,'%') OR
		a.LastName LIKE concat('%', filterText,'%') OR
        a.OrgEmpId LIKE concat('%', filterText,'%') OR
        a.JoiningDate LIKE concat('%', filterText,'%') OR
        a.Email LIKE concat('%', filterText,'%') OR
        a.IsValid = IF(filterText = 'yes',true,false) OR
		a.CreatedOn LIKE concat('%', filterText,'%')
	LIMIT 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_GetMasterValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_GetMasterValidList`()
BEGIN
	SELECT * FROM IdentityGroup  WHERE IsValid = true;
    SELECT * FROM MasterDepartment WHERE IsValid = true;
    SELECT * FROM MasterSkill  WHERE IsValid = true;
    SELECT * FROM MasterOrganizationRole  WHERE IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Employee_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Employee_MarkInvalid`(
	IN masterEmployeeId int(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION;
    
	UPDATE Employee SET
		IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE
		Id = masterEmployeeId;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroupRight_BulkInsert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroupRight_BulkInsert`(IN xmltext text)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	SET nodeCount = ExtractValue(xmltext, 'count(/ArrayOfIdentityGroupRight/IdentityGroupRight)');
	WHILE i <= nodeCount DO
		INSERT INTO IdentityGroupRight 
        (
			`GroupId`,
            `RightId`,
            `Action`,
            `IsValid`,
            `CreatedBy`,
            `CreatedOn`,
            `UpdatedBy`,
            `UpdatedOn`
		)
        VALUES
        (
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/GroupId'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/RightId'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Action'),
			IF(ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/IsValid') = 'true',1,0),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedBy'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedOn'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedBy'),
			ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/CreatedOn')
		);
        
        SET i = i+1;
	END WHILE;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroupRight_BulkUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroupRight_BulkUpdate`(
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
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroupRight_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroupRight_Get`(
	IN GroupId INT(4)
)
BEGIN
	SELECT 
		b.Id, 
        b.GroupId, 
        b.RightId, 
        b.Action, 
        b.IsValid, 
        b.CreatedOn,
		b.CreatedBy, 
        b.UpdatedBy, 
        b.UpdatedOn, 
        a.RightTitle,
		concat(c.FirstName, ' ', c.LastName) AS CreatedByName,
		concat(d.FirstName, ' ', d.LastName) AS UpdatedByName 
	FROM 
		IdentityGroupRight b 
	INNER JOIN
		IdentityRight a ON a.RightId = b.RightId
	LEFT JOIN
		Employee c ON b.CreatedBy = c.Id 
	LEFT JOIN
		Employee d ON b.UpdatedBy = d.Id 
	WHERE 
		b.GroupId = GroupId
	ORDER BY
		a.RightTitle ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroup_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroup_Get`(
	IN GroupId int(4)
)
BEGIN
	SELECT 
		a.Id, 
        a.GroupName, 
        a.GroupDescription,
        a.IsValid, 
        a.CreatedOn, 
        a.UpdatedOn, 
        a.CreatedBy, 
        a.UpdatedBy,
		CONCAT(b.FirstName, ' ', b.LastName) AS CreatedByName,
		CONCAT(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		IdentityGroup a 
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = GroupId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroup_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroup_GetList`(
	IN FilterText varchar(200), 
	IN RecordFrom int(4), 
	IN RecordTill int(4)
)
BEGIN

	SELECT 
		a.Id, 
        a.GroupName,
        a.GroupDescription,
        IF(a.IsValid,'Yes','No') AS IsValid,
		CONCAT(b.FirstName ,' ', b.LastName) AS Name, 
		DATE_FORMAT(a.CreatedOn,'%d/%m/%Y') AS CreatedOn
	FROM 
		CuelogicResourceManagement.IdentityGroup a
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id
	WHERE
		a.IsValid = IF(FilterText = 'yes',true,false) OR
		a.GroupName LIKE concat('%', FilterText,'%') OR
		a.GroupDescription LIKE concat('%', FilterText,'%') OR
		b.FirstName LIKE concat('%', FilterText,'%') OR
		b.LastName LIKE concat('%', FilterText,'%') OR
		a.CreatedOn LIKE concat('%', FilterText,'%')
	LIMIT 
		RecordFrom, RecordTill;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroup_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroup_Insert`(
IN groupName VARCHAR(150),
IN groupDesc VARCHAR(500),
IN isValid BOOL,
IN createdBy INT(11),
IN createdOn VARCHAR(150)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO IdentityGroup
    (
		`GroupName`,
        `GroupDescription`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
    (
		groupName,
        groupDesc,
        isValid,
        createdBy,
        createdOn,
        createdBy,
        createdOn);
        
    SELECT MAX(Id) AS Id FROM IdentityGroup;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroup_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroup_MarkInvalid`(IN groupId int(11))
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE IdentityGroupRight SET
	IsValid = false
	WHERE GroupId = groupId;
    
	UPDATE IdentityGroup SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = groupId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityGroup_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityGroup_Update`(
	IN GroupId INT(11),
	IN grpname VARCHAR(150),
	IN groupdesc VARCHAR(500),
	IN valid BIT,
	IN updatedby INT(11),
	IN updatedon DATE
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE IdentityGroup SET 
		GroupName = grpname ,
		`GroupDescription` = groupdesc,
		`IsValid` = valid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE 
		`Id` = GroupId;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `IdentityRight_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `IdentityRight_Get`()
BEGIN
	SELECT * FROM IdentityRight ORDER BY RightTitle ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_AddOrUpdate`(
	IN mcId int(11),
	IN mcClientName varchar(150),
    IN mcCountryId int(11),
    IN mcCityId int(11),
    IN mcIsValid bit,
    IN mcUpdatedBy int(11),
    IN mcCreatedBy int(11),
    IN mcUpdatedOn varchar(50),
    IN mcCreatedOn varchar(50)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO MasterClient
    (
		`Id`,
		`ClientName`,
        `CountryId`,
        `CityId`,
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
        mcCountryId,
        mcCityId,
		mcIsValid,
		mcCreatedBy,
        mcCreatedOn,
		mcCreatedBy, 
        mcCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		ClientName = mcClientName,
        CountryId = mcCountryId,
        CityId = mcCityId,
		IsValid = mcIsValid,
		UpdatedBy = mcUpdatedBy,
		UpdatedOn = mcUpdatedOn;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_Get`(
	IN mcId int(11)
)
BEGIN
	SELECT 
		a.Id, 
		a.ClientName,
        a.CountryId,
        a.CityId,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterClient a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mcId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_GetCityList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_GetCityList`(
	IN mcCountryId INT(11)
)
BEGIN

	SELECT * FROM MasterCity WHERE CountryId = mcCountryId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_GetCountryList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_GetCountryList`()
BEGIN

	SELECT * FROM MasterCountry;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_GetList`(
	IN filterText varchar(200), 
	IN recordFrom int(4), 
	IN recordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.ClientName,
        c.CountryName,
		IF(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterClient a
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id
	INNER JOIN MasterCountry c ON a.CountryId = c.Id
	WHERE 
		a.IsValid = IF(filterText = 'yes',true,false) OR
		a.ClientName LIKE concat('%', filterText,'%') OR
        a.IsValid LIKE concat('%', filterText,'%') OR
		b.FirstName LIKE concat('%', filterText,'%') OR
		b.LastName LIKE concat('%', filterText,'%') OR
		a.CreatedOn LIKE concat('%', filterText,'%')
	LIMIT 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterClient_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterClient_MarkInvalid`(
	IN mcId int(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterClient SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = mcId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterDepartment_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterDepartment_Get`(
	IN MasterDepartmentId int(11)
)
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
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterDepartment a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = MasterDepartmentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterDepartment_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterDepartment_GetList`(
	IN FilterText varchar(200), 
	IN RecordFrom int(4), 
	IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.DepartmentName,
		a.DepartmentHead,
		if(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterDepartment a
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id
	WHERE 
		a.IsValid = IF(FilterText = 'yes',true,false) OR
		a.DepartmentName LIKE concat('%', FilterText,'%') OR
		a.DepartmentHead LIKE concat('%', FilterText,'%') OR
		b.FirstName LIKE concat('%', FilterText,'%') OR
		b.LastName LIKE concat('%', FilterText,'%') OR
		a.CreatedOn LIKE concat('%', FilterText,'%')
	LIMIT 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterDepartment_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterDepartment_Insert`(
	IN departmentName VARCHAR(150),
	IN departmentHead VARCHAR(500),
	IN isValid bit,
	IN createdBy int(11),
	IN createdOn date
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO MasterDepartment
	(
		`DepartmentName`,
        `DepartmentHead`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
	(
		departmentName,
        departmentHead,
        isValid,
        createdBy,
        createdOn,
        createdBy,
        createdOn
	);
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterDepartment_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterDepartment_MarkInvalid`(IN MasterDepartmentId int(11))
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterDepartment SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = MasterDepartmentId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterDepartment_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterDepartment_Update`(
	IN departmentId int(11),
	IN departmentName VARCHAR(150),
	IN departmentHead VARCHAR(500),
	IN isValid bit,
	IN updatedby int(11),
	IN updatedon date
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterDepartment 
    SET
		`DepartmentName` = departmentName,
		`DepartmentHead` = departmentHead,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = departmentId;

	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterOrganizationRole_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterOrganizationRole_Get`(IN Id int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterOrganizationRole a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterOrganizationRole_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterOrganizationRole_GetList`(
	IN FilterText varchar(200), 
	IN RecordFrom int(4), 
	IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		IF(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterOrganizationRole a
	INNER JOIN 
		Employee b ON a.CreatedBy = b.Id
	WHERE 
		a.IsValid = IF(FilterText = 'yes',true,false) OR
		a.Role LIKE CONCAT('%', FilterText,'%') OR
		b.FirstName LIKE CONCAT('%', FilterText,'%') OR
		b.LastName LIKE CONCAT('%', FilterText,'%') OR
		a.CreatedOn LIKE CONCAT('%', FilterText,'%')
	LIMIT 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterOrganizationRole_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterOrganizationRole_Insert`(	
	IN role VARCHAR(150),
	IN isValid BIT,
	IN createdBy INT(11),
	IN createdOn DATE
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO MasterOrganizationRole
	(
		`Role`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
	(
		role,
        isValid,
        createdBy,
        createdOn,
        createdBy,
        createdOn
	);
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterOrganizationRole_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterOrganizationRole_MarkInvalid`(
	IN MasterOrganizationRoleId int(11)
)
BEGIN
	
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterOrganizationRole SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = MasterOrganizationRoleId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterOrganizationRole_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterOrganizationRole_Update`(
	IN masterOrganizationRoleId int(11),
	IN role VARCHAR(150),
	IN isValid bit,
	IN updatedby int(11),
	IN updatedon date
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterOrganizationRole 
    SET
		`Role` = role,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = masterOrganizationRoleId;

	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterProjectType_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterProjectType_AddOrUpdate`(
	IN mptId int(11),
	IN mptType varchar(150),
    IN mptIsValid bit,
    IN mptUpdatedBy int(11),
    IN mptCreatedBy int(11),
    IN mptUpdatedOn varchar(50),
    IN mptCreatedOn varchar(50)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
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
        
	COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterProjectType_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterProjectType_Get`(
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
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterProjectType a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mptId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterProjectType_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterProjectType_GetList`(
	IN filterText VARCHAR(200), 
	IN recordFrom INT(4), 
	IN recordTill INT(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Type,
		IF(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterProjectType a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = IF(filterText = 'yes',true,false) OR
		a.Type LIKE CONCAT('%', filterText,'%') OR
		b.FirstName LIKE CONCAT('%', filterText,'%') OR
		b.LastName LIKE CONCAT('%', filterText,'%') OR
		a.CreatedOn LIKE CONCAT('%', filterText,'%')
	LIMIT 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterProjectType_GetValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterProjectType_GetValidList`()
BEGIN
	SELECT * FROM MasterProjectType WHERE IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterProjectType_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterProjectType_MarkInvalid`(
	IN mptId int(11)
)
BEGIN
	
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterProjectType SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = mptId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterRole_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterRole_AddOrUpdate`(
	IN mpId int(11),
	IN mpRole varchar(150),
    IN mpIsValid bit,
    IN mpUpdatedBy int(11),
    IN mpCreatedBy int(11),
    IN mpUpdatedOn varchar(50),
    IN mpCreatedOn varchar(50)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO MasterRole 
    (
		`Id`,
		`Role`,
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
		mpIsValid,
		mpCreatedBy,
        mpCreatedOn,
		mpCreatedBy, 
        mpCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		Role = mpRole,
		IsValid = mpIsValid,
		UpdatedBy = mpUpdatedBy,
		UpdatedOn = mpUpdatedOn;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterRole_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterRole_Get`(IN mpId int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterRole a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = mpId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterRole_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterRole_GetList`(
	IN filterText VARCHAR(200), 
	IN recordFrom INT(4), 
	IN recordTill INT(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Role,
		IF(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterRole a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.Role LIKE CONCAT('%', filterText,'%') OR
		b.FirstName LIKE CONCAT('%', filterText,'%') OR
		b.LastName LIKE CONCAT('%', filterText,'%') OR
		a.CreatedOn LIKE CONCAT('%', filterText,'%') OR
        a.IsValid = IF(STRCMP(filterText,'Yes') = 0 ,true,false) 
	LIMIT 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterRole_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterRole_MarkInvalid`(
	IN masterProjectRoleId int(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    	
	UPDATE MasterRole SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = masterProjectRoleId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterSkill_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterSkill_Get`(IN MasterSkillId int(11))
BEGIN
	SELECT 
		a.Id, 
		a.Skill,
		a.IsValid, 
		a.CreatedOn, 
		a.UpdatedOn, 
		a.CreatedBy, 
		a.UpdatedBy,
		concat(b.FirstName, ' ', b.LastName) AS CreatedByName,
		concat(c.FirstName, ' ', c.LastName) AS UpdatedByName
	FROM 
		MasterSkill a 
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id 
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id 
	WHERE 
		a.Id = MasterSkillId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterSkill_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterSkill_GetList`(
	IN FilterText varchar(200), 
	IN RecordFrom int(4), 
	IN RecordTill int(4)
)
BEGIN
	SELECT 
		a.Id, 
		a.Skill,
		IF(a.IsValid,'Yes','No') AS IsValid,
		a.CreatedBy,
		DATE_FORMAT(a.CreatedOn,'%Y/%m/%d') AS CreatedOn,
		a.UpdatedBy,
		DATE_FORMAT(a.UpdatedBy,'%Y/%m/%d') AS UpdatedBy,
		CONCAT(b.FirstName ,' ', b.LastName) AS CreatedByName
	FROM 
		CuelogicResourceManagement.MasterSkill a
	INNER JOIN 
		Employee b on a.CreatedBy = b.Id
	WHERE 
		a.IsValid = IF(FilterText = 'yes',true,false) OR
		a.Skill LIKE CONCAT('%', FilterText,'%') OR
		b.FirstName LIKE CONCAT('%', FilterText,'%') OR
		b.LastName LIKE CONCAT('%', FilterText,'%') OR
		a.CreatedOn LIKE CONCAT('%', FilterText,'%')
	LIMIT 
		RecordFrom, RecordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterSkill_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterSkill_Insert`(	
	IN skill VARCHAR(150),
	IN isValid bit,
	IN createdBy int(11),
	IN createdOn date
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO MasterSkill
	(
		`Skill`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
	(
		skill,
        isValid,
        createdBy,
        createdOn,
        createdBy,
        createdOn
	);
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterSkill_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterSkill_MarkInvalid`(
	IN MasterSkillId int(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterSkill SET
	IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE Id = MasterSkillId;
    
    COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MasterSkill_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `MasterSkill_Update`(
IN masterSkillId int(11),
IN skill VARCHAR(150),
IN isValid bit,
IN updatedby int(11),
IN updatedon date
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE MasterSkill 
    SET
		`Skill` = skill,
		`IsValid` = isValid,
		`UpdatedBy` = updatedby,
		`UpdatedOn` = updatedon
	WHERE
		`Id` = masterSkillId;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_AddOrUpdate`(
	IN pId INT(11),
    IN pProjectName VARCHAR(500),
    IN pProjectTypeId INT(11),
    IN pStartDate VARCHAR(50),
    IN pEndDate VARCHAR(50),
    IN pDescription VARCHAR(500),
    IN pClientId INT(11),
    IN pIsComplete BIT,
    IN pIsValid BIT,
    IN pCreatedBy INT(11),
    IN pCreatedOn VARCHAR(50),
    IN pUpdatedBy INT(11),
    IN pUpdatedOn VARCHAR(50)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	INSERT INTO Project 
    (
		`Id`,
		`ProjectName`,
		`ProjectTypeId`,
		`StartDate`,
        `EndDate`,
        `Description`,
        `ClientId`,
        `IsComplete`,
        `IsValid`,
        `CreatedBy`,
        `CreatedOn`,
        `UpdatedBy`,
        `UpdatedOn`
	)
    VALUES
    (
		pId,
		pProjectName,
		pProjectTypeId,
		pStartDate,
        IF((pEndDate = ''), NULL,pEndDate),
		pDescription, 
        pClientId,
        pIsComplete,
        pIsValid,
        pCreatedBy,
        pCreatedOn,
        pCreatedBy,
        pCreatedOn
    )
    ON DUPLICATE KEY UPDATE
		ProjectName = pProjectName,
		ProjectTypeId = pProjectTypeId,
		StartDate = IF((pStartDate = ''), NULL,pStartDate),
        EndDate = IF((pEndDate = ''), NULL,pEndDate),
        Description = pDescription,
        ClientId = pClientId,
        IsComplete = pIsComplete,
        IsValid = pIsValid,
        UpdatedBy = pUpdatedBy,
        UpdatedOn = pUpdatedOn;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_BulkInsertRoles` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_BulkInsertRoles`(
	IN xmlText text, 
	IN user INT(11) )
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    DECLARE prId INT(11);
    DECLARE prProjectId INT(11);
    DECLARE prRoleId INT(11);
    DECLARE prBillingRate INT(11);
    DECLARE prCurrencyId INT(11);
    DECLARE prIsValid BIT;
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfProjectRole/ProjectRole)');
  
	WHILE i <= nodeCount DO
    
		SET prId = ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/Id');
		SET prProjectId = ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/ProjectId');
		SET prRoleId = ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/RoleId');
		SET prBillingRate = ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/BillingRate');
		SET prCurrencyId = ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/CurrencyId');
		SET prIsValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfProjectRole/ProjectRole[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
    
		INSERT INTO 
			ProjectRole 
        (
			`Id`,
			`ProjectId`,
            `RoleId`,
            `BillingRate`,
            `CurrencyId`,
            `IsValid`,
            `CreatedBy`,
            `CreatedOn`,
            `UpdatedBy`,
            `UpdatedOn`
		)
        VALUES
        (
			prId,
			prProjectId,
            prRoleId,
            prBillingRate,
            prCurrencyId,
            prIsValid,
            user,
            DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
            user,
            DATE_FORMAT(CURDATE(),'%Y-%m-%d')
		)
		ON DUPLICATE KEY UPDATE
			ProjectId = prProjectId,
			RoleId = prRoleId,
            BillingRate = prBillingRate,
            CurrencyId = prCurrencyId,
            IsValid = prIsValid,
			UpdatedBy = user,
			UpdatedOn = DATE_FORMAT(CURDATE(),'%Y-%m-%d');
        SET i = i+1;
        END WHILE;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_Get`(
	IN pId INT(11)
)
BEGIN
	SELECT
		a.Id,
        a.ProjectName,
        a.ProjectTypeId,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') AS StartDate,
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') AS EndDate,
        a.Description,
        a.ClientId,
        a.IsComplete,
        a.IsValid,
        a.CreatedBy,
        a.CreatedOn,
        a.UpdatedBy,
        a.UpdatedOn,
        CONCAT(b.FirstName,' ',b.LastName) AS CreatedByName,
        CONCAT(c.FirstName,' ',c.LastName) AS UpdatedByName
	FROM
		Project a
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id
	WHERE
		a.Id = pId;
        
	SELECT * FROM ProjectRole WHERE ProjectId = pId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_GetLatestId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_GetLatestId`()
BEGIN
	SELECT MAX(Id) FROM Project;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_GetList`(
	IN filterText VARCHAR(200), 
	IN recordFrom INT(4), 
	IN recordTill INT(4)
)
BEGIN
	SELECT
		a.Id, 
        a.ProjectName, 
        b.Type, 
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') AS StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') AS EndDate,
        IF(a.IsComplete,'Yes','No') AS IsComplete,
        IF(a.IsValid,'Yes','No') AS IsValid
	FROM
		Project a
	INNER JOIN 
		MasterProjectType b ON  a.ProjectTypeId = b.Id
    WHERE
		a.ProjectName like CONCAT('%', filterText,'%') OR
		b.Type LIKE CONCAT('%', filterText,'%') 
	LIMIT 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_GetSelectList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_GetSelectList`()
BEGIN
	SELECT *  FROM MasterClient WHERE IsValid = true;
    SELECT *  FROM MasterRole WHERE IsValid = true;
    SELECT *  FROM MasterCurrency;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Project_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Project_MarkInvalid`(
	IN pId INT(11)
)
BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	UPDATE Project SET
		IsValid = CASE 
		  WHEN IsValid = 1 THEN 0 
		  WHEN IsValid = 0 THEN 1 END
	WHERE
		Id = pId;
        
	COMMIT;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UserGroup_GetEmployees` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserGroup_GetEmployees`(
	IN employeeName VARCHAR(150)
)
BEGIN

	SELECT 
		Id,
        CONCAT(FirstName,' ',MiddleName,' ',LastName) AS FullName
    FROM 
		Employee 
    WHERE 
		IsValid = true
    AND
		(
			FirstName like CONCAT('%', employeeName,'%') OR
			MiddleName like CONCAT('%', employeeName,'%') OR
			LastName like CONCAT('%', employeeName,'%')
        ); 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UserGroup_GetIdentityGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserGroup_GetIdentityGroup`()
BEGIN

	SELECT * FROM IdentityGroup WHERE IsValid = true;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UserGroup_GetIdentityGroupMembers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserGroup_GetIdentityGroupMembers`(
	IN gId INT(11)
)
BEGIN
	
     SELECT 
		a.Id,
        CONCAT(a.FirstName,' ',a.MiddleName,' ',a.LastName) AS FullName,
        b.IsValid
	FROM 
		Employee a
	INNER JOIN
		IdentityEmployeeGroup b ON a.Id = b.EmployeeId
	INNER JOIN
		IdentityGroup c ON b.GroupId = c.Id
	WHERE 
		a.IsValid = true AND
        c.IsValid = true AND
        c.Id = gId
	ORDER BY 
		a.FirstName ASC;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UserGroup_InsertGroupUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UserGroup_InsertGroupUser`(IN xmlText text)
BEGIN
DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    DECLARE employeeGroupId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterGroupId INT(11);
    DECLARE isGroupValid BIT;
    DECLARE user INT(11);
    DECLARE mGroupId INT(11);
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING, NOT FOUND
	BEGIN
		ROLLBACK;
		RESIGNAL;
	END;

	START TRANSACTION; 
    
	SET nodeCount = ExtractValue(xmlText, 'count(/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup)');
		
        WHILE i <= nodeCount DO
			SET mGroupId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/GroupId');
			DELETE FROM IdentityEmployeeGroup WHERE GroupId = mGroupId;
            SET i = i+1;
		END WHILE;
        
        SET i = 1;
        
		WHILE i <= nodeCount DO
		
			SET employeeGroupId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/Id');
			SET masterEmployeeId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/EmployeeId');
			SET masterGroupId = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/GroupId');
			SET isGroupValid = CASE WHEN (ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/IsValid') = 'true') THEN 1 ELSE 0 END;
            SET user = ExtractValue(xmlText, '/ArrayOfIdentityEmployeeGroup/IdentityEmployeeGroup[$i]/CreatedBy');
            
            INSERT INTO
				IdentityEmployeeGroup
			(
                `EmployeeId`,
                `GroupId`,
                `IsValid`,
                `CreatedBy`,
                `CreatedOn`,
                `UpdatedBy`,
                `UpdatedOn`
            )
            VALUES
            (
                masterEmployeeId,
                masterGroupId,
                isGroupValid,
                user,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d'),
                user,
                DATE_FORMAT(CURDATE(),'%Y-%m-%d')
            );
                      
		SET i = i+1;
		END WHILE;
        
	COMMIT;
    
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

-- Dump completed on 2018-03-13 14:19:15
