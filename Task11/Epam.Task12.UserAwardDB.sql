USE [master]
GO
/****** Object:  Database [Epam.Task12.DB]    Script Date: 14.02.2019 3:33:55 ******/
CREATE DATABASE [Epam.Task12.DB]
 CONTAINMENT = NONE
 GO
ALTER DATABASE [Epam.Task12.DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Epam.Task12.DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Epam.Task12.DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Epam.Task12.DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Epam.Task12.DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Epam.Task12.DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Epam.Task12.DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Epam.Task12.DB] SET  MULTI_USER 
GO
ALTER DATABASE [Epam.Task12.DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Epam.Task12.DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Epam.Task12.DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Epam.Task12.DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Epam.Task12.DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Epam.Task12.DB', N'ON'
GO
ALTER DATABASE [Epam.Task12.DB] SET QUERY_STORE = OFF
GO
USE [Epam.Task12.DB]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [varbinary](max) NULL,
	[title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [varbinary](max) NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[patronymic] [nvarchar](50) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](15) NOT NULL,
	[password] [nvarchar](256) NOT NULL,
	[role] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAward](
	[idUser] [int] NOT NULL,
	[idAward] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Award] ON 

INSERT [dbo].[Award] ([id], [image], [title]) VALUES (1, NULL, N'Medal of Honor')
SET IDENTITY_INSERT [dbo].[Award] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [image], [firstName], [lastName], [patronymic], [dateOfBirth]) VALUES (1, NULL, N'Veronika', N'Dedova', N'Vadimovna', CAST(N'1995-03-06' AS Date))
INSERT [dbo].[User] ([id], [image], [firstName], [lastName], [patronymic], [dateOfBirth]) VALUES (2, NULL, N'Artem', N'Drozdev', N'Stanislavovich', CAST(N'1995-11-20' AS Date))
INSERT [dbo].[User] ([id], [image], [firstName], [lastName], [patronymic], [dateOfBirth]) VALUES (3, NULL, N'Alina', N'Semenova', N'Denisovna', CAST(N'1971-03-07' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([id], [userName], [password], [role]) VALUES (1, N'Nika', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Admin')
INSERT [dbo].[UserAccount] ([id], [userName], [password], [role]) VALUES (2, N'Slava', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'User')
INSERT [dbo].[UserAccount] ([id], [userName], [password], [role]) VALUES (3, N'Artem', N'65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5', N'Admin')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
INSERT [dbo].[UserAward] ([idUser], [idAward]) VALUES (2, 1)
ALTER TABLE [dbo].[UserAward]  WITH CHECK ADD  CONSTRAINT [FK1_UserAward] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAward] CHECK CONSTRAINT [FK1_UserAward]
GO
ALTER TABLE [dbo].[UserAward]  WITH CHECK ADD  CONSTRAINT [FK2_UserAward] FOREIGN KEY([idAward])
REFERENCES [dbo].[Award] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAward] CHECK CONSTRAINT [FK2_UserAward]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
	@title NVARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [Award](title) 
	VALUES (@title);
END
GO
/****** Object:  StoredProcedure [dbo].[AddImageAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddImageAward]
	@id INT,
	@image VARBINARY(MAX)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [Award] 
	SET [image] = @image 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[AddImageUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddImageUser]
	@id INT,
	@image VARBINARY(MAX)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [User] 
	SET image = @image 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@patronymic NVARCHAR(50),
	@dateOfBirth DATE
AS
BEGIN
	INSERT INTO [User] (firstName, lastName, patronymic, dateOfBirth) 
	VALUES (@firstName, @lastName, @patronymic, @dateOfBirth);
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUserAward]
	@idUser INT,
	@idAward INT
AS
BEGIN

	SET NOCOUNT ON;
	INSERT INTO [UserAward] (idUser, idAward)
	VALUES (@idUser, @idAward);
END
GO
/****** Object:  StoredProcedure [dbo].[AppointAdmin]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AppointAdmin]
	@userName NVARCHAR(15),
	@role NVARCHAR(5)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [UserAccount]
	SET [role] = @role
	WHERE userName = @userName;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM [Award] 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteImageAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteImageAward]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [Award] 
	SET [image] = NULL 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteImageUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteImageUser]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [User] 
	SET [image] = NULL 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM [User] 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserAward]
	@idAward INT
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM [UserAward] 
	WHERE idAward = @idAward;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT	[Award].id, 
			[Award].[image], 
			[Award].title
	FROM [Award];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllFromUserAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllFromUserAward]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT	[UserAward].idUser,
			[UserAward].idAward
	FROM [UserAward];
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserAccount]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUserAccount]

AS
BEGIN

	SET NOCOUNT ON;

    SELECT	[UserAccount].id, 
			[UserAccount].userName, 
			[UserAccount].[password], 
			[UserAccount].[role]
	FROM [UserAccount];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT	[User].id, 
			[User].[image], 
			[User].firstName, 
			[User].lastName, 
			[User].patronymic, 
			[User].dateOfBirth 
	FROM [User];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	[Award].id, 
			[Award].[image], 
			[Award].title
	FROM [Award] WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetRolesForUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRolesForUser]
	@userName NVARCHAR(15)
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT DISTINCT [role] 
	FROM [UserAccount] 
	WHERE userName = @userName;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	[User].id, 
			[User].[image], 
			[User].firstName, 
			[User].lastName, 
			[User].patronymic, 
			[User].dateOfBirth 
	FROM [User] WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GiveAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GiveAward] 
	@idUser INT,
	@idAward INT
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [UserAward](idUser, idAward) 
	VALUES (@idUser, @idAward);
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Login]
	@userName NVARCHAR(15),
	@password NVARCHAR(256)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT userName 
	FROM [UserAccount]
	WHERE userName = @userName AND [password] = @password

END
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Registration]
	@userName NVARCHAR(15),
	@password NVARCHAR(256),
	@role NVARCHAR(5)
AS
BEGIN

	SET NOCOUNT ON;
	INSERT INTO [UserAccount] (userName, [password], [role])
	VALUES (@userName, @password, @role);
END
GO
/****** Object:  StoredProcedure [dbo].[UniqueUserName]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UniqueUserName]
	@userName NVARCHAR(15)
AS
BEGIN
	SELECT @userName 
	FROM [UserAccount]
	Where userName = @userName;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@title NVARCHAR(50),
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [Award] 
	SET		title = @title 
	WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 14.02.2019 3:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@patronymic NVARCHAR(50),
	@dateOfBirth DATE,
	@id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [User] 
	SET		firstName = @firstName, 
			lastName = @lastName, 
			patronymic = @patronymic, 
			dateOfBirth = @dateOfBirth 
	WHERE id = @id;
END
GO
USE [master]
GO
ALTER DATABASE [Epam.Task12.DB] SET  READ_WRITE 
GO
