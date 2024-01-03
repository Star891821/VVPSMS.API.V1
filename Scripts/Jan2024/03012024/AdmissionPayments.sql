
/****** Object:  Table [dbo].[AdmissionPayments]    Script Date: 03-01-2024 23:21:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdmissionPayments](
	[admissionpayment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[image_name] [nvarchar](255) NOT NULL,
	[image_path] [nvarchar](255) NOT NULL,
	[useremail] [nvarchar](255) NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[admissionpayment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AdmissionPayments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[AdmissionPayments]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[MstUsers] ([user_id])
GO


