using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers.AdmissionDataManagers;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class EnquiryUnitOfWork: IEnquiryUnitOfWork
    {
        #region Private Declarations
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        #endregion

        #region public Declarations

        public IMstEnquiryQuestionDetails mstEnquiryQuestionDetails { get; private set; }
        public IMstEnquiryAnswerDetails mstEnquiryAnswerDetails { get; private set; }


        #endregion


        #region public methods
        public EnquiryUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            mstEnquiryQuestionDetails = new MstEnquiryQuestionDetailService(vvpsmsdbContext);
            mstEnquiryAnswerDetails = new MstEnquiryAnswerDetailService(vvpsmsdbContext);
        }
        public void RemoveNullableEntitiesFromDb()
        {
            mstEnquiryAnswerDetails.RemoveRangeofDetails();
        }


        public void RemoveEntitiesById(int id)
        {
            mstEnquiryAnswerDetails.RemoveRangeofEnquiryAnswers(id);
        }
        public Task CompleteAsync()
        {
            return vvpsmsdbContext.SaveChangesAsync();
        }
        public bool Complete()
        {
            return vvpsmsdbContext.SaveChanges() > 0;
        }
        public void Dispose()
        {
            vvpsmsdbContext.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await vvpsmsdbContext.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
