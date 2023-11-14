TRUNCATE TABLE [dbo].[StudentInfoDetails] 
TRUNCATE TABLE [dbo].[FamilyOrGuardianInfoDetails]
TRUNCATE TABLE [dbo].[EmergencyContactDetails]
TRUNCATE TABLE [dbo].[StudentHealthInfoDetails]
TRUNCATE TABLE [dbo].[TransportDetails]

TRUNCATE TABLE [dbo].[AdmissionDocuments]
TRUNCATE TABLE [dbo].[AdmissionEnquiryDetails]
TRUNCATE TABLE [dbo].[SiblingInfo]
TRUNCATE TABLE [dbo].[StudentIllnessDetails]
TRUNCATE TABLE [dbo].[StudentInfoDetails]
TRUNCATE TABLE [dbo].[TrackAdmissionStatus]
TRUNCATE TABLE [dbo].[PreviousSchoolDetails]
Delete from [dbo].[AdmissionForms]



TRUNCATE TABLE [dbo].[ArStudentInfoDetails] 
TRUNCATE TABLE [dbo].[ArFamilyOrGuardianInfoDetails]
TRUNCATE TABLE [dbo].[ArEmergencyContactDetails]
TRUNCATE TABLE [dbo].[ArStudentHealthInfoDetails]
TRUNCATE TABLE [dbo].[ArTransportDetails]

TRUNCATE TABLE [dbo].[ArAdmissionDocuments]
TRUNCATE TABLE [dbo].[ArAdmissionEnquiryDetails]
TRUNCATE TABLE [dbo].[ArSiblingInfo]
TRUNCATE TABLE [dbo].[ArStudentIllnessDetails]
TRUNCATE TABLE [dbo].[ArStudentInfoDetails]
TRUNCATE TABLE [dbo].[ArPreviousSchoolDetails]
Delete from [dbo].[ArAdmissionForms]


ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ALTER COLUMN office_address nvarchar(255) NULL
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN office_address nvarchar(255) NULL


ALTER TABLE [dbo].[ArPreviousSchoolDetails] ALTER COLUMN hasapplicantever_expelledorsuspended nvarchar(255) NULL
ALTER TABLE [dbo].[PreviousSchoolDetails] ALTER COLUMN hasapplicantever_expelledorsuspended nvarchar(255) NULL

ALTER TABLE [dbo].[ArStudentHealthInfoDetails] ALTER COLUMN [weight] nvarchar(100) NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN [weight] nvarchar(100) NULL

ALTER TABLE [dbo].[ArEmergencyContactDetails] ALTER COLUMN [contact_number] nvarchar(100) NULL
ALTER TABLE [dbo].[EmergencyContactDetails] ALTER COLUMN [contact_number] nvarchar(100) NULL




