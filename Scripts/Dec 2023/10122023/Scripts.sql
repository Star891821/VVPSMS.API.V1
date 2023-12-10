USE [VVPSMSDB]
GO

/****** Object:  Table [dbo].[MstRoleTypes]    Script Date: 10-12-2023 12:42:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MstRoleTypes](
	[roletype_id] [int] IDENTITY(1,1) NOT NULL,
	[roletype_name] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[roletype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MstRoleTypes] ADD  DEFAULT (getdate()) FOR [created_at]
GO


USE [VVPSMSDB]
GO

/****** Object:  Table [dbo].[MstPermissions]   Script Date: 10-12-2023 12:42:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MstPermissions](
	[permission_id] [int] IDENTITY(1,1) NOT NULL,
	[permission_name] [nvarchar](255) NOT NULL,
	[permission_details] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[permission_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MstPermissions] ADD  DEFAULT (getdate()) FOR [created_at]
GO


USE [VVPSMSDB]
GO

/****** Object:  Table [dbo].[RolePermissionsMapping]   Script Date: 10-12-2023 12:42:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RolePermissionsMapping](
	[mapping_id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[permission_id] [int] NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mapping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RolePermissionsMapping] ADD  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[RolePermissionsMapping]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[MstUserRoles] ([role_id])

ALTER TABLE [dbo].[RolePermissionsMapping]  WITH CHECK ADD FOREIGN KEY([permission_id])
REFERENCES [dbo].[MstPermissions] ([permission_id])

ALTER TABLE [dbo].[MstUserRoles] add [roletype_id] int  NULL

ALTER TABLE [dbo].[MstUserRoles]  WITH CHECK ADD FOREIGN KEY([roletype_id])
REFERENCES [dbo].[MstRoleTypes] ([roletype_id])



USE [VVPSMSDB]
GO
SET IDENTITY_INSERT [dbo].[MstRoleTypes] ON 
GO
INSERT [dbo].[MstRoleTypes] ([roletype_id], [roletype_name], [activeYN], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'Seeded', 1, CAST(N'2023-12-10T13:54:06.157' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstRoleTypes] ([roletype_id], [roletype_name], [activeYN], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'Custom', 1, CAST(N'2023-12-10T13:54:18.223' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MstRoleTypes] OFF
GO

Update [VVPSMSDB].[dbo].[MstUserRoles]
  Set [roletype_id] = 1

