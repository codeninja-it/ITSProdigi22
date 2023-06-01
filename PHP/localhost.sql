-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Creato il: Giu 01, 2023 alle 17:00
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
CREATE DATABASE IF NOT EXISTS `enngzjko_wp9` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `enngzjko_wp9`;

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
-- Struttura della tabella `messaggi`
--

CREATE TABLE `messaggi` (
  `idmessaggio` int(11) NOT NULL,
  `messaggio` text NOT NULL,
  `idutente` int(11) NOT NULL,
  `creazione` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `messaggi`
--

INSERT INTO `messaggi` (`idmessaggio`, `messaggio`, `idutente`, `creazione`) VALUES
(21, 'secondo', 1, '2023-05-25 11:27:00'),
(22, 'terzo', 1, '2023-05-25 11:27:03'),
(23, 'puÃ² scrivere tutto quello che vuole', 5, '2023-05-25 12:08:05');

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
-- Struttura della tabella `tkt_categorie`
--

CREATE TABLE `tkt_categorie` (
  `idcategoria` int(11) NOT NULL,
  `categoria` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tkt_categorie`
--

INSERT INTO `tkt_categorie` (`idcategoria`, `categoria`) VALUES
(1, 'fonia'),
(2, 'internet'),
(3, 'hosting'),
(5, 'ammennicoli'),
(7, 'schiavismo');

-- --------------------------------------------------------

--
-- Struttura della tabella `tkt_statiticket`
--

CREATE TABLE `tkt_statiticket` (
  `idstato` int(11) NOT NULL,
  `stato` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tkt_statiticket`
--

INSERT INTO `tkt_statiticket` (`idstato`, `stato`) VALUES
(1, 'nuovo'),
(2, 'in lavorazione'),
(3, 'chiuso');

-- --------------------------------------------------------

--
-- Struttura della tabella `tkt_tickets`
--

CREATE TABLE `tkt_tickets` (
  `idticket` int(11) NOT NULL,
  `idutente` int(11) DEFAULT NULL,
  `idcategoria` int(11) DEFAULT NULL,
  `idstato` int(11) DEFAULT NULL,
  `ticket` text DEFAULT NULL,
  `creazione` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tkt_tickets`
--

INSERT INTO `tkt_tickets` (`idticket`, `idutente`, `idcategoria`, `idstato`, `ticket`, `creazione`) VALUES
(7, 1, 5, 3, 'tutto a posto!', '0000-00-00 00:00:00'),
(8, 1, 5, 3, 'tutto a posto!', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Struttura della tabella `tkt_tipiutente`
--

CREATE TABLE `tkt_tipiutente` (
  `idtipo` int(11) NOT NULL,
  `tipo` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tkt_tipiutente`
--

INSERT INTO `tkt_tipiutente` (`idtipo`, `tipo`) VALUES
(1, 'utente'),
(2, 'tecnico'),
(3, 'amministratore');

-- --------------------------------------------------------

--
-- Struttura della tabella `tkt_utenti`
--

CREATE TABLE `tkt_utenti` (
  `idutente` int(11) NOT NULL,
  `idtipo` int(11) DEFAULT 1,
  `nome` text DEFAULT NULL,
  `cognome` text DEFAULT NULL,
  `email` text DEFAULT NULL,
  `pass` text DEFAULT NULL,
  `creazione` datetime DEFAULT current_timestamp(),
  `valido` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dump dei dati per la tabella `tkt_utenti`
--

INSERT INTO `tkt_utenti` (`idutente`, `idtipo`, `nome`, `cognome`, `email`, `pass`, `creazione`, `valido`) VALUES
(1, 1, 'utente', 'demo', 'demo@miaazienda.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-29 12:29:38', 1),
(2, 2, 'tecnico', 'demo', 'tecnico@miaazienda.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-29 12:29:38', 1),
(3, 3, 'admin', 'demo', 'admin@miaazienda.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-29 12:29:38', 1);

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
(2, 'utente2@prova.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-24 12:40:06', 1),
(5, 'simoncini@codeninja.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-24 16:52:20', 1),
(6, 'asdosfp@virgilio.it', 'c514c91e4ed341f263e458d44b3bb0a7', '2023-05-25 09:53:15', 0);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `contatti`
--
ALTER TABLE `contatti`
  ADD PRIMARY KEY (`idcontatto`);

--
-- Indici per le tabelle `messaggi`
--
ALTER TABLE `messaggi`
  ADD PRIMARY KEY (`idmessaggio`);

--
-- Indici per le tabelle `tipi`
--
ALTER TABLE `tipi`
  ADD PRIMARY KEY (`idtipo`);

--
-- Indici per le tabelle `tkt_categorie`
--
ALTER TABLE `tkt_categorie`
  ADD PRIMARY KEY (`idcategoria`);

--
-- Indici per le tabelle `tkt_statiticket`
--
ALTER TABLE `tkt_statiticket`
  ADD PRIMARY KEY (`idstato`);

--
-- Indici per le tabelle `tkt_tickets`
--
ALTER TABLE `tkt_tickets`
  ADD PRIMARY KEY (`idticket`);

--
-- Indici per le tabelle `tkt_tipiutente`
--
ALTER TABLE `tkt_tipiutente`
  ADD PRIMARY KEY (`idtipo`);

--
-- Indici per le tabelle `tkt_utenti`
--
ALTER TABLE `tkt_utenti`
  ADD PRIMARY KEY (`idutente`);

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
-- AUTO_INCREMENT per la tabella `messaggi`
--
ALTER TABLE `messaggi`
  MODIFY `idmessaggio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT per la tabella `tipi`
--
ALTER TABLE `tipi`
  MODIFY `idtipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `tkt_categorie`
--
ALTER TABLE `tkt_categorie`
  MODIFY `idcategoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `tkt_statiticket`
--
ALTER TABLE `tkt_statiticket`
  MODIFY `idstato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `tkt_tickets`
--
ALTER TABLE `tkt_tickets`
  MODIFY `idticket` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT per la tabella `tkt_tipiutente`
--
ALTER TABLE `tkt_tipiutente`
  MODIFY `idtipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `tkt_utenti`
--
ALTER TABLE `tkt_utenti`
  MODIFY `idutente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `idutente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
