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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Allocation`
--

LOCK TABLES `Allocation` WRITE;
/*!40000 ALTER TABLE `Allocation` DISABLE KEYS */;
INSERT INTO `Allocation` VALUES (6,18,16,18,'',0,'2017-01-01','2018-03-31','\0',17,'2018-03-08',1,'2018-03-09');
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
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES (1,'Amol','Maruti','Wabale','CUE355','2018-02-28',NULL,'9876543210','amol.wabale@cuelogic.com','',1,'2018-02-02',1,'2018-03-09'),(17,'Vivek','','Phadke','CUE238','2018-03-15',NULL,'987654321','vivek.phadke@cuelogic.co.in','',1,'2018-03-06',17,'2018-03-08'),(18,'Pranav','Ravindra','Shinde','CUE672','2018-01-05',NULL,'7854123698','pranav.shinde@cuelogic.com','',1,'2018-03-06',1,'2018-03-09'),(19,'Debujit','Shrikant','Suryavanshi','CUE295','2017-08-04',NULL,'8541235698','debujit.suryavanshi@cuelogic.com','',1,'2018-03-06',1,'2018-03-08'),(20,'Pandurang','Tukaram','Deshpande','CUE674','2017-08-04',NULL,'8745121385784','panduranf.tukaram@cuelogic.com','',1,'2018-03-06',1,'2018-03-08'),(21,'Bharat','','Puranik','CUE456','2018-02-21',NULL,'1234567895','bharat.puranik@cuelogic.com','',1,'2018-03-07',1,'2018-03-08'),(27,'Amit','','Govil','CUE333','2018-03-08',NULL,'987654321','amit.govil@cuelogic.co.in','',1,'2018-03-08',1,'2018-03-08'),(28,'Nikhil','','Babur','CUE0012','2018-03-08',NULL,'123456789','nikhil.babar@cuelogic.co.in','',1,'2018-03-08',1,'2018-03-08'),(29,'gaurav','','mothe kadam','cue250','2016-08-17',NULL,'7848578544','gaurav.mothekadam@cuelogic.co.in','\0',17,'2018-03-08',17,'2018-03-08');
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeDepartment`
--

LOCK TABLES `EmployeeDepartment` WRITE;
/*!40000 ALTER TABLE `EmployeeDepartment` DISABLE KEYS */;
INSERT INTO `EmployeeDepartment` VALUES (1,20,17,'',1,'2018-03-06',NULL,NULL),(2,20,18,'',1,'2018-03-06',NULL,NULL),(3,20,19,'',1,'2018-03-06',NULL,NULL),(4,22,1,'\0',1,'2018-03-06',1,'2018-03-08'),(5,23,1,'',1,'2018-03-06',NULL,NULL),(6,20,20,'',1,'2018-03-06',1,'2018-03-06'),(7,21,20,'',1,'2018-03-06',1,'2018-03-06'),(8,22,20,'',1,'2018-03-06',1,'2018-03-06'),(9,23,20,'',1,'2018-03-06',1,'2018-03-06'),(10,20,21,'',1,'2018-03-07',1,'2018-03-07'),(17,20,27,'',1,'2018-03-08',1,'2018-03-08'),(18,20,28,'',1,'2018-03-08',1,'2018-03-08'),(19,20,29,'',17,'2018-03-08',17,'2018-03-08');
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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeOrganizationRole`
--

LOCK TABLES `EmployeeOrganizationRole` WRITE;
/*!40000 ALTER TABLE `EmployeeOrganizationRole` DISABLE KEYS */;
INSERT INTO `EmployeeOrganizationRole` VALUES (1,17,21,'',1,'2018-03-06',NULL,NULL),(2,18,20,'',1,'2018-03-06',NULL,NULL),(3,19,25,'',1,'2018-03-06',NULL,NULL),(4,1,22,'\0',1,'2018-03-06',1,'2018-03-08'),(5,1,23,'',1,'2018-03-06',NULL,NULL),(6,20,23,'',1,'2018-03-06',1,'2018-03-06'),(7,20,24,'',1,'2018-03-06',1,'2018-03-06'),(8,20,25,'',1,'2018-03-06',1,'2018-03-06'),(9,20,26,'',1,'2018-03-06',1,'2018-03-06'),(10,21,22,'',1,'2018-03-07',1,'2018-03-07'),(11,21,23,'',1,'2018-03-07',1,'2018-03-07'),(18,27,26,'',1,'2018-03-08',1,'2018-03-08'),(19,28,21,'',1,'2018-03-08',1,'2018-03-08'),(20,29,21,'',17,'2018-03-08',17,'2018-03-08');
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
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeSkill`
--

