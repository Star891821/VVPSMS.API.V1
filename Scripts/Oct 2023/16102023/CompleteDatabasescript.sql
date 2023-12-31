USE [VVPSMSDB]
GO
/****** Object:  Table [dbo].[AdmissionDocuments]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[AdmissionEnquiryDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdmissionEnquiryDetails](
	[admissionenquirydetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
	[mstenquiryquestiondetails_id] [int] NULL,
	[enquiry_response] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[admissionenquirydetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdmissionForms]    Script Date: 16-10-2023 20:44:11 ******/
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
	[admission_status] [int] NULL,
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
/****** Object:  Table [dbo].[Announcements]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcements](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[post_title] [nvarchar](255) NOT NULL,
	[post_description] [text] NOT NULL,
	[user_id] [int] NOT NULL,
	[status] [nvarchar](255) NOT NULL,
	[post_groups] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArAdmissionDocuments]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArAdmissionEnquiryDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArAdmissionForms]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArAdmissionForms](
	[arform_id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[ArEmergencyContactDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArFamilyOrGuardianInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArPreviousSchoolDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArSiblingInfo]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArStudentHealthInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArStudentIllnessDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[ArTransportDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
	[created_at] [datetime] NOT NULL,
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
/****** Object:  Table [dbo].[EmergencyContactDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencyContactDetails](
	[emergencycontactdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[emergencycontactdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyOrGuardianInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyOrGuardianInfoDetails](
	[familyorguardianinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
/****** Object:  Table [dbo].[MstAcademicYears]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstAcademicYears](
	[academicId] [int] IDENTITY(1,1) NOT NULL,
	[academicyear_name] [nvarchar](255) NOT NULL,
	[academicyear_from] [datetime] NOT NULL,
	[academicyear_to] [datetime] NOT NULL,
	[academicterm_no] [nvarchar](255) NOT NULL,
	[academic_startdate] [datetime] NOT NULL,
	[academic_enddate] [datetime] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[academicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstAdmissionStatus]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstAdmissionStatus](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_code] [int] NOT NULL,
	[status_description] [nvarchar](255) NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
 CONSTRAINT [PK_MstAdmissionStatus] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstClasses]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstClasses](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstDocumentTypes]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[MstEnquiryAnswerDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryAnswerDetails](
	[mstenquiryanswerdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[mstenquiryquestiondetails_id] [int] NULL,
	[enquiry_answer_details] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryanswerdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstEnquiryQuestionDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionDetails](
	[mstenquiryquestiondetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question] [nvarchar](255) NULL,
	[mstenquiryquestiontypedetails_id] [int] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiondetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstEnquiryQuestionTypeDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstEnquiryQuestionTypeDetails](
	[mstenquiryquestiontypedetails_id] [int] IDENTITY(1,1) NOT NULL,
	[enquiry_question_type] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mstenquiryquestiontypedetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstGroupOfSchools]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstGroupOfSchools](
	[groupofSchools_id] [int] IDENTITY(1,1) NOT NULL,
	[groupofSchools_Name] [nvarchar](255) NOT NULL,
	[groupofSchools_Code] [nvarchar](255) NOT NULL,
	[groupofSchools_Logo] [nvarchar](255) NULL,
	[group_address] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[groupofSchools_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstRoleGroups]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstRoleGroups](
	[rolegroup_id] [int] IDENTITY(1,1) NOT NULL,
	[rolegroup_name] [nvarchar](255) NOT NULL,
	[rolegroup_description] [nvarchar](255) NULL,
	[role_id] [int] NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[rolegroup_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstSchoolGrades]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstSchoolGrades](
	[grade_id] [int] IDENTITY(1,1) NOT NULL,
	[grade_name] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[grade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstSchools]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstSchools](
	[school_id] [int] IDENTITY(1,1) NOT NULL,
	[school_name] [nvarchar](255) NOT NULL,
	[school_code] [nvarchar](255) NOT NULL,
	[school_description] [nvarchar](255) NOT NULL,
	[school_address1] [nvarchar](255) NOT NULL,
	[school_address2] [nvarchar](255) NULL,
	[school_logopath] [nvarchar](255) NULL,
	[school_phone] [nvarchar](15) NOT NULL,
	[school_website] [nvarchar](255) NULL,
	[school_coordinates] [nvarchar](255) NULL,
	[school_landmark] [nvarchar](255) NOT NULL,
	[school_district] [nvarchar](255) NOT NULL,
	[school_state] [nvarchar](255) NOT NULL,
	[school_country] [nvarchar](255) NOT NULL,
	[streams_available] [nvarchar](255) NULL,
	[grades_available] [nvarchar](255) NULL,
	[classes_available] [nvarchar](255) NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[school_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstSchoolStreams]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstSchoolStreams](
	[stream_id] [int] IDENTITY(1,1) NOT NULL,
	[stream_name] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[stream_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstUserRoles]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstUserRoles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](255) NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstUsers]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstUsers](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[userpassword] [nvarchar](255) NOT NULL,
	[user_givenName] [nvarchar](255) NOT NULL,
	[user_surname] [nvarchar](255) NOT NULL,
	[user_phone] [nvarchar](15) NULL,
	[role_id] [int] NOT NULL,
	[user_loginType] [nvarchar](255) NOT NULL,
	[enforce2FA] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[lastlogin_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentDocuments]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Parents]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parents](
	[parent_id] [int] IDENTITY(1,1) NOT NULL,
	[parent_username] [nvarchar](255) NOT NULL,
	[parent_password] [nvarchar](255) NOT NULL,
	[parent_givenName] [nvarchar](255) NOT NULL,
	[parent_surname] [nvarchar](255) NOT NULL,
	[parent_phone] [nvarchar](15) NULL,
	[parent_role] [nvarchar](255) NULL,
	[parent_loginType] [nvarchar](255) NOT NULL,
	[enforce2FA] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[lastlogin_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[parent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreviousSchoolDetails]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[SiblingInfo]    Script Date: 16-10-2023 20:44:11 ******/
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
/****** Object:  Table [dbo].[StudentDocuments]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[StudentHealthInfoDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentHealthInfoDetails](
	[studenthealthinfodetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[studenthealthinfodetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentIllnessDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentIllnessDetails](
	[studentillnessdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[studentillnessdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
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
/****** Object:  Table [dbo].[Students]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[student_id] [int] IDENTITY(1,1) NOT NULL,
	[student_username] [nvarchar](255) NOT NULL,
	[student_password] [nvarchar](255) NOT NULL,
	[student_givenName] [nvarchar](255) NOT NULL,
	[student_surname] [nvarchar](255) NOT NULL,
	[student_phone] [nvarchar](15) NULL,
	[student_role] [nvarchar](255) NULL,
	[student_loginType] [nvarchar](255) NOT NULL,
	[enforce2FA] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[lastlogin_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherDocuments]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherDocuments](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_username] [nvarchar](255) NOT NULL,
	[teacher_password] [nvarchar](255) NOT NULL,
	[teacher_givenName] [nvarchar](255) NOT NULL,
	[teacher_surname] [nvarchar](255) NOT NULL,
	[teacher_phone] [nvarchar](15) NOT NULL,
	[teacher_role] [nvarchar](255) NOT NULL,
	[school_code] [int] NOT NULL,
	[teacher_loginType] [nvarchar](255) NOT NULL,
	[enforce2FA] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[lastlogin_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportDetails]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportDetails](
	[transportdetails_id] [int] IDENTITY(1,1) NOT NULL,
	[form_id] [int] NULL,
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
	[academicid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[transportdetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 16-10-2023 20:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[register_id] [int] IDENTITY(1,1) NOT NULL,
	[register_email] [nvarchar](255) NULL,
	[register_givenname] [nvarchar](255) NOT NULL,
	[register_surname] [nvarchar](255) NOT NULL,
	[register_password] [nvarchar](255) NOT NULL,
	[register_phone] [nvarchar](15) NULL,
	[register_type] [nvarchar](255) NOT NULL,
	[enforce2FA] [int] NOT NULL,
	[activeYN] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[register_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdmissionDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[AdmissionEnquiryDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Announcements] ADD  DEFAULT (getdate()) FOR [created_at]
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
ALTER TABLE [dbo].[MstAcademicYears] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstAdmissionStatus] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstClasses] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstDocumentTypes] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstEnquiryAnswerDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstEnquiryQuestionDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstEnquiryQuestionTypeDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstGroupOfSchools] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstRoleGroups] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstSchoolGrades] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstSchools] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstSchoolStreams] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MstUserRoles] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ParentDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Parents] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[PreviousSchoolDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[SiblingInfo] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[StudentDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[StudentHealthInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[StudentIllnessDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[StudentInfoDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[TeacherDocuments] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Teachers] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[TransportDetails] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[UserRegistration] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[AdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[AdmissionDocuments]  WITH CHECK ADD FOREIGN KEY([mstdocumenttypes_id])
REFERENCES [dbo].[MstDocumentTypes] ([mstdocumenttypes_id])
GO
ALTER TABLE [dbo].[AdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[AdmissionEnquiryDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiondetails_id])
REFERENCES [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id])
GO
ALTER TABLE [dbo].[Announcements]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[MstUsers] ([user_id])
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
ALTER TABLE [dbo].[ArTransportDetails]  WITH CHECK ADD FOREIGN KEY([academicid])
REFERENCES [dbo].[MstAcademicYears] ([academicId])
GO
ALTER TABLE [dbo].[ArTransportDetails]  WITH CHECK ADD FOREIGN KEY([arform_id])
REFERENCES [dbo].[ArAdmissionForms] ([arform_id])
GO
ALTER TABLE [dbo].[EmergencyContactDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[MstEnquiryAnswerDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiondetails_id])
REFERENCES [dbo].[MstEnquiryQuestionDetails] ([mstenquiryquestiondetails_id])
GO
ALTER TABLE [dbo].[MstEnquiryQuestionDetails]  WITH CHECK ADD FOREIGN KEY([mstenquiryquestiontypedetails_id])
REFERENCES [dbo].[MstEnquiryQuestionTypeDetails] ([mstenquiryquestiontypedetails_id])
GO
ALTER TABLE [dbo].[MstRoleGroups]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[MstUserRoles] ([role_id])
GO
ALTER TABLE [dbo].[MstUsers]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[MstUserRoles] ([role_id])
GO
ALTER TABLE [dbo].[ParentDocuments]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Parents] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Parents] ([parent_id])
GO
ALTER TABLE [dbo].[ParentDocuments] CHECK CONSTRAINT [FK_Documents_Parents]
GO
ALTER TABLE [dbo].[PreviousSchoolDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[SiblingInfo]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[StudentDocuments]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([student_id])
GO
ALTER TABLE [dbo].[StudentDocuments] CHECK CONSTRAINT [FK_Documents_Students]
GO
ALTER TABLE [dbo].[StudentHealthInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[StudentIllnessDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[StudentInfoDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
ALTER TABLE [dbo].[TeacherDocuments]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Teachers] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[TeacherDocuments] CHECK CONSTRAINT [FK_Documents_Teachers]
GO
ALTER TABLE [dbo].[TransportDetails]  WITH CHECK ADD FOREIGN KEY([academicid])
REFERENCES [dbo].[MstAcademicYears] ([academicId])
GO
ALTER TABLE [dbo].[TransportDetails]  WITH CHECK ADD FOREIGN KEY([form_id])
REFERENCES [dbo].[AdmissionForms] ([form_id])
GO
