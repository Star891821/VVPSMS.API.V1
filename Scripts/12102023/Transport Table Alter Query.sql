
Truncate table dbo.TransportDetails
ALTER TABLE [dbo].[TransportDetails] 
DROP COLUMN if exists academic_year 

ALTER TABLE [dbo].[TransportDetails] 
ADD [academicid] int NULL

ALTER TABLE [dbo].[TransportDetails]  WITH CHECK ADD FOREIGN KEY([academicid])
REFERENCES [dbo].[MstAcademicYears] ([academicid])
GO


Truncate table dbo.[ArTransportDetails]
ALTER TABLE [dbo].[ArTransportDetails] 
DROP COLUMN if exists academic_year 

ALTER TABLE [dbo].[ArTransportDetails] 
ADD [academicid] int NULL

ALTER TABLE [dbo].[ArTransportDetails]  WITH CHECK ADD FOREIGN KEY([academicid])
REFERENCES [dbo].[MstAcademicYears] ([academicid])
GO