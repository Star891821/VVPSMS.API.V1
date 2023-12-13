ALTER TABLE [dbo].[AdmissionForms] 
ADD scheduled_date datetime NULL DEFAULT GETDATE();

ALTER TABLE [dbo].[AdmissionForms] 
ADD comments nvarchar(500) NULL