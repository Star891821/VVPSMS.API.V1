﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Filters;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionService : ICommonService<AdmissionForm>
    {
        Task<(List<AdmissionForm>, int)> GetAll(PaginationFilter paginationFilter);
        Task<List<AdmissionForm>> GetAdmissionDetailsByUserId(int id);
        Task<AdmissionForm> GetAdmissionDetailsByUserIdAndFormId(int id, int UserId);
        AdmissionForm UpdateApplicationStatus(AdmissionFormStatusDto admissionFormStatusDto);

        bool SaveAdmissionPaymentDetails(AdmissionPayment admissionPayment);

        List<AdmissionPayment> GetAdmissionPaymentDetailsByUserId(int UserId);

        bool UpdateAdmissionPaymentStatus(int admissionPaymentId, int StatusId);
        bool UpdateAdmissionPaymentStatusbyUserId(int UserId, int StatusId);

        List<AdmissionPayment> GetAdmissionPaymentDetails(int UserId);
        public List<AdmissionPayment> GetAdmissionPaymentDetailsByPaymentId(int PaymentId);
        void createDirectory(string directoryPath);
        public void deleteFileFromDirectory(string directory, string fileName);
        bool DeleteAdmissionPaymentDetails(List<AdmissionPayment> admissionPayments);
    }
}
