USE [master]
GO
/****** Object:  Database [UrunTakip]    Script Date: 12.09.2020 10:44:39 ******/
CREATE DATABASE [UrunTakip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KAMYONTAKIP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KAMYONTAKIP.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KAMYONTAKIP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KAMYONTAKIP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UrunTakip] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UrunTakip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UrunTakip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UrunTakip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UrunTakip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UrunTakip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UrunTakip] SET ARITHABORT OFF 
GO
ALTER DATABASE [UrunTakip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UrunTakip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UrunTakip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UrunTakip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UrunTakip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UrunTakip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UrunTakip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UrunTakip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UrunTakip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UrunTakip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UrunTakip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UrunTakip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UrunTakip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UrunTakip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UrunTakip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UrunTakip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UrunTakip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UrunTakip] SET RECOVERY FULL 
GO
ALTER DATABASE [UrunTakip] SET  MULTI_USER 
GO
ALTER DATABASE [UrunTakip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UrunTakip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UrunTakip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UrunTakip] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UrunTakip] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UrunTakip', N'ON'
GO
USE [UrunTakip]
GO
/****** Object:  Table [dbo].[TBL_Musteriler]    Script Date: 12.09.2020 10:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Musteriler](
	[MusteriId] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAd] [varchar](50) NULL,
	[MusteriSoyad] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_Musteriler] PRIMARY KEY CLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Satislar]    Script Date: 12.09.2020 10:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Satislar](
	[SatisId] [int] IDENTITY(1,1) NOT NULL,
	[Urun] [int] NULL,
	[Musteri] [int] NULL,
	[Adet] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[SevkTarihi] [datetime2](7) NULL,
	[KamyonPlaka] [varchar](20) NULL,
	[KamyonDurum] [int] NULL,
 CONSTRAINT [PK_TBL_Siparis] PRIMARY KEY CLUSTERED 
(
	[SatisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Urunler]    Script Date: 12.09.2020 10:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Urunler](
	[UrunId] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [varchar](50) NULL,
	[UrunFiyat] [decimal](18, 2) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_TBL_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Users]    Script Date: 12.09.2020 10:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](64) NULL,
	[UserPassword] [varchar](64) NULL,
 CONSTRAINT [PK_TBL_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_Musteriler] ON 

INSERT [dbo].[TBL_Musteriler] ([MusteriId], [MusteriAd], [MusteriSoyad]) VALUES (1, N'Ahmet', N'Sezer')
INSERT [dbo].[TBL_Musteriler] ([MusteriId], [MusteriAd], [MusteriSoyad]) VALUES (2, N'Mustafa', N'Yagci')
INSERT [dbo].[TBL_Musteriler] ([MusteriId], [MusteriAd], [MusteriSoyad]) VALUES (3, N'Resulll', N'Dasss')
INSERT [dbo].[TBL_Musteriler] ([MusteriId], [MusteriAd], [MusteriSoyad]) VALUES (1013, N'Islam', N'Sahin')
INSERT [dbo].[TBL_Musteriler] ([MusteriId], [MusteriAd], [MusteriSoyad]) VALUES (1016, N'Yasin', N'Yagci')
SET IDENTITY_INSERT [dbo].[TBL_Musteriler] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_Satislar] ON 

INSERT [dbo].[TBL_Satislar] ([SatisId], [Urun], [Musteri], [Adet], [Fiyat], [SevkTarihi], [KamyonPlaka], [KamyonDurum]) VALUES (1, 2, 2, 2, CAST(2.00 AS Decimal(18, 2)), CAST(N'1996-10-02T00:00:00.0000000' AS DateTime2), N'09 TC 02', 1)
INSERT [dbo].[TBL_Satislar] ([SatisId], [Urun], [Musteri], [Adet], [Fiyat], [SevkTarihi], [KamyonPlaka], [KamyonDurum]) VALUES (2, 3, 2, 2, CAST(2.00 AS Decimal(18, 2)), CAST(N'1997-10-04T00:00:00.0000000' AS DateTime2), N'09 TC 10', 0)
INSERT [dbo].[TBL_Satislar] ([SatisId], [Urun], [Musteri], [Adet], [Fiyat], [SevkTarihi], [KamyonPlaka], [KamyonDurum]) VALUES (12, 1016, 1016, 1, CAST(999999.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'09 TR 999', 1)
INSERT [dbo].[TBL_Satislar] ([SatisId], [Urun], [Musteri], [Adet], [Fiyat], [SevkTarihi], [KamyonPlaka], [KamyonDurum]) VALUES (14, 1, 1, 123, CAST(123.00 AS Decimal(18, 2)), CAST(N'1111-11-11T00:00:00.0000000' AS DateTime2), N'11-tc-11', 2)
INSERT [dbo].[TBL_Satislar] ([SatisId], [Urun], [Musteri], [Adet], [Fiyat], [SevkTarihi], [KamyonPlaka], [KamyonDurum]) VALUES (15, 3, 1016, 25, CAST(1.00 AS Decimal(18, 2)), CAST(N'1952-12-12T00:00:00.0000000' AS DateTime2), N'07-tc-07', 2)
SET IDENTITY_INSERT [dbo].[TBL_Satislar] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_Urunler] ON 

INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (1, N'Tugla', CAST(50.00 AS Decimal(18, 2)), 500)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (2, N'Micir', CAST(25.00 AS Decimal(18, 2)), 350)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (3, N'Çimentoo', CAST(75.75 AS Decimal(18, 2)), 1212)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (1013, N'odunt', CAST(2525.07 AS Decimal(18, 2)), 1567)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (1014, N'anten', CAST(32.00 AS Decimal(18, 2)), 23)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (1015, N'bardak', CAST(12.00 AS Decimal(18, 2)), 123)
INSERT [dbo].[TBL_Urunler] ([UrunId], [UrunAdi], [UrunFiyat], [Stok]) VALUES (1016, N'Mijölnir', CAST(99999.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[TBL_Urunler] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_Users] ON 

INSERT [dbo].[TBL_Users] ([UserId], [UserName], [UserPassword]) VALUES (1, N'yasinyagci0990@gmail.com', N'yasin')
INSERT [dbo].[TBL_Users] ([UserId], [UserName], [UserPassword]) VALUES (3, N'test@gmail.com123', N'test123')
INSERT [dbo].[TBL_Users] ([UserId], [UserName], [UserPassword]) VALUES (4, N'testest@gmail.com', N'testest@gmail.com')
SET IDENTITY_INSERT [dbo].[TBL_Users] OFF
GO
ALTER TABLE [dbo].[TBL_Satislar]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Satislar_TBL_Musteriler] FOREIGN KEY([Musteri])
REFERENCES [dbo].[TBL_Musteriler] ([MusteriId])
GO
ALTER TABLE [dbo].[TBL_Satislar] CHECK CONSTRAINT [FK_TBL_Satislar_TBL_Musteriler]
GO
ALTER TABLE [dbo].[TBL_Satislar]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Satislar_TBL_Urunler] FOREIGN KEY([Urun])
REFERENCES [dbo].[TBL_Urunler] ([UrunId])
GO
ALTER TABLE [dbo].[TBL_Satislar] CHECK CONSTRAINT [FK_TBL_Satislar_TBL_Urunler]
GO
USE [master]
GO
ALTER DATABASE [UrunTakip] SET  READ_WRITE 
GO
