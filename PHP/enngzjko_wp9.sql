-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Creato il: Mag 24, 2023 alle 17:15
-- Versione del server: 10.5.19-MariaDB-cll-lve-log
-- Versione PHP: 8.1.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `enngzjko_wp9`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `contatti`
--

CREATE TABLE `contatti` (
  `idcontatto` int(11) NOT NULL,
  `nome` varchar(20) DEFAULT NULL,
  `cognome` varchar(20) DEFAULT NULL,
  `telefono` varchar(11) DEFAULT NULL,
  `idtipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `contatti`
--

INSERT INTO `contatti` (`idcontatto`, `nome`, `cognome`, `telefono`, `idtipo`) VALUES
(1, 'Paolo', 'Rossi', '1234567890', 1),
(2, 'Giuseppe', 'Verdi', '987654321', 2),
(3, 'Jhon', 'Doe', '0000000001', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `tipi`
--

CREATE TABLE `tipi` (
  `idtipo` int(11) NOT NULL,
  `tipo` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tipi`
--

INSERT INTO `tipi` (`idtipo`, `tipo`) VALUES
(1, 'lavoro'),
(2, 'famiglia');

-- --------------------------------------------------------

--
-- Struttura della tabella `utenti`
--

CREATE TABLE `utenti` (
  `idutente` int(11) NOT NULL,
  `email` text NOT NULL,
  `pass` text NOT NULL,
  `creazione` datetime NOT NULL DEFAULT current_timestamp(),
  `valido` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `utenti`
--

INSERT INTO `utenti` (`idutente`, `email`, `pass`, `creazione`, `valido`) VALUES
(2, 'utente2@prova.it', '83e034a83c9101d18866867499680b73', '2023-05-24 12:40:06', 1),
(5, 'simoncini@codeninja.it', 'df98a5824b0366db60b0254794cb904b', '2023-05-24 16:52:20', 1);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `contatti`
--
ALTER TABLE `contatti`
  ADD PRIMARY KEY (`idcontatto`);

--
-- Indici per le tabelle `tipi`
--
ALTER TABLE `tipi`
  ADD PRIMARY KEY (`idtipo`);

--
-- Indici per le tabelle `utenti`
--
ALTER TABLE `utenti`
  ADD PRIMARY KEY (`idutente`),
  ADD UNIQUE KEY `emailsingola` (`email`) USING HASH;

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `contatti`
--
ALTER TABLE `contatti`
  MODIFY `idcontatto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `tipi`
--
ALTER TABLE `tipi`
  MODIFY `idtipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `idutente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
