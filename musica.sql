-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3307
-- Tiempo de generación: 05-08-2023 a las 06:29:31
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `musica`
--
CREATE DATABASE IF NOT EXISTS `musica` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `musica`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `albumes`
--

CREATE TABLE `albumes` (
  `ID_Album` int(11) NOT NULL,
  `Nombre_Album` varchar(100) NOT NULL,
  `ID_Artista` int(11) DEFAULT NULL,
  `ID_Genero` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `albumes`
--

INSERT INTO `albumes` (`ID_Album`, `Nombre_Album`, `ID_Artista`, `ID_Genero`) VALUES
(1, 'ASTROWORLD', 3, 6),
(2, 'Blue Rev', 1, 7),
(3, 'Balas Perdidas', 5, 3),
(4, 'El Rugido De los Tigres Del Norte', 6, 4),
(5, 'Bleach', 2, 1),
(6, 'Caifanes', 8, 1),
(7, 'Meteora', 9, 5),
(8, 'Awake', 10, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `artistas`
--

CREATE TABLE `artistas` (
  `ID_Artista` int(11) NOT NULL,
  `Nombre_Artista` varchar(100) NOT NULL,
  `Nacionalidad_Artista` varchar(50) DEFAULT NULL,
  `ID_Genero` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `artistas`
--

INSERT INTO `artistas` (`ID_Artista`, `Nombre_Artista`, `Nacionalidad_Artista`, `ID_Genero`) VALUES
(1, 'Alvvays', 'Estados Unidos', 7),
(2, 'Nirvana', 'Estados Unidos', 1),
(3, 'Travis Scott', 'Estados Unidos', 6),
(5, 'Morat', 'Colombia', 3),
(6, 'Los Tigres Del Norte', 'México', 4),
(8, 'Caifanes', 'México', 1),
(9, 'Linkin Park', 'Estados Unidos', 5),
(10, 'Skillet', 'Estados Unidos', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `canciones`
--

CREATE TABLE `canciones` (
  `ID_Cancion` int(11) NOT NULL,
  `ID_Artista` int(11) DEFAULT NULL,
  `ID_Album` int(11) DEFAULT NULL,
  `ID_Genero` int(11) DEFAULT NULL,
  `Nombre_Cancion` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `canciones`
--

INSERT INTO `canciones` (`ID_Cancion`, `ID_Artista`, `ID_Album`, `ID_Genero`, `Nombre_Cancion`) VALUES
(2, 3, 1, 6, 'carousel-xd'),
(3, 3, 1, 6, 'SICKO MODE'),
(4, 3, 1, 6, 'R.I.P. SCREW'),
(5, 3, 1, 6, 'STOP TRYING TO BE GOD'),
(6, 3, 1, 6, 'NO BYSTANDERS'),
(7, 3, 1, 6, 'SKELETONS'),
(8, 3, 1, 6, 'WAKE UP'),
(9, 3, 1, 6, '5% TINT'),
(10, 3, 1, 6, 'NC-17'),
(11, 3, 1, 6, 'ASTROTHUNDER'),
(12, 3, 1, 6, 'YOSEMITE'),
(13, 3, 1, 6, 'CAN\'T SAY'),
(14, 3, 1, 6, 'WHO? WHAT!'),
(15, 3, 1, 6, 'BUTTERFLY EFFECT'),
(16, 3, 1, 6, 'HOUSTONFORNICATION'),
(17, 3, 1, 6, 'COFFEE BEAN'),
(18, 1, 2, 7, 'Pharmacist'),
(19, 1, 2, 7, 'Easy On Your Own?'),
(20, 1, 2, 7, 'After the Earthquake'),
(21, 1, 2, 7, 'Tom Verlaine'),
(22, 1, 2, 7, 'Pressed'),
(23, 1, 2, 7, 'Many Mirrors'),
(24, 1, 2, 7, 'Very Online Guy'),
(25, 1, 2, 7, 'Velveteen'),
(26, 1, 2, 7, 'Tile by Tile'),
(27, 1, 2, 7, 'Pomeranian Spinster'),
(28, 1, 2, 7, 'Belinda Says'),
(29, 1, 2, 7, 'Bored in Bristol'),
(30, 1, 2, 7, 'Lottery Noises'),
(31, 1, 2, 7, 'Fourth Figure'),
(32, 5, 3, 3, 'Otras Se Pierden'),
(33, 5, 3, 3, 'Acuérdate De Mí'),
(34, 5, 3, 3, 'Besos En Guerra'),
(35, 5, 3, 3, 'Cuando El Amor Se Escapa'),
(36, 5, 3, 3, 'No Se Va'),
(37, 5, 3, 3, 'Mi Vida Entera'),
(38, 5, 3, 3, 'El Embrujo'),
(39, 5, 3, 3, 'Yo No Merezco Volver'),
(40, 5, 3, 3, 'Maldita Costumbre'),
(41, 5, 3, 3, 'Cuando Nadie Ve'),
(42, 5, 3, 3, 'Punto Y Aparte'),
(43, 5, 3, 3, '11 Besos'),
(44, 6, 4, 4, 'Aguas Revueltas'),
(45, 6, 4, 4, 'El Enfermito'),
(46, 6, 4, 4, 'Mi Curiosidad'),
(47, 6, 4, 4, 'Rumbo Al Sur'),
(48, 6, 4, 4, 'Detalles'),
(49, 6, 4, 4, 'La Granja'),
(50, 6, 4, 4, 'El Hijo Del Pueblo'),
(51, 6, 4, 4, 'Señor Locutor'),
(52, 6, 4, 4, 'Directo Al Corazón'),
(53, 2, 5, 1, 'Blew'),
(54, 2, 5, 1, 'Floyd the Barber'),
(55, 2, 5, 1, 'About a Girl'),
(56, 2, 5, 1, 'School'),
(57, 2, 5, 1, 'Love Buzz'),
(58, 2, 5, 1, 'Paper Cuts'),
(59, 2, 5, 1, 'Negative creep'),
(60, 2, 5, 1, 'Scoff'),
(61, 2, 5, 1, 'Swap Meet'),
(62, 2, 5, 1, 'Mr Moustache'),
(63, 2, 5, 1, 'Sifting'),
(64, 2, 5, 1, 'Big Cheese'),
(65, 2, 5, 1, 'Downer'),
(66, 8, 6, 1, 'Afuera'),
(67, 8, 6, 1, 'Matenme porque me muero'),
(68, 8, 6, 1, 'Viento'),
(69, 8, 6, 1, 'La negra Tomasa'),
(70, 8, 6, 1, 'Perdi mi ojo de venado'),
(71, 8, 6, 1, 'Nunca me voy a transformar en ti'),
(72, 8, 6, 1, 'Miedo'),
(73, 8, 6, 1, 'Dioses ocultos'),
(74, 8, 6, 1, 'Para que no digas que no pienso en ti'),
(75, 6, 4, 4, 'La Sorpresa'),
(76, 6, 4, 4, 'La Manzanita'),
(77, 6, 4, 4, 'Regalo Caro'),
(78, 6, 4, 4, 'Jose Perez Leon'),
(79, 6, 4, 4, 'En Que Falle'),
(80, 6, 4, 4, 'Le Compre La Muerte A Mi Hijo'),
(81, 9, 7, 5, 'Foreword'),
(82, 9, 7, 5, 'Dont Stay'),
(83, 9, 7, 5, 'Somewhere I Belong'),
(84, 9, 7, 5, 'Lying from You'),
(85, 9, 7, 5, 'Hit the Floor'),
(86, 9, 7, 5, 'Easier to Run'),
(87, 9, 7, 5, 'Faint'),
(88, 9, 7, 5, 'Figure 09'),
(89, 9, 7, 5, 'Breaking the Habit'),
(90, 9, 7, 5, 'From the Inside'),
(91, 9, 7, 5, 'Nobodys Listening'),
(92, 9, 7, 5, 'Session'),
(93, 9, 7, 5, 'Numb'),
(94, 10, 8, 1, 'Hero'),
(95, 10, 8, 1, 'Monster'),
(96, 10, 8, 1, 'Dont Wake Me'),
(97, 10, 8, 1, 'Awake and Alive'),
(98, 10, 8, 1, 'One Day Too Late'),
(99, 10, 8, 1, 'Its Not Me Its You'),
(100, 10, 8, 1, 'Shouldve When You Couldve'),
(101, 10, 8, 1, 'Believe'),
(102, 10, 8, 1, 'Forgiven'),
(103, 10, 8, 1, 'Sometimes'),
(104, 10, 8, 1, 'Never Surrender'),
(110, 3, 1, 6, 'Panteon'),
(111, 3, 1, 6, 'El diablo me persigue ayudame dios'),
(120, 3, 1, 6, 'Rafa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `generos`
--

CREATE TABLE `generos` (
  `ID_Genero` int(11) NOT NULL,
  `Nombre_Genero` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `generos`
--

INSERT INTO `generos` (`ID_Genero`, `Nombre_Genero`) VALUES
(1, 'Rock'),
(2, 'Rap'),
(3, 'Pop'),
(4, 'Norteño'),
(5, 'Nu Metal'),
(6, 'Trap'),
(7, 'Alternativo'),
(8, 'Salsa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `links`
--

CREATE TABLE `links` (
  `ID_Cancion` int(11) NOT NULL,
  `Link_Spotify` varchar(255) DEFAULT NULL,
  `Link_Youtube` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `portadas`
--

CREATE TABLE `portadas` (
  `ID_Album` int(11) NOT NULL,
  `Portada_Album` longblob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `albumes`
--
ALTER TABLE `albumes`
  ADD PRIMARY KEY (`ID_Album`),
  ADD KEY `ID_Artista` (`ID_Artista`),
  ADD KEY `ID_Genero` (`ID_Genero`);

--
-- Indices de la tabla `artistas`
--
ALTER TABLE `artistas`
  ADD PRIMARY KEY (`ID_Artista`),
  ADD KEY `ID_Genero` (`ID_Genero`);

--
-- Indices de la tabla `canciones`
--
ALTER TABLE `canciones`
  ADD PRIMARY KEY (`ID_Cancion`),
  ADD KEY `ID_Artista` (`ID_Artista`),
  ADD KEY `ID_Album` (`ID_Album`),
  ADD KEY `ID_Genero` (`ID_Genero`);

--
-- Indices de la tabla `generos`
--
ALTER TABLE `generos`
  ADD PRIMARY KEY (`ID_Genero`);

--
-- Indices de la tabla `links`
--
ALTER TABLE `links`
  ADD PRIMARY KEY (`ID_Cancion`);

--
-- Indices de la tabla `portadas`
--
ALTER TABLE `portadas`
  ADD PRIMARY KEY (`ID_Album`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `albumes`
--
ALTER TABLE `albumes`
  MODIFY `ID_Album` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `artistas`
--
ALTER TABLE `artistas`
  MODIFY `ID_Artista` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `canciones`
--
ALTER TABLE `canciones`
  MODIFY `ID_Cancion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=121;

--
-- AUTO_INCREMENT de la tabla `generos`
--
ALTER TABLE `generos`
  MODIFY `ID_Genero` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `albumes`
--
ALTER TABLE `albumes`
  ADD CONSTRAINT `albumes_ibfk_1` FOREIGN KEY (`ID_Artista`) REFERENCES `artistas` (`ID_Artista`),
  ADD CONSTRAINT `albumes_ibfk_2` FOREIGN KEY (`ID_Genero`) REFERENCES `generos` (`ID_Genero`);

--
-- Filtros para la tabla `artistas`
--
ALTER TABLE `artistas`
  ADD CONSTRAINT `artistas_ibfk_1` FOREIGN KEY (`ID_Genero`) REFERENCES `generos` (`ID_Genero`);

--
-- Filtros para la tabla `canciones`
--
ALTER TABLE `canciones`
  ADD CONSTRAINT `canciones_ibfk_1` FOREIGN KEY (`ID_Artista`) REFERENCES `artistas` (`ID_Artista`),
  ADD CONSTRAINT `canciones_ibfk_2` FOREIGN KEY (`ID_Album`) REFERENCES `albumes` (`ID_Album`),
  ADD CONSTRAINT `canciones_ibfk_3` FOREIGN KEY (`ID_Genero`) REFERENCES `generos` (`ID_Genero`);

--
-- Filtros para la tabla `links`
--
ALTER TABLE `links`
  ADD CONSTRAINT `links_ibfk_1` FOREIGN KEY (`ID_Cancion`) REFERENCES `canciones` (`ID_Cancion`);

--
-- Filtros para la tabla `portadas`
--
ALTER TABLE `portadas`
  ADD CONSTRAINT `portadas_ibfk_1` FOREIGN KEY (`ID_Album`) REFERENCES `albumes` (`ID_Album`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
