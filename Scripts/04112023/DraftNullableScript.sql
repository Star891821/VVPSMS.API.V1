ALTER TABLE [dbo].[ArAdmissionForms] ALTER COLUMN academic_id INT  NULL
ALTER TABLE [dbo].[ArAdmissionForms] ALTER COLUMN school_id INT  NULL
ALTER TABLE [dbo].[ArAdmissionForms] ALTER COLUMN stream_id INT  NULL
ALTER TABLE [dbo].[ArAdmissionForms] ALTER COLUMN grade_id INT  NULL
ALTER TABLE [dbo].[ArAdmissionForms] ALTER COLUMN class_id INT  NULL

ALTER TABLE [dbo].[ArAdmissionDocuments] ALTER COLUMN document_name [nvarchar](255) NULL
ALTER TABLE [dbo].[ArAdmissionDocuments] ALTER COLUMN document_path [nvarchar](255) NULL


ALTER TABLE [dbo].[ArEmergencyContactDetails] ALTER COLUMN [name] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArEmergencyContactDetails] ALTER COLUMN contact_number int NULL
ALTER TABLE [dbo].[ArEmergencyContactDetails] ALTER COLUMN relationship [nvarchar](255) NULL

ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ALTER COLUMN [name] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ALTER COLUMN [dob] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ALTER COLUMN [contact] [nvarchar](15) NULL

ALTER TABLE [dbo].[ArStudentHealthInfoDetails] ALTER COLUMN [created_at] [datetime] NULL


ALTER TABLE [dbo].[ArStudentIllnessDetails] ALTER COLUMN [created_at] [datetime] NULL


ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [first_name] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [middle_name] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [last_name] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [dob] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [dob_in_words] [nvarchar](255) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [nationality] [nvarchar](100) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [gender] [nvarchar](80) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [age] [int] NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN [aadhar_number] [nvarchar](100) NULL

ALTER TABLE [dbo].[ArTransportDetails] ALTER COLUMN [created_at] [datetime] NULL

DROP TABLE if exists [ArAdmissionDocuments]
DROP TABLE if exists [ArAdmissionEnquiryDetails]
DROP TABLE if exists [ArTransportDetails] 

GO
/****** Object:  Table [dbo].[ArAdmissionDocuments]    Script Date: 04-11-2023 13:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionDocuments](
	[ardocument_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[mstdocumenttypes_id] [int] NULL,
	[document_name] [nvarchar](255) NULL,
	[document_path] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ardocument_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArAdmissionEnquiryDetails]    Script Date: 04-11-2023 13:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionEnquiryDetails](
	[aradmissionenquirydetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[mstenquiryquestiondetails_id] [int] NULL,
	[enquiry_response] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[aradmissionenquirydetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArTransportDetails]    Script Date: 04-11-2023 13:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArTransportDetails](
	[artransportdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[dateof_application] [datetime] NULL,
	[nameof_student] [nvarchar](255) NULL,
	[admitted_to] [nvarchar](255) NULL,
	[father_name] [nvarchar](255) NULL,
	[father_phone] [int] NULL,
	[father_email] [nvarchar](100) NULL,
	[mother_name] [nvarchar](255) NULL,
	[mother_phone] [int] NULL,
	[mother_email] [nvarchar](100) NULL,
	[address] [nvarchar](255) NULL,
	[land_mark] [nvarchar](255) NULL,
	[preferred_pickup_point] [nvarchar](255) NULL,
	[preferred_drop_point] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[academicid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[artransportdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArAdmissionDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArAdmissionEnquiryDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArTransportDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArAdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArAdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArTransportDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
