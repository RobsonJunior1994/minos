-- phpMyAdmin SQL Dump
-- version 4.0.10.12
-- http://www.phpmyadmin.net
--
-- Máquina: 186.202.152.104
-- Data de Criação: 27-Set-2018 às 14:58
-- Versão do servidor: 5.1.73-rel14.11-log
-- versão do PHP: 5.6.30-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de Dados: `cmirj`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `15_turmas`
--

CREATE TABLE IF NOT EXISTS `15_turmas` (
  `anolet` int(11) NOT NULL DEFAULT '0',
  `curso` varchar(5) DEFAULT NULL,
  `turma` varchar(10) NOT NULL DEFAULT '',
  `descricao` varchar(20) DEFAULT NULL,
  `segmento` smallint(6) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `15_turmas`
--

INSERT INTO `15_turmas` (`anolet`, `curso`, `turma`, `descricao`, `segmento`) VALUES
(2018, 'EM', '8EM2AM    ', '2º ANO ENSINO MÉDIO', 4),
(2018, 'EM', '7EM1AM    ', '1º ANO ENSINO MÉDIO', 4),
(2018, 'EI', '2EIPIIBT  ', 'PRÉ II TARDE', 2),
(2018, 'EI', '2EIPIIAM  ', 'PRÉ II MANHÃ', 2),
(2018, 'EI', '2EIPIBT   ', 'PRÉ I TARDE', 2),
(2018, 'EI', '2EIPIAM   ', 'PRÉ I MANHÃ', 2),
(2018, 'EI', '1EIMIIBT  ', 'MATERNAL II TARDE', 1),
(2018, 'EI', '1EIMIIAM  ', 'MATERNAL II MANHÃ', 1),
(2018, 'EI', '1EIMIBT   ', 'MATERNAL I TARDE', 1),
(2018, 'EI', '1EIMIAM   ', 'MATERNAL I MANHÃ', 1),
(2018, 'EI', '0EIB2BT   ', 'BERÇÁRIO II TARDE', 1),
(2018, 'EI', '0EIB2AM   ', 'BERÇÁRIO II MANHÃ', 1),
(2018, 'EF', '6EF9AM    ', '9º ANO A MANHÃ', 3),
(2018, 'EF', '6EF8AM    ', '8º ANO A MANHÃ', 3),
(2018, 'EF', '6EF7AM    ', '7º ANO A MANHÃ', 3),
(2018, 'EF', '5EF6BM    ', '6º ANO B MANHÃ', 3),
(2018, 'EF', '5EF6AM    ', '6º ANO A MANHÃ', 3),
(2018, 'EF', '4EF5AM    ', '5º ANO A MANHÃ', 2),
(2018, 'EF', '4EF4BM    ', '4º ANO A MANHÃ', 2),
(2018, 'EF', '4EF4AM    ', '4º ANO A MANHÃ', 2),
(2018, 'EF', '4EF3BT    ', '3º ANO B TARDE', 2),
(2018, 'EF', '4EF3AM    ', '3º ANO A MANHÃ', 2),
(2017, 'EM', '9EM3AM    ', '3º ANO ENSINO MÉDIO', NULL),
(2017, 'EM', '8EM2AM    ', '2º ANO ENSINO MÉDIO', NULL),
(2017, 'EM', '7EM1AM    ', '1º ANO ENSINO MÉDIO', NULL),
(2017, 'EI', '2EIPIIBT  ', 'PRÉ ESCOLA II B TARD', NULL),
(2017, 'EI', '2EIPIIAM  ', 'PRÉ ESCOLA II A MANH', NULL),
(2017, 'EI', '2EIPIBT   ', 'PRÉ ESCOLA I B TARDE', NULL),
(2017, 'EI', '2EIPIAM   ', 'PRÉ ESCOLA I A MANHÃ', NULL),
(2017, 'EI', '1EIMIIBT  ', 'MATERNAL II B TARDE', NULL),
(2017, 'EI', '1EIMIIAM  ', 'MATERNAL II A MANHÃ', NULL),
(2017, 'EI', '1EIMIBT   ', 'MATERNAL I B TARDE', NULL),
(2017, 'EI', '1EIMIAM   ', 'MATERNAL I A MANHÃ', NULL),
(2017, 'EF', '6EF9AM    ', '9º ANO A MANHÃ', NULL),
(2017, 'EF', '6EF8AM    ', '8º ANO A MANHÃ', NULL),
(2017, 'EF', '6EF7AM    ', '7º ANO A MANHÃ', NULL),
(2017, 'EF', '5EF6AM    ', '6º ANO A MANHÃ', NULL),
(2017, 'EF', '4EF5BM    ', '5º ANO B MANHÃ', NULL),
(2017, 'EF', '4EF5AM    ', '5º ANO A MANHÃ', NULL),
(2017, 'EF', '4EF4AM    ', '4º ANO A MANHÃ', NULL),
(2017, 'EF', '4EF3BT    ', '3º ANO B TARDE', NULL),
(2017, 'EF', '4EF3AM    ', '3º ANO A MANHÃ', NULL),
(2017, 'EF', '4EF2BT    ', '2º ANO B TARDE', NULL),
(2017, 'EF', '4EF2AM    ', '2º ANO A MANHÃ', NULL),
(2017, 'EF', '3EF1BT    ', '1º ANO B TARDE', NULL),
(2017, 'EF', '3EF1AM    ', '1º ANO A MANHÃ', NULL),
(2018, 'EF', '4EF2BT    ', '2º ANO B TARDE', 2),
(2018, 'EF', '4EF2AM    ', '2º ANO A MANHÃ', 2),
(2018, 'EF', '3EF1BT    ', '1º ANO B TARDE', 2),
(2018, 'EF', '3EF1AM    ', '1º ANO A MANHÃ', 2),
(2018, 'EM', '9EM3AM    ', '3º ANO ENSINO MÉDIO', 4);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
