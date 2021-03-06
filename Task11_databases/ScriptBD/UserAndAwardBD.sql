USE [master]
GO
/****** Object:  Database [Epam.Task11.UsersAndAwards]    Script Date: 13.02.2019 19:08:54 ******/
CREATE DATABASE [Epam.Task11.UsersAndAwards]
 CONTAINMENT = NONE
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Epam.Task11.UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Epam.Task11.UsersAndAwards]
GO
/****** Object:  Table [dbo].[award]    Script Date: 13.02.2019 19:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[award](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](50) NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[siteUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[siteUser](
	[login] [nvarchar](100) NOT NULL,
	[password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_siteUser] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userAward](
	[idUser] [int] NOT NULL,
	[idAward] [int] NOT NULL,
 CONSTRAINT [PK_userAward] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC,
	[idAward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[userAward]  WITH CHECK ADD  CONSTRAINT [FK_userAward_award] FOREIGN KEY([idAward])
REFERENCES [dbo].[award] ([id])
GO
ALTER TABLE [dbo].[userAward] CHECK CONSTRAINT [FK_userAward_award]
GO
ALTER TABLE [dbo].[userAward]  WITH CHECK ADD  CONSTRAINT [FK_userAward_user] FOREIGN KEY([idUser])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[userAward] CHECK CONSTRAINT [FK_userAward_user]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAward]
	@title NVARCHAR(50),
	@image VARBINARY(MAX)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO award(title,[image])
	VALUES(@title,@image)

END
GO
/****** Object:  StoredProcedure [dbo].[AddSiteUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddSiteUser] 
	@login NVARCHAR(50),
	@password VARBINARY(MAX)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO siteUser([login],[password])
	VALUES (@login,@password)

END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@name NVARCHAR(50),
	@dateOfBirth DATE,
	@image VARBINARY(MAX)
AS 
BEGIN

	INSERT INTO [user]([name],dateOfBirth,[image])
	VALUES(@name,@dateOfBirth,@image)


END
GO
/****** Object:  StoredProcedure [dbo].[AddUserAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUserAward]
	@idAward int,
	@idUser int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO userAward (idAward,idUser)
	VALUES (@idAward, @idUser)
   
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
		@id int
AS
BEGIN

	SET NOCOUNT ON;
	DELETE FROM userAward
	WHERE userAward.idAward=@id

 	DELETE FROM award
	WHERE award.id=@id
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS
BEGIN


	SET NOCOUNT ON;

	DELETE FROM userAward
	WHERE userAward.idUser=@id

	DELETE FROM [user]
	WHERE [user].id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserAward]
	@idAward int,
	@idUser int
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE FROM userAward
	WHERE userAward.idAward=@idAward AND userAward.idUser=@idUser
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT   a.id
			,a.title
			,a.[image]
			 FROM Award a
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSiteUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllSiteUser]
AS
BEGIN

	SET NOCOUNT ON;
		SELECT	 
			siteUser.[login]
			,siteUser.[password]
			
	 FROM siteUser
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSiteUserLogin]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllSiteUserLogin]
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT	siteUser.[login]
	FROM siteUser

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserAwards]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUserAwards]

AS
BEGIN

	SET NOCOUNT ON;

		SELECT   uA.idAward
				,uA.idUser
		FROM userAward uA

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	 u.id
			,u.[name]
			,u.dateOfBirth
			,u.[image]
	 FROM [user] u
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@id int,
	@title NVARCHAR(50)
AS
BEGIN
	
	SET NOCOUNT ON;
		UPDATE award
	SET title = @title
	WHERE id = @id
    
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@name NVARCHAR(50),
	@birthDate DATE
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [user]
	SET [name] = @name
		,dateOfBirth =@birthDate
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserAward]    Script Date: 13.02.2019 19:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUserAward]
	@oldIdAward int,
	@oldIdUser int,
	@idAward int,
	@idUser int

AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE userAward
	SET idAward=@idAward,
		idUser=@idUser
	WHERE idAward = @oldIdAward AND idUser=@oldIdUser
    
END
GO
USE [master]
GO
ALTER DATABASE [Epam.Task11.UsersAndAwards] SET  READ_WRITE 
GO