LOCK TABLES `EmployeeSkill` WRITE;
/*!40000 ALTER TABLE `EmployeeSkill` DISABLE KEYS */;
INSERT INTO `EmployeeSkill` VALUES (1,17,28,'',1,'2018-03-06',NULL,NULL),(2,17,29,'\0',1,'2018-03-06',17,'2018-03-08'),(3,17,31,'',1,'2018-03-06',NULL,NULL),(4,17,33,'',1,'2018-03-06',NULL,NULL),(5,17,35,'',1,'2018-03-06',NULL,NULL),(6,17,37,'',1,'2018-03-06',NULL,NULL),(7,17,38,'',1,'2018-03-06',NULL,NULL),(8,18,32,'',1,'2018-03-06',NULL,NULL),(9,18,33,'',1,'2018-03-06',NULL,NULL),(10,18,34,'',1,'2018-03-06',NULL,NULL),(11,18,35,'',1,'2018-03-06',NULL,NULL),(12,18,36,'',1,'2018-03-06',NULL,NULL),(13,18,37,'',1,'2018-03-06',NULL,NULL),(14,18,38,'',1,'2018-03-06',NULL,NULL),(15,19,28,'',1,'2018-03-06',NULL,NULL),(16,19,29,'',1,'2018-03-06',NULL,NULL),(17,19,30,'',1,'2018-03-06',NULL,NULL),(18,19,31,'',1,'2018-03-06',NULL,NULL),(19,19,32,'',1,'2018-03-06',NULL,NULL),(20,19,33,'',1,'2018-03-06',NULL,NULL),(21,19,34,'',1,'2018-03-06',NULL,NULL),(22,1,28,'',1,'2018-03-06',1,'2018-03-08'),(23,1,29,'\0',1,'2018-03-06',1,'2018-03-08'),(24,1,30,'',1,'2018-03-06',NULL,NULL),(25,1,31,'',1,'2018-03-06',NULL,NULL),(26,1,32,'',1,'2018-03-06',NULL,NULL),(27,1,33,'',1,'2018-03-06',NULL,NULL),(28,1,34,'',1,'2018-03-06',NULL,NULL),(29,20,30,'',1,'2018-03-06',1,'2018-03-06'),(30,20,31,'',1,'2018-03-06',1,'2018-03-06'),(31,20,32,'',1,'2018-03-06',1,'2018-03-06'),(32,20,33,'',1,'2018-03-06',1,'2018-03-06'),(33,20,34,'',1,'2018-03-06',1,'2018-03-06'),(34,20,35,'',1,'2018-03-06',1,'2018-03-06'),(35,20,36,'',1,'2018-03-06',1,'2018-03-06'),(36,21,28,'',1,'2018-03-07',1,'2018-03-07'),(37,21,29,'',1,'2018-03-07',1,'2018-03-07'),(38,21,30,'',1,'2018-03-07',1,'2018-03-07'),(39,21,31,'',1,'2018-03-07',1,'2018-03-07'),(40,21,32,'',1,'2018-03-07',1,'2018-03-07'),(41,21,33,'',1,'2018-03-07',1,'2018-03-07'),(42,21,34,'',1,'2018-03-07',1,'2018-03-07'),(43,21,35,'',1,'2018-03-07',1,'2018-03-07'),(50,27,32,'',1,'2018-03-08',1,'2018-03-08'),(51,28,28,'',1,'2018-03-08',1,'2018-03-08'),(52,28,29,'',1,'2018-03-08',1,'2018-03-08'),(53,28,30,'',1,'2018-03-08',1,'2018-03-08'),(54,28,31,'',1,'2018-03-08',1,'2018-03-08'),(55,28,32,'',1,'2018-03-08',1,'2018-03-08'),(56,29,42,'',17,'2018-03-08',17,'2018-03-08');
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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityEmployeeGroup`
--

LOCK TABLES `IdentityEmployeeGroup` WRITE;
/*!40000 ALTER TABLE `IdentityEmployeeGroup` DISABLE KEYS */;
INSERT INTO `IdentityEmployeeGroup` VALUES (23,17,115,'',1,'2018-03-09',1,'2018-03-09'),(24,1,115,'',1,'2018-03-09',1,'2018-03-09'),(30,27,116,'',1,'2018-03-09',1,'2018-03-09'),(31,21,117,'',1,'2018-03-09',1,'2018-03-09'),(32,19,117,'',1,'2018-03-09',1,'2018-03-09'),(33,28,117,'',1,'2018-03-09',1,'2018-03-09'),(34,20,117,'',1,'2018-03-09',1,'2018-03-09'),(35,18,117,'\0',1,'2018-03-09',1,'2018-03-09');
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
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroup`
--

