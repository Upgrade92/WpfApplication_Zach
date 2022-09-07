USE [master]
GO
/****** Object:  Database [WPFApp_Database]    Script Date: 07.09.2022 11:58:13 ******/
CREATE DATABASE [WPFApp_Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WPFApp_Database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL\MSSQL\DATA\WPFApp_Database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WPFApp_Database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL\MSSQL\DATA\WPFApp_Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WPFApp_Database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WPFApp_Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WPFApp_Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WPFApp_Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WPFApp_Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WPFApp_Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WPFApp_Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [WPFApp_Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WPFApp_Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WPFApp_Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WPFApp_Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WPFApp_Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WPFApp_Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WPFApp_Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WPFApp_Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WPFApp_Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WPFApp_Database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WPFApp_Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WPFApp_Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WPFApp_Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WPFApp_Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WPFApp_Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WPFApp_Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WPFApp_Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WPFApp_Database] SET RECOVERY FULL 
GO
ALTER DATABASE [WPFApp_Database] SET  MULTI_USER 
GO
ALTER DATABASE [WPFApp_Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WPFApp_Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WPFApp_Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WPFApp_Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WPFApp_Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WPFApp_Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WPFApp_Database', N'ON'
GO
ALTER DATABASE [WPFApp_Database] SET QUERY_STORE = OFF
GO
USE [WPFApp_Database]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 07.09.2022 11:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablePeople]    Script Date: 07.09.2022 11:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablePeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[E-Mail] [nvarchar](50) NOT NULL,
	[Geschlecht] [nvarchar](50) NOT NULL,
	[Geburtstag] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WPFApp_Database] SET  READ_WRITE 
GO
