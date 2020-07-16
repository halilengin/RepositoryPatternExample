# RepositoryPatternExample


1-) Spesific olarak şu tasarım desenini tanımını bilerek kullanmadım, sadece standart bir repository pattern ile geliştirilmiş bir API projesi geliştirdim.
2-) EntityFramework .Net Developer olarak sürekli kullandığımız bir ORM, bunun yanında olmazsa olmaz Linq proje geliştirme esnasında kullandım.
    Kullanım nedenleri veri filtrelemesi ve Veritabanı işlemleri için. 
    DI için ilk defa AutoFac kullandım.
3-) Rol bazlı işlem yetkileri, generic result nesneleri, JWT, Cacheleme ve Loglama eklemek isterdim. Standart bir Blog sitesinde olması gereken omurgayı minimal
    düzeyde oluşturmak isterdim.
4-) Sağlıklı günler :)


Projede kullanılan veritabanı;

USE [master]
GO
/****** Object:  Database [ArticleDb]    Script Date: 17.07.2020 00:22:32 ******/
CREATE DATABASE [ArticleDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArticleDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ArticleDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ArticleDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ArticleDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ArticleDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArticleDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArticleDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArticleDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArticleDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArticleDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArticleDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArticleDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArticleDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArticleDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArticleDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArticleDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArticleDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArticleDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArticleDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArticleDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArticleDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArticleDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArticleDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArticleDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArticleDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArticleDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArticleDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArticleDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArticleDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArticleDb] SET  MULTI_USER 
GO
ALTER DATABASE [ArticleDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArticleDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArticleDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArticleDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ArticleDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ArticleDb]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 17.07.2020 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Contain] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.07.2020 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NickName] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [UserId], [Title], [Contain]) VALUES (1, 1, N'postmant update', N'postman update test 123456')
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [NickName], [Email], [Password]) VALUES (1, N'admin', N'halilengin39@gmail.com', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Users]
GO
USE [master]
GO
ALTER DATABASE [ArticleDb] SET  READ_WRITE 
GO