LOCK TABLES `IdentityGroup` WRITE;
/*!40000 ALTER TABLE `IdentityGroup` DISABLE KEYS */;
INSERT INTO `IdentityGroup` VALUES (115,'Super Admin','Super Admin','',1,'2018-03-09',1,'2018-03-09'),(116,'Manager','Manager','',1,'2018-03-09',1,'2018-03-09'),(117,'Employee','Employee','',1,'2018-03-09',1,'2018-03-09');
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
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroupRight`
--

LOCK TABLES `IdentityGroupRight` WRITE;
/*!40000 ALTER TABLE `IdentityGroupRight` DISABLE KEYS */;
INSERT INTO `IdentityGroupRight` VALUES (1,115,202,7,'\0',1,'2018-03-09',1,'2018-03-09'),(2,115,200,7,'\0',1,'2018-03-09',1,'2018-03-09'),(3,115,201,7,'\0',1,'2018-03-09',1,'2018-03-09'),(4,115,403,7,'\0',1,'2018-03-09',1,'2018-03-09'),(5,115,400,7,'\0',1,'2018-03-09',1,'2018-03-09'),(6,115,305,7,'\0',1,'2018-03-09',1,'2018-03-09'),(7,115,301,7,'\0',1,'2018-03-09',1,'2018-03-09'),(8,115,302,7,'\0',1,'2018-03-09',1,'2018-03-09'),(9,115,303,7,'\0',1,'2018-03-09',1,'2018-03-09'),(10,115,304,7,'\0',1,'2018-03-09',1,'2018-03-09'),(11,115,300,7,'\0',1,'2018-03-09',1,'2018-03-09'),(12,115,401,7,'\0',1,'2018-03-09',1,'2018-03-09'),(13,115,402,7,'\0',1,'2018-03-09',1,'2018-03-09'),(14,116,202,0,'\0',1,'2018-03-09',1,'2018-03-09'),(15,116,200,0,'\0',1,'2018-03-09',1,'2018-03-09'),(16,116,201,0,'\0',1,'2018-03-09',1,'2018-03-09'),(17,116,403,4,'\0',1,'2018-03-09',1,'2018-03-09'),(18,116,400,4,'\0',1,'2018-03-09',1,'2018-03-09'),(19,116,305,0,'\0',1,'2018-03-09',1,'2018-03-09'),(20,116,301,0,'\0',1,'2018-03-09',1,'2018-03-09'),(21,116,302,0,'\0',1,'2018-03-09',1,'2018-03-09'),(22,116,303,0,'\0',1,'2018-03-09',1,'2018-03-09'),(23,116,304,0,'\0',1,'2018-03-09',1,'2018-03-09'),(24,116,300,0,'\0',1,'2018-03-09',1,'2018-03-09'),(25,116,401,4,'\0',1,'2018-03-09',1,'2018-03-09'),(26,116,402,4,'\0',1,'2018-03-09',1,'2018-03-09'),(27,117,202,0,'\0',1,'2018-03-09',1,'2018-03-09'),(28,117,200,0,'\0',1,'2018-03-09',1,'2018-03-09'),(29,117,201,0,'\0',1,'2018-03-09',1,'2018-03-09'),(30,117,403,0,'\0',1,'2018-03-09',1,'2018-03-09'),(31,117,400,0,'\0',1,'2018-03-09',1,'2018-03-09'),(32,117,305,0,'\0',1,'2018-03-09',1,'2018-03-09'),(33,117,301,0,'\0',1,'2018-03-09',1,'2018-03-09'),(34,117,302,0,'\0',1,'2018-03-09',1,'2018-03-09'),(35,117,303,0,'\0',1,'2018-03-09',1,'2018-03-09'),(36,117,304,0,'\0',1,'2018-03-09',1,'2018-03-09'),(37,117,300,0,'\0',1,'2018-03-09',1,'2018-03-09'),(38,117,401,4,'\0',1,'2018-03-09',1,'2018-03-09'),(39,117,402,0,'\0',1,'2018-03-09',1,'2018-03-09');
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterClient`
--

