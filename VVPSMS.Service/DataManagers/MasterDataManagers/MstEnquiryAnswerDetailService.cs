using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstEnquiryAnswerDetailService : GenericService<MstEnquiryAnswerDetail>, IMstEnquiryAnswerDetails
    {
        #region Declarations
        protected VvpsmsdbContext context;
        #endregion

        #region
        public MstEnquiryAnswerDetailService(VvpsmsdbContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task<bool> InsertOrUpdate(MstEnquiryAnswerDetail entity)
        {
            try
            {
                if(entity.MstenquiryquestiondetailsId != null)
                {
                    //var exist = getbyID(entity.MstenquiryquestiondetailsId);
                    //if (exist != null)
                    //{
                    //    await base.Update(exist, UpdatedEnquiryAnswerEntity(exist, entity));// UpdatedAdmissionEntity(exist, entity));
                    //}
                    //else
                    //{
                        await base.InsertOrUpdate(entity);
                   // }
                }
                

                return true;
            }
            catch
            {
                return false;
            }
        }
        public override async Task<List<MstEnquiryAnswerDetail>> GetAll(int id)
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
        public override async Task<List<MstEnquiryAnswerDetail>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async void RemoveRangeofEnquiryAnswers(int id)
        {
            try
            {
                var enquiryAnswerDetails = dbSet.Where(x => x.MstenquiryquestiondetailsId == id).ToList();

                if (enquiryAnswerDetails.Count > 0)
                {
                  
                    await base.RemoveRange(enquiryAnswerDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            try
            {
                var enquiryAnswerDetails = dbSet.Where(x => x.MstenquiryquestiondetailsId == null).ToList();

                if (enquiryAnswerDetails.Count > 0)
                {
                    base.RemoveRange(enquiryAnswerDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Private Methods
        
        public List<MstEnquiryAnswerDetail> getbyID(int? id)
        {
            var enquiryForm = new List<MstEnquiryAnswerDetail>();
            try
            {
                enquiryForm = dbSet.Where(x => x.MstenquiryquestiondetailsId == id).ToList();
               

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
