

DROP TABLE IF EXISTS [dbo].[StudentInfoDetails]
DROP TABLE IF EXISTS [dbo].[FamilyOrGuardianInfoDetails]
DROP TABLE IF EXISTS [dbo].[SiblingInfo]
DROP TABLE IF EXISTS [dbo].[EmergencyContactDetails]
DROP TABLE IF EXISTS [dbo].[PreviousSchoolDetails]
DROP TABLE IF EXISTS [dbo].[StudentHealthInfoDetails]
DROP TABLE IF EXISTS [dbo].[StudentIllnessDetails]
DROP TABLE IF EXISTS [dbo].[AdmissionEnquiryDetails]
DROP TABLE IF EXISTS [dbo].[TransportDetails]
DROP TABLE IF EXISTS [dbo].[AdmissionDocuments]

DROP TABLE IF EXISTS [dbo].[ArAdmissionDocuments]
DROP TABLE IF EXISTS [dbo].[ArAdmissionForms]
DROP TABLE IF EXISTS [dbo].[MstEnquiryQuestionDetails]
DROP TABLE IF EXISTS [dbo].[AdmissionForms]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdmissionForms](
	[form_id] [int] IDENTITY(1,1) NOT NULL,
	[academic_id] [int] NOT NULL,
	[school_id] [int] NOT NULL,
	[stream_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[admission_status] [varchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[form_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Students]    Script Date: 08-09-2023 23:01:35 ******/
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
	[religion] [nvarchar](100)  NULL,
	[caste] [nvarchar](100)  NULL,
	[aadhar_number] [nvarchar](100) NOT NULL,
	[sats_child_number] [nvarchar](100)  NULL,
	[u_dise_code] [nvarchar](100)  NULL,
	[passport_number] [nvarchar](100)  NULL,
	[date_of_issue] [datetime] NULL,
	[date_of_expiry] [datetime] NULL,
	[permanent_address] [nvarchar](255)  NULL,
	[student_lives_with] [nvarchar](255)  NULL,
	[typeof_family] [nvarchar](255)  NULL,
	[no_of_familymembers] [int]  NULL,
	[mother_tongue] [nvarchar](255)  NULL,
	[other_knownLanguages] [nvarchar](255)  NULL,
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
ALTER TABLE [dbo].[StudentInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO

/****** Object:  Table [dbo].[ArAdmissionForms]    Script Date: 08-09-2023 23:01:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionForms](
	[Arform_id] [int] IDENTITY(1,1) NOT NULL,
	[academic_id] [int]  NULL,
	[school_code] [int] NOT NULL,
	[stream_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[student_givenName] [nvarchar](255) NOT NULL,
	[student_surname] [nvarchar](255) NOT NULL,
	[student_dob] [datetime] NOT NULL,
	[student_gender] [varchar](10) NOT NULL,
	[student_age] [int] NOT NULL,
	[parent_name1] [nvarchar](255) NOT NULL,
	[highest_qualification1] [nvarchar](255) NULL,
	[parent_contact1] [nvarchar](15) NOT NULL,
	[parent_email1] [nvarchar](255) NULL,
	[parent_name2] [nvarchar](255) NULL,
	[highest_qualification2] [nvarchar](255) NULL,
	[parent_contact2] [nvarchar](15) NULL,
	[parent_email2] [nvarchar](255) NULL,
	[preferred_contact] [nvarchar](15) NULL,
	[declaration] [int] NOT NULL,
	[siblings_YN] [char](4) NOT NULL,
	[special_needs] [int] NULL,
	[learning_disabilities] [int] NULL,
	[previous_school] [nvarchar](255) NULL,
	[reason_description] [text] NULL,
	[student_expelled] [int] NULL,
	[details_expulsion] [text] NULL,
	[admission_status] [int] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Arform_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[Arform_id] [int]  NULL,
	[document_name] [nvarchar](255) NOT NULL,
	[document_path] [nvarchar](255) NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[document_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyOrGuardianInfoDetails](
	[familyorguardianinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[name] [nvarchar](255) NOT NULL,
	[dob] [nvarchar](255) NOT NULL,
	[highest_qualification] [nvarchar](255)  NULL,
	[occupation] [nvarchar](100)  NULL,
	[designation_nameofcompany] [nvarchar](80)  NULL,
	[annual_income] [int]  NULL,
	[office_address] [nvarchar](100)  NULL,
	[aadhar_number] [nvarchar](100)  NULL,
	[pan_number] [nvarchar](100)  NULL,
	[passportnumber] [nvarchar](100)  NULL,
	[passportissuedate] [datetime] NULL,
	[passportexpirydate] [datetime] NULL,
	[contact][nvarchar](15) NOT NULL,
	[email][nvarchar](100)  NULL,
	[preferredcontact][nvarchar](255)  NULL,
	[relationshiptype][nvarchar](100)  NULL,
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

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SiblingInfo](
	[sibling_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[sibling_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SiblingInfo] ADD  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[SiblingInfo]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencyContactDetails](
	[emergencycontactdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[name] [nvarchar](255) NOT NULL,
	[contact_number] [int] NOT NULL,
	[relationship] [nvarchar](100) NOT NULL,
	[nameofparent_incaseofstaff_ward] [nvarchar](255)  NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[emergencycontactdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmergencyContactDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreviousSchoolDetails](
	[previousschooldetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[name_school] [nvarchar](255)  NULL,
	[address] [nvarchar](255)  NULL,
	[curriculum] [nvarchar](255)  NULL,
	[class_completed] [nvarchar](255)  NULL,
	[dateOf_leavingschool] [datetime] NULL,
	[years_attended] [nvarchar](255)  NULL,
	[mediumof_instruction] [nvarchar](255)  NULL,
	[reason_forleaving] [nvarchar](255)  NULL,
	[hasapplicantever_expelledorsuspended] [nvarchar](25)  NULL,
	[reasonforsuspension] [nvarchar](25)  NULL,
	[created_at] [int]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[previousschooldetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PreviousSchoolDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentHealthInfoDetails](
	[studenthealthinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[child_name] [nvarchar](255)  NULL,
	[class] [nvarchar](255)  NULL,
	[blood_group] [nvarchar](255)  NULL,
	[vision_left] [nvarchar](255)  NULL,
	[vision_right] [nvarchar](255)  NULL,
	[height] [nvarchar](25)  NULL,
	[weight] [int]  NULL,
	[immunization_status] [nvarchar](255)  NULL,
	[identification_marks] [nvarchar](255)  NULL,
	[regularmedicine_takenbystudent] [nvarchar](255)  NULL,
	[health_history] [nvarchar](255)  NULL,
	[allergies_ifAny] [nvarchar](255)  NULL,
	[special_needs] [nvarchar](255)  NULL,
	[learning_disabilities] [nvarchar](255)  NULL,
	[created_at] [int] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[studenthealthinfodetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudentHealthInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentIllnessDetails](
	[studentillnessdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[illness_type] [nvarchar](255)  NULL,
	[illness_name] [nvarchar](255)  NULL,
	[illness_date] [nvarchar](255)  NULL,
	[illness_details] [nvarchar](255)  NULL,
	[created_at] [int] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[studentillnessdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudentIllnessDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionDetails](
	[mstenquiryquestiondetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question] [nvarchar](255)  NULL,
	[created_at] [int]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiondetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] ON 

INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'What according to you should be the role of a parent in the child’s education?', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'What are the long term goals set for your child?', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'How did you hear about Vishwa Vidyapeeth?', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, N'Why are you interested in taking admission to Vishwa Vidyapeeth?', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, N'Mention your expectations from the School', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, N'Please share something special about your child', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, N'How can you collaborate with the school for betterment of your child?', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, N'Any information you wish to share regarding your family members', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [created_at], [created_by], [modified_at], [modified_by]) VALUES (9, N'In case, both parents are working, what is the support system at home?', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdmissionEnquiryDetails](
	[admissionenquirydetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[mstenquiryquestiondetails_id] [int]  Not NULL,
	[enquiry_response] [nvarchar](255)  NULL,
	[created_at] [int] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[admissionenquirydetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[AdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiondetails_id])
REFERENCES [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id])
GO






SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportDetails](
	[transportdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[academic_year][datetime] NULL,
	[dateof_application][datetime] NULL,
	[nameof_student] [nvarchar](255)  NULL,
	[admitted_to] [nvarchar](255)  NULL,
	[father_name] [nvarchar](255)  NULL,
	[father_phone] [int]  NULL,
	[father_email] [nvarchar](100)  NULL,
	[mother_name] [nvarchar](255)  NULL,
	[mother_phone] [int]  NULL,
	[mother_email] [nvarchar](100)  NULL,
	[address] [nvarchar](255)  NULL,
	[land_mark] [nvarchar](255)  NULL,
	[preferred_pickup_point] [nvarchar](255)  NULL,
	[preferred_drop_point] [nvarchar](255)  NULL,
	[created_at] [int] NOT NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[transportdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TransportDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO

/****** Object:  Table [dbo].[AdmissionDocuments]    Script Date: 21-09-2023 22:31:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdmissionDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NOT NULL,
	[document_name] [nvarchar](255) NOT NULL,
	[document_path] [nvarchar](255) NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[document_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AdmissionDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[AdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
