-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Waktu pembuatan: 10 Jun 2025 pada 01.28
-- Versi server: 8.4.3
-- Versi PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `restoran`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `laporan`
--

CREATE TABLE `laporan` (
  `id` int NOT NULL,
  `nama` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `makan` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `jumlahmakan` int NOT NULL,
  `minum` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `jumlahminuman` int NOT NULL,
  `total` int NOT NULL,
  `tanggal` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `laporan`
--

INSERT INTO `laporan` (`id`, `nama`, `makan`, `jumlahmakan`, `minum`, `jumlahminuman`, `total`, `tanggal`) VALUES
(1, 'ucup', 'ketop', 3, 'es teh', 5, 45000, '2024-12-11'),
(2, 'cecep', 'seblak', 5, 'gula batu', 8, 56000, '2024-12-11'),
(3, 'cucu', 'tempe', 1, 'tutu', 1, 4000, '2024-12-13'),
(4, 'www', 'ketop', 1, 'es teh', 1, 13000, '2024-12-13'),
(5, 'pupipu', 'nasi goreng', 2, 'kopi', 3, 45000, '2024-12-15'),
(6, 'tautu', 'spageti', 4, 'macha', 6, 152000, '2024-12-15'),
(8, 'being', 'nasi goreng', 10, 'kopi', 5, 175000, '2024-12-19'),
(9, 'bedul', 'ayam geprek', 2, 'es teh', 3, 45000, '2024-12-20'),
(10, 'eka', 'spageti', 2, 'es teh', 2, 50000, '2024-12-20'),
(1, 'ijal', 'tahu', 1, 'kopi', 2, 12000, '2024-12-26'),
(12, 'nisa', 'burger', 2, 'susu', 1, 25000, '2024-12-30'),
(13, 'aku', 'tahu bakar', 40, 'kopi', 7, 235000, '2025-04-21'),
(14, 'akuuuuuuuuu', 'lengko', 2, 'es teh', 2, 22000, '2025-04-21');

-- --------------------------------------------------------

--
-- Struktur dari tabel `menumakanan`
--

CREATE TABLE `menumakanan` (
  `nama` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `harga` int NOT NULL,
  `stok` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `menumakanan`
--

INSERT INTO `menumakanan` (`nama`, `harga`, `stok`) VALUES
('ayam geprek', 15000, 28),
('burger', 7000, 22),
('kentang goreng', 8000, 38),
('lengko', 6000, 3),
('nasi goreng', 15000, 43),
('tahu', 2000, 48),
('tahu bakar', 5000, 10);

-- --------------------------------------------------------

--
-- Struktur dari tabel `menuminuman`
--

CREATE TABLE `menuminuman` (
  `nama` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `harga` int NOT NULL,
  `stok` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `menuminuman`
--

INSERT INTO `menuminuman` (`nama`, `harga`, `stok`) VALUES
('es teh', 5000, 28),
('kopi', 5000, 14),
('kopi susu', 10000, 23),
('macha', 12000, 33),
('susu', 5000, 27),
('teh anget', 5000, 27);

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id` int NOT NULL,
  `username` varchar(50) NOT NULL,
  `pasword` varchar(255) NOT NULL,
  `role` enum('admin','pelanggan') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id`, `username`, `pasword`, `role`) VALUES
(1, 'admin', '12345678', 'admin'),
(2, 'pelanggan', '12345678', 'pelanggan');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `menumakanan`
--
ALTER TABLE `menumakanan`
  ADD PRIMARY KEY (`nama`);

--
-- Indeks untuk tabel `menuminuman`
--
ALTER TABLE `menuminuman`
  ADD PRIMARY KEY (`nama`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