LOCK TABLES `MasterClient` WRITE;
/*!40000 ALTER TABLE `MasterClient` DISABLE KEYS */;
INSERT INTO `MasterClient` VALUES (15,'Abbott Laboratories',2,6,'',1,'2018-01-01',NULL,NULL),(16,'Aarons, Inc',2,6,'',1,'2018-01-01',NULL,NULL),(17,'Walmart',2,6,'\0',1,'2018-01-01',NULL,NULL),(18,'ExxonMobil',2,6,'',1,'2018-01-01',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterDepartment`
--

LOCK TABLES `MasterDepartment` WRITE;
/*!40000 ALTER TABLE `MasterDepartment` DISABLE KEYS */;
INSERT INTO `MasterDepartment` VALUES (20,'Delivery','Vivek Phadke','',1,'2018-01-01',1,'2018-03-07'),(21,'HR','Uma Ramani','\0',1,'2018-01-01',NULL,NULL),(22,'Sales','Neel Vartikar','',1,'2018-01-01',NULL,NULL),(23,'Management','Nikhil Ambekar','',1,'2018-01-01',NULL,NULL),(24,'Technical','Vikrant Labde','',1,'2018-01-01',NULL,NULL),(25,'Admin','Admin','',1,'2018-03-06',1,'2018-03-06');
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
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterOrganizationRole`
--

LOCK TABLES `MasterOrganizationRole` WRITE;
/*!40000 ALTER TABLE `MasterOrganizationRole` DISABLE KEYS */;
INSERT INTO `MasterOrganizationRole` VALUES (20,'Software Engineer','',1,'2018-01-01',NULL,NULL),(21,'Sr. Software Engineer','',1,'2018-01-01',NULL,NULL),(22,'Devops','\0',1,'2018-01-01',NULL,NULL),(23,'Trainee Software Engineer','',1,'2018-01-01',NULL,NULL),(24,'Principle Engineer','',1,'2018-01-01',NULL,NULL),(25,'Project Manager','',1,'2018-01-01',NULL,NULL),(26,'Sr. Project Manager','',1,'2018-01-01',NULL,NULL),(27,'Rails Developer','',1,'2018-03-06',1,'2018-03-06');
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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectRole`
--

LOCK TABLES `MasterProjectRole` WRITE;
/*!40000 ALTER TABLE `MasterProjectRole` DISABLE KEYS */;
INSERT INTO `MasterProjectRole` VALUES (13,'Developer',20000,'',1,'2018-01-01',NULL,NULL),(14,'Product Developer',30000,'',1,'2018-01-01',NULL,NULL),(15,'Technical Analyst',25000,'\0',1,'2018-01-01',NULL,NULL),(16,'Ui Engineer',35000,'',1,'2018-01-01',NULL,NULL),(17,'Backend Developer',50000,'',1,'2018-01-01',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectType`
--

LOCK TABLES `MasterProjectType` WRITE;
/*!40000 ALTER TABLE `MasterProjectType` DISABLE KEYS */;
INSERT INTO `MasterProjectType` VALUES (11,'Billable','',1,'2018-01-01',NULL,NULL),(12,'Non Billable','\0',1,'2018-01-01',NULL,NULL),(13,'In House','',1,'2018-01-01',NULL,NULL),(14,'R & D','',1,'2018-01-01',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterSkill`
--

LOCK TABLES `MasterSkill` WRITE;
/*!40000 ALTER TABLE `MasterSkill` DISABLE KEYS */;
INSERT INTO `MasterSkill` VALUES (28,'C#','',1,'2018-01-01',NULL,NULL),(29,'Html','',1,'2018-01-01',NULL,NULL),(30,'Jquery','',1,'2018-01-01',NULL,NULL),(31,'Javascript','\0',1,'2018-01-01',NULL,NULL),(32,'SQL','',1,'2018-01-01',NULL,NULL),(33,'AngularJS 1','',1,'2018-01-01',NULL,NULL),(34,'Angular 4','',1,'2018-01-01',NULL,NULL),(35,'LINQ','',1,'2018-01-01',NULL,NULL),(36,'Entity Framework','',1,'2018-01-01',NULL,NULL),(37,'Ionic Cordova','',1,'2018-01-01',NULL,NULL),(38,'Scala','',1,'2018-01-01',NULL,NULL),(39,'Swift','',1,'2018-01-01',NULL,NULL),(40,'Python','',1,'2018-01-01',NULL,NULL),(41,'NodeJS','',1,'2018-01-01',NULL,NULL),(42,'Ruby On Rails','',1,'2018-03-06',1,'2018-03-06');
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
  `CurrencyId` int(11) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Project`
--

LOCK TABLES `Project` WRITE;
/*!40000 ALTER TABLE `Project` DISABLE KEYS */;
INSERT INTO `Project` VALUES (15,'Kantar',11,'2017-07-01',NULL,'Kantar',2,16,'\0','',1,'2018-03-06',NULL,NULL),(16,'Tiny Torch',11,'2017-01-01',NULL,'Tiny Torch',3,15,'\0','\0',1,'2018-03-06',NULL,NULL),(17,'Cuelogic Resource Management',13,'2018-01-15',NULL,'Cuelogic Resource Management',1,15,'\0','',1,'2018-03-06',1,NULL),(18,'Big Data Charting System',11,'2018-03-01',NULL,'Big Data Charting System',2,18,'\0','',1,'2018-03-06',1,'2018-03-06');
/*!40000 ALTER TABLE `Project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'CuelogicResourceManagement'
--

--
-- Dumping routines for database 'CuelogicResourceManagement'
--
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_AddOrUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_AddOrUpdate`(
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_Get`(
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
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate,
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        a.IsValid,
		a.CreatedBy,
		a.CreatedOn,
		a.UpdatedBy,
		a.UpdatedOn,
        CONCAT(b.FirstName,' ',b.LastName) as CreatedByName,
        CONCAT(c.FirstName,' ',c.LastName) as UpdatedByName
	FROM
		Allocation a
	LEFT JOIN 
		Employee b ON a.CreatedBy = b.Id
	LEFT JOIN 
		Employee c ON a.UpdatedBy = c.Id
	WHERE
		a.Id = aId
	Group By a.EmployeeId;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_GetAllocationSum` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_GetAllocationSum`(
	IN aId INT(11)
)
BEGIN
	SELECT SUM(PercentageAllocation) FROM Allocation WHERE EmployeeId = aId AND IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_GetList`(
IN filterText varchar(200), 
IN recordFrom int(4), 
IN recordTill int(4)
)
BEGIN
	SELECT
		a.Id,
        CONCAT(b.FirstName,' ', b.MiddleName ,' ',b.LastName) as FullName,
        c.Role,
        d.ProjectName,
        if(a.IsBillable,'Yes','No') as IsBillable,
        a.PercentageAllocation,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        if(a.IsValid,'Yes','No') as IsValid
	FROM 
		Allocation a
	INNER JOIN Employee b ON a.EmployeeId = b.Id
    INNER JOIN MasterProjectRole c ON a.ProjectRoleId = c.Id
    INNER JOIN Project d ON a.ProjectId = d.Id
    WHERE
		b.FirstName like concat('%', filterText,'%') or
		b.MiddleName like concat('%', filterText,'%') or
		b.LastName like concat('%', filterText,'%') or
		c.Role like concat('%', filterText,'%') or
		d.ProjectName like concat('%', filterText,'%') or
		a.StartDate like concat('%', filterText,'%') or
		a.EndDate like concat('%', filterText,'%') or
		a.PercentageAllocation like concat('%', filterText,'%') or
		a.IsBillable = if(filterText = 'yes',true,false) or
        a.IsValid = if(filterText = 'yes',true,false)
	ORDER BY a. EmployeeId Asc
	limit 
		recordFrom, recordTill;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_GetSelectList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_GetSelectList`()
BEGIN
	SELECT Id, CONCAT(FirstName,' ',MiddleName,' ',LastName) AS FullName FROM Employee WHERE IsValid = true;
    SELECT Id, Role FROM MasterProjectRole  WHERE IsValid = true;
    SELECT Id, ProjectName FROM Project  WHERE IsValid = true;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAllocation_MarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAllocation_MarkInvalid`(
	IN aId INT(11)
)
BEGIN
	UPDATE Allocation SET
		IsValid = false
	WHERE
		Id = aId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeAllocation_GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeAllocation_GetList`(
	IN employeeId INT(11)
)
BEGIN
	
	SELECT
		a.Id,
        CONCAT(b.FirstName,' ', b.MiddleName ,' ',b.LastName) as FullName,
        c.Role,
        d.ProjectName,
        if(a.IsBillable,'Yes','No') as IsBillable,
        a.PercentageAllocation,
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        if(a.IsValid,'Yes','No') as IsValid
	FROM 
		Allocation a
	INNER JOIN Employee b ON a.EmployeeId = b.Id
    INNER JOIN MasterProjectRole c ON a.ProjectRoleId = c.Id
    INNER JOIN Project d ON a.ProjectId = d.Id
    WHERE
		a.EmployeeId = employeeId;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEmployeeRights_Get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployeeRights_Get`(
	IN employeeId INT(11)
)
BEGIN
	SELECT 
		d.Id,d.GroupId, d.RightId,d.Action,d.IsValid,d.CreatedBy,d.CreatedOn,
        d.UpdatedBy,d.UpdatedOn
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
/*!50003 DROP PROCEDURE IF EXISTS `spEmployee_GetByOrgEmpId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmployee_GetByOrgEmpId`(
	IN eOrgEmpId varchar(150)
)
BEGIN
select * from Employee where OrgEmpId = eOrgEmpId;
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
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId
    ORDER BY a.IsValid = true DESC;
    
	SELECT a.Id, a.EmployeeId, a.DepartmentId, a.IsValid, a.CreatedBy, 
    a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.DepartmentName  
    FROM EmployeeDepartment a
    INNER JOIN
		MasterDepartment b ON a.DepartmentId = b. Id
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId
    ORDER BY a.IsValid = true DESC;
    
	SELECT a.Id, a.EmployeeId, a.SkillId, a.IsValid, a.CreatedBy, a.CreatedOn,
    a.UpdatedBy, a.UpdatedOn, b.Skill AS SkillName FROM EmployeeSkill  a 
    INNER JOIN
		MasterSkill b ON a.SkillId = b. Id
    WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId
    ORDER BY a.IsValid = true DESC;
    
    SELECT a.Id, a.EmployeeId, a.RoleId, a.IsValid, a.CreatedBy, 
    a.CreatedOn, a.UpdatedBy, a.UpdatedOn, b.Role AS RoleName
    FROM EmployeeOrganizationRole a 
    INNER JOIN
		MasterOrganizationRole b ON a.RoleId = b. Id
	WHERE b.IsValid = true AND a.EmployeeId = masterEmployeeId
    ORDER BY a.IsValid = true DESC;
    
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
        (`GroupId`,`RightId`,`Action`,`IsValid`,`CreatedBy`,`CreatedOn`,`UpdatedBy`,`UpdatedOn`)
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
inner join IdentityRight a on a.RightId = b.RightId
left join Employee c on b.CreatedBy = c.Id 
left join Employee d on b.UpdatedBy = d.Id 
where b.GroupId = GroupId
order by a.RightTitle asc;
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
    (`GroupName`,`GroupDescription`,`IsValid`,`CreatedBy`,`CreatedOn`,`UpdatedBy`,`UpdatedOn`)
    VALUES
    (groupName,groupDesc,isValid,createdBy,createdOn,createdBy,createdOn);
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
	SELECT * FROM IdentityRight ORDER BY RightTitle Asc;
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
    IN mcCountryId int(11),
    IN mcCityId int(11),
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
        a.CountryId,
        a.CityId,
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
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_GetCityList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_GetCityList`(
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
/*!50003 DROP PROCEDURE IF EXISTS `spMasterClient_GetCountryList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterClient_GetCountryList`()
BEGIN

	SELECT * FROM MasterCountry;
    
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
        c.CountryName,
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
	INNER JOIN MasterCountry c on a.CountryId = c.Id
	WHERE 
		a.IsValid = if(filterText = 'yes',true,false) or
		a.ClientName like concat('%', filterText,'%') or
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
		(`DepartmentName`,`DepartmentHead`,`IsValid`,`CreatedBy`,`CreatedOn`,`UpdatedBy`,`UpdatedOn`)
    VALUES
		(departmentName,departmentHead,isValid,createdBy,createdOn,createdBy,createdOn);
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
		(`Role`,`IsValid`,`CreatedBy`,`CreatedOn`,`UpdatedBy`,`UpdatedOn`)
    VALUES
		(role,isValid,createdBy,createdOn,createdBy,createdOn);
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
		a.Role like concat('%', filterText,'%') or
		b.FirstName like concat('%', filterText,'%') or
		b.LastName like concat('%', filterText,'%') or
		a.CreatedOn like concat('%', filterText,'%') or
        a.IsValid = if(STRCMP(filterText,'Yes') = 0 ,true,false) 
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
/*!50003 DROP PROCEDURE IF EXISTS `spMasterProjectType_GetValidList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterProjectType_GetValidList`()
BEGIN
	SELECT * FROM MasterProjectType WHERE IsValid = true;
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
		(`Skill`,`IsValid`,`CreatedBy`,`CreatedOn`,`UpdatedBy`,`UpdatedOn`)
    VALUES
		(skill,isValid,createdBy,createdOn,createdBy,createdOn);
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
    IN pCurrencyId INT(11),
    IN pClientId INT(11),
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
        `CurrencyId`,
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
        pCurrencyId,
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
        CurrencyId = pCurrencyId,
        ClientId = pClientId,
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
        a.CurrencyId,
        a.ClientId,
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
		Employee c ON a.UpdatedBy = c.Id
	WHERE
		a.Id = pId;
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
		a.Id, 
        a.ProjectName, 
        b.Type, 
        DATE_FORMAT(a.StartDate,'%Y/%m/%d') as StartDate, 
        DATE_FORMAT(a.EndDate,'%Y/%m/%d') as EndDate,
        if(a.IsComplete,'Yes','No') as IsComplete,
        if(a.IsValid,'Yes','No') as IsValid
	FROM
		Project a
	INNER JOIN 
		MasterProjectType b ON  a.ProjectTypeId = b.Id
    WHERE
		a.ProjectName like concat('%', filterText,'%') or
		b.Type like concat('%', filterText,'%') 
	limit 
		recordFrom, recordTill;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProject_GetSelectList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProject_GetSelectList`()
BEGIN
	SELECT *  FROM MasterClient WHERE IsValid = true;
    SELECT *  FROM MasterCurrency;
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
/*!50003 DROP PROCEDURE IF EXISTS `spUserGroup_GetEmployees` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUserGroup_GetEmployees`(
	IN employeeName VARCHAR(150)
)
BEGIN

	SELECT 
		Id,
        CONCAT(FirstName,' ',MiddleName,' ',LastName) as FullName
    FROM 
		Employee 
    WHERE 
		IsValid = true
    AND
		(FirstName like concat('%', employeeName,'%') or
        MiddleName like concat('%', employeeName,'%') or
		LastName like concat('%', employeeName,'%')); 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUserGroup_GetIdentityGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUserGroup_GetIdentityGroup`()
BEGIN

	SELECT * FROM IdentityGroup WHERE IsValid = true;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUserGroup_GetIdentityGroupMembers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUserGroup_GetIdentityGroupMembers`(
	IN gId INT(11)
)
BEGIN
	
     SELECT 
		a.Id,
        CONCAT(a.FirstName,' ',a.MiddleName,' ',a.LastName) as FullName,
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
/*!50003 DROP PROCEDURE IF EXISTS `spUserGroup_InsertGroupUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUserGroup_InsertGroupUser`(IN xmlText text)
BEGIN
DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
    
    DECLARE employeeGroupId INT(11);
    DECLARE masterEmployeeId INT(11);
    DECLARE masterGroupId INT(11);
    DECLARE isGroupValid BIT;
    DECLARE user INT(11);
    DECLARE mGroupId INT(11);
    
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

-- Dump completed on 2018-03-09 18:55:06
