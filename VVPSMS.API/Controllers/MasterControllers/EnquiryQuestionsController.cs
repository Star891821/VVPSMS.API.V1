using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnquiryQuestionsController : ControllerBase
    {
        private readonly IEnquiryUnitOfWork _enquiryUnitOfWork;
        private ILog _logger;
        private IMapper _mapper;
        public EnquiryQuestionsController(IEnquiryUnitOfWork _enquiryUnitOfWork, IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._enquiryUnitOfWork = _enquiryUnitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnquiryDetails()
        {
            try
            {
                _logger.Information($"GetAllEnquiryDetails API Started");
                var result = await _enquiryUnitOfWork.mstEnquiryQuestionDetails.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllEnquiryDetails for" + typeof(EnquiryQuestionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllEnquiryDetails API completed Successfully");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnquiryDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetEnquiryDetailsById API Started");
                var item = await _enquiryUnitOfWork.mstEnquiryQuestionDetails.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetEnquiryDetailsById for" + typeof(EnquiryQuestionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetEnquiryDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAnswersByEnquiryQuestionId(int id)
        {
            try
            {
                _logger.Information($"GetAllAnswersByEnquiryQuestionId API Started");
                var item = await _enquiryUnitOfWork.mstEnquiryAnswerDetails.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllAnswersByEnquiryQuestionId for" + typeof(EnquiryQuestionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllAnswersByEnquiryQuestionId API completed Successfully");
            }

        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(MstEnquiryQuestionDetailDto enquiryFormDto)
        {
            try
            {
                if (enquiryFormDto != null)
                {
                    _logger.Information($"InsertOrUpdate API Started");

                    var result = _mapper.Map<MstEnquiryQuestionDetail>(enquiryFormDto);
                    result.MstEnquiryAnswerDetails.Clear();

                    #region Admission Form transaction

                    if (enquiryFormDto.ListOfMstEnquiryAnswerDetails != null)
                    {

                        for (var i = 0; i < enquiryFormDto.ListOfMstEnquiryAnswerDetails.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(enquiryFormDto.ListOfMstEnquiryAnswerDetails[i].EnquiryAnswerDetails))
                            {

                                MstEnquiryAnswerDetail enquiryAnswer = new()
                                {
                                    MstenquiryanswerdetailsId = enquiryFormDto.ListOfMstEnquiryAnswerDetails[i].MstenquiryanswerdetailsId,
                                    MstenquiryquestiondetailsId = enquiryFormDto.ListOfMstEnquiryAnswerDetails[i].MstenquiryquestiondetailsId,
                                    EnquiryAnswerDetails = enquiryFormDto.ListOfMstEnquiryAnswerDetails[i].EnquiryAnswerDetails,
                                    CreatedAt = DateTime.Now,
                                    ModifiedAt = DateTime.Now,
                                };
                                result.MstEnquiryAnswerDetails.Add(enquiryAnswer);
                            }

                        }
                        await _enquiryUnitOfWork.mstEnquiryQuestionDetails.InsertOrUpdate(result);
                        await _enquiryUnitOfWork.CompleteAsync();
                        #endregion

                    }
                    else
                    {
                        _logger.Information($"ListOfMstEnquiryAnswerDetails or MstenquiryquestiondetailsId is Null");
                    }



                    return Ok();

                }
                else
                {
                    _logger.Information($"Enqiry Form is null");
                    return StatusCode(500, "Enqiry Form JSON is null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(EnquiryQuestionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _enquiryUnitOfWork.RemoveNullableEntitiesFromDb();
                await _enquiryUnitOfWork.CompleteAsync();
                #endregion

                _logger.Information($"InsertOrUpdate API completed Successfully");
            }
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(MstEnquiryQuestionDetailDto enquiryFormDto)
        {
            try
            {
                _logger.Information($"Delete API Started");
                var result = _enquiryUnitOfWork.mstEnquiryQuestionDetails.GetById(enquiryFormDto.MstenquiryquestiondetailsId);
                if (result.Result != null)
                {
                    var item = await _enquiryUnitOfWork.mstEnquiryQuestionDetails.Remove(result.Result);


                    await _enquiryUnitOfWork.CompleteAsync();
                    return Ok(item);
                }
                else
                {
                    _logger.Information($"Admission Form is not availablein Database");
                    return StatusCode(404, "Admission Form is not available in Database");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(EnquiryQuestionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _enquiryUnitOfWork.RemoveNullableEntitiesFromDb();
                await _enquiryUnitOfWork.CompleteAsync();
                #endregion
                _logger.Information($"Delete API completed Successfully");
            }
        }
    }
}
