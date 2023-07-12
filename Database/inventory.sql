-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 12, 2023 at 02:51 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inventory`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id_admin` varchar(6) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `jk_admin` varchar(25) NOT NULL,
  `alamat` varchar(25) NOT NULL,
  `telepon` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id_admin`, `username`, `password`, `jk_admin`, `alamat`, `telepon`) VALUES
('adm001', 'admin', 'admin', 'Pria', 'Lamongan', '099765465869'),
('adm002', 'kayla', 'kayla123', 'Wanita', 'Surabaya', '0872122134673'),
('adm003', 'melvin', 'melvin123', 'Pria', 'Gresik', '085656512786');

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `id_barang` varchar(6) NOT NULL,
  `nama_barang` varchar(25) NOT NULL,
  `qty` int(11) NOT NULL,
  `satuan` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id_barang`, `nama_barang`, `qty`, `satuan`) VALUES
('brg001', 'hp', 20, 'unit'),
('brg002', 'laptop', 25, 'unit'),
('brg003', 'televisi', 10, 'unit');

-- --------------------------------------------------------

--
-- Table structure for table `barang_keluar`
--

CREATE TABLE `barang_keluar` (
  `id_keluar` varchar(6) NOT NULL,
  `tanggal_keluar` date NOT NULL,
  `id_barang` varchar(6) NOT NULL,
  `nama_barang` varchar(25) NOT NULL,
  `qty` int(11) NOT NULL,
  `satuan` varchar(25) NOT NULL,
  `id_penerima` varchar(6) NOT NULL,
  `nama_penerima` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `barang_keluar`
--

INSERT INTO `barang_keluar` (`id_keluar`, `tanggal_keluar`, `id_barang`, `nama_barang`, `qty`, `satuan`, `id_penerima`, `nama_penerima`) VALUES
('klr001', '2023-07-11', 'brg001', 'hp', 20, 'unit', 'pen001', 'Benny'),
('klr002', '2023-07-11', 'brg002', 'laptop', 25, 'unit', 'pen002', 'Rania'),
('klr003', '2023-07-11', 'brg003', 'televisi', 10, 'unit', 'pen003', 'Kevin');

--
-- Triggers `barang_keluar`
--
DELIMITER $$
CREATE TRIGGER `product_out` AFTER INSERT ON `barang_keluar` FOR EACH ROW BEGIN
UPDATE barang SET qty = qty - new.qty
WHERE id_barang = new.id_barang;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `barang_masuk`
--

CREATE TABLE `barang_masuk` (
  `id_masuk` varchar(6) NOT NULL,
  `tanggal_masuk` date NOT NULL,
  `id_barang` varchar(6) NOT NULL,
  `nama_barang` varchar(25) NOT NULL,
  `qty` int(11) NOT NULL,
  `satuan` varchar(25) NOT NULL,
  `id_supplier` varchar(6) NOT NULL,
  `nama_supplier` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `barang_masuk`
--

INSERT INTO `barang_masuk` (`id_masuk`, `tanggal_masuk`, `id_barang`, `nama_barang`, `qty`, `satuan`, `id_supplier`, `nama_supplier`) VALUES
('msk001', '2023-07-09', 'brg001', 'hp', 40, 'unit', 'sup003', 'Niko'),
('msk002', '2023-07-09', 'brg002', 'laptop', 50, 'unit', 'sup001', 'Putri'),
('msk003', '2023-07-09', 'brg003', 'televisi', 20, 'unit', 'sup002', 'Ivan');

--
-- Triggers `barang_masuk`
--
DELIMITER $$
CREATE TRIGGER `product_in` AFTER INSERT ON `barang_masuk` FOR EACH ROW BEGIN
UPDATE barang SET qty = qty + new.qty
WHERE id_barang = new.id_barang;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `penerima`
--

CREATE TABLE `penerima` (
  `id_penerima` varchar(6) NOT NULL,
  `nama_penerima` varchar(25) NOT NULL,
  `jk_penerima` varchar(25) NOT NULL,
  `alamat_penerima` varchar(25) NOT NULL,
  `telepon_penerima` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `penerima`
--

INSERT INTO `penerima` (`id_penerima`, `nama_penerima`, `jk_penerima`, `alamat_penerima`, `telepon_penerima`) VALUES
('pen001', 'Benny', 'Pria', 'Bojonegoro', '08276543221'),
('pen002', 'Rania', 'Wanita', 'Tuban', '081165432134'),
('pen003', 'Kevin', 'Pria', 'Jombang', '087765213311'),
('sup004', 'Kamaniya', 'Wanita', 'Lamongan', '081234567123');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id_supplier` varchar(6) NOT NULL,
  `nama_supplier` varchar(25) NOT NULL,
  `jk_supplier` varchar(25) NOT NULL,
  `alamat_supplier` varchar(25) NOT NULL,
  `telepon_supplier` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id_supplier`, `nama_supplier`, `jk_supplier`, `alamat_supplier`, `telepon_supplier`) VALUES
('sup001', 'Putri', 'Wanita', 'Lamongan', '0897654321'),
('sup002', 'Ivan', 'Pria', 'Gresik', '08765443331'),
('sup003', 'Niko', 'Pria', 'Surabaya', '089756123456'),
('sup004', 'Vela', 'Wanita', 'Mojokerto', '081211345765');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id_barang`);

--
-- Indexes for table `barang_keluar`
--
ALTER TABLE `barang_keluar`
  ADD PRIMARY KEY (`id_keluar`);

--
-- Indexes for table `barang_masuk`
--
ALTER TABLE `barang_masuk`
  ADD PRIMARY KEY (`id_masuk`);

--
-- Indexes for table `penerima`
--
ALTER TABLE `penerima`
  ADD PRIMARY KEY (`id_penerima`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id_supplier`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
