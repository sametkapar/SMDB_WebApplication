CREATE DATABASE SM_DB
GO
USE SM_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(120)
	CONSTRAINT pk_YoneticiTurleri PRIMARY KEY(ID)
)
GO

INSERT INTO YoneticiTurleri (Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri (Isim) VALUES('Moderatör')
INSERT INTO YoneticiTurleri (Isim) VALUES('Eleþtirmen')

GO

CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	Isim nvarchar(120) NOT NULL,
	Soyisim nvarchar(120) NOT NULL,
	Mail nvarchar(200) NOT NULL,
	KullaniciAdi nvarchar(50),
	Sifre nvarchar(20),
	AktifMi bit,
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiTur FOREIGN KEY(YoneticiTur_ID) 
	REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler (YoneticiTur_ID, Isim, Soyisim, Mail, KullaniciAdi, Sifre, Aktifmi)
VALUES(1,'Samet', 'Kapar', 'sk@smdb.com','MCMLXV','1965',1)
INSERT INTO Yoneticiler (YoneticiTur_ID, Isim, Soyisim, Mail, KullaniciAdi, Sifre, Aktifmi)
VALUES(2,'Alp', 'Sarýkýþla', 'as@smdb.com','CodeBreaker','1234',1)
INSERT INTO Yoneticiler (YoneticiTur_ID, Isim, Soyisim, Mail, KullaniciAdi, Sifre, Aktifmi)
VALUES(3,'Mevlüt', 'Koyuncu', 'mk@smdb.com','NeighborCode','1234',1)
GO

CREATE TABLE Kategori
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	Durum bit,
	CONSTRAINT pk_Kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Sanatci
(
	ID int IDENTITY(1,1),
	Isim nvarchar(200),
	Soyisim nvarchar(200),
	GrupMu bit,
	Durum bit,
	CONSTRAINT pk_Sanatci PRIMARY KEY(ID)
)
GO
CREATE TABLE Album
(
	ID int IDENTITY(1,1),
	Sanatci_ID int,
	CikisYili Datetime,
	OylanmaSayisi bigint,
	KapakFoto nvarchar(50),
	MuzikSayisi tinyint,
	Durum bit,
	CONSTRAINT pk_Album	PRIMARY KEY(ID),
	CONSTRAINT fk_SanatciAlbum FOREIGN KEY(Sanatci_ID)
	REFERENCES Sanatci(ID)
)
GO
CREATE TABLE Muzik
(
	ID int IDENTITY(1,1),
	Album_ID int,
	Isim nvarchar(200),
	Durum bit,
	CONSTRAINT pk_Muzik PRIMARY KEY(ID),
	CONSTRAINT fk_MuzikAlbum FOREIGN KEY(Album_ID)
	REFERENCES Album(ID)
)
GO
CREATE TABLE MuzikTur
(
	ID int IDENTITY(1,1),
	Isim nvarchar(120),
	CONSTRAINT pk_MuzikTur PRIMARY KEY(ID)
)
GO
CREATE TABLE MuzikTurleri
(
	ID bigint IDENTITY(1,1),
	Muzik_ID int,
	Tur_ID int,
	CONSTRAINT pk_MuzikTurleri PRIMARY KEY(ID),
	CONSTRAINT fk_MuzikTurMuzik FOREIGN KEY(Muzik_ID)
	REFERENCES Muzik(ID),
	CONSTRAINT fk_MuzikTurTur FOREIGN KEY(Tur_ID)
	REFERENCES MuzikTur(ID)
)
GO
CREATE TABLE PlakSirket
(
	ID int IDENTITY(1,1),
	Isim nvarchar(200),
	Adres ntext,
	Telefon nvarchar(50),
	Durum bit,
	CONSTRAINT pk_PlakSirket PRIMARY KEY(ID)
)
GO
CREATE TABLE AlbumSirket
(
	ID int IDENTITY(1,1),
	Album_ID int,
	Sirket_ID int,
	CONSTRAINT pk_AlbumSirket PRIMARY KEY(ID),
	CONSTRAINT fk_AlbumSirketAlbum FOREIGN KEY(Album_ID)
	REFERENCES Album(ID),
	CONSTRAINT fk_AlbumSirketSirket FOREIGN KEY(Sirket_ID)
	REFERENCES PlakSirket(ID)
)
GO
CREATE TABLE Kullanici
(
	ID int IDENTITY(1,1),
	Isim nvarchar(120) NOT NULL,
	Soyisim nvarchar(120) NOT NULL,
	Mail nvarchar(200) NOT NULL,
	KullaniciAdi nvarchar(50),
	Sifre nvarchar(20),
	AktifMi bit,
	CONSTRAINT pk_Kullanici PRIMARY KEY(ID)
)
GO
CREATE TABLE CriticReviews
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	Kategori_ID int,
	Yorum nvarchar(500),
	EklemeTarihi Datetime,
	Durum Bit,
	CONSTRAINT pk_CriticReviews PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiTurCritic FOREIGN KEY(YoneticiTur_ID)
	REFERENCES Yoneticiler(ID),
	CONSTRAINT fk_KategoriCritic FOREIGN KEY(Kategori_ID)
	REFERENCES Kategori(ID)
)
GO
CREATE TABLE UserReviews
(
	ID int IDENTITY(1,1),
	Uye_ID int,
	Kategori_ID int,
	Yorum nvarchar(500),
	EklemeTarihi Datetime,
	Durum Bit,
	CONSTRAINT pk_UserReviews PRIMARY KEY(ID),
	CONSTRAINT fk_KullaniciReviews FOREIGN KEY(Uye_ID)
	REFERENCES Kullanici(ID),
	CONSTRAINT fk_KategoriReviews FOREIGN KEY(Kategori_ID)
	REFERENCES Kategori(ID)
)
GO
CREATE TABLE KullaniciMusicList
(
	ID int IDENTITY(1,1),
	Uye_ID int,
	Muzik_ID int,
	UserRev_ID int,
	Dinledim Bit,
	Dinleyecem Bit,
	CONSTRAINT pk_KullaniciMusicList PRIMARY KEY(ID),
	CONSTRAINT fk_ListUye FOREIGN KEY(Uye_ID)
	REFERENCES Kullanici(ID),
	CONSTRAINT fk_ListMuzik FOREIGN KEY(Muzik_ID)
	REFERENCES Muzik(ID),
	CONSTRAINT fk_ListRev FOREIGN KEY(UserRev_ID)
	REFERENCES UserReviews(ID)
)
GO





