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
  `CreatedOn` int(11) NOT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
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
  KEY `IdentityGroupCreatedBy_Employee_Id` (`CreatedBy`),
  KEY `IdentityGroupUpdatedBy_Employee_Id` (`UpdatedBy`),
  CONSTRAINT `IdentityGroupCreatedBy_Employee_Id` FOREIGN KEY (`CreatedBy`) REFERENCES `Employee` (`Id`),
  CONSTRAINT `IdentityGroupUpdatedBy_Employee_Id` FOREIGN KEY (`UpdatedBy`) REFERENCES `Employee` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroup`
--

LOCK TABLES `IdentityGroup` WRITE;
/*!40000 ALTER TABLE `IdentityGroup` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityGroupRight`
--

LOCK TABLES `IdentityGroupRight` WRITE;
/*!40000 ALTER TABLE `IdentityGroupRight` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityRight`
--

LOCK TABLES `IdentityRight` WRITE;
/*!40000 ALTER TABLE `IdentityRight` DISABLE KEYS */;
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
  `Name` varchar(150) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MasterDepartment`
--

LOCK TABLES `MasterDepartment` WRITE;
/*!40000 ALTER TABLE `MasterDepartment` DISABLE KEYS */;
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-30 14:30:00
