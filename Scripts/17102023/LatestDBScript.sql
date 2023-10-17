
DROP TABLE IF EXISTS [dbo].[StudentInfoDetails]
DROP TABLE IF EXISTS [dbo].[ArStudentInfoDetails]
DROP TABLE IF EXISTS [dbo].[FamilyOrGuardianInfoDetails]
DROP TABLE IF EXISTS [dbo].[ArFamilyOrGuardianInfoDetails]
/****** Object:  Table [dbo].[StudentInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInfoDetails](
	[studentinfo_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
	[first_name] [nvarchar](255) NOT NULL,
	[middle_name] [nvarchar](255) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL,
	[dob] [nvarchar](255) NOT NULL,
	[dob_in_words] [nvarchar](255) NOT NULL,
	[nationality] [nvarchar](100) NOT NULL,
	[gender] [nvarchar](80) NOT NULL,
	[age] [int] NOT NULL,
	[religion] [nvarchar](100) NULL,
	[caste] [nvarchar](100) NULL,
	[aadhar_number] [nvarchar](100) NOT NULL,
	[sats_child_number] [nvarchar](100) NULL,
	[u_dise_code] [nvarchar](100) NULL,
	[passport_number] [nvarchar](100) NULL,
	[date_of_issue] [datetime] NULL,
	[date_of_expiry] [datetime] NULL,
	[permanent_address] [nvarchar](255) NULL,
	[present_address] [nvarchar](255) NULL,
	[student_lives_with] [nvarchar](255) NULL,
	[typeof_family] [nvarchar](255) NULL,
	[no_of_familymembers] [int] NULL,
	[mother_tongue] [nvarchar](255) NULL,
	[other_knownLanguages] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[studentinfo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudentInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[StudentInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO




/****** Object:  Table [dbo].[ArStudentInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArStudentInfoDetails](
	[arstudentinfo_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[first_name] [nvarchar](255) NOT NULL,
	[middle_name] [nvarchar](255) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL,
	[dob] [nvarchar](255) NOT NULL,
	[dob_in_words] [nvarchar](255) NOT NULL,
	[nationality] [nvarchar](100) NOT NULL,
	[gender] [nvarchar](80) NOT NULL,
	[age] [int] NOT NULL,
	[religion] [nvarchar](100) NULL,
	[caste] [nvarchar](100) NULL,
	[aadhar_number] [nvarchar](100) NOT NULL,
	[sats_child_number] [nvarchar](100) NULL,
	[u_dise_code] [nvarchar](100) NULL,
	[passport_number] [nvarchar](100) NULL,
	[date_of_issue] [datetime] NULL,
	[date_of_expiry] [datetime] NULL,
	[permanent_address] [nvarchar](255) NULL,
	[present_address] [nvarchar](255) NULL,
	[student_lives_with] [nvarchar](255) NULL,
	[typeof_family] [nvarchar](255) NULL,
	[no_of_familymembers] [int] NULL,
	[mother_tongue] [nvarchar](255) NULL,
	[other_knownLanguages] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arstudentinfo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ArStudentInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArStudentInfoDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO


/****** Object:  Table [dbo].[FamilyOrGuardianInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyOrGuardianInfoDetails](
	[familyorguardianinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
	[legalguardian] bit NULL,
	[name] [nvarchar](255) NOT NULL,
	[dob] [nvarchar](255) NOT NULL,
	[highest_qualification] [nvarchar](255) NULL,
	[occupation] [nvarchar](100) NULL,
	[designation_nameofcompany] [nvarchar](80) NULL,
	[annual_income] [int] NULL,
	[office_address] [nvarchar](100) NULL,
	[aadhar_number] [nvarchar](100) NULL,
	[pan_number] [nvarchar](100) NULL,
	[passportnumber] [nvarchar](100) NULL,
	[passportissuedate] [datetime] NULL,
	[passportexpirydate] [datetime] NULL,
	[contact] [nvarchar](15) NOT NULL,
	[email] [nvarchar](100) NULL,
	[preferredcontact] [nvarchar](255) NULL,
	[relationshiptype] [nvarchar](100) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[familyorguardianinfodetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO

ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO

/****** Object:  Table [dbo].[ArFamilyOrGuardianInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArFamilyOrGuardianInfoDetails](
	[arfamilyorguardianinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[legalguardian] bit NULL,
	[name] [nvarchar](255) NOT NULL,
	[dob] [nvarchar](255) NOT NULL,
	[highest_qualification] [nvarchar](255) NULL,
	[occupation] [nvarchar](100) NULL,
	[designation_nameofcompany] [nvarchar](80) NULL,
	[annual_income] [int] NULL,
	[office_address] [nvarchar](100) NULL,
	[aadhar_number] [nvarchar](100) NULL,
	[pan_number] [nvarchar](100) NULL,
	[passportnumber] [nvarchar](100) NULL,
	[passportissuedate] [datetime] NULL,
	[passportexpirydate] [datetime] NULL,
	[contact] [nvarchar](15) NOT NULL,
	[email] [nvarchar](100) NULL,
	[preferredcontact] [nvarchar](255) NULL,
	[relationshiptype] [nvarchar](100) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arfamilyorguardianinfodetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO

ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO