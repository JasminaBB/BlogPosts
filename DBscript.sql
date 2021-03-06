USE [master]
GO
/****** Object:  Database [BlogPost]    Script Date: 4/1/2020 3:07:36 PM ******/
CREATE DATABASE [BlogPost]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogPost', FILENAME = N'C:\Users\jasmina\BlogPost.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogPost_log', FILENAME = N'C:\Users\jasmina\BlogPost_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlogPost] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogPost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogPost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogPost] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogPost] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BlogPost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogPost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogPost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogPost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogPost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogPost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogPost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogPost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogPost] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlogPost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogPost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogPost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogPost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogPost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogPost] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlogPost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogPost] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogPost] SET  MULTI_USER 
GO
ALTER DATABASE [BlogPost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogPost] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogPost] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogPost] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogPost] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlogPost] SET QUERY_STORE = OFF
GO
USE [BlogPost]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BlogPost]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/1/2020 3:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 4/1/2020 3:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[Id] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPostTag]    Script Date: 4/1/2020 3:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPostTag](
	[BlogPostId] [nvarchar](450) NOT NULL,
	[TagId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_BlogPostTag] PRIMARY KEY CLUSTERED 
(
	[BlogPostId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 4/1/2020 3:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200330211247_InitialCreate', N'2.1.14-servicing-32113')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200330211432_AddedSlugForBlogPost', N'2.1.14-servicing-32113')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200330230913_AddedDatabaseGeneratedId', N'2.1.14-servicing-32113')
INSERT [dbo].[BlogPosts] ([Id], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [Slug]) VALUES (N'1607dff5-eb38-4b00-83d2-35c3ec6c1815', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2020-04-01T13:28:02.6148087' AS DateTime2), CAST(N'2020-04-01T13:28:02.6150541' AS DateTime2), N'augmented-reality-ios-application')
INSERT [dbo].[BlogPosts] ([Id], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [Slug]) VALUES (N'31b24b17-e49a-4ce1-ba3b-93beaef65835', N'internet-trends-2018', N'An opinionated commentary, of the most important presentation of the year', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-04-01T02:04:07.9655631' AS DateTime2), CAST(N'2020-04-01T15:02:07.7752126' AS DateTime2), N'internet-trends-2018')
INSERT [dbo].[BlogPosts] ([Id], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [Slug]) VALUES (N'4e57ffe6-13e7-4228-b78b-8ef433ff1f5f', N'New internet-trends-2018', N'Updated blog post', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-03-31T01:31:17.8024497' AS DateTime2), CAST(N'2020-04-01T14:02:08.2158810' AS DateTime2), N'new-internet-trends-2018')
INSERT [dbo].[BlogPosts] ([Id], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [Slug]) VALUES (N'9dbf25e5-2732-432f-a071-60fc1d6f7576', N'Internet trends 2020', N'Post for Internet trends 2020', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-04-01T12:37:18.8710651' AS DateTime2), CAST(N'2020-04-01T12:37:23.2164062' AS DateTime2), N'internet-trends-2020')
INSERT [dbo].[BlogPostTag] ([BlogPostId], [TagId]) VALUES (N'31b24b17-e49a-4ce1-ba3b-93beaef65835', N'15ab6c4b-2e45-4bf9-ad90-fa927218c4cf')
INSERT [dbo].[BlogPostTag] ([BlogPostId], [TagId]) VALUES (N'9dbf25e5-2732-432f-a071-60fc1d6f7576', N'7a1fbfd5-c1a7-4ebc-83be-3acbbb2acf67')
INSERT [dbo].[BlogPostTag] ([BlogPostId], [TagId]) VALUES (N'1607dff5-eb38-4b00-83d2-35c3ec6c1815', N'dd466ee0-7195-4564-bfa7-ef232e06f175')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'15ab6c4b-2e45-4bf9-ad90-fa927218c4cf', N'2018')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'237ba77b-723c-4a70-9e50-f7120edc661b', N'iOS')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'782795d1-5cd7-4105-9d95-ae142b09dc47', N'innovation')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'7a1fbfd5-c1a7-4ebc-83be-3acbbb2acf67', N'Angular')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'dd466ee0-7195-4564-bfa7-ef232e06f175', N'AR')
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_SLUG]    Script Date: 4/1/2020 3:07:36 PM ******/
CREATE NONCLUSTERED INDEX [IDX_SLUG] ON [dbo].[BlogPosts]
(
	[Id] ASC
)
INCLUDE([Slug]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_BlogPostTag_TagId]    Script Date: 4/1/2020 3:07:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogPostTag_TagId] ON [dbo].[BlogPostTag]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  DEFAULT (N'') FOR [Slug]
GO
ALTER TABLE [dbo].[BlogPostTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogPostTag_BlogPosts_BlogPostId] FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPosts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogPostTag] CHECK CONSTRAINT [FK_BlogPostTag_BlogPosts_BlogPostId]
GO
ALTER TABLE [dbo].[BlogPostTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogPostTag_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogPostTag] CHECK CONSTRAINT [FK_BlogPostTag_Tags_TagId]
GO
USE [master]
GO
ALTER DATABASE [BlogPost] SET  READ_WRITE 
GO
