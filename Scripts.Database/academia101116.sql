CREATE DATABASE  IF NOT EXISTS `academia` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `academia`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: academia
-- ------------------------------------------------------
-- Server version	5.7.14

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
-- Table structure for table `alumnos_inscripciones`
--

DROP TABLE IF EXISTS `alumnos_inscripciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alumnos_inscripciones` (
  `id_inscripcion` int(11) NOT NULL AUTO_INCREMENT,
  `id_alumno` int(11) NOT NULL,
  `id_curso` int(11) NOT NULL,
  `condicion` enum('regular','inscripto','no inscripto','libre','aprobada') DEFAULT NULL,
  `nota` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_inscripcion`),
  KEY `id_curso` (`id_curso`),
  KEY `id_alumno` (`id_alumno`),
  CONSTRAINT `alumnos_inscripciones_ibfk_1` FOREIGN KEY (`id_curso`) REFERENCES `cursos` (`id_curso`) ON UPDATE CASCADE,
  CONSTRAINT `alumnos_inscripciones_ibfk_2` FOREIGN KEY (`id_alumno`) REFERENCES `personas` (`id_persona`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnos_inscripciones`
--

LOCK TABLES `alumnos_inscripciones` WRITE;
/*!40000 ALTER TABLE `alumnos_inscripciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `alumnos_inscripciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comisiones`
--

DROP TABLE IF EXISTS `comisiones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comisiones` (
  `id_comision` int(11) NOT NULL AUTO_INCREMENT,
  `desc_comision` varchar(50) NOT NULL,
  `anio_especialidad` int(11) DEFAULT NULL,
  `id_plan` int(11) NOT NULL,
  PRIMARY KEY (`id_comision`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `comisiones_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comisiones`
--

LOCK TABLES `comisiones` WRITE;
/*!40000 ALTER TABLE `comisiones` DISABLE KEYS */;
INSERT INTO `comisiones` VALUES (1,'ISI - 101',2016,4),(3,'ISI - 102',2016,4),(4,'ISI - 103',2016,4);
/*!40000 ALTER TABLE `comisiones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursos`
--

DROP TABLE IF EXISTS `cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cursos` (
  `id_curso` int(11) NOT NULL AUTO_INCREMENT,
  `id_materia` int(11) NOT NULL,
  `id_comision` int(11) NOT NULL,
  `anio_calendario` int(11) DEFAULT NULL,
  `cupo` int(11) DEFAULT NULL,
  `desc_curso` varchar(50) NOT NULL,
  PRIMARY KEY (`id_curso`),
  KEY `id_comision` (`id_comision`),
  KEY `id_materia` (`id_materia`),
  CONSTRAINT `cursos_ibfk_1` FOREIGN KEY (`id_comision`) REFERENCES `comisiones` (`id_comision`) ON UPDATE CASCADE,
  CONSTRAINT `cursos_ibfk_2` FOREIGN KEY (`id_materia`) REFERENCES `materias` (`id_materia`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursos`
--

LOCK TABLES `cursos` WRITE;
/*!40000 ALTER TABLE `cursos` DISABLE KEYS */;
INSERT INTO `cursos` VALUES (4,26,1,2016,50,'AM I'),(5,26,1,2016,50,'AM II');
/*!40000 ALTER TABLE `cursos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docentes_cursos`
--

DROP TABLE IF EXISTS `docentes_cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docentes_cursos` (
  `id_dictado` int(11) NOT NULL AUTO_INCREMENT,
  `id_curso` int(11) NOT NULL,
  `id_docente` int(11) NOT NULL,
  `cargo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_dictado`),
  KEY `id_docente` (`id_docente`),
  CONSTRAINT `docentes_cursos_ibfk_1` FOREIGN KEY (`id_docente`) REFERENCES `personas` (`id_persona`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docentes_cursos`
--

LOCK TABLES `docentes_cursos` WRITE;
/*!40000 ALTER TABLE `docentes_cursos` DISABLE KEYS */;
/*!40000 ALTER TABLE `docentes_cursos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidades`
--

DROP TABLE IF EXISTS `especialidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especialidades` (
  `id_especialidad` int(11) NOT NULL AUTO_INCREMENT,
  `desc_especialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`id_especialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidades`
--

LOCK TABLES `especialidades` WRITE;
/*!40000 ALTER TABLE `especialidades` DISABLE KEYS */;
INSERT INTO `especialidades` VALUES (2,'ISI'),(3,'Mecánica'),(4,'Civil');
/*!40000 ALTER TABLE `especialidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materias`
--

DROP TABLE IF EXISTS `materias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materias` (
  `id_materia` int(11) NOT NULL AUTO_INCREMENT,
  `desc_materia` varchar(50) NOT NULL,
  `horas_semanales` int(11) DEFAULT NULL,
  `hs_totales` int(11) DEFAULT NULL,
  `id_plan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_materia`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `materias_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materias`
--

LOCK TABLES `materias` WRITE;
/*!40000 ALTER TABLE `materias` DISABLE KEYS */;
INSERT INTO `materias` VALUES (1,'AM I',8,300,NULL),(5,'AM II',8,300,NULL),(7,'Fisica I',6,216,NULL),(23,'AM I',8,300,17),(24,'AM II',8,300,17),(25,'Fisica I',6,216,17),(26,'AM I',8,300,4),(27,'AM II',8,300,4),(28,'Fisica I',6,216,4);
/*!40000 ALTER TABLE `materias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulos`
--

DROP TABLE IF EXISTS `modulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulos` (
  `id_modulo` int(11) NOT NULL AUTO_INCREMENT,
  `desc_modulo` varchar(50) DEFAULT NULL,
  `ejecuta` varchar(50) NOT NULL,
  PRIMARY KEY (`id_modulo`),
  UNIQUE KEY `id_modulo_UNIQUE` (`id_modulo`),
  UNIQUE KEY `ejecuta_UNIQUE` (`ejecuta`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulos`
--

LOCK TABLES `modulos` WRITE;
/*!40000 ALTER TABLE `modulos` DISABLE KEYS */;
INSERT INTO `modulos` VALUES (1,'alumnos_inscripciones','alumnos_inscripciones'),(2,'comisiones','comisiones'),(3,'cursos','cursos'),(4,'docentes_cursos','docentes_cursos'),(5,'especialidades','especialidades'),(6,'materias','materias'),(7,'modulos y modulo_usuarios','permisos'),(8,'personas','personas'),(9,'planes','planes'),(10,'usuarios','usuarios');
/*!40000 ALTER TABLE `modulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulos_usuarios`
--

DROP TABLE IF EXISTS `modulos_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulos_usuarios` (
  `id_modulo_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `id_modulo` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `alta` tinyint(1) DEFAULT NULL,
  `baja` tinyint(1) DEFAULT NULL,
  `modificacion` tinyint(1) DEFAULT NULL,
  `consulta` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_modulo_usuario`),
  KEY `id_usuario` (`id_usuario`),
  KEY `id_modulo` (`id_modulo`),
  CONSTRAINT `modulos_usuarios_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `modulos_usuarios_ibfk_2` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulos_usuarios`
--

LOCK TABLES `modulos_usuarios` WRITE;
/*!40000 ALTER TABLE `modulos_usuarios` DISABLE KEYS */;
INSERT INTO `modulos_usuarios` VALUES (1,1,5,1,1,1,1),(2,2,5,1,1,1,1),(3,3,5,1,1,1,1),(4,4,5,1,1,1,1),(5,5,5,1,1,1,1),(6,6,5,1,1,1,1),(7,7,5,0,0,0,1),(8,8,5,1,1,1,1),(9,9,5,1,1,1,1),(10,10,5,1,1,1,1);
/*!40000 ALTER TABLE `modulos_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personas`
--

DROP TABLE IF EXISTS `personas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personas` (
  `id_persona` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `direccion` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `fecha_nac` date NOT NULL,
  `legajo` int(11) DEFAULT NULL,
  `tipo_persona` enum('alumno','docente','admin') NOT NULL,
  `id_plan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_persona`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `personas_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personas`
--

LOCK TABLES `personas` WRITE;
/*!40000 ALTER TABLE `personas` DISABLE KEYS */;
INSERT INTO `personas` VALUES (2,'Facundo','Segarra','Maipú 686','facu@gmail.com','(03464) 15448309','1987-03-08',32412,'alumno',1),(3,'Ernesto','Bugdahl','San Lorenzo 930','vitty@gmail.com','(0341) 153214221','1999-07-21',42332,'alumno',1),(4,'Adrian','Meca','Corrientes 334','adrian@gmail.com','34133668942','1980-01-03',42333,'docente',NULL),(5,'Pablo','Fernandez','Sarmiento 331','pablo@utn.frro.com.ar','33641236564','1975-05-24',42334,'admin',NULL),(6,'Martin','Dante','9 de Julio','martin@gmail.com','(341) 153643502','2016-01-08',42333,'docente',NULL);
/*!40000 ALTER TABLE `personas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planes`
--

DROP TABLE IF EXISTS `planes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `planes` (
  `id_plan` int(11) NOT NULL AUTO_INCREMENT,
  `desc_plan` varchar(50) NOT NULL,
  `id_especialidad` int(11) NOT NULL,
  PRIMARY KEY (`id_plan`),
  KEY `id_especialidad` (`id_especialidad`),
  CONSTRAINT `planes_ibfk_1` FOREIGN KEY (`id_especialidad`) REFERENCES `especialidades` (`id_especialidad`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planes`
--

LOCK TABLES `planes` WRITE;
/*!40000 ALTER TABLE `planes` DISABLE KEYS */;
INSERT INTO `planes` VALUES (1,'ISI- 2005',2),(2,'Mecánica - 2005',3),(3,'Civil - 2005',4),(4,'ISI - 2008',2),(17,'Mecánica - 2008',3);
/*!40000 ALTER TABLE `planes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_usuario` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `habilitado` tinyint(1) DEFAULT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `cambia_clave` tinyint(1) NOT NULL,
  `id_persona` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`,`cambia_clave`),
  KEY `id_persona` (`id_persona`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`id_persona`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Vitty','3caracoles',1,'Vitty','Bugdahl','ebugdahl@gmail.com',0,3),(2,'Facu','gabibatistuta',0,'Facundo','Gardella','facugardella@hotmail.com',0,2),(5,'Admin','admin1234',1,'admin','admin','admin@utn.frro.com.ar',0,5),(6,'fernando','',1,'Fernando','Fernandez','fer@gmail.com',0,NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-10  7:54:15
