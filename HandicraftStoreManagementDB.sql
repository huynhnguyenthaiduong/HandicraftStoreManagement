USE [HandicraftStoreDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/6/2024 6:23:44 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/6/2024 6:23:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HandicraftCategories]    Script Date: 3/6/2024 6:23:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HandicraftCategories](
	[HandicraftCategoryId] [uniqueidentifier] NOT NULL,
	[HCCategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_HandicraftCategories] PRIMARY KEY CLUSTERED 
(
	[HandicraftCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Handicrafts]    Script Date: 3/6/2024 6:23:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Handicrafts](
	[HandicraftId] [uniqueidentifier] NOT NULL,
	[HandicraftCategoryId] [uniqueidentifier] NOT NULL,
	[HandicraftName] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OriginalSource] [nvarchar](max) NOT NULL,
	[Material] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Handicrafts] PRIMARY KEY CLUSTERED 
(
	[HandicraftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/6/2024 6:23:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229081609_HCCStore-v3', N'6.0.20')
GO
INSERT [dbo].[Accounts] ([AccountId], [RoleId], [UserName], [Password], [FullName], [Email], [Gender], [PhoneNumber], [Address], [Status]) VALUES (N'ca1edcbd-be11-4951-3d25-08dc3c2b537d', N'59cbc3ed-8a8a-4a50-96b1-62bec4d1dd6d', N'Staff2', N'2222', N'Staff2', N'sfaff2@gmail.com', N'Male', N'0846294658', N'abc xyz', 1)
INSERT [dbo].[Accounts] ([AccountId], [RoleId], [UserName], [Password], [FullName], [Email], [Gender], [PhoneNumber], [Address], [Status]) VALUES (N'0a017797-63ea-4395-a54b-2fce8b8d84e9', N'b010a310-72dc-4acb-8d2e-b56ad0d0aa36', N'User1', N'0000', N'User1', N'user1@gmail.com', N'Male', N'097462845', N'test', 1)
INSERT [dbo].[Accounts] ([AccountId], [RoleId], [UserName], [Password], [FullName], [Email], [Gender], [PhoneNumber], [Address], [Status]) VALUES (N'9e9a9642-4b1e-443c-9af4-9521647a694e', N'365e0361-d1f1-436f-a233-89db21f0250b', N'Admin', N'0000', N'Admin', N'admin@gmail.com', N'Male', N'0947285647', N'Admin', 1)
INSERT [dbo].[Accounts] ([AccountId], [RoleId], [UserName], [Password], [FullName], [Email], [Gender], [PhoneNumber], [Address], [Status]) VALUES (N'804efd7d-1ef3-48ee-8cd4-bba8d81ba8cf', N'59cbc3ed-8a8a-4a50-96b1-62bec4d1dd6d', N'Staff1', N'1111', N'Staff1', N'staff1@gmail.com', N'Female', N'0964725481', N'Staff ', 1)
GO
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'57ee2158-99d2-4554-a8da-054ae28cf0b8', N'Poetry')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'50f43263-af02-4a67-fb0a-08dc3c2c0879', N'Pashmina Shawls')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'0016119e-d4cb-43f2-fb0b-08dc3c2c0879', N'Metal')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'fefd582f-251e-4892-8d47-1324481213a5', N'LeatherWork')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'e29b0278-26c4-40e4-ba51-2f3c86e89aee', N'Brass')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'2119de53-4751-4249-8556-3236c37cc6a4', N'Printing')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'fa0719c2-8902-4c8b-a633-68b320ef156b', N'GlassArt')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'95da3051-be4f-45b4-964c-8cee7e2ff346', N'Carving')
INSERT [dbo].[HandicraftCategories] ([HandicraftCategoryId], [HCCategoryName]) VALUES (N'067d4e16-7cf6-4755-8855-da366b3b3fa9', N'Woodcraft')
GO
INSERT [dbo].[Handicrafts] ([HandicraftId], [HandicraftCategoryId], [HandicraftName], [Description], [OriginalSource], [Material], [Price], [Quantity], [Status]) VALUES (N'88a6d6fe-9143-4da6-2906-08dc3dbd5f78', N'95da3051-be4f-45b4-964c-8cee7e2ff346', N'Wood Carving Elephant', N'Decorate your home with Rajasthani hand carved statue. ', N'India', N'Kadam Wood', 100000, 10, 1)
INSERT [dbo].[Handicrafts] ([HandicraftId], [HandicraftCategoryId], [HandicraftName], [Description], [OriginalSource], [Material], [Price], [Quantity], [Status]) VALUES (N'ed35ce0c-36ad-48b7-2907-08dc3dbd5f78', N'fa0719c2-8902-4c8b-a633-68b320ef156b', N'Handmade Glass Art Sculpture ‘Most Charming Creatures VIII’', N'This handmade glass art sculpture is number 8 in the ‘Most Charming Creatures’ collection. Beautifully hand made and polished to an intense clarity and shine as with all of Roberta’s work.  Roberta captures the beauty of marine life and the ocean with her wonderous glass art. A piece which is both joyous to look at and inspirational.', N'Roberta Mason in UK', N'glass', 19882000, 2, 1)
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'59cbc3ed-8a8a-4a50-96b1-62bec4d1dd6d', N'Staff')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'365e0361-d1f1-436f-a233-89db21f0250b', N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'b010a310-72dc-4acb-8d2e-b56ad0d0aa36', N'User')
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles_RoleId]
GO
ALTER TABLE [dbo].[Handicrafts]  WITH CHECK ADD  CONSTRAINT [FK_Handicrafts_HandicraftCategories_HandicraftCategoryId] FOREIGN KEY([HandicraftCategoryId])
REFERENCES [dbo].[HandicraftCategories] ([HandicraftCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Handicrafts] CHECK CONSTRAINT [FK_Handicrafts_HandicraftCategories_HandicraftCategoryId]
GO
