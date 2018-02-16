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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES (1,'Amol','Maruti','Wabale','CUE355','0000-00-00','2018-02-02','9595519028','amol.wabale@cuelogic.com','',1,'2018-02-02',NULL,NULL),(2,'Vivek','-','Phadke','CUE355','0000-00-00',NULL,'9595519028','Vivek.Phadke@cuelogic.com','',1,'2018-02-03',NULL,NULL);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeDepartment`
--

LOCK TABLES `EmployeeDepartment` WRITE;
/*!40000 ALTER TABLE `EmployeeDepartment` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeOrganizationRole`
--

LOCK TABLES `EmployeeOrganizationRole` WRITE;
/*!40000 ALTER TABLE `EmployeeOrganizationRole` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeSkill`
--

LOCK TABLES `EmployeeSkill` WRITE;
/*!40000 ALTER TABLE `EmployeeSkill` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityEmployeeGroup`
--

LOCK TABLES `IdentityEmployeeGroup` WRITE;
/*!40000 ALTER TABLE `IdentityEmployeeGroup` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroup`
--

LOCK TABLES `IdentityGroup` WRITE;
/*!40000 ALTER TABLE `IdentityGroup` DISABLE KEYS */;
INSERT INTO `IdentityGroup` VALUES (1,'Super Admin','Super Admin','',1,'2018-02-05',1,'2018-02-16'),(61,'Admin','admin','\0',1,'2018-02-14',NULL,NULL),(62,'Admin','Admin','',1,'2018-02-06',1,'2018-02-16'),(63,'Staff','Staff','',1,'2018-03-06',NULL,NULL),(64,'User','User','',1,'2018-02-07',NULL,NULL),(65,'Employee','Employee','',1,'2018-02-08',NULL,NULL),(66,'Hr','Hr','',1,'2018-02-10',NULL,NULL),(67,'Sales','Sales','',1,'2018-02-12',NULL,NULL),(68,'Delivery','Delivery','',1,'2017-10-06',NULL,NULL),(69,'Non Technical','Non Technical','',1,'2018-03-14',NULL,NULL),(70,'Infrastructure','Infrastructure','',1,'2018-02-21',NULL,NULL),(71,'Hardware','Hardware','',1,'2018-02-28',NULL,NULL),(72,'Interior','Interior','',1,'2018-01-01',NULL,NULL),(73,'Admin','Admin','',1,'2018-02-06',NULL,NULL),(74,'Staff','Staff','',1,'2018-03-06',NULL,NULL),(75,'User','User','',1,'2018-02-07',NULL,NULL),(76,'Employee','Employee','',1,'2018-02-08',NULL,NULL),(77,'Hr','Hr','',1,'2018-02-10',NULL,NULL),(78,'Sales','Sales','',1,'2018-02-12',NULL,NULL),(79,'Delivery','Delivery','',1,'2017-10-06',NULL,NULL),(80,'Non Technical','Non Technical','',1,'2018-03-14',NULL,NULL),(81,'Infrastructure','Infrastructure','',1,'2018-02-21',NULL,NULL),(82,'Hardware','Hardware','',1,'2018-02-28',NULL,NULL),(83,'Interior','Interior','',1,'2018-01-01',NULL,NULL),(84,'adsas','asdasd','\0',1,'2018-02-15',NULL,NULL),(85,'we','we','\0',1,'2018-02-15',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroupRight`
--

LOCK TABLES `IdentityGroupRight` WRITE;
/*!40000 ALTER TABLE `IdentityGroupRight` DISABLE KEYS */;
INSERT INTO `IdentityGroupRight` VALUES (1,1,1,7,'',1,'2018-02-02',1,'2018-02-16'),(14,1,2,7,'',1,'2018-02-02',1,'2018-02-16'),(15,1,3,7,'',1,'2018-02-02',1,'2018-02-16'),(28,61,1,6,'\0',1,'2018-02-14',NULL,NULL),(29,61,2,6,'\0',1,'2018-02-14',NULL,NULL),(30,61,3,6,'\0',1,'2018-02-14',NULL,NULL),(31,84,1,6,'\0',1,'2018-02-15',NULL,NULL),(32,84,2,6,'\0',1,'2018-02-15',NULL,NULL),(33,84,3,4,'\0',1,'2018-02-15',NULL,NULL),(34,85,1,4,'\0',1,'2018-02-15',NULL,NULL),(35,85,2,4,'\0',1,'2018-02-15',NULL,NULL),(36,85,3,4,'\0',1,'2018-02-15',NULL,NULL);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterClient`
--

LOCK TABLES `MasterClient` WRITE;
/*!40000 ALTER TABLE `MasterClient` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterDepartment`
--

LOCK TABLES `MasterDepartment` WRITE;
/*!40000 ALTER TABLE `MasterDepartment` DISABLE KEYS */;
INSERT INTO `MasterDepartment` VALUES (1,'Delivery','Vivek Pandhre','',1,'2010-01-01',1,'2018-02-16'),(2,'amoluiouio cvbcvb cvb cvb','Wabale','',1,'2018-02-16',1,'2018-02-16'),(3,'iop','iop','\0',1,'2018-02-16',NULL,NULL);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterOrganizationRole`
--

LOCK TABLES `MasterOrganizationRole` WRITE;
/*!40000 ALTER TABLE `MasterOrganizationRole` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectRole`
--

LOCK TABLES `MasterProjectRole` WRITE;
/*!40000 ALTER TABLE `MasterProjectRole` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterProjectType`
--

LOCK TABLES `MasterProjectType` WRITE;
/*!40000 ALTER TABLE `MasterProjectType` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterSkill`
--

LOCK TABLES `MasterSkill` WRITE;
/*!40000 ALTER TABLE `MasterSkill` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Project`
--

LOCK TABLES `Project` WRITE;
/*!40000 ALTER TABLE `Project` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProjectClient`
--

LOCK TABLES `ProjectClient` WRITE;
/*!40000 ALTER TABLE `ProjectClient` DISABLE KEYS */;
/*!40000 ALTER TABLE `ProjectClient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'CuelogicResourceManagement'
--

--
-- Dumping routines for database 'CuelogicResourceManagement'
--
/*!50003 DROP PROCEDURE IF EXISTS `spBulkInsertIdentityGroupRight` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spBulkInsertIdentityGroupRight`(IN xmltext text)
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
/*!50003 DROP PROCEDURE IF EXISTS `spBulkUpdateIdentityGroupRight` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spBulkUpdateIdentityGroupRight`(IN xmltext text)
BEGIN
	DECLARE i INT DEFAULT 1;
	DECLARE nodeCount INT(11);
	SET nodeCount = ExtractValue(xmltext, 'count(/ArrayOfIdentityGroupRight/IdentityGroupRight)');
	WHILE i <= nodeCount DO
		UPDATE IdentityGroupRight 
        SET
			GroupId = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/GroupId'),
			RightId = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/RightId'),
			Action = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Action'),
			IsValid = IF(ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/IsValid') = 'true',1,0),
			UpdatedBy = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/UpdatedBy'),
			UpdatedOn = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/UpdatedOn')
		WHERE Id = ExtractValue(xmltext, '/ArrayOfIdentityGroupRight/IdentityGroupRight[$i]/Id');
        SET i = i+1;
	END WHILE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeByEmailId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetEmployeeByEmailId`(IN EmailId varchar(100))
BEGIN
select * from Employee where Email = EmailId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetIdentityGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIdentityGroup`(IN GroupId int(4))
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetIdentityGroupList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIdentityGroupList`(
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetIdentityGroupRights` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIdentityGroupRights`(IN GroupId int(4))
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetIdentityRight` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIdentityRight`()
BEGIN
	SELECT * FROM IdentityRight;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMasterDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMasterDepartment`(IN MasterDepartmentId int(11))
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetMasterDepartmentList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMasterDepartmentList`(
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
/*!50003 DROP PROCEDURE IF EXISTS `spIdentityGroupMarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIdentityGroupMarkInvalid`(IN groupId int(11))
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
/*!50003 DROP PROCEDURE IF EXISTS `spInsertIdentityGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertIdentityGroup`(
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
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMasterDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMasterDepartment`(
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
	SELECT max(Id) from MasterDepartment;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMasterDepartmentMarkInvalid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMasterDepartmentMarkInvalid`(IN MasterDepartmentId int(11))
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
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateIdentityGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateIdentityGroup`(
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
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMasterDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMasterDepartment`(
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-16 20:11:02
