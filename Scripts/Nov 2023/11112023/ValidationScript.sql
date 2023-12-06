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

ALTER TABLE [dbo].[StudentInfoDetails] ALTER COLUMN middle_name nvarchar(255) NULL
ALTER TABLE [dbo].[StudentInfoDetails] ALTER COLUMN last_name nvarchar(255) NULL
ALTER TABLE [dbo].[StudentInfoDetails] ALTER COLUMN dob datetime not NULL
ALTER TABLE [dbo].[StudentInfoDetails] ALTER COLUMN aadhar_number int NULL


ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN dob datetime not NULL
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN aadhar_number int not NULL
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN annual_income int not NULL
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN pan_number nvarchar(100)  NULL
ALTER TABLE [dbo].[FamilyOrGuardianInfoDetails] ALTER COLUMN email nvarchar(100) not NULL


ALTER TABLE [dbo].[EmergencyContactDetails] ALTER COLUMN [name] nvarchar(255) NULL
ALTER TABLE [dbo].[EmergencyContactDetails] ALTER COLUMN contact_number int NULL
ALTER TABLE [dbo].[EmergencyContactDetails] ALTER COLUMN relationship nvarchar(100) NULL
ALTER TABLE [dbo].[EmergencyContactDetails] ALTER COLUMN nameofparent_incaseofstaff_ward nvarchar(255) NULL


ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN child_name nvarchar(255) NOT NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN class nvarchar(255) NOT NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN blood_group nvarchar(255) NOT NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN height nvarchar(255) NOT NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN [weight] nvarchar(255) NOT NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN immunization_status nvarchar(255) NOT NULL


ALTER TABLE [dbo].[TransportDetails] ALTER COLUMN created_at datetime NULL
ALTER TABLE [dbo].[StudentHealthInfoDetails] ALTER COLUMN created_at datetime NULL
ALTER TABLE [dbo].[StudentIllnessDetails] ALTER COLUMN created_at datetime NULL

ALTER TABLE [dbo].[TransportDetails] ALTER COLUMN father_phone nvarchar(70) NULL
ALTER TABLE [dbo].[TransportDetails] ALTER COLUMN mother_phone nvarchar(70) NULL




