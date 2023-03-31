-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: the_guardian_pro
-- ------------------------------------------------------
-- Server version	8.0.25

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
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `Id` int NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'Общий отдел'),(2,'Охрана');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `division`
--

DROP TABLE IF EXISTS `division`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `division` (
  `ID` int NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `division`
--

LOCK TABLES `division` WRITE;
/*!40000 ALTER TABLE `division` DISABLE KEYS */;
INSERT INTO `division` VALUES (1,'Производство'),(2,'Сбыт'),(3,'Администрация'),(4,'Служба безопасности'),(5,'Планирование');
/*!40000 ALTER TABLE `division` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `groups` (
  `Group_id` int NOT NULL,
  `Date_of_creation` date NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`Group_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (1,'2023-04-24','Производство Фомичева'),(2,'2023-04-24','Производство Фомичева');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purpos_of_the_visit`
--

DROP TABLE IF EXISTS `purpos_of_the_visit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purpos_of_the_visit` (
  `ID` int NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purpos_of_the_visit`
--

LOCK TABLES `purpos_of_the_visit` WRITE;
/*!40000 ALTER TABLE `purpos_of_the_visit` DISABLE KEYS */;
INSERT INTO `purpos_of_the_visit` VALUES (1,'Прогулка'),(2,'Школьная экскурсия'),(3,'Туристическая экскурсия');
/*!40000 ALTER TABLE `purpos_of_the_visit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requests` (
  `ID` int NOT NULL,
  `Type` varchar(10) NOT NULL,
  `Division` int NOT NULL,
  `VisitorId` int NOT NULL,
  `GroupId` int DEFAULT NULL,
  `Datetime` datetime NOT NULL,
  `Status` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Visitor` (`Status`),
  KEY `Visitor_idx` (`VisitorId`),
  KEY `Group_idx` (`GroupId`),
  KEY `Division_idx` (`Division`),
  CONSTRAINT `Division` FOREIGN KEY (`Division`) REFERENCES `division` (`ID`),
  CONSTRAINT `Groups` FOREIGN KEY (`GroupId`) REFERENCES `groups` (`Group_id`),
  CONSTRAINT `Status` FOREIGN KEY (`Status`) REFERENCES `status` (`ID`),
  CONSTRAINT `Visitors` FOREIGN KEY (`VisitorId`) REFERENCES `visitor` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requests`
--

LOCK TABLES `requests` WRITE;
/*!40000 ALTER TABLE `requests` DISABLE KEYS */;
INSERT INTO `requests` VALUES (2,'Групповая',1,2,1,'2023-03-01 15:34:00',2),(3,'Групповая',1,3,1,'2023-03-13 19:32:00',3),(4,'Групповая',1,4,1,'2023-03-15 15:12:00',NULL);
/*!40000 ALTER TABLE `requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `Staff_id` int NOT NULL,
  `Full_name` text NOT NULL,
  `Division` int DEFAULT NULL,
  `Department` int DEFAULT NULL,
  PRIMARY KEY (`Staff_id`),
  KEY `Division_idx` (`Department`),
  KEY `Department_idx` (`Division`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (9362831,'Марков Юрий Романович',NULL,2),(9362832,'Архипов Тимофей Васильевич',4,NULL),(9367788,'Фомичева Авдотья Трофимовна',1,NULL),(9404040,'Чернов Всеволод Наумович',NULL,2),(9736379,'Носкова Наталия Прохоровна',3,NULL),(9737848,'Орехова Вероника Артемовна',5,NULL),(9768239,'Савельев Павел Степанович',NULL,1),(9788737,'Гаврилова Римма Ефимовна',2,NULL);
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `ID` int NOT NULL,
  `Status` tinyint NOT NULL,
  `Discription` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,1,'Одобрено'),(2,1,'Одобрено'),(3,0,'Не одобрено');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visit`
--

DROP TABLE IF EXISTS `visit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit` (
  `Visit_id` int NOT NULL,
  `Visitor_id` int NOT NULL,
  `Visit_date` datetime NOT NULL,
  `Group_id` int DEFAULT NULL,
  PRIMARY KEY (`Visit_id`),
  KEY `Group_idx` (`Group_id`),
  KEY `Visitor_idx` (`Visitor_id`),
  CONSTRAINT `Group` FOREIGN KEY (`Group_id`) REFERENCES `groups` (`Group_id`),
  CONSTRAINT `Visitor` FOREIGN KEY (`Visitor_id`) REFERENCES `visitor` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit`
--

LOCK TABLES `visit` WRITE;
/*!40000 ALTER TABLE `visit` DISABLE KEYS */;
INSERT INTO `visit` VALUES (1,1,'2024-04-20 00:00:00',NULL),(2,2,'2024-04-20 00:00:00',NULL),(3,3,'2024-04-20 00:00:00',NULL),(4,4,'2025-04-20 00:00:00',NULL),(5,5,'2025-04-20 00:00:00',NULL),(6,6,'2025-04-20 00:00:00',NULL),(7,7,'2026-04-20 00:00:00',NULL),(8,8,'2026-04-20 00:00:00',NULL),(9,9,'2026-04-20 00:00:00',NULL),(10,10,'2027-04-20 00:00:00',NULL),(11,11,'2027-04-20 00:00:00',NULL),(12,12,'2027-04-20 00:00:00',NULL),(13,13,'2028-04-20 00:00:00',NULL),(14,14,'2028-04-20 00:00:00',NULL),(15,15,'2028-04-20 00:00:00',NULL),(16,16,'2024-04-20 00:00:00',1),(17,17,'2024-04-20 00:00:00',1),(18,18,'2024-04-20 00:00:00',1),(19,19,'2024-04-20 00:00:00',1),(20,20,'2024-04-20 00:00:00',1),(21,21,'2024-04-20 00:00:00',1),(22,22,'2024-04-20 00:00:00',1),(23,23,'2024-04-20 00:00:00',1),(24,24,'2024-04-20 00:00:00',2),(25,25,'2024-04-20 00:00:00',2),(26,26,'2024-04-20 00:00:00',2),(27,27,'2024-04-20 00:00:00',2),(28,28,'2024-04-20 00:00:00',2),(29,29,'2024-04-20 00:00:00',2),(30,30,'2024-04-20 00:00:00',2);
/*!40000 ALTER TABLE `visit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visitor`
--

DROP TABLE IF EXISTS `visitor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visitor` (
  `ID` int NOT NULL,
  `Full_name` text,
  `Phone_number` varchar(45) DEFAULT NULL,
  `Email` text NOT NULL,
  `Visitor_passport` char(11) DEFAULT NULL,
  `Birthdate` date DEFAULT NULL,
  `Login` text,
  `Password` varchar(45) NOT NULL,
  `Blacklist` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visitor`
--

LOCK TABLES `visitor` WRITE;
/*!40000 ALTER TABLE `visitor` DISABLE KEYS */;
INSERT INTO `visitor` VALUES (1,'Степанова Радинка Власовна','+7 (613) 272-60-62','Radinka100@yandex.ru','208530509','1986-10-18','Vlas86','b3uWS6#Thuvq',0),(2,'Богданов Елизар Артемович','+7 (165) 768-30-97','Elizar30@yandex.ru','573198559','1978-02-02','Elizar30','wJs1~r3RS~dr',0),(3,'Овчинников Кузьма Ефимович','+7 (562) 866-15-27','Kuzjma124@yandex.ru','766647226','1993-08-02','Kuzjma124','OsByQJ}vYznW',0),(4,'Голубев Леонтий Вячеславович','+7 (160) 527-57-41','Leontij161@mail.ru','1059822077','1990-10-03','Leontij161','KkMY8yKw@oCa',0),(5,'Петухов Тарас Фадеевич','+7 (376) 220-62-51','Taras24@rambler.ru','1609171096','1991-01-05','Taras24','07m5yspn3K~K',0),(6,'Мартынов Яков Ростиславович','+7 (546) 159-67-33','YAkov196@rambler.ru','1793986063','1976-12-05','YAkov196','$6s5bggKP7aw',0),(7,'Исаев Лев Юлианович','+7 (675) 593-89-30','Lev131@rambler.ru','1860680004','1994-08-05','Lev131','~?oj2Lh@S7*T',0),(8,'Лыткин Алексей Максимович','+7 (994) 353-29-52','Aleksej43@gmail.com','2383259825','1996-03-07','Aleksej43','~c%PlTY0?qgl',0),(9,'Беляков Роман Викторович','+7 (595) 196-56-28','Roman89@gmail.com','2411478305','1991-06-07','Roman89','Xd?xP$2yICcG',0),(10,'Кононов Юрин Романович','+7 (784) 673-51-91','YUrin155@gmail.com','2747790512','1971-10-08','YUrin155','u@m*~ACBCqNQ',0),(11,'Шилов Прохор Герасимович','+7 (615) 594-77-66','Prohor156@list.ru','3036796488','1977-10-09','Prohor156','zDdom}SIhWs?',0),(12,'Кузьмина Вера Максимовна','+7 (598) 583-53-45','Vera195@list.ru','3537982933','1989-12-10','Vera195','B|5v$2r$7luL',0),(13,'Родионов Аркадий Власович','+7 (491) 696-17-11','Arkadij123@inbox.ru','3841642594','1993-08-11','Arkadij123','vk2N7lxX}ck%',0),(14,'Орехов Сергей Емельянович','+7 (669) 603-29-87','Sergej35@inbox.ru','3844223682','1972-02-11','Sergej35','$39vc%ljqN%r',0),(15,'Исаев Георгий Павлович','+7 (678) 516-36-86','Georgij121@inbox.ru','4076629809','1987-08-11','Georgij121','bbx5H}f*BC?w',0),(16,'Никифоров Даниил Степанович','+7 (384) 358-77-82','Daniil198@bk.ru','4557999958','1970-12-13','lzaihtvkdn','L2W#uo7z{EsO',0),(17,'Самойлова Таисия Гермоновна','+7 (891) 555-81-44','Taisiya177@lenta.ru','5193897719','1979-11-14','Taisiya177','R94YGT3XFjgD',0),(18,'Елисеева Альбина Николаевна','+7 (654) 864-77-46','Aljbina33@lenta.ru','5241213304','1983-02-15','Aljbina33','Bu?BHCtwDFin',0),(19,'Зиновьева Бронислава Викторовна','+7 (778) 565-12-18','Bronislava56@yahoo.com','6736319423','1981-03-19','Bronislava56','LO}xyC~1S4l6',0),(20,'Карпова Серафима Михаиловна','+7 (459) 930-91-70','Serafima169@yahoo.com','7034858987','1989-11-19','Serafima169','gNe3I9}8J3Z@',0),(21,'Абрамова Таисия Дмитриевна','+7 (528) 312-18-20','Taisiya176@hotmail.com','7310893510','1982-11-20','Taisiya176','~rIWfsnXA~7C',0),(22,'Ситникова Аделаида Гермоновна','+7 (793) 736-70-31','Adelaida20@hotmail.com','7561148016','1979-01-21','Adelaida20','LCY*{L*fEGYB',0),(23,'Титова Людмила Якововна','+7 (221) 729-16-84','Lyudmila123@hotmail.com','7715639425','1976-08-21','Lyudmila123','@8mk9M?NBAGj',0),(24,'Шарова Клавдия Макаровна','+7 (822) 525-82-40','Klavdiya113@live.com','8143593309','1980-08-22','Klavdiya113','FjC#hNIJori}',0),(25,'Сидорова Тамара Григорьевна','+7 (334) 692-79-77','Tamara179@live.com','8143905520','1995-11-22','Tamara179','TJxVqMXrbesI',0),(26,'Тихонова Лана Семеновна','+7 (478) 467-75-15','Lana117@outlook.com','8761609740','1990-08-24','Lana117','mFoG$jcS3c4~',0),(27,'Шубина Надежда Викторовна','+7 (736) 488-66-95','Nadezhda137@outlook.com','8844708476','1981-09-24','Nadezhda137','QQ~0q~rXHb?p',0),(28,'Горшкова Глафира Валентиновна','+7 (553) 343-38-82','Glafira73@outlook.com','9170402601','1978-06-25','Glafira73','Zz8POQlP}M4~',0),(29,'Евсеева Нина Павловна','+7 (833) 521-31-50','Nina145@msn.com','9323745717','1994-09-26','Nina145','Uxy6RtBXIcpT',0),(30,'Кириллова Гавриила Яковна','+7 (648) 700-43-34','Gavriila68@msn.com','9438379667','1992-04-26','Gavriila68','x4K5WthEe8ua',0),(31,'Мусифуллин Тимур Эдуардович','+7 (902) 692-25-26','timurmusifullin@gmail.com','4657754745','2004-03-30','123@gmail.com','Qpf0SxOVUjUkWySXOZ16kw==',0);
/*!40000 ALTER TABLE `visitor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'the_guardian_pro'
--

--
-- Dumping routines for database 'the_guardian_pro'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-24 13:08:16
