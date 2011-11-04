-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: muvykive
-- ------------------------------------------------------
-- Server version	5.1.53-community-log

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
-- Current Database: `muvykive`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `muvykive` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `muvykive`;

--
-- Table structure for table `certification`
--

DROP TABLE IF EXISTS `certification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `certification` (
  `certification_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `rating` varchar(45) DEFAULT NULL,
  `abbreviation` varchar(10) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`certification_id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `certification`
--

LOCK TABLES `certification` WRITE;
/*!40000 ALTER TABLE `certification` DISABLE KEYS */;
INSERT INTO `certification` VALUES (1,'General Audiences','G','All Ages Admitted'),(2,'Parental Guidance Suggested','PG','Some Material May Not Be Suitable For Children'),(3,'Parents Strongly Cautioned','PG-13','Some Material May Be Inappropriate For Children Under 13'),(4,'Restricted','R','Children Under 17 Require Accompanying Parent or Adult Guardian'),(5,'Adult','NC-17','No One 17 and Under Admitted');
/*!40000 ALTER TABLE `certification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genres` (
  `genre_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(25) NOT NULL,
  PRIMARY KEY (`genre_id`),
  UNIQUE KEY `genre_id_UNIQUE` (`genre_id`)
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (1,'Action'),(2,'Adventure'),(3,'Animation'),(4,'Biography'),(5,'Comedy'),(6,'Crime'),(7,'Documentary'),(8,'Drama'),(9,'Family'),(10,'Fantasy'),(11,'Film-Noir'),(12,'Game-Show'),(13,'History'),(14,'Horror'),(15,'Music'),(16,'Musical'),(17,'Mystery'),(18,'News'),(19,'Reality-TV'),(20,'Romance'),(21,'Sci-Fi'),(22,'Sport'),(23,'Talk-Show'),(24,'Thriller'),(25,'War'),(26,'Western');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movie_genres`
--

DROP TABLE IF EXISTS `movie_genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movie_genres` (
  `movie_genres_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `movie_id` int(10) unsigned DEFAULT NULL,
  `genre_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`movie_genres_id`),
  UNIQUE KEY `movie_genres_id_UNIQUE` (`movie_genres_id`)
) ENGINE=MyISAM AUTO_INCREMENT=94 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movie_genres`
--

LOCK TABLES `movie_genres` WRITE;
/*!40000 ALTER TABLE `movie_genres` DISABLE KEYS */;
INSERT INTO `movie_genres` VALUES (49,5,1),(48,5,2),(61,4,1),(4,2,14),(60,4,14),(54,3,5),(65,1,2),(64,1,1),(63,1,5),(50,5,6),(53,3,14),(55,3,10),(59,4,2),(62,4,5),(66,1,18),(68,6,5),(69,6,21),(74,7,2),(73,7,1),(75,7,10),(80,8,2),(79,8,1),(81,8,21),(86,9,2),(85,9,1),(87,9,5),(92,10,2),(91,10,1),(93,10,24);
/*!40000 ALTER TABLE `movie_genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movies`
--

DROP TABLE IF EXISTS `movies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movies` (
  `movie_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `certification_id` int(10) unsigned DEFAULT NULL,
  `released` datetime DEFAULT NULL,
  `runtime` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`movie_id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (1,'X-Men: First Class',3,'2011-12-01 00:00:00',132),(2,'The Evil Dead',4,'1981-12-01 00:00:00',85),(3,'Evil Dead II',4,'1987-12-01 00:00:00',84),(4,'Army Of Darkness',4,'1992-02-19 00:00:00',81),(5,'The Count Of Monte Cristo',3,'2002-12-01 00:00:00',131),(6,'Paul',4,'2011-12-01 00:00:00',104),(7,'Thor',3,'2011-05-06 00:00:00',114),(8,'Captain America',3,'2011-07-22 00:00:00',124),(9,'Zombieland',4,'2009-10-02 00:00:00',88),(10,'The A-Team',3,'2010-07-11 00:00:00',117);
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2011-11-02  8:51:48
