


Truncate table dbo.AdmissionEnquiryDetails
Truncate table dbo.StudentInfoDetails
Truncate table dbo.StudentIllnessDetails
Truncate table dbo.TransportDetails
Truncate table dbo.StudentHealthInfoDetails
Truncate table dbo.PreviousSchoolDetails
Truncate table dbo.FamilyOrGuardianInfoDetails
Truncate table dbo.SiblingInfo
Truncate table dbo.AdmissionDocuments
Truncate table dbo.EmergencyContactDetails

delete from dbo.AdmissionForms
dbcc checkident('dbo.AdmissionForms',reseed,0)

ALTER TABLE [dbo].[AdmissionForms] 
ALTER COLUMN admission_status int NULL
