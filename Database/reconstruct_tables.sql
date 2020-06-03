/* Drop all Primary Key constraints */

DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)

WHILE @name IS NOT NULL
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint is not null
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint)+']'
        EXEC (@SQL)
        PRINT 'Dropped PK Constraint: ' + @constraint + ' on ' + @name
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
END
GO

/* Drop all tables */
DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Table: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
END
GO

DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Table: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
END
GO


--drop all stored procedures
declare @procName varchar(500)
declare cur cursor 

for select [name] from sys.objects where type = 'p'
open cur
fetch next from cur into @procName
while @@fetch_status = 0
begin
    exec('drop procedure [' + @procName + ']')
    fetch next from cur into @procName
end
close cur
deallocate cur



/****** Object:  Table [dbo].[Books]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ItemsID] [int] NOT NULL,
	[Pages] [int] NOT NULL,
	[Author] [varchar](255) NOT NULL,
	[Category] [varchar](255) NOT NULL,
	[Publisher] [varchar](255) NOT NULL,
	[ISBN] [bigint] NOT NULL,
 CONSTRAINT [PK_TestBooks] PRIMARY KEY CLUSTERED 
(
	[ItemsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksCategory]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksCategory](
	[CategoryID] [varchar](255) NOT NULL,
	[DDK] [varchar](255) NOT NULL,
	[SAB] [varchar](255) NOT NULL,
 CONSTRAINT [PK_BooksCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowList]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowList](
	[BorrowListID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[UsersID] [int] NOT NULL,
	[BorrowDate] [date] NOT NULL,
	[DueDate] [date] NOT NULL,
 CONSTRAINT [PK__BorrowLi__6EB68068F6A4B254] PRIMARY KEY CLUSTERED 
(
	[BorrowListID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowListHistory]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowListHistory](
	[BorrowListHistoryID] [int] NOT NULL,
	[StockID] [int] NOT NULL,
	[UsersID] [int] NOT NULL,
	[BorrowDate] [date] NOT NULL,
	[DueDate] [date] NOT NULL,
	[ReturnDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BorrowListHistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CardsID] [int] IDENTITY(1,1) NOT NULL,
	[UsersID] [int] NOT NULL,
	[Created] [date] NOT NULL,
	[Suspended] [bit] NOT NULL,
	[Reason] [varchar](255) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[CardsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ebooks]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ebooks](
	[ItemsID] [int] NOT NULL,
	[Pages] [int] NOT NULL,
	[Size] [int] NOT NULL,
	[Author] [varchar](255) NOT NULL,
	[Category] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Ebooks] PRIMARY KEY CLUSTERED 
(
	[ItemsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemsID] [int] IDENTITY(1,1) NOT NULL,
	[ItemType] [varchar](255) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Price] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_ItemsT] PRIMARY KEY CLUSTERED 
(
	[ItemsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[ItemsID] [int] NOT NULL,
	[Director] [varchar](255) NOT NULL,
	[Duration] [int] NOT NULL,
	[Actors] [varchar](255) NOT NULL,
	[Genre] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TestMovies] PRIMARY KEY CLUSTERED 
(
	[ItemsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[StockID] [int] NOT NULL,
	[UsersID] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seminars]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seminars](
	[SeminarsID] [int] IDENTITY(1,1) NOT NULL,
	[Author] [varchar](255) NOT NULL,
	[Date] [date] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK__Seminars__E9458E9DF8C769B5] PRIMARY KEY CLUSTERED 
(
	[SeminarsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[ItemsID] [int] NOT NULL,
	[Available] [bit] NOT NULL,
	[Reason] [varchar](255) NULL,
 CONSTRAINT [PK__Stock__2C83A9E260FCEDF9] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UsersID] [int] IDENTITY(1,1) NOT NULL,
	[IdentityNO] [varchar](12) NOT NULL,
	[Firstname] [varchar](255) NOT NULL,
	[Lastname] [varchar](255) NOT NULL,
	[JoinDate] [date] NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Banned] [bit] NOT NULL,
	[UsersCategory] [int] NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Reason] [varchar](255) NULL,
 CONSTRAINT [PK__Users__A349B042C7A8895B] PRIMARY KEY CLUSTERED 
(
	[UsersID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSeminars]    Script Date: 2020-06-02 21:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSeminars](
	[UsersID] [int] NOT NULL,
	[SeminarsID] [int] NOT NULL,
 CONSTRAINT [PK_UserSeminars] PRIMARY KEY CLUSTERED 
(
	[UsersID] ASC,
	[SeminarsID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (4, 864, N'John Bunyan', N'Religion', N'Francisco de Robles', 9789174994031)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (5, 863, N'Daniel Defoe', N'Engelska & fornengelska litteraturer', N'Francisco de Robles', 9789174994032)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (6, 863, N'Alexandre Dumas', N'Drama', N'Francisco de Robles', 9789174994033)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (7, 863, N'Charlotte Brontë', N'Filosofi', N'Francisco de Robles', 9789174994034)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (19, 232, N'Camilla Läckberg', N'Skönlitteratur', N'Bokförlaget Forum', 9789137152714)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (27, 299, N'Elias Lönnrot', N'Engelska & fornengelska', N'Bonnier ', 9893428452853)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (29, 500, N'Monika Wendleby', N'Juridik', N'Sanoma Utbildning', 9789152358221)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (30, 332, N'Sally Rooney', N'Skönliteratur', N'Albert Bonniers Förlag', 9789100179724)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (31, 253, N'Suzanne Collins', N'Skönlitteratur', N'Bonnier Carlsen', 9789178038428)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (32, 324, N'Suzanne Collins', N'Skönlitteratur', N'Bonnier Carlsen', 9789179751579)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (33, 689, N'Thomas Padron-McCarthy', N'Datavetenskap', N'Studentlitteratur', 9789144069197)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (34, 228, N'Eva Holmquist', N'Datavetenskap', N'Studentlittereatur', 9789144117775)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (35, 299, N'Jan-Eric Thelin', N'Datavetenskap', N'Thelin förlag', 97891737930320)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (36, 224, N'Maria Bergengren', N'Företagsledning & PR', N'Sanoma Utbildning', 9789152353721)
GO
INSERT [dbo].[Books] ([ItemsID], [Pages], [Author], [Category], [Publisher], [ISBN]) VALUES (37, 431, N'Yuval Noah Harari', N'Historia', N'Natur Kultur Allmänlitteratur', 9789127161450)
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Afrikas historia', N'960', N'Kp, Jp')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Amerikansk litteratur på engelska', N'810', N'Heq, Geq')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Antik, medeltida & österländsk filosofi', N'180', N'Dba')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Arkitektur', N'720', N'Ic')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Asiens historia', N'950', N'Ko, Jo')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Astronomi', N'520', N'Ua')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Bibeln', N'220', N'Cb-Cc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Bibliografier', N'010', N'Aa')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Biblioteks- & informationsvetenskap', N'020', N'Ab,Ac')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Biografi & genealogi', N'920', N'L')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Biologi', N'570', N'Ue')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Byggnadsteknik', N'690', N'Pp')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Citat', N'080', N'Bt')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Datavetenskap', N'004-006', N'Pu')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Datavetenskap, kunskap & system	', N'000', N'A,B')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Djur (zoologi)', N'590', N'Ug')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Drama', N'3', N'D')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Engelska & fornengelska', N'420', N'Fe')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Engelska & fornengelska litteraturer', N'820', N'He, Ge')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Etik', N'170', N'Dg')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Europas historia', N'940', N'Ka')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Filosofi', N'100', N'D')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Filosofisk logik', N'160', N'Dc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Filosofiska skolor', N'140', N'Dbc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Föreningar, organisationer & museer', N'060', N'Bk,Bg-Bh')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Företagsledning & PR', N'650', N'Qb')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Forntida världens historia (före ca 499)', N'930', N'J,K')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Fossiler & förhistoriskt liv', N'560', N'Udb')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Fotografi, datorkonst, film, video', N'770', N'In, Pn')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Franska & besläktade litteraturer', N'840', N'Hj, Gj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Franska & besläktade romanska språk', N'440', N'Fj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Fysik', N'530', N'Ucc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Fysisk planering & landskapsarkitektur', N'710', N'Icu, Odg')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Geografi & resor', N'910', N'N')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Geovetenskaper & geologi', N'550', N'Ud,Ub')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Grafiska konstformer & konsthantverk', N'740', N'Ig, Ih, Hci, H+.05')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Handel, kommunikationer & transport', N'380', N'Qi,Pr')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Handskrifter & rara böcker', N'090', N'Aea')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Hemkunskap & familjekunskap', N'640', N'Qc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Historia', N'900', N'K')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Idrott, spel & underhållning', N'790', N'R')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Ingenjörsvetenskap', N'620', N'P, Pa, Pb')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Italienska, rumänska & besläktade litteraturer', N'850', N'Hi, Gj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Italienska, rumänska & besläktade språk', N'450', N'Fi')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Jordbruk', N'630', N'Qd-Qg')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Juridik', N'340', N'Oe, respektive ämne + :oe')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kemi', N'540', N'Uce')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kemisk teknik', N'660', N'Pm')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Klassisk & modern grekisk litteratur', N'880', N'Hoa, Goa')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Klassisk grekiska & modern grekiska', N'480', N'Foa')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Konstarterna', N'700', N'I')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kristen organisation, socialt arbete & tillbedjan', N'260', N'Ch,Cg')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kristendom & kristen teologi', N'230', N'Ca,Ce')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kristendomshistoria', N'270', N'Cj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kristendomsutövning & kristet bruk', N'240', N'Cf,Ci')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kristna samfund', N'280', N'Ck')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Kunskapsteori', N'120', N'Bdb')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Latin & italiska språk', N'470', N'Foc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Latinska & italiska litteraturer', N'870', N'Hoc, Goc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Litteratur', N'800', N'H, G')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Målarkonst', N'750', N'Ie')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Matematik', N'510', N'T')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Medicin & hälsa', N'610', N'V')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Metafysik', N'110', N'Dj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Militärvetenskap', N'355-359', N'S')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Modern västerländsk filosofi', N'190', N'Dbc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Musik', N'780', N'Ij, X, Y')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Nationalekonomi', N'330', N'Qa')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Naturvetenskaper', N'500', N'U')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Nordamerikas historia', N'970', N'Kqa-Kqc, Jqa-Jqc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Nyhetsmedier, journalistik & publicering', N'070', N'Bt')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Offentlig förvaltning', N'351-354', N'Od')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Övrig skönlitteratur', N'899', N'Hx')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Övriga litteraturer', N'890', N'Hp-Hå, Gp-Gy')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Övriga områdens historia', N'990', N'Kr, Ks, Jr, Js')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Övriga religioner', N'290', N'Cm,Cn')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Övriga språk', N'490', N'Fp-Få')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Parapsykologi & ockultism', N'130', N'Bl,Dop')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Psykologi', N'150', N'Do')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Religion', N'200', N'C')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Religionsfilosofi & religionsteori', N'210', N'C:d, Cm')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Samhällsvetenskaper', N'300', N'O')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Seder, etikett & folklore', N'390', N'M')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Skönlitteratur', N'800', N'H')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Skulptur, keramik & metallkonst', N'730', N'Id')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Sociala problem & sociala tjänster', N'360', N'Oh')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Sociologi & antropologi', N'301-307', N'Oa,M')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Spanska, portugisiska & galiciska litteraturer', N'860', N'Hk, Gk')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Spanska, portugisiska, galiciska', N'460', N'Fk,Fl')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Språk', N'400', N'F')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Språkvetenskap', N'410', N'F')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Statistik', N'310', N'Oj')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Statsvetenskap', N'320', N'Oc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Svensk skönlitteratur', N'839.7', N'Hc')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Sydamerikas historia', N'980', N'Kqd; Jqd')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Teknik', N'600', N'P')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Tidskrifter & seriella resurser', N'050', N'Bd')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Tillverkning', N'670-680', N'Pe-Pl')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Tryckframställning & grafiska tryck', N'760', N'If')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Tyska & besläktade litteraturer', N'830', N'Hf, Gf')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Tyska & besläktade språk', N'430', N'Ff,Fi')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Uppslagsverk & kalendrar', N'030', N'Ba')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Utbildning', N'370', N'E')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Utövande av prästämbete & religiösa ordnar', N'250', N'Cg')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Vakant]', N'040', N'')
GO
INSERT [dbo].[BooksCategory] ([CategoryID], [DDK], [SAB]) VALUES (N'Växter (botanik)', N'580', N'Uf')
GO
SET IDENTITY_INSERT [dbo].[BorrowList] ON 
GO
INSERT [dbo].[BorrowList] ([BorrowListID], [StockID], [UsersID], [BorrowDate], [DueDate]) VALUES (25, 30, 4, CAST(N'2020-05-30' AS Date), CAST(N'2020-06-30' AS Date))
GO
INSERT [dbo].[BorrowList] ([BorrowListID], [StockID], [UsersID], [BorrowDate], [DueDate]) VALUES (26, 29, 4, CAST(N'2020-05-30' AS Date), CAST(N'2020-06-30' AS Date))
GO
INSERT [dbo].[BorrowList] ([BorrowListID], [StockID], [UsersID], [BorrowDate], [DueDate]) VALUES (30, 1, 17, CAST(N'2020-06-02' AS Date), CAST(N'2020-07-02' AS Date))
GO
INSERT [dbo].[BorrowList] ([BorrowListID], [StockID], [UsersID], [BorrowDate], [DueDate]) VALUES (31, 32, 17, CAST(N'2020-06-02' AS Date), CAST(N'2020-07-02' AS Date))
GO
SET IDENTITY_INSERT [dbo].[BorrowList] OFF
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (1, 2, 13, CAST(N'2010-05-20' AS Date), CAST(N'2020-06-19' AS Date), CAST(N'2020-05-31' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (3, 4, 13, CAST(N'2020-05-20' AS Date), CAST(N'2020-06-19' AS Date), CAST(N'2020-05-27' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (4, 5, 17, CAST(N'2020-05-20' AS Date), CAST(N'2020-06-19' AS Date), CAST(N'2020-05-27' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (5, 1, 22, CAST(N'2020-05-20' AS Date), CAST(N'2020-06-19' AS Date), CAST(N'2020-05-27' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (6, 6, 22, CAST(N'2020-05-20' AS Date), CAST(N'2020-06-19' AS Date), CAST(N'2020-05-28' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (14, 14, 17, CAST(N'2020-05-24' AS Date), CAST(N'2020-06-24' AS Date), CAST(N'2020-05-27' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (15, 11, 13, CAST(N'2020-05-25' AS Date), CAST(N'2020-06-25' AS Date), CAST(N'2020-05-31' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (16, 17, 17, CAST(N'2020-05-26' AS Date), CAST(N'2020-06-26' AS Date), CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (17, 1, 17, CAST(N'2020-05-28' AS Date), CAST(N'2020-06-28' AS Date), CAST(N'2020-05-28' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (18, 6, 17, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-01' AS Date), CAST(N'2020-05-28' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (19, 15, 17, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-01' AS Date), CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (20, 24, 4, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-01' AS Date), CAST(N'2020-06-02' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (21, 1, 4, CAST(N'2020-05-28' AS Date), CAST(N'2020-06-28' AS Date), CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (22, 22, 17, CAST(N'2020-05-29' AS Date), CAST(N'2020-06-29' AS Date), CAST(N'2020-05-29' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (23, 26, 13, CAST(N'2020-05-29' AS Date), CAST(N'2020-06-29' AS Date), CAST(N'2020-05-31' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (24, 28, 4, CAST(N'2020-05-29' AS Date), CAST(N'2020-06-29' AS Date), CAST(N'2020-05-31' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (27, 22, 17, CAST(N'2020-06-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (28, 23, 17, CAST(N'2020-06-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[BorrowListHistory] ([BorrowListHistoryID], [StockID], [UsersID], [BorrowDate], [DueDate], [ReturnDate]) VALUES (29, 10, 17, CAST(N'2020-06-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-06-02' AS Date))
GO
INSERT [dbo].[Ebooks] ([ItemsID], [Pages], [Size], [Author], [Category]) VALUES (8, 876, 32, N'Jonathan Swift', N'Adventure')
GO
INSERT [dbo].[Ebooks] ([ItemsID], [Pages], [Size], [Author], [Category]) VALUES (9, 876, 32, N'Mary Shelley', N'Thriller')
GO
INSERT [dbo].[Ebooks] ([ItemsID], [Pages], [Size], [Author], [Category]) VALUES (10, 876, 32, N'Charlotte Brontë', N'Drama')
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (2, N'Books', N'Don Quixote', N'The story of the gentle knight and his servant Sancho Panza has entranced readers for centuries.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (4, N'Books', N'Pilgrim´s Progress', N'The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (5, N'Books', N'Robinson Crusoe', N'The first English novel.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (6, N'Books', N'The Count of Monte Cristo', N'A revenge thriller also set in France after Bonaparte: a masterpiece of adventure writing.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (7, N'Books', N'Jane Eyre', N'Obsessive emotional grip and haunting narrative.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (8, N'Ebooks', N'Gulliver´s Travels', N'A wonderful satire that still works for all ages, despite the savagery of Swift´s vision.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (9, N'Ebooks', N'Frankenstein', N'Inspired by spending too much time with Shelley and Byron.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (10, N'Ebooks', N'Jane Eyre', N'Obsessive emotional grip and haunting narrative.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (11, N'Movies', N'The Godfather', N'A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (12, N'Movies', N'The Silence of The Lambs', N'A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (13, N'Movies', N'Titanic', N'A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (14, N'Movies', N'The Matrix', N'A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (15, N'Movies', N'Inception', N'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (16, N'Movies', N'The Terminator', N'A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her teenage son, John Connor, from a more advanced and powerful cyborg.', 99, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (19, N'Books', N'Vingar av silver', N'Just när Faye trodde allt var över hotas hennes tillvaro igen. Hon har byggt upp ett liv utomlands, exmaken Jack sitter i fängelse och hennes företag Revenge skördar stora framgångar. Men när Revenge ska lanseras i USA dyker det plötsligt upp ett allvarligt hot mot bolaget och Faye tvingas återvända till Stockholm.', 150, CAST(N'2020-05-13' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (27, N'Books', N'Kalevala', N'The Kalevala is a 19th-century work of epic poetry compiled by Elias L nnrot from Finnish and Karelian oral folklore and mythology.It is regarded as the national epic of Finland and is one of the most significant works of Finnish literature. ', 122, CAST(N'2020-05-14' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (29, N'Books', N'GDPR för dataskyddsombud och andra ansvariga', N'Dataskyddsarbetet är roligt men utmanande och lyder under ett komplext regelverk. Den här boken vänder sig till alla som arbetar med integritetsskydd: dataskyddsombud och dataskyddsansvariga, men också ansvariga chefer. Den är inte begränsad till dataskyddsförordningen, utan täcker även in brottsdatalagen', 270, CAST(N'2020-05-20' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (30, N'Books', N'Normala människor', N'Connell och Marianne växer upp i samma småstad. Han är en populär fotbollskille, hon rik men ensam. De börjar prata, snart ligger de med varandra, kort därefter gör de slut. Så fortsätter det, hela vägen till universitetet i Dublin. ', 150, CAST(N'2020-05-21' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (31, N'Books', N'Balladen om sångfåglar och ormar', N'I Balladen om sångfåglar och ormar följer vi händelserna som skedde 64 år innan Hungerspelen-trilogin utspelar sig.', 153, CAST(N'2020-05-26' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (32, N'Books', N'Revolt ', N'De två första delarna i trilogin om Hungerspelen har gått som en raket på den litterära himeln, bland annat som etta på New York Times bestseller-lista. Förväntningarna på del tre är enorma.', 199, CAST(N'2020-05-26' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (33, N'Books', N'Databasteknik', N'Boken Databasteknik börjar med grunderna om databaser, som scheman, datamodellering och användningsområden för databaser. Vi går vidare bland annat med frågespråk, transaktionshantering, säkerhet, prestanda och hur databashanteraren arbetar internt.', 504, CAST(N'2020-05-29' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (34, N'Books', N'Praktisk mjukvarutestning', N'I Praktisk mjukvarutestning behandlas ämnen som sammanhangets påverkan på test, testledning, att genomföra tester, testmiljöer, testdata, automatiserade tester. I boken ges också många tips och konkreta exempel på vad det innebär att vara testare.', 379, CAST(N'2020-05-29' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (35, N'Books', N'Nätverksteknik med Windows server 2012', N'Lärobok för nätverksteknink windows 2012', 450, CAST(N'2020-05-29' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (36, N'Books', N'Ledarskap och organisation ', N'Ledarskap och organisation betonar människans roll i organisationen och ger dina elever möjlighet att förstå begrepp, teorier och modeller inom detta tvärvetenskapliga ämne. Den tydliga strukturen gör ämnet överskådligt. Boken är indelad i fyra block som kan studeras i valfri ordning', 449, CAST(N'2020-05-29' AS Date))
GO
INSERT [dbo].[Items] ([ItemsID], [ItemType], [Title], [Description], [Price], [Date]) VALUES (37, N'Books', N'Sapiens ', N'Sapiens är en storslagen berättelse om människans ursprung, nutid och framtid. Historikern Yuval Noah Harari tar oss med från Homo sapiens första steg på jorden, då vi var ett däggdjur bland alla andra, till idag när vi står som världens obestridda härskare - med makt att både skapa och utplåna liv.', 150, CAST(N'2020-05-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (11, N'Francis Ford Coppola', 120, N'Marlon Brando, Al Pacino', N'Action, Drama')
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (12, N'Jonathan Demme', 120, N'Jodie Foster, Anthony Hopkins', N'Drama, Thriller')
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (13, N'James Cameron', 120, N'Leonardo DiCaprio, Kate Winslet, Billy Zane', N'Drama')
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (14, N'The Wachowski Brothers', 120, N'Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss', N'Sci-Fi')
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (15, N'Christopher Nolan', 120, N'Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page', N'Sci-Fi')
GO
INSERT [dbo].[Movies] ([ItemsID], [Director], [Duration], [Actors], [Genre]) VALUES (16, N'James Cameron', 120, N'Arnold Schwarzenegger, Linda Hamilton', N'Action, Sci-Fi')
GO
INSERT [dbo].[Reservations] ([StockID], [UsersID]) VALUES (22, 13)
GO
INSERT [dbo].[Reservations] ([StockID], [UsersID]) VALUES (2, 17)
GO
INSERT [dbo].[Reservations] ([StockID], [UsersID]) VALUES (24, 17)
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (1, 4, 1, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (2, 6, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (3, 8, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (4, 9, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (5, 12, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (6, 15, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (7, 2, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (8, 2, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (9, 2, 1, N'1')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (10, 19, 1, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (11, 30, 1, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (12, 30, 1, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (13, 4, 0, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (14, 4, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (15, 29, 0, N'')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (17, 4, 0, N'Trasig')
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (18, 4, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (22, 5, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (23, 27, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (24, 7, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (25, 4, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (26, 33, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (27, 34, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (28, 33, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (29, 35, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (30, 36, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (31, 29, 0, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (32, 37, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (33, 4, 1, NULL)
GO
INSERT [dbo].[Stock] ([StockID], [ItemsID], [Available], [Reason]) VALUES (34, 37, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (4, N'197707131234', N'Firas', N'Hanna', CAST(N'2020-05-01' AS Date), N'1234', 0, 2, N'test@test.se', N'0701233212', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (7, N'198012121212', N'Arne', N'Hegerfors', CAST(N'2020-05-02' AS Date), N'123', 0, 1, N'test@test.Org,', N'0701233111', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (13, N'198006061234', N'John', N'Kramer', CAST(N'2020-05-07' AS Date), N'1234', 0, 0, N'john@kramer.saw', N'0709876543', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (17, N'198005051234', N'Mister', N'President', CAST(N'2020-05-20' AS Date), N'1234', 0, 0, N'president@mail.com', N'0701234567', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (21, N'199209079202', N'Aata', N'Miettinen', CAST(N'2020-05-17' AS Date), N'usertest', 0, 1, N'aata@hotmail.com', N'0735956683', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (22, N'198704019202', N'Aata', N'Miettinen', CAST(N'2020-05-17' AS Date), N'testtest', 0, 0, N'tea@hotmail.com', N'0735956686', N'')
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (27, N'205001017777', N'Aysen', N'Furhoff', CAST(N'2020-05-29' AS Date), N'stalin77', 0, 0, N'stalin77@mail.com', N'0709874561', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (29, N'198009079555', N'Johan', N'Victor', CAST(N'2020-05-30' AS Date), N'test', 0, 2, N'test@gmail.com', N'0734545532', NULL)
GO
INSERT [dbo].[Users] ([UsersID], [IdentityNO], [Firstname], [Lastname], [JoinDate], [Password], [Banned], [UsersCategory], [Email], [PhoneNumber], [Reason]) VALUES (30, N'198022221234', N'Jesse', N'XXX', CAST(N'2020-05-31' AS Date), N'Stalin77', 0, 0, N'jesses@skogaholmlimpa.se', N'0703764344', NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__135E2CA5BF52D841]    Script Date: 2020-06-02 21:04:10 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__135E2CA5BF52D841] UNIQUE NONCLUSTERED 
(
	[IdentityNO] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_TestBooks_Items] FOREIGN KEY([ItemsID])
REFERENCES [dbo].[Items] ([ItemsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_TestBooks_Items]
GO
ALTER TABLE [dbo].[BorrowList]  WITH CHECK ADD  CONSTRAINT [FK_BorrowList_Items] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowList] CHECK CONSTRAINT [FK_BorrowList_Items]
GO
ALTER TABLE [dbo].[BorrowList]  WITH CHECK ADD  CONSTRAINT [FK_BorrowList_Users] FOREIGN KEY([UsersID])
REFERENCES [dbo].[Users] ([UsersID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BorrowList] CHECK CONSTRAINT [FK_BorrowList_Users]
GO
ALTER TABLE [dbo].[BorrowListHistory]  WITH CHECK ADD  CONSTRAINT [FK_BorrowListHistory_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowListHistory] CHECK CONSTRAINT [FK_BorrowListHistory_Stock]
GO
ALTER TABLE [dbo].[BorrowListHistory]  WITH CHECK ADD  CONSTRAINT [FK_BorrowListHistory_Users] FOREIGN KEY([UsersID])
REFERENCES [dbo].[Users] ([UsersID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BorrowListHistory] CHECK CONSTRAINT [FK_BorrowListHistory_Users]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Cards] FOREIGN KEY([UsersID])
REFERENCES [dbo].[Users] ([UsersID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Cards]
GO
ALTER TABLE [dbo].[Ebooks]  WITH CHECK ADD  CONSTRAINT [FK_Ebooks_Items] FOREIGN KEY([ItemsID])
REFERENCES [dbo].[Items] ([ItemsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ebooks] CHECK CONSTRAINT [FK_Ebooks_Items]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Items] FOREIGN KEY([ItemsID])
REFERENCES [dbo].[Items] ([ItemsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Items]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_BorrowList] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_BorrowList]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Items] FOREIGN KEY([ItemsID])
REFERENCES [dbo].[Items] ([ItemsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Items]
GO
ALTER TABLE [dbo].[UserSeminars]  WITH CHECK ADD  CONSTRAINT [FK_UserSeminars_Seminars] FOREIGN KEY([SeminarsID])
REFERENCES [dbo].[Seminars] ([SeminarsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSeminars] CHECK CONSTRAINT [FK_UserSeminars_Seminars]
GO
ALTER TABLE [dbo].[UserSeminars]  WITH CHECK ADD  CONSTRAINT [FK_UserSeminars_Users] FOREIGN KEY([UsersID])
REFERENCES [dbo].[Users] ([UsersID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSeminars] CHECK CONSTRAINT [FK_UserSeminars_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	
	
	@IdentityNo varchar(12),
	@Firstname varchar(50),
	@Lastname varchar(50),
	@JoinDate date,
	@Password varchar(50),
	@Banned bit = 0,
	@UsersCategory int,
	@PhoneNumber varchar(10),
	@Email varchar(255)
AS
BEGIN
	
	SET NOCOUNT ON;

   	INSERT INTO Users(IdentityNO, Firstname, Lastname, JoinDate,[Password], Banned, UsersCategory, PhoneNumber, Email)
	VALUES(@IdentityNo, @Firstname, @Lastname, @JoinDate, @Password, @Banned, @UsersCategory, @PhoneNumber, @Email )
END

GO
/****** Object:  StoredProcedure [dbo].[BorrowItem]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[BorrowItem]
(
    -- Add the parameters for the stored procedure here
    @StockID int,
	@UsersID int,
	@BorrowDate date,
	@DueDate date
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO BorrowList (StockID, UsersID, BorrowDate, DueDate)
	VALUES (@StockID, @UsersID, @BorrowDate, @DueDate);
END
GO
/****** Object:  StoredProcedure [dbo].[CheckInItem]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Fredrik Molén
-- Create Date: 2020-05-27
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[CheckInItem]
(
    -- Add the parameters for the stored procedure here
    @BorrowListID int,
    @StockID int,
    @UsersID int,
    @BorrowDate Date,
    @DueDate Date,
    @ReturnDate Date
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    Delete from BorrowList
	WHERE BorrowListID = @BorrowListID

	INSERT INTO BorrowListHistory
	VALUES (@BorrowListID, @StockID, @UsersID, @BorrowDate, @DueDate, @ReturnDate)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateBook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateBook]
	@Title varchar(255),
	@Description varchar(max),
	@Price int,
	@Pages int,
	@Author varchar(255),
	@Category varchar(255),
	@Date date,
	@ISBN bigint,
	@Publisher varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
	insert into Items (ItemType, Title, Description, Price, Date)
	values ('Books', @Title, @Description, @Price, @Date)
	insert into Books (ItemsID, Pages, Author, Category, Publisher, ISBN)
	values ((SELECT MAX(ItemsID) from Items), @Pages, @Author, @Category, @Publisher, @ISBN)
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[CreateItemWithStockID]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[CreateItemWithStockID]
(
    -- Add the parameters for the stored procedure here
	@ItemsID int,
	@Available bit

)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Stock (ItemsID, Available)
	values ( @ItemsID, @Available)
END
GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[deleteUser]
	-- Add the parameters for the stored procedure here
	@UsersID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Users
	WHERE UsersID = @UsersID;
END
GO
/****** Object:  StoredProcedure [dbo].[EditBook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditBook]
	@Title varchar(255),
	@Description varchar(max),
	@Price int,
	@Pages int,
	@Author varchar(255),
	@Category varchar(255),
	@Date date,
	@ISBN bigint,
	@Publisher varchar(255),
	@ID int

AS
BEGIN TRANSACTION
	UPDATE Books
	set Books.Author = @Author,Books.Pages = @Pages, Books.Category = @Category, Books.Publisher = @Publisher, Books.ISBN = @ISBN
	from Books 
	where Books.ItemsID = @ID

	UPDATE Items
	set items.Price = Price, items.Title = @Title, items.Description = @Description, items.Date = @Date
	from Items
	where Items.ItemsID = @ID
	and Items.ItemType = 'Books'
COMMIT
	

GO
/****** Object:  StoredProcedure [dbo].[EditBookStatus]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[EditBookStatus]
(
    -- Add the parameters for the stored procedure here
@StockID int,
@ItemsID int,
@Available bit,
@Reason varchar(255)

)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here	
	UPDATE Stock
	SET ItemsID = @ItemsID, Available = @Available, Reason = @Reason
	where StockID = @StockID
END
GO
/****** Object:  StoredProcedure [dbo].[editUser]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editUser]
	-- Add the parameters for the stored procedure here
	@UsersID int,
	@IdentityNo varchar(12),
	@Firstname varchar(50),
	@Lastname varchar(50),
	@JoinDate date,
	@Password varchar(50),
	@Banned bit,
	@UsersCategory int,
	@Reason varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Users
	SET IdentityNO = @IdentityNo, Firstname = @Firstname, Lastname = @Lastname, JoinDate = @JoinDate, Password = @Password, Banned = @Banned, UsersCategory = @UsersCategory, Reason = @Reason
	WHERE UsersID = @UsersID
END
GO
/****** Object:  StoredProcedure [dbo].[GetBook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetBook]
@ItemID int

AS
select * from Books where @ItemID=ItemsID
select * from Items where @ItemID=ItemsID




GO
/****** Object:  StoredProcedure [dbo].[GetBookCategories]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[GetBookCategories]

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT CategoryID From BooksCategory
END
GO
/****** Object:  StoredProcedure [dbo].[GetBooks]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBooks]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Books
	inner join
	Items on Books.ItemsID=Items.ItemsID
	left join 
	BooksCategory on Books.Category = BooksCategory.CategoryID

END
GO
/****** Object:  StoredProcedure [dbo].[GetBorrowList]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBorrowList]
	@UserID int

AS
BEGIN

    -- Insert statements for procedure here
    
Select Items.ItemType, items.Title, Books.Author, Items.Description, BorrowList.BorrowDate,
BorrowList.DueDate, BorrowList.UsersID as UserID
, BorrowListHistory.ReturnDate, Reservations.StockID as Reservation
From BorrowList
join Stock on BorrowList.StockID = Stock.StockID
join Items on Items.ItemsID = Stock.ItemsID
join Books on Books.ItemsID = Items.ItemsID
left join BorrowListHistory on BorrowListHistory.StockID = BorrowList.StockID
left join Reservations on Reservations.StockID = BorrowList.StockID
where BorrowList.UsersID = @UserID
union
Select Items.ItemType, items.Title, Books.Author, Items.Description, BorrowListHistory.BorrowDate,
BorrowListHistory.DueDate, BorrowListHistory.UsersID as UserID
, BorrowListHistory.ReturnDate , Reservations.StockID as Reservation
From BorrowListHistory
join Stock on BorrowListHistory.StockID = Stock.StockID
join Items on Items.ItemsID = Stock.ItemsID
join Books on Books.ItemsID = Items.ItemsID
left join Reservations on Reservations.StockID = BorrowListHistory.StockID
where BorrowListHistory.UsersID = @UserID
union 
Select Items.ItemType, items.Title, Books.Author, Items.Description, BorrowList.BorrowDate,
BorrowList.DueDate, BorrowList.UsersID as UserID
, BorrowListHistory.ReturnDate , Reservations.StockID as Reservation
From Reservations 
join Stock on Reservations.StockID = Stock.StockID
join Items on Items.ItemsID = Stock.ItemsID
join Books on Books.ItemsID = Items.ItemsID
left Join BorrowList on BorrowList.StockID = Stock.StockID
left join BorrowListHistory on BorrowListHistory.StockID = Reservations.StockID
where Reservations.UsersID = @UserID
	
END
GO
/****** Object:  StoredProcedure [dbo].[getSpeciesList]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getSpeciesList]
	-- Add the parameters for the stored procedure here
	@userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT species.[name] as Name, species.ID
	from users,species, user_species
	where users.ID = user_species.userID and 
	species.ID = user_species.userID and users.ID = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetStock]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[GetStock]
	@ItemsID int
AS
BEGIN
    -- Insert statements for procedur
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Stock.StockID, Stock.ItemsID, Stock.Available, Stock.Reason,
		BorrowList.BorrowDate, BorrowList.DueDate, BorrowList.UsersID, 
		Reservations.UsersID as ReservationsUsersID, BorrowList.BorrowListID
	FROM Stock  
	LEFT JOIN BorrowList ON Stock.StockID = BorrowList.StockID
	LEFT JOIN Reservations ON Stock.StockID = Reservations.StockID
	where ItemsID = @ItemsID
END
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getUser]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from users
	where UsersID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[getUsers]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getUsers]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from users
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserStock]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[GetUserStock]
(
    -- Add the parameters for the stored procedure here
    @UsersID int
)
AS
BEGIN
    -- Insert statements for procedur
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Stock.StockID, Stock.ItemsID, Stock.Available, Stock.Reason,
		BorrowList.BorrowDate, BorrowList.DueDate, BorrowList.UsersID, 
		BorrowList.BorrowListID
	FROM Stock  
	LEFT JOIN BorrowList ON Stock.StockID = BorrowList.StockID
	where BorrowList.UsersID = @UsersID
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login]
	-- Add the parameters for the stored procedure here
	@IdentityNO varchar(12),
	@Password varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Users
	where IdentityNO = @IdentityNO and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveBook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveBook]
@ItemsID int
AS
delete from Books where @ItemsID = ItemsID
GO
/****** Object:  StoredProcedure [dbo].[RemoveItem]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveItem]
	-- Add the parameters for the stored procedure here
	@ItemsID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Items where @ItemsID = ItemsID
END
GO
/****** Object:  StoredProcedure [dbo].[RemovetemFromBorrowList]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemovetemFromBorrowList]

@StockID int, 
@UserID int 

AS

DELETE FROM BorrowList 
WHERE StockID = @StockID AND UsersID = @UserID 
GO
/****** Object:  StoredProcedure [dbo].[ReserveItem]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Fredrik Molén
-- Create Date: 2020-05-26
-- Description: Reserves a item from the BorrowList table using
--				the Stock-table and a UsersID
-- =============================================
CREATE PROCEDURE [dbo].[ReserveItem]
(
    -- Add the parameters for the stored procedure here
    @StockID int,
	@UsersID int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO Reservations (StockID, UsersID)
	VALUES (@StockID, @UsersID)
END
GO
/****** Object:  StoredProcedure [dbo].[SearchAllUsers]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchAllUsers]
@Search varchar(255)
as
select * from users where Firstname like '%'+@Search+'%' or IdentityNO like '%'+@Search+'%'
GO
/****** Object:  StoredProcedure [dbo].[SearchAllUsersWithIdentityNO]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchAllUsersWithIdentityNO]
@Search varchar(255)
as
select * from users where IdentityNO like '%'+@Search+'%'
GO
/****** Object:  StoredProcedure [dbo].[SearchBook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchBook]
@Search varchar(255)
AS
SELECT Title,Description,Author,Pages,Category,ItemType,Date,StockID from Items 
inner join Books on Books.ItemsID = Items.ItemsID 
inner join Stock on Stock.ItemsID = Items.ItemsID
left join BooksCategory on Books.Category = BooksCategory.CategoryID
where Title like '%'+@Search+'%'
order by case when Title like '%'+@Search+'%' then null
else Title end asc


GO
/****** Object:  StoredProcedure [dbo].[SearchBooksAllItems]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchBooksAllItems]
@Search varchar(255)
AS
SELECT * from Items 
inner join Books on Books.ItemsID = Items.ItemsID 

left join BooksCategory on Books.Category = BooksCategory.CategoryID
where Title like '%'+@Search+'%'
or Author like '%'+@Search+'%'
or Books.ISBN like @Search

order by case when Title like '%'+@Search+'%' then null
else Title end asc
GO
/****** Object:  StoredProcedure [dbo].[SearchCheifLibrarians]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchCheifLibrarians]
@Search varchar(255)
as
select * from users where Firstname like '%'+@Search+'%' and Users.UsersCategory like '2'
GO
/****** Object:  StoredProcedure [dbo].[SearchEbook]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in

CREATE PROCEDURE [dbo].[SearchEbook]
@Search Varchar(255)
AS
SELECT Title,Description,Author,Pages,Category,ItemType from Items 
inner join Ebooks on EBooks.ItemsID = Items.ItemsID where Title like '%'+@Search+'%'
order by case when Title like '%'+@Search+'%' then null
else Title end asc
GO
/****** Object:  StoredProcedure [dbo].[SearchItems]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in

CREATE PROCEDURE [dbo].[SearchItems]
@Search Varchar(255)
AS
select * from (

select Title,Description,ItemType,Author,Pages,Category
from Ebooks
inner join Items 
on Ebooks.ItemsID = Items.ItemsID 
where Title like '%'+@Search+'%'
union 

select Title,Description,ItemType,Director,Duration,Genre
from Movies 
inner join Items 
on Movies.ItemsID = Items.ItemsID 
where Title like '%'+@Search+'%'
union


select Title,Description,ItemType ,Author, Pages,Category
from Books inner join Items
on Books.ItemsID = Items.ItemsID 
where Title like '%'+@Search+'%'
) x
ORDER BY case when Title like '%'+@Search+'%' then null
else Title end asc



GO
/****** Object:  StoredProcedure [dbo].[SearchLibrarians]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchLibrarians]
@Search varchar(255)
as
select * from users where Firstname like '%'+@Search+'%' and Users.UsersCategory like '1'
GO
/****** Object:  StoredProcedure [dbo].[SearchMovie]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in

CREATE PROCEDURE [dbo].[SearchMovie]
@Search Varchar(255)
AS
SELECT Title,Description,Duration,Director,Actors,Genre,ItemType from Items 
inner join Movies on Movies.ItemsID = Items.ItemsID where Title like '%'+@Search+'%'
order by case when Title like '%'+@Search+'%' then null
else Title end asc
GO
/****** Object:  StoredProcedure [dbo].[SearchUserEmail]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchUserEmail]
@Search varchar(255)
as
select * from users where Email like '%'+@Search+'%' and Users.UsersCategory like '0'
GO
/****** Object:  StoredProcedure [dbo].[SearchUserIdentityNO]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SearchUserIdentityNO]
@Search varchar(255)
as
select * from users where IdentityNO like '%'+@Search+'%' and Users.UsersCategory like '0'
GO
/****** Object:  StoredProcedure [dbo].[SearchUserName]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchUserName]
@Search varchar(255)
as
select * from users where Firstname like '%'+@Search+'%' and Users.UsersCategory like '0'
GO
/****** Object:  StoredProcedure [dbo].[SearchVisitors]    Script Date: 2020-06-02 21:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SearchVisitors]
@Search varchar(255)
as
select * from users where Firstname like '%'+@Search+'%' and Users.UsersCategory like '0' 

GO
