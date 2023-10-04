using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstEnquiryQuestionDetailService : IGenericService<MstEnquiryQuestionDetailDto>
    {
        private IMapper _mapper;
        public MstEnquiryQuestionDetailService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstEnquiryQuestionDetails.FirstOrDefault(e => e.MstenquiryquestiondetailsId == id);
                if (entity != null)
                {
                    dbContext.MstEnquiryQuestionDetails.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }

        }

        public List<MstEnquiryQuestionDetailDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstEnquiryQuestionDetails.ToList();
                return _mapper.Map<List<MstEnquiryQuestionDetailDto>>(result);
            }
        }

        public MstEnquiryQuestionDetailDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstEnquiryQuestionDetails?.FirstOrDefault(e => e.MstenquiryquestiondetailsId.Equals(id));
                return _mapper.Map<MstEnquiryQuestionDetailDto>(result);
            }
        }

        public bool InsertOrUpdate(MstEnquiryQuestionDetailDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.MstenquiryquestiondetailsId != 0)
                    {
                        var dbentity = dbContext.MstEnquiryQuestionDetails.FirstOrDefault(e => e.MstenquiryquestiondetailsId == entity.MstenquiryquestiondetailsId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstEnquiryQuestionDetail>(entity));
                        }
                    }
                    else
                    {                    
                        dbContext.MstEnquiryQuestionDetails.Add(_mapper.Map<MstEnquiryQuestionDetail>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }


    }
}
