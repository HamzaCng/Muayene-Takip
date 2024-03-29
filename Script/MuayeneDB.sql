USE [master]
GO
/****** Object:  Database [MuayeneDB]    Script Date: 28.03.2019 18:05:33 ******/
CREATE DATABASE [MuayeneDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MuayeneDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MuayeneDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MuayeneDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MuayeneDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MuayeneDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MuayeneDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MuayeneDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MuayeneDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MuayeneDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MuayeneDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MuayeneDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MuayeneDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MuayeneDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MuayeneDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MuayeneDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MuayeneDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MuayeneDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MuayeneDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MuayeneDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MuayeneDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MuayeneDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MuayeneDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MuayeneDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MuayeneDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MuayeneDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MuayeneDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MuayeneDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MuayeneDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MuayeneDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MuayeneDB] SET  MULTI_USER 
GO
ALTER DATABASE [MuayeneDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MuayeneDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MuayeneDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MuayeneDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MuayeneDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MuayeneDB] SET QUERY_STORE = OFF
GO
USE [MuayeneDB]
GO
/****** Object:  Table [dbo].[Hasta]    Script Date: 28.03.2019 18:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hasta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TcKimlikNo] [char](11) NOT NULL,
	[Ad] [varchar](30) NOT NULL,
	[Soyad] [varchar](30) NOT NULL,
	[DogumTarihi] [date] NULL,
	[CinsiyetEnum] [tinyint] NOT NULL,
	[KanGrubuEnum] [tinyint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Hasta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaDetay]    Script Date: 28.03.2019 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaDetay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MedeniHalEnum] [tinyint] NULL,
	[ResimYolu] [varchar](max) NULL,
	[Notlar] [varchar](500) NULL,
	[HastaID] [int] NOT NULL,
 CONSTRAINT [PK_HastaDetay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iletisim]    Script Date: 28.03.2019 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iletisim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Telefon] [char](10) NULL,
	[Adres] [varchar](250) NULL,
	[HastaID] [int] NOT NULL,
 CONSTRAINT [PK_Iletisim] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 28.03.2019 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTable](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](50) NOT NULL,
	[OldData] [varchar](max) NULL,
	[NewData] [varchar](max) NULL,
	[ProcessType] [tinyint] NOT NULL,
 CONSTRAINT [PK_LogTable] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Hasta] ON 

INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (6, N'11111111122', N'Enes', N'Akderel', CAST(N'2019-03-25' AS Date), 2, 3, 0)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (7, N'66666666666', N'Onur', N'Çiçek', CAST(N'2019-03-25' AS Date), 2, 3, 0)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (8, N'99999999999', N'sdfasf', N'adsfa', CAST(N'2019-03-26' AS Date), 1, 5, 0)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (10, N'12312321321', N'oamdnafasdf', N'asdfasdf', CAST(N'2019-03-27' AS Date), 2, 2, 1)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (11, N'23423423423', N'osman', N'yazici', CAST(N'2019-03-27' AS Date), 2, 5, 0)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (12, N'21312312313', N'sadfasdf', N'asdfasdf', CAST(N'2019-03-27' AS Date), 2, 2, 0)
INSERT [dbo].[Hasta] ([ID], [TcKimlikNo], [Ad], [Soyad], [DogumTarihi], [CinsiyetEnum], [KanGrubuEnum], [IsDeleted]) VALUES (18, N'35353535353', N'alafor', N'tanfoni', CAST(N'2019-03-27' AS Date), 3, 8, 0)
SET IDENTITY_INSERT [dbo].[Hasta] OFF
SET IDENTITY_INSERT [dbo].[HastaDetay] ON 

INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (6, 2, N'C:\Users\X\Desktop\DSC_0704.JPG', N'sdfsdf', 6)
INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (7, 2, N'', N'dfdf', 7)
INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (8, 1, NULL, N'asdfas', 8)
INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (11, 2, NULL, N'sadfadsf', 11)
INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (12, 2, NULL, N'asdfa', 12)
INSERT [dbo].[HastaDetay] ([ID], [MedeniHalEnum], [ResimYolu], [Notlar], [HastaID]) VALUES (18, 1, NULL, N'dfsdf', 18)
SET IDENTITY_INSERT [dbo].[HastaDetay] OFF
SET IDENTITY_INSERT [dbo].[Iletisim] ON 

INSERT [dbo].[Iletisim] ([ID], [Telefon], [Adres], [HastaID]) VALUES (6, N'234234324 ', N'dfsfd', 6)
INSERT [dbo].[Iletisim] ([ID], [Telefon], [Adres], [HastaID]) VALUES (8, N'23232     ', N'fasdfa', 8)
INSERT [dbo].[Iletisim] ([ID], [Telefon], [Adres], [HastaID]) VALUES (11, N'23432     ', N'sdf sa', 11)
INSERT [dbo].[Iletisim] ([ID], [Telefon], [Adres], [HastaID]) VALUES (12, N'23234     ', N'sdfad', 12)
INSERT [dbo].[Iletisim] ([ID], [Telefon], [Adres], [HastaID]) VALUES (18, N'2343233   ', N'sdfsdf', 18)
SET IDENTITY_INSERT [dbo].[Iletisim] OFF
SET IDENTITY_INSERT [dbo].[LogTable] ON 

INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (1, N'Hasta', N'{ID:"9",TcKimlikNo:"234234234  ",Ad:"sdfads",Soyad:"asdfads",DogumTarihi:"2019-03-27",CinsiyetEnum:"2",KanGrubuEnum:"2",IsDeleted:"0"}', NULL, 2)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (7, N'Hasta', NULL, N'{ID:"18",TcKimlikNo:"35353535353",Ad:"alafor",Soyad:"tanfoni",DogumTarihi:"2019-03-27",CinsiyetEnum:"3",KanGrubuEnum:"8",IsDeleted:"0"}', 1)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (8, N'Hasta', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"asdfasdfas",Soyad:"sdfsdfsdf",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"Alafortanfoni",Soyad:"sdfsdfsdf",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', 3)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (9, N'Hasta', N'{ID:"10",TcKimlikNo:"12312321321",Ad:"oamdnafasdf",Soyad:"asdfasdf",DogumTarihi:"2019-03-27",CinsiyetEnum:"2",KanGrubuEnum:"2",IsDeleted:"0"}', N'{ID:"10",TcKimlikNo:"12312321321",Ad:"oamdnafasdf",Soyad:"asdfasdf",DogumTarihi:"2019-03-27",CinsiyetEnum:"2",KanGrubuEnum:"2",IsDeleted:"1"}', 3)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (10, N'Hasta', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"Alafortanfoni",Soyad:"sdfsdfsdf",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"Enes",Soyad:"Akdereli",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', 3)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (11, N'Hasta', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"Enes",Soyad:"Akdereli",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', N'{ID:"6",TcKimlikNo:"11111111122",Ad:"Enes",Soyad:"Akderel",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', 3)
INSERT [dbo].[LogTable] ([LogID], [TableName], [OldData], [NewData], [ProcessType]) VALUES (12, N'Hasta', N'{ID:"7",TcKimlikNo:"66666666666",Ad:"sdfds",Soyad:"sdfsf",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', N'{ID:"7",TcKimlikNo:"66666666666",Ad:"Onur",Soyad:"Çiçek",DogumTarihi:"2019-03-25",CinsiyetEnum:"2",KanGrubuEnum:"3",IsDeleted:"0"}', 3)
SET IDENTITY_INSERT [dbo].[LogTable] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Hasta]    Script Date: 28.03.2019 18:05:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Hasta] ON [dbo].[Hasta]
(
	[TcKimlikNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Iletisim]    Script Date: 28.03.2019 18:05:35 ******/
