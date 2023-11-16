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


ALTER TABLE [dbo].[StudentInfoDetails] ALTER COLUMN aadhar_number nvarchar(20) NULL
ALTER TABLE [dbo].[ArStudentInfoDetails] ALTER COLUMN aadhar_number nvarchar(20) NULL


ALTER TABLE [dbo].[StudentInfoDetails] add  Ispresentaddresspermanentaddress BIT default 'FALSE';
ALTER TABLE [dbo].[ArStudentInfoDetails] add  Ispresentaddresspermanentaddress BIT default 'FALSE';


ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN aadhar_number nvarchar(20) NOT NULL
ALTER TABLE [dbo].[ArFamilyOrGuardianInfoDetails] ALTER COLUMN aadhar_number nvarchar(20) NULL
