-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 29, 2020 at 07:44 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dotnet`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(255) NOT NULL,
  `admin_name` varchar(255) NOT NULL,
  `admin_password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `admin_name`, `admin_password`) VALUES
(1, 'abc123', '123');

-- --------------------------------------------------------

--
-- Table structure for table `loan`
--

CREATE TABLE `loan` (
  `id` int(11) NOT NULL,
  `Account_No` int(10) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `C_name` varchar(255) NOT NULL,
  `M_transaction` double NOT NULL,
  `LoanTaken` char(3) NOT NULL,
  `Balance` double NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `loan`
--

INSERT INTO `loan` (`id`, `Account_No`, `Password`, `C_name`, `M_transaction`, `LoanTaken`, `Balance`, `Date`) VALUES
(1, 1234567891, '123', 'ABC', 55543.3, 'YES', 10000.67, '2020-03-16 08:36:22'),
(2, 1234567892, '1234', 'xyz', 125000, 'YES', 137000, '2020-03-16 08:36:22'),
(3, 1234567893, '789', 'TYH', 50000, 'YES', 1350000, '2020-03-18 08:27:42'),
(5, 1234567899, 'abc', 'ABHI', 10000, 'YES', 20000, '2020-05-28 08:40:26'),
(6, 1234567898, 'abc', 'RUTVIK', 20000, 'NO', 21000, '2020-03-18 08:27:42');

-- --------------------------------------------------------

--
-- Table structure for table `loan_taken`
--

CREATE TABLE `loan_taken` (
  `id` int(11) NOT NULL,
  `Account_No` int(11) NOT NULL,
  `C_name` varchar(255) NOT NULL,
  `Loan_Ammount` int(10) NOT NULL,
  `Duration` double NOT NULL,
  `Rate` double NOT NULL,
  `M_Payment` double NOT NULL,
  `Date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `loan_taken`
--

INSERT INTO `loan_taken` (`id`, `Account_No`, `C_name`, `Loan_Ammount`, `Duration`, `Rate`, `M_Payment`, `Date`) VALUES
(3, 1234567891, 'ABC', 12345, 12, 1, 13826.4, '2020-03-05 04:05:00'),
(8, 1234567892, 'xyz', 12000, 12, 1, 1120, '18-03-2020 12:00:00 AM'),
(21, 1234567899, 'ABHI', 10000, 1.5, 1.5, 568.055555555556, '29-05-2020 12:00:00 AM');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loan`
--
ALTER TABLE `loan`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Account` (`Account_No`);

--
-- Indexes for table `loan_taken`
--
ALTER TABLE `loan_taken`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Account_No` (`Account_No`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `loan`
--
ALTER TABLE `loan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `loan_taken`
--
ALTER TABLE `loan_taken`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