ALTER TABLE [dbo].[Iletisim] ADD  CONSTRAINT [IX_Iletisim] UNIQUE NONCLUSTERED 
(
	[Telefon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HastaDetay]  WITH CHECK ADD  CONSTRAINT [FK_HastaDetay_Hasta] FOREIGN KEY([HastaID])
REFERENCES [dbo].[Hasta] ([ID])
GO
ALTER TABLE [dbo].[HastaDetay] CHECK CONSTRAINT [FK_HastaDetay_Hasta]
GO
ALTER TABLE [dbo].[Iletisim]  WITH CHECK ADD  CONSTRAINT [FK_Iletisim_Hasta] FOREIGN KEY([HastaID])
REFERENCES [dbo].[Hasta] ([ID])
GO
ALTER TABLE [dbo].[Iletisim] CHECK CONSTRAINT [FK_Iletisim_Hasta]
GO
/****** Object:  StoredProcedure [dbo].[sp_HastaGuncelle]    Script Date: 28.03.2019 18:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_HastaGuncelle]
(
@Id int,
@Tc char(11),
@Ad	varchar(30),
@Soyad varchar(30),
@DogumTarihi date,
@Cinsiyet tinyint,
@KanGrubu tinyint,
@MedeniHal tinyint,
@Adres varchar(250),
@Telefon char(10),
@Notlar varchar(500),
@ResimYolu varchar(max)
)
as
begin
	begin tran
	begin try
		update Hasta set TcKimlikNo=@Tc,Ad=@Ad,Soyad=@Soyad,CinsiyetEnum=@Cinsiyet,DogumTarihi=@DogumTarihi,KanGrubuEnum=@KanGrubu where ID=@Id
		update HastaDetay set MedeniHalEnum=@MedeniHal,Notlar=@Notlar,ResimYolu=@ResimYolu where HastaID=@Id
		update Iletisim set Adres=@Adres,Telefon=@Telefon where HastaID=@Id
		commit tran
	end try
	begin catch
		rollback tran
		throw
	end catch
end
GO
USE [master]
GO
ALTER DATABASE [MuayeneDB] SET  READ_WRITE 
GO
