USE [master]
GO
/****** Object:  Database [OHD]    Script Date: 11/16/2021 10:03:43 PM ******/
CREATE DATABASE [OHD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OHD', FILENAME = N'E:\sql\MSSQL15.MSSQLSERVER\MSSQL\DATA\OHD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OHD_log', FILENAME = N'E:\sql\MSSQL15.MSSQLSERVER\MSSQL\DATA\OHD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OHD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OHD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OHD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OHD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OHD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OHD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OHD] SET ARITHABORT OFF 
GO
ALTER DATABASE [OHD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OHD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OHD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OHD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OHD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OHD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OHD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OHD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OHD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OHD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OHD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OHD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OHD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OHD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OHD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OHD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OHD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OHD] SET RECOVERY FULL 
GO
ALTER DATABASE [OHD] SET  MULTI_USER 
GO
ALTER DATABASE [OHD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OHD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OHD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OHD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OHD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OHD', N'ON'
GO
ALTER DATABASE [OHD] SET QUERY_STORE = OFF
GO
USE [OHD]
GO
/****** Object:  Table [dbo].[account]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[role_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK__account__3213E83F74F9BBA9] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facility]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facility](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[head_account_id] [int] NULL,
	[description] [text] NULL,
 CONSTRAINT [PK__facility__3213E83F97CB6EB5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[head_task]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[head_task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[request_by_user_id] [int] NULL,
	[head_task_status] [varchar](255) NULL,
	[note] [text] NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[head_account_id] [int] NULL,
 CONSTRAINT [PK__head_tas__3213E83F0C83CCEB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[req_log]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[req_log](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[request_by_user_id] [int] NULL,
	[log_time] [datetime] NULL,
	[status] [varchar](50) NULL,
	[req_content] [varchar](255) NULL,
	[user_account_id] [int] NULL,
 CONSTRAINT [req_log_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[request_by_user]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[request_by_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[request_priority_id] [int] NULL,
	[request_status_id] [int] NULL,
	[description] [varchar](255) NULL,
	[facility_id] [int] NULL,
	[account_id] [int] NULL,
	[service_id] [int] NULL,
	[reason_close_request] [varchar](255) NULL,
 CONSTRAINT [PK__request___3213E83F3F8975A9] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[request_priority]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[request_priority](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK__request___3213E83F18C62229] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[request_status]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[request_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
 CONSTRAINT [PK__request___3213E83F79D1D2F8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
 CONSTRAINT [PK__role__3213E83F6447DDF3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[facility_id] [int] NULL,
	[description] [text] NULL,
 CONSTRAINT [PK__service__3213E83F6352E5BA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_task]    Script Date: 11/16/2021 10:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[request_by_user_id] [int] NULL,
	[user_task_status] [varchar](255) NULL,
	[note] [text] NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[head_task_id] [int] NULL,
	[user_account_id] [int] NULL,
 CONSTRAINT [PK__user_tas__3213E83FF0BCBF14] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [FK__account__role_id__398D8EEE] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [FK__account__role_id__398D8EEE]
GO
ALTER TABLE [dbo].[facility]  WITH CHECK ADD  CONSTRAINT [FK_facility_account] FOREIGN KEY([head_account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[facility] CHECK CONSTRAINT [FK_facility_account]
GO
ALTER TABLE [dbo].[head_task]  WITH CHECK ADD  CONSTRAINT [FK__head_task__head___3D5E1FD2] FOREIGN KEY([head_account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[head_task] CHECK CONSTRAINT [FK__head_task__head___3D5E1FD2]
GO
ALTER TABLE [dbo].[head_task]  WITH CHECK ADD  CONSTRAINT [FK__head_task__reque__3A81B327] FOREIGN KEY([request_by_user_id])
REFERENCES [dbo].[request_by_user] ([id])
GO
ALTER TABLE [dbo].[head_task] CHECK CONSTRAINT [FK__head_task__reque__3A81B327]
GO
ALTER TABLE [dbo].[req_log]  WITH CHECK ADD  CONSTRAINT [FK_req_log_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[req_log] CHECK CONSTRAINT [FK_req_log_account]
GO
ALTER TABLE [dbo].[req_log]  WITH CHECK ADD  CONSTRAINT [FK_req_log_request_by_user] FOREIGN KEY([request_by_user_id])
REFERENCES [dbo].[request_by_user] ([id])
GO
ALTER TABLE [dbo].[req_log] CHECK CONSTRAINT [FK_req_log_request_by_user]
GO
ALTER TABLE [dbo].[request_by_user]  WITH CHECK ADD  CONSTRAINT [FK__request_b__accou__33D4B598] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[request_by_user] CHECK CONSTRAINT [FK__request_b__accou__33D4B598]
GO
ALTER TABLE [dbo].[request_by_user]  WITH CHECK ADD  CONSTRAINT [FK__request_b__facil__36B12243] FOREIGN KEY([facility_id])
REFERENCES [dbo].[facility] ([id])
GO
ALTER TABLE [dbo].[request_by_user] CHECK CONSTRAINT [FK__request_b__facil__36B12243]
GO
ALTER TABLE [dbo].[request_by_user]  WITH CHECK ADD  CONSTRAINT [FK__request_b__reque__34C8D9D1] FOREIGN KEY([request_status_id])
REFERENCES [dbo].[request_status] ([id])
GO
ALTER TABLE [dbo].[request_by_user] CHECK CONSTRAINT [FK__request_b__reque__34C8D9D1]
GO
ALTER TABLE [dbo].[request_by_user]  WITH CHECK ADD  CONSTRAINT [FK__request_b__reque__35BCFE0A] FOREIGN KEY([request_priority_id])
REFERENCES [dbo].[request_priority] ([id])
GO
ALTER TABLE [dbo].[request_by_user] CHECK CONSTRAINT [FK__request_b__reque__35BCFE0A]
GO
ALTER TABLE [dbo].[request_by_user]  WITH CHECK ADD  CONSTRAINT [FK__request_b__servi__37A5467C] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[request_by_user] CHECK CONSTRAINT [FK__request_b__servi__37A5467C]
GO
ALTER TABLE [dbo].[service]  WITH CHECK ADD  CONSTRAINT [FK_service_facility] FOREIGN KEY([facility_id])
REFERENCES [dbo].[facility] ([id])
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_facility]
GO
ALTER TABLE [dbo].[user_task]  WITH CHECK ADD  CONSTRAINT [FK__user_task__head___38996AB5] FOREIGN KEY([head_task_id])
REFERENCES [dbo].[head_task] ([id])
GO
ALTER TABLE [dbo].[user_task] CHECK CONSTRAINT [FK__user_task__head___38996AB5]
GO
ALTER TABLE [dbo].[user_task]  WITH CHECK ADD  CONSTRAINT [FK__user_task__reque__3B75D760] FOREIGN KEY([request_by_user_id])
REFERENCES [dbo].[request_by_user] ([id])
GO
ALTER TABLE [dbo].[user_task] CHECK CONSTRAINT [FK__user_task__reque__3B75D760]
GO
ALTER TABLE [dbo].[user_task]  WITH CHECK ADD  CONSTRAINT [FK__user_task__user___3C69FB99] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[user_task] CHECK CONSTRAINT [FK__user_task__user___3C69FB99]
GO
USE [master]
GO
ALTER DATABASE [OHD] SET  READ_WRITE 
GO
