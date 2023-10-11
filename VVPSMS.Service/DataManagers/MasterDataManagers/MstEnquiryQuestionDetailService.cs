using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstEnquiryQuestionDetailService : GenericService<MstEnquiryQuestionDetail>, IMstEnquiryQuestionDetails
    {
        #region Declarations
        protected VvpsmsdbContext context;
        #endregion

        #region
        public MstEnquiryQuestionDetailService(VvpsmsdbContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task<bool> InsertOrUpdate(MstEnquiryQuestionDetail entity)
        {
            try
            {
                var exist = getbyID(entity.MstenquiryquestiondetailsId);
                if (exist != null)
                {
                    await base.Update(exist, UpdatedEnquiryEntity(exist, entity));// UpdatedAdmissionEntity(exist, entity));
                }
                else
                {
                    await base.InsertOrUpdate(entity);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public override async Task<MstEnquiryQuestionDetail?> GetById(int id)
        {
            try
            {
                return getbyID(id);
            }
            catch
            {
                return null;
            }
        }
        public override async Task<List<MstEnquiryQuestionDetail>> GetAll()
        {
            return await dbSet.Include(a => a.MstEnquiryAnswerDetails)
                .ToListAsync();
        }
        #endregion

        #region Private Methods
        private MstEnquiryQuestionDetail UpdatedEnquiryEntity(MstEnquiryQuestionDetail entityToUpdate, MstEnquiryQuestionDetail entity)
        {
            entityToUpdate.MstenquiryquestiondetailsId = entity.MstenquiryquestiondetailsId;
            entityToUpdate.EnquiryQuestion = entity.EnquiryQuestion;
            entityToUpdate.MstenquiryquestiontypedetailsId = entity.MstenquiryquestiontypedetailsId;
            entityToUpdate.MstEnquiryAnswerDetails = entity.MstEnquiryAnswerDetails;
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }
        public MstEnquiryQuestionDetail getbyID(int id)
        {
            var enquiryForm = new MstEnquiryQuestionDetail();
            try
            {
                enquiryForm = dbSet.Where(x => x.MstenquiryquestiondetailsId == id)
                                      .FirstOrDefault();
                if (enquiryForm != null)
                {
                    dbSet.Entry(enquiryForm).Collection(adm => adm.MstEnquiryAnswerDetails).Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return enquiryForm;
        }
        #endregion 

    }
}
