/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.7.14-log : Database - academia
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`academia` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `academia`;

/*Table structure for table `alumnos_inscripciones` */

DROP TABLE IF EXISTS `alumnos_inscripciones`;

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

/*Data for the table `alumnos_inscripciones` */

/*Table structure for table `comisiones` */

DROP TABLE IF EXISTS `comisiones`;

CREATE TABLE `comisiones` (
  `id_comision` int(11) NOT NULL AUTO_INCREMENT,
  `desc_comision` varchar(50) NOT NULL,
  `anio_especialidad` int(11) DEFAULT NULL,
  `id_plan` int(11) NOT NULL,
  PRIMARY KEY (`id_comision`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `comisiones_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `comisiones` */

insert  into `comisiones`(`id_comision`,`desc_comision`,`anio_especialidad`,`id_plan`) values (1,'ISI - 101',2016,4),(3,'ISI - 102',2016,4),(4,'ISI - 103',2016,4);

/*Table structure for table `cursos` */

DROP TABLE IF EXISTS `cursos`;

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

/*Data for the table `cursos` */

insert  into `cursos`(`id_curso`,`id_materia`,`id_comision`,`anio_calendario`,`cupo`,`desc_curso`) values (4,26,1,2016,50,'AM I'),(5,26,1,2016,50,'AM II');

/*Table structure for table `docentes_cursos` */

DROP TABLE IF EXISTS `docentes_cursos`;

CREATE TABLE `docentes_cursos` (
  `id_dictado` int(11) NOT NULL AUTO_INCREMENT,
  `id_curso` int(11) NOT NULL,
  `id_docente` int(11) NOT NULL,
  `cargo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_dictado`),
  KEY `id_docente` (`id_docente`),
  CONSTRAINT `docentes_cursos_ibfk_1` FOREIGN KEY (`id_docente`) REFERENCES `personas` (`id_persona`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `docentes_cursos` */

/*Table structure for table `especialidades` */

DROP TABLE IF EXISTS `especialidades`;

CREATE TABLE `especialidades` (
  `id_especialidad` int(11) NOT NULL AUTO_INCREMENT,
  `desc_especialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`id_especialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `especialidades` */

insert  into `especialidades`(`id_especialidad`,`desc_especialidad`) values (2,'ISI'),(3,'Mecánica'),(4,'Civil');

/*Table structure for table `materias` */

DROP TABLE IF EXISTS `materias`;

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

/*Data for the table `materias` */

insert  into `materias`(`id_materia`,`desc_materia`,`horas_semanales`,`hs_totales`,`id_plan`) values (1,'AM I',8,300,NULL),(5,'AM II',8,300,NULL),(7,'Fisica I',6,216,NULL),(23,'AM I',8,300,17),(24,'AM II',8,300,17),(25,'Fisica I',6,216,17),(26,'AM I',8,300,4),(27,'AM II',8,300,4),(28,'Fisica I',6,216,4);

/*Table structure for table `modulos` */

DROP TABLE IF EXISTS `modulos`;

CREATE TABLE `modulos` (
  `id_modulo` int(11) NOT NULL AUTO_INCREMENT,
  `desc_modulo` varchar(50) NOT NULL,
  `ejecuta` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_modulo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `modulos` */

insert  into `modulos`(`id_modulo`,`desc_modulo`,`ejecuta`) values (1,'admin','todo'),(2,'alumno',NULL),(3,'docente',NULL);

/*Table structure for table `modulos_usuarios` */

DROP TABLE IF EXISTS `modulos_usuarios`;

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `modulos_usuarios` */

insert  into `modulos_usuarios`(`id_modulo_usuario`,`id_modulo`,`id_usuario`,`alta`,`baja`,`modificacion`,`consulta`) values (1,2,2,0,0,0,1),(4,2,1,0,0,0,1),(5,3,4,0,0,1,1),(6,1,5,1,1,1,1);

/*Table structure for table `personas` */

DROP TABLE IF EXISTS `personas`;

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `personas` */

insert  into `personas`(`id_persona`,`nombre`,`apellido`,`direccion`,`email`,`telefono`,`fecha_nac`,`legajo`,`tipo_persona`,`id_plan`) values (2,'Facundo','Segarra','Maipú 686','facu@gmail.com','(03464) 15448309','1987-03-08',32412,'alumno',1),(3,'Ernesto','Bugdahl','San Lorenzo 930','vitty@gmail.com','(0341) 153214221','1999-07-21',42332,'alumno',1),(4,'Adrian','Meca','Corrientes 334','adrian@gmail.com','34133668942','1980-01-03',42333,'docente',NULL),(5,'Pablo','Fernandez','Sarmiento 331','pablo@utn.frro.com.ar','33641236564','1975-05-24',42334,'admin',NULL);

/*Table structure for table `planes` */

DROP TABLE IF EXISTS `planes`;

CREATE TABLE `planes` (
  `id_plan` int(11) NOT NULL AUTO_INCREMENT,
  `desc_plan` varchar(50) NOT NULL,
  `id_especialidad` int(11) NOT NULL,
  PRIMARY KEY (`id_plan`),
  KEY `id_especialidad` (`id_especialidad`),
  CONSTRAINT `planes_ibfk_1` FOREIGN KEY (`id_especialidad`) REFERENCES `especialidades` (`id_especialidad`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

/*Data for the table `planes` */

insert  into `planes`(`id_plan`,`desc_plan`,`id_especialidad`) values (1,'ISI- 2005',2),(2,'Mecánica - 2005',3),(3,'Civil - 2005',4),(4,'ISI - 2008',2),(17,'Mecánica - 2008',3);

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `usuarios` */

insert  into `usuarios`(`id_usuario`,`nombre_usuario`,`clave`,`habilitado`,`nombre`,`apellido`,`email`,`cambia_clave`,`id_persona`) values (1,'Vitty','3caracoles',1,'Vitty','Bugdahl','ebugdahl@gmail.com',0,3),(2,'Facu','gabibatistuta',0,'Facundo','Gardella','facugardella@hotmail.com',0,2),(4,'fer','onomatopeya',1,'Fernando','Duarte','fer@yahoo.com',0,NULL),(5,'Admin','admin1234',1,'admin','admin','admin@utn.frro.com.ar',0,5);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
