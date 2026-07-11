-- Membuat table fakultas
CREATE TABLE Fakultas (
    KodeFakultas INT,
    NamaFakultas VARCHAR(30),
    NamaDekan VARCHAR(50)
);
GO

-- Membuat table prodi
CREATE TABLE Prodi (
    KodeProdi INT,
    KodeFakultas INT,
    NamaProdi VARCHAR(30),
    NamaKetuaProdi VARCHAR(50)
);
GO

-- Membuat table mahasiswa
CREATE TABLE Mahasiswa (
    NPM VARCHAR(8) PRIMARY KEY,
    KodeProdi INT,
    NamaMahasiswa VARCHAR(50),
    TempatLahir VARCHAR(30),
    TanggalLahir DATE,
    Alamat VARCHAR(100)
);
GO

-- Menambahkan primary key pada table fakultas
ALTER TABLE Fakultas ALTER COLUMN KodeFakultas INT NOT NULL;
GO
ALTER TABLE Fakultas ADD CONSTRAINT PK_Fakultas PRIMARY KEY (KodeFakultas);
GO

-- Menambahkan primary key pada table prodi dan fakultas
ALTER TABLE Prodi ALTER COLUMN KodeProdi INT NOT NULL;
GO
ALTER TABLE Prodi ALTER COLUMN KodeFakultas INT NOT NULL;
GO
ALTER TABLE Prodi ADD CONSTRAINT PK_Prodi PRIMARY KEY (KodeProdi, KodeFakultas);
GO

-- Menambahkan data pada table fakultas
INSERT INTO Fakultas (KodeFakultas, NamaFakultas, NamaDekan) VALUES
(1, 'Teknik', 'Ahmad Riyadi'),
(2, 'Pertanian', 'Paiman'),
(3, 'Ekonomi', 'Sukhemi'),
(4, 'Keguruan', 'Suharni');

-- Menambahkan data pada table prodi
INSERT INTO Prodi (KodeProdi, KodeFakultas, NamaProdi, NamaKetuaProdi) VALUES
(11, 1, 'Teknik Informatika', 'Bachtiar Dwi Effendi'),
(21, 2, 'Agroteknologi', 'Bahrum'),
(31, 3, 'Manajemen', 'Vita'),
(32, 3, 'Akuntansi', 'Siti Maisaroh'),
(41, 4, 'PPKN', 'Sigit'),
(42, 4, 'Sejarah', 'Gunawan'),
(43, 4, 'Pendidikan Matematika', 'Tri'),
(44, 4, 'Bimbingan Konseling', 'Siswanti'),
(45, 4, 'PGSD', 'Haniek');

-- Menambahkan data pada table mahasiswa
INSERT INTO Mahasiswa (NPM, KodeProdi, NamaMahasiswa, TempatLahir, TanggalLahir, Alamat) VALUES
('08110167', 11, 'Andi', 'Jakarta', '1988-03-12', 'Gunung Kidul'),
('08110231', 11, 'Joko', 'Sleman', '1989-02-01', 'Sleman'),
('08210232', 21, 'Budi', 'Bantul', '1988-09-15', 'Bantul'),
('08210233', 21, 'Cici', 'Purwokerto', '1989-02-21', 'Bantul'),
('08310234', 31, 'Didi', 'Bandung', '1987-07-11', 'Kodya'),
('08320235', 32, 'Alfin', 'Makassar', '1986-09-22', 'Kodya'),
('08320236', 32, 'Dodi', 'Gunung Kidul', '1979-03-24', 'Kodya'),
('08320237', 32, 'Derri', 'Pangkal Pinang', '1984-02-09', 'Sleman'),
('08410121', 41, 'Dudung', 'Kebumen', '1985-02-25', 'Sleman'),
('08410122', 41, 'Afgan', 'Palembang', '1986-11-21', 'Kulon Progo'),
('08420123', 42, 'Didi', 'Kutoarjo', '1986-09-11', 'Kulon Progo'),
('08430124', 43, 'Firza', 'Purworejo', '1986-09-11', 'Bantul'),
('08440125', 44, 'Zahir', 'Temom', '1986-09-11', 'Kulon Progo');

-- Menambahkan kolom Tanggal Daftar pada table mahasiswa
ALTER TABLE Mahasiswa ADD TanggalDaftar DATE;

-- Menampilkan nama mahasiswa dan alamat yang lahirnya di tahun 70-an
SELECT NamaMahasiswa, Alamat 
FROM Mahasiswa 
WHERE YEAR(TanggalLahir) BETWEEN 1970 AND 1979;

-- Menampilkan seluruh nama mahasiswa beserta prodinya
SELECT m.NamaMahasiswa, p.NamaProdi
FROM Mahasiswa m
JOIN Prodi p ON m.KodeProdi = p.KodeProdi;

-- Menampilkan nama dan alamat dari 3 mahasiswa tertua dari fakultas Teknik
SELECT TOP (3) m.NamaMahasiswa, m.Alamat
FROM Mahasiswa m
JOIN Prodi p ON m.KodeProdi = p.KodeProdi
JOIN Fakultas f ON p.KodeFakultas = f.KodeFakultas
WHERE f.NamaFakultas = 'Teknik'
ORDER BY m.TanggalLahir ASC;

-- Menampilkan jumlah mahasiswa yang berasal dari Sleman
SELECT COUNT(*) AS 'Jumlah Mahasiswa dari Sleman'
FROM Mahasiswa
WHERE Alamat = 'Sleman';

-- Mengganti tanggal daftar semua mahasiswa menjadi 3 September 2013
UPDATE Mahasiswa SET TanggalDaftar = '2013-09-03';

-- Menampilkan semua informasi mahasiswa yang namanya berawalan huruf D
SELECT * FROM Mahasiswa 
WHERE NamaMahasiswa 
LIKE 'D%';

-- Mengganti tanggal lahir Joko menjadi 20 Januari 1990
UPDATE Mahasiswa 
SET TanggalLahir = '1990-01-20' 
WHERE NamaMahasiswa = 'Joko';

-- Menampilkan data nama prodi beserta jumlah mahasiswanya
SELECT p.NamaProdi, COUNT(m.NPM) AS 'Jumlah Mahasiswa'
FROM Prodi p
LEFT JOIN Mahasiswa m ON p.KodeProdi = m.KodeProdi
GROUP BY p.NamaProdi;
