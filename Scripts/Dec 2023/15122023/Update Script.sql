USE [VVPSMSDB]
GO

UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Registered'
 WHERE status_id = 1
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Submitted'
 WHERE status_id = 2
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Active'
 WHERE status_id = 3
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Reviewed'
 WHERE status_id = 5
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Entrance'
 WHERE status_id = 6
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Interview'
 WHERE status_id = 7
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Confirmed'
 WHERE status_id = 8
GO
UPDATE [dbo].[MstAdmissionStatus]
   SET 
      [status_description] = 'Rejected'
 WHERE status_id = 9
GO