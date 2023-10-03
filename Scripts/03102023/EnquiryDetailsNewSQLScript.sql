
DROP TABLE IF EXISTS [dbo].[AdmissionEnquiryDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryQuestionDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryQuestionTypeDetails]
DROP TABLE IF EXISTS [dbo].[MstEnquiryAnswerDetails]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionTypeDetails](
	[mstenquiryquestiontypedetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question_type] [nvarchar](255)  NULL,
	[created_at] [int]  NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiontypedetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionTypeDetails] ON 
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'Radio Button', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'CheckBox', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'TextArea', NULL, NULL, NULL, NULL)
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

ALTER TABLE [dbo].[MstEnquiryQuestionDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiontypedetails_id])
REFERENCES [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id])
GO

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] ON 

INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'What according to you should be the role of a parent in the child’s education?', 3,NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'What are the long term goals set for your child?', 3,NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'How did you hear about Vishwa Vidyapeeth?', 3,NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, N'Why are you interested in taking admission to Vishwa Vidyapeeth?', 3,NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, N'Mention your expectations from the School', 3, NULL,NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, N'Please share something special about your child', 3, NULL,NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, N'How can you collaborate with the school for betterment of your child?', 3, NULL,NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, N'Any information you wish to share regarding your family members', 3, NULL,NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (9, N'In case, both parents are working, what is the support system at home?', 3,NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question],[mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (10, N'Two areas in which you will be willing to participate at Vishwa Vidyapeeth? (Please tick)', 2, NULL,NULL, NULL, NULL)

SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] OFF
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryAnswerDetails](
	[mstenquiryanswerdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[mstenquiryquestiondetails_id] [int] NULL,
	[enquiry_answer_details] [nvarchar](255)  NULL,
	[created_at] [int]  NULL,
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

SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] ON 
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1,10, N'Field trips', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2,10, N'Sports', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3,10, N'Event management', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4,10, N'Social awareness group activities', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5,10, N'Volunteering', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6,10, N'Help with Annual Day/Sports Day', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7,10, N'Mother on Duty', NULL, NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id],[mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8,10, N'Parent Engagement Programme Committee', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] OFF
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
