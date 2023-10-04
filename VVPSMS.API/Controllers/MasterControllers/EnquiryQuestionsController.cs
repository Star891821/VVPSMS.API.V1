using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnquiryQuestionsController : GenericController<MstEnquiryQuestionDetailDto>
    {
        public EnquiryQuestionsController(IGenericService<MstEnquiryQuestionDetailDto> genericService, ILog logger)
           : base(genericService, logger)
        {

        }
    }
}
