-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: guardian
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` int NOT NULL,
  `Full_name` text NOT NULL,
  `Gender` char(1) NOT NULL,
  `Post` int NOT NULL,
  `Type` int DEFAULT NULL,
  `Secret_word` varchar(45) DEFAULT NULL,
  `Login` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Photo` text,
  `Verificated` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `Post_idx` (`Post`),
  KEY `Type_idx` (`Type`),
  CONSTRAINT `Post` FOREIGN KEY (`Post`) REFERENCES `user_post` (`ID`),
  CONSTRAINT `Type` FOREIGN KEY (`Type`) REFERENCES `user_type` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Уварова Агрипина Валентиновна','Ж',1,1,'Сова','Agripina17','obdxbosmqa',NULL,1),(2,'Горбунов Юрин Валерианович','М',2,2,'Спутник','YUrin68','hibljzslmv',NULL,1),(3,'Федотов Климент Васильевич','М',3,3,'Фобос','Kliment119','lpghliewgw',NULL,1),(4,'Бобылева Жанна Петровна','Ж',4,4,'Краска','Zhanna95','ultxzjtryl',NULL,1),(5,'Русаков Семен Леонтьевич','М',3,3,'Стекло','Semen150','ltlyheruzc',NULL,1),(6,'Гусева Юстина Антоновна','Ж',4,4,'Буря','YUstina138','drfocfsdjm',NULL,1),(7,'Мусифуллин Тимур Эдуардович','М',2,NULL,NULL,NULL,NULL,NULL,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_post`
--

DROP TABLE IF EXISTS `user_post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_post` (
  `ID` int NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_post`
--

LOCK TABLES `user_post` WRITE;
/*!40000 ALTER TABLE `user_post` DISABLE KEYS */;
INSERT INTO `user_post` VALUES (1,'Администратор доступа'),(2,'Специалист по ИБ'),(3,'Руководитель отдела'),(4,'Контролёр ГОЗ');
/*!40000 ALTER TABLE `user_post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_type`
--

DROP TABLE IF EXISTS `user_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_type` (
  `ID` int NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_type`
--

LOCK TABLES `user_type` WRITE;
/*!40000 ALTER TABLE `user_type` DISABLE KEYS */;
INSERT INTO `user_type` VALUES (1,'Администратор доступа'),(2,'Служба ИБ'),(3,'Руководитель ПОП'),(4,'Контролёр МО');
/*!40000 ALTER TABLE `user_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'guardian'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-30 14:51:41
