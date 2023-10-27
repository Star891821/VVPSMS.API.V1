USE [VVPSMSDB]
GO
/****** Object:  Table [dbo].[[TrackAdmissionStatus]]    Script Date: 27-10-2023 18:16:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrackAdmissionStatus](
	[track_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
	[admission_status] [int] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [VVPSMSDB]
GO
SET IDENTITY_INSERT [dbo].[MstAdmissionStatus] ON
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, 0, N'User Registrered', CAST(N'2023-10-26T20:22:44.697' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, 1, N'Submitted, Payment Pending', CAST(N'2023-10-26T20:22:59.187' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, 2, N'Active and Submitted Application', CAST(N'2023-10-26T20:23:17.773' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, 3, N'Applied', CAST(N'2023-10-26T20:23:27.613' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, 4, N'Review Application', CAST(N'2023-10-26T20:23:40.837' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, 5, N'Scheduled', CAST(N'2023-10-26T20:23:48.867' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, 6, N'Schedule Interview', CAST(N'2023-10-26T20:23:59.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, 7, N'Confirm Admission', CAST(N'2023-10-26T20:24:06.910' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[MstAdmissionStatus] ([status_id], [status_code], [status_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (9, 100, N'Rejected or Cancelled', CAST(N'2023-10-26T20:24:18.043' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MstAdmissionStatus] OFF
GO






