DROP TABLE IF EXISTS [dbo].[ArAdmissionDocuments]
DROP TABLE IF EXISTS [dbo].[ArAdmissionForms]
/****** Object:  Table [dbo].[ArAdmissionDocuments]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionDocuments](
	[ardocument_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[mstdocumenttypes_id] [int] NULL,
	[document_name] [nvarchar](255) NOT NULL,
	[document_path] [nvarchar](255) NOT NULL,
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
/****** Object:  Table [dbo].[ArAdmissionEnquiryDetails]    Script Date: 09-10-2023 21:57:47 ******/
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
/****** Object:  Table [dbo].[ArAdmissionForms]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionForms](
	[arform_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[academic_id] [int] NOT NULL,
	[school_id] [int] NOT NULL,
	[stream_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[admission_status] [int] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arform_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArEmergencyContactDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArEmergencyContactDetails](
	[aremergencycontactdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[name] [nvarchar](255) NOT NULL,
	[contact_number] [int] NOT NULL,
	[relationship] [nvarchar](100) NOT NULL,
	[nameofparent_incaseofstaff_ward] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[aremergencycontactdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArFamilyOrGuardianInfoDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArFamilyOrGuardianInfoDetails](
	[arfamilyorguardianinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
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
/****** Object:  Table [dbo].[ArPreviousSchoolDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArPreviousSchoolDetails](
	[arpreviousschooldetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[name_school] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[curriculum] [nvarchar](255) NULL,
	[class_completed] [nvarchar](255) NULL,
	[dateOf_leavingschool] [datetime] NULL,
	[years_attended] [nvarchar](255) NULL,
	[mediumof_instruction] [nvarchar](255) NULL,
	[reason_forleaving] [nvarchar](255) NULL,
	[hasapplicantever_expelledorsuspended] [nvarchar](25) NULL,
	[reasonforsuspension] [nvarchar](25) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arpreviousschooldetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArSiblingInfo]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArSiblingInfo](
	[arsibling_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[sibling_name] [nvarchar](255) NULL,
	[sibling_dob] [datetime] NULL,
	[sibling_gender] [nvarchar](255) NULL,
	[sibling_school] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arsibling_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArStudentHealthInfoDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArStudentHealthInfoDetails](
	[arstudenthealthinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[child_name] [nvarchar](255) NULL,
	[class] [nvarchar](255) NULL,
	[blood_group] [nvarchar](255) NULL,
	[vision_left] [nvarchar](255) NULL,
	[vision_right] [nvarchar](255) NULL,
	[height] [nvarchar](25) NULL,
	[weight] [int] NULL,
	[immunization_status] [nvarchar](255) NULL,
	[identification_marks] [nvarchar](255) NULL,
	[regularmedicine_takenbystudent] [nvarchar](255) NULL,
	[health_history] [nvarchar](255) NULL,
	[allergies_ifAny] [nvarchar](255) NULL,
	[special_needs] [nvarchar](255) NULL,
	[learning_disabilities] [nvarchar](255) NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arstudenthealthinfodetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArStudentIllnessDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArStudentIllnessDetails](
	[arstudentillnessdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[illness_type] [nvarchar](255) NULL,
	[illness_name] [nvarchar](255) NULL,
	[illness_date] [nvarchar](255) NULL,
	[illness_details] [nvarchar](255) NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[arstudentillnessdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArStudentInfoDetails]    Script Date: 09-10-2023 21:57:47 ******/
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
/****** Object:  Table [dbo].[ArTransportDetails]    Script Date: 09-10-2023 21:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArTransportDetails](
	[artransportdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[arform_id] [int] NULL,
	[academic_year] [datetime] NULL,
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
	[created_at] [datetime] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
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
ALTER TABLE [dbo].[ArPreviousSchoolDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArSiblingInfo] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArStudentHealthInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArStudentIllnessDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArStudentInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArTransportDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ArAdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArAdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([mstdocumenttypes_id])
REFERENCES [dbo].[MstDocumentTypes] ([mstdocumenttypes_id])
GO
ALTER TABLE [dbo].[ArAdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArAdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiondetails_id])
REFERENCES [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id])
GO
ALTER TABLE [dbo].[ArEmergencyContactDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArPreviousSchoolDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArSiblingInfo]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArStudentHealthInfoDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArStudentIllnessDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArStudentInfoDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[ArTransportDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
