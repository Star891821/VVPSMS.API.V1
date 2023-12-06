DROP TABLE IF EXISTS [dbo].[AdmissionDocuments]
DROP TABLE IF EXISTS [dbo].[MstDocumentTypes]
DROP TABLE IF EXISTS [dbo].[PreviousSchoolDetails]
DROP TABLE IF EXISTS [dbo].[StudentHealthInfoDetails]
DROP TABLE IF EXISTS [dbo].[StudentInfoDetails]
DROP TABLE IF EXISTS [dbo].[StudentIllnessDetails]
DROP TABLE IF EXISTS [dbo].[TransportDetails]
DROP TABLE IF EXISTS [dbo].[AdmissionEnquiryDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryAnswerDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryQuestionDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryQuestionTypeDetails]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionTypeDetails](
	[mstenquiryquestiontypedetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question_type] [nvarchar](255)  NULL,
	[created_at] [datetime]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiontypedetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MstEnquiryQuestionTypeDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionTypeDetails] ON 
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'Radio Button', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'CheckBox', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'TextArea', getdate(), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionTypeDetails] OFF
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionDetails](
	[mstenquiryquestiondetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question] [nvarchar](255)  NULL,
	[mstenquiryquestiontypedetails_id] [int]  NULL,
	[created_at] [datetime]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiondetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MstEnquiryQuestionDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiontypedetails_id])
REFERENCES [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id])
GO
ALTER TABLE [dbo].[MstEnquiryQuestionDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] ON 

INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'What according to you should be the role of a parent in the child’s education?', 3,getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'What are the long term goals set for your child?', 3,getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'How did you hear about Vishwa Vidyapeeth?', 3,getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, N'Why are you interested in taking admission to Vishwa Vidyapeeth?', 3,getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, N'Mention your expectations from the School', 3, getdate(),NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, N'Please share something special about your child', 3, getdate(),NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, N'How can you collaborate with the school for betterment of your child?', 3, getdate(),NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, N'Any information you wish to share regarding your family members', 3, getdate(),NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (9, N'In case, both parents are working, what is the support system at home?', 3,getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (10, N'Two areas in which you will be willing to participate at Vishwa Vidyapeeth? (Please tick)', 2, getdate(),NULL, NULL, NULL)

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] OFF
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryAnswerDetails](
	[mstenquiryanswerdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[mstenquiryquestiondetails_id] [int]   NULL,
	[enquiry_answer_details] [nvarchar](255)  NULL,
	[created_at] [datetime]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryanswerdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MstEnquiryAnswerDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiondetails_id])
REFERENCES [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id])
GO
ALTER TABLE [dbo].[MstEnquiryAnswerDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] ON 
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1,10, N'Field trips', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2,10, N'Sports', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3,10, N'Event management', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4,10, N'Social awareness group activities', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5,10, N'Volunteering', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6,10, N'Help with Annual Day/Sports Day', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7,10, N'Mother on Duty', getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8,10, N'Parent Engagement Programme Committee', getdate(), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdmissionEnquiryDetails](
	[admissionenquirydetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int]  NULL,
	[mstenquiryquestiondetails_id] [int]   NULL,
	[enquiry_response] [nvarchar](255)  NULL,
	[created_at] [datetime]  NULL,
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
ALTER TABLE [dbo].[AdmissionEnquiryDetails] ADD  DEFAULT (getdate()) FOR [created_at]
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
ALTER TABLE [dbo].[StudentInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
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
	[created_at] [datetime] NOT NULL,
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
ALTER TABLE [dbo].[StudentIllnessDetails] ADD  DEFAULT (getdate()) FOR [created_at]
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
	[created_at] [datetime] NOT NULL,
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
ALTER TABLE [dbo].[TransportDetails] ADD  DEFAULT (getdate()) FOR [created_at]
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
	[created_at] [datetime] NOT NULL,
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
ALTER TABLE [dbo].[StudentHealthInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MstDocumentTypes](
	[mstdocumenttypes_id] [int] IDENTITY(1,1) NOT NULL,
	[mstdocumenttypes_description] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstdocumenttypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MstDocumentTypes] ADD  DEFAULT (getdate()) FOR [created_at]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PreviousSchoolDetails](
	[previousschooldetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[previousschooldetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PreviousSchoolDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[PreviousSchoolDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdmissionDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
	[mstdocumenttypes_id] [int] NULL,
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

ALTER TABLE [dbo].[AdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([mstdocumenttypes_id])
REFERENCES [dbo].[MstDocumentTypes] ([mstdocumenttypes_id])
GO


SET IDENTITY_INSERT [dbo].[MstDocumentTypes] ON 

INSERT [dbo].[MstDocumentTypes] ([mstdocumenttypes_id], [mstdocumenttypes_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'text',getdate(), NULL, NULL, NULL)
INSERT [dbo].[MstDocumentTypes] ([mstdocumenttypes_id], [mstdocumenttypes_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'pdf',getdate(), NULL, NULL, NULL)

SET IDENTITY_INSERT [dbo].[MstDocumentTypes] OFF
GO
