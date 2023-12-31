USE [VVPSMSDB]
GO
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionTypeDetails] ON 

INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'Radio Button', CAST(N'2023-10-09T20:33:15.353' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'CheckBox', CAST(N'2023-10-09T20:33:15.357' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id], [enquiry_question_type], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'TextArea', CAST(N'2023-10-09T20:33:15.357' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionTypeDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] ON 

INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'What according to you should be the role of a parent in the child’s education?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'What are the long term goals set for your child?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, N'How did you hear about Vishwa Vidyapeeth?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, N'Why are you interested in taking admission to Vishwa Vidyapeeth?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, N'Mention your expectations from the School', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, N'Please share something special about your child', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, N'How can you collaborate with the school for betterment of your child?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, N'Any information you wish to share regarding your family members', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (9, N'In case, both parents are working, what is the support system at home?', 3, CAST(N'2023-10-09T20:33:15.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id], [enquiry_question], [mstenquiryquestiontypedetails_id], [created_at], [created_by], [modified_at], [modified_by]) VALUES (10, N'Two areas in which you will be willing to participate at Vishwa Vidyapeeth? (Please tick)', 2, CAST(N'2023-10-09T20:33:15.393' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryQuestionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] ON 

INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, 10, N'Field trips', CAST(N'2023-10-09T20:33:15.427' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, 10, N'Sports', CAST(N'2023-10-09T20:33:15.430' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (3, 10, N'Event management', CAST(N'2023-10-09T20:33:15.430' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (4, 10, N'Social awareness group activities', CAST(N'2023-10-09T20:33:15.430' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (5, 10, N'Volunteering', CAST(N'2023-10-09T20:33:15.430' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (6, 10, N'Help with Annual Day/Sports Day', CAST(N'2023-10-09T20:33:15.430' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (7, 10, N'Mother on Duty', CAST(N'2023-10-09T20:33:15.433' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstEnquiryAnswerDetails] ([mstenquiryanswerdetails_id], [mstenquiryquestiondetails_id], [enquiry_answer_details], [created_at], [created_by], [modified_at], [modified_by]) VALUES (8, 10, N'Parent Engagement Programme Committee', CAST(N'2023-10-09T20:33:15.433' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstEnquiryAnswerDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[MstDocumentTypes] ON 

INSERT [dbo].[MstDocumentTypes] ([mstdocumenttypes_id], [mstdocumenttypes_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (1, N'text', CAST(N'2023-10-09T20:33:15.543' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MstDocumentTypes] ([mstdocumenttypes_id], [mstdocumenttypes_description], [created_at], [created_by], [modified_at], [modified_by]) VALUES (2, N'pdf', CAST(N'2023-10-09T20:33:15.547' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MstDocumentTypes] OFF
GO
