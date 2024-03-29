USE [master]
GO

/****** Object:  Database [MoviesAPI]    Script Date: 7/25/2023 8:27:05 PM ******/
CREATE DATABASE [MoviesAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoviesAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MoviesAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoviesAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MoviesAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoviesAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MoviesAPI] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MoviesAPI] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MoviesAPI] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MoviesAPI] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MoviesAPI] SET ARITHABORT OFF 
GO

ALTER DATABASE [MoviesAPI] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [MoviesAPI] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MoviesAPI] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MoviesAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MoviesAPI] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MoviesAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MoviesAPI] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MoviesAPI] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MoviesAPI] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MoviesAPI] SET  ENABLE_BROKER 
GO

ALTER DATABASE [MoviesAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MoviesAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MoviesAPI] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MoviesAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MoviesAPI] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MoviesAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [MoviesAPI] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MoviesAPI] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MoviesAPI] SET  MULTI_USER 
GO

ALTER DATABASE [MoviesAPI] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MoviesAPI] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MoviesAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MoviesAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MoviesAPI] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MoviesAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MoviesAPI] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MoviesAPI] SET  READ_WRITE 
GO


