DROP DATABASE IF EXISTS `academia`;

CREATE DATABASE  IF NOT EXISTS `academia`;

USE `academia`;

DROP TABLE IF EXISTS `especialidades`;

CREATE TABLE `especialidades` (
  `id_especialidad` int(11) NOT NULL AUTO_INCREMENT,
  `desc_especialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`id_especialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `planes`;

CREATE TABLE `planes` (
  `id_plan` int(11) NOT NULL AUTO_INCREMENT,
  `desc_plan` varchar(50) NOT NULL,
  `id_especialidad` int(11) NOT NULL,
  PRIMARY KEY (`id_plan`),
  KEY `id_especialidad` (`id_especialidad`),
  CONSTRAINT `planes_ibfk_1` FOREIGN KEY (`id_especialidad`) REFERENCES `especialidades` (`id_especialidad`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `comisiones`;

CREATE TABLE `comisiones` (
  `id_comision` int(11) NOT NULL AUTO_INCREMENT,
  `desc_comision` varchar(50) NOT NULL,
  `anio_especialidad` int(11) DEFAULT NULL,
  `id_plan` int(11) NOT NULL,
  PRIMARY KEY (`id_comision`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `comisiones_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `materias`;

CREATE TABLE `materias` (
  `id_materia` int(11) NOT NULL AUTO_INCREMENT,
  `desc_materia` varchar(50) NOT NULL,
  `horas_semanales` int(11) DEFAULT NULL,
  `hs_totales` int(11) DEFAULT NULL,
  `id_plan` int(11) NOT NULL,
  PRIMARY KEY (`id_materia`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `materias_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `cursos`;

CREATE TABLE `cursos` (
  `id_curso` int(11) NOT NULL AUTO_INCREMENT,
  `id_materia` int(11) NOT NULL,
  `id_comision` int(11) NOT NULL,
  `anio_calendario` int(11) DEFAULT NULL,
  `cupo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_curso`),
  KEY `id_comision` (`id_comision`),
  KEY `id_materia` (`id_materia`),
  CONSTRAINT `cursos_ibfk_1` FOREIGN KEY (`id_comision`) REFERENCES `comisiones` (`id_comision`) ON UPDATE CASCADE,
  CONSTRAINT `cursos_ibfk_2` FOREIGN KEY (`id_materia`) REFERENCES `materias` (`id_materia`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `personas`;

CREATE TABLE `personas` (
  `id_persona` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `direccion` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `fecha_nac` datetime NOT NULL,
  `legajo` int(11) DEFAULT NULL,
  `tipo_persona` enum('alumno','docente') NOT NULL,
  `id_plan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_persona`),
  KEY `id_plan` (`id_plan`),
  CONSTRAINT `personas_ibfk_1` FOREIGN KEY (`id_plan`) REFERENCES `planes` (`id_plan`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `alumnos_inscripciones`;

CREATE TABLE `alumnos_inscripciones` (
  `id_inscripcion` int(11) NOT NULL AUTO_INCREMENT,
  `id_alumno` int(11) NOT NULL,
  `id_curso` int(11) NOT NULL,
  `condicion` varchar(50) DEFAULT NULL,
  `nota` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_inscripcion`),
  KEY `id_curso` (`id_curso`),
  KEY `id_alumno` (`id_alumno`),
  CONSTRAINT `alumnos_inscripciones_ibfk_1` FOREIGN KEY (`id_curso`) REFERENCES `cursos` (`id_curso`) ON UPDATE CASCADE,
  CONSTRAINT `alumnos_inscripciones_ibfk_2` FOREIGN KEY (`id_alumno`) REFERENCES `personas` (`id_persona`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

DROP TABLE IF EXISTS `modulos`;

CREATE TABLE `modulos` (
  `id_modulo` int(11) NOT NULL AUTO_INCREMENT,
  `desc_modulo` varchar(50) NOT NULL,
  `ejecuta` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `modulos_usuarios`;

CREATE TABLE `modulos_usuarios` (
  `id_modulo_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `id_modulo` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `alta` bit(1) DEFAULT NULL,
  `baja` bit(1) DEFAULT NULL,
  `modificacion` bit(1) DEFAULT NULL,
  `consulta` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id_modulo_usuario`),
  KEY `id_usuario` (`id_usuario`),
  KEY `id_modulo` (`id_modulo`),
  CONSTRAINT `modulos_usuarios_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `modulos_usuarios_ibfk_2` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


INSERT INTO `especialidades` VALUES (2,'ISI'),(3,'Mecánica'),(4,'Civil');

INSERT INTO `planes` VALUES (1,'ISI- 2005',2),(2,'Mecánica - 2005',3),(3,'Civil - 2005',4),(4,'ISI - 2008',2);

INSERT INTO `personas` VALUES (2,'Facundo','Segarra','Maipú 686','facu@gmail.com','(03464) 15448309','1987-03-08 00:00:00',32412,'alumno',1),(3,'Ernesto','Bugdahl','San Lorenzo 930','vitty@gmail.com','(0341) 153214221','1999-07-21 00:00:00',42332,'alumno',1);

INSERT INTO `usuarios` VALUES (1,'Vitty','3caracoles',1,'Vitty','Bugdahl','ebugdahl@gmail.com',0,NULL),(2,'Facu','gabibatistuta',0,'Facundo','Gardella','facugardella@hotmail.com',0,NULL),(4,'fer','onomatopeya',1,'Fernando','Duarte','fer@yahoo.com',0,NULL);