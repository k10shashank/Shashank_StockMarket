USE [master]
GO
/****** Object:  Database [stockmarketdb]    Script Date: 05-08-2020 1.06.13 PM ******/
CREATE DATABASE [stockmarketdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'stockmarketdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\stockmarketdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'stockmarketdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\stockmarketdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [stockmarketdb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stockmarketdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stockmarketdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stockmarketdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stockmarketdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stockmarketdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stockmarketdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [stockmarketdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [stockmarketdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stockmarketdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stockmarketdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stockmarketdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stockmarketdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stockmarketdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stockmarketdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stockmarketdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stockmarketdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [stockmarketdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stockmarketdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stockmarketdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stockmarketdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stockmarketdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stockmarketdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stockmarketdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stockmarketdb] SET RECOVERY FULL 
GO
ALTER DATABASE [stockmarketdb] SET  MULTI_USER 
GO
ALTER DATABASE [stockmarketdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stockmarketdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [stockmarketdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [stockmarketdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [stockmarketdb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'stockmarketdb', N'ON'
GO
ALTER DATABASE [stockmarketdb] SET QUERY_STORE = OFF
GO
USE [stockmarketdb]
GO
/****** Object:  Table [dbo].[company]    Script Date: 05-08-2020 1.06.14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[companyCode] [int] NOT NULL,
	[companyName] [nvarchar](50) NOT NULL,
	[turnover] [float] NULL,
	[ceo] [nvarchar](50) NULL,
	[boardDirector] [nvarchar](50) NULL,
	[listedStockExchange] [nvarchar](50) NULL,
	[sectorID] [int] NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[companyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sector]    Script Date: 05-08-2020 1.06.14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector](
	[sectorID] [int] NOT NULL,
	[sectorName] [nvarchar](50) NOT NULL,
	[brief] [nvarchar](50) NULL,
 CONSTRAINT [PK_sector] PRIMARY KEY CLUSTERED 
(
	[sectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockexchange]    Script Date: 05-08-2020 1.06.14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockexchange](
	[stockExchangeID] [int] NOT NULL,
	[stockExchangeName] [nvarchar](50) NOT NULL,
	[brief] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_stockexchange] PRIMARY KEY CLUSTERED 
(
	[stockExchangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockprice]    Script Date: 05-08-2020 1.06.14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockprice](
	[stockpriceID] [int] IDENTITY(1,1) NOT NULL,
	[companyCode] [int] NOT NULL,
	[stockExchangeID] [int] NOT NULL,
	[currentPrice] [float] NOT NULL,
	[date] [date] NOT NULL,
	[time] [time](7) NOT NULL,
 CONSTRAINT [PK_stockprice_1] PRIMARY KEY CLUSTERED 
(
	[stockpriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 05-08-2020 1.06.14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[userId] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[userType] [nchar](1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[confirmed] [nvarchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[company]  WITH CHECK ADD  CONSTRAINT [FK_company_sector] FOREIGN KEY([sectorID])
REFERENCES [dbo].[sector] ([sectorID])
GO
ALTER TABLE [dbo].[company] CHECK CONSTRAINT [FK_company_sector]
GO
ALTER TABLE [dbo].[stockprice]  WITH CHECK ADD  CONSTRAINT [FK_stockprice_company] FOREIGN KEY([companyCode])
REFERENCES [dbo].[company] ([companyCode])
GO
ALTER TABLE [dbo].[stockprice] CHECK CONSTRAINT [FK_stockprice_company]
GO
ALTER TABLE [dbo].[stockprice]  WITH CHECK ADD  CONSTRAINT [FK_stockprice_stockexchange] FOREIGN KEY([stockExchangeID])
REFERENCES [dbo].[stockexchange] ([stockExchangeID])
GO
ALTER TABLE [dbo].[stockprice] CHECK CONSTRAINT [FK_stockprice_stockexchange]
GO
USE [master]
GO
ALTER DATABASE [stockmarketdb] SET  READ_WRITE 
GO
