using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AdmissionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILog _logger;

        public AdmissionController(IAdmissionUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmissionDetails()
        {
            try
            {
                _logger.Information($"GetAllAdmissionDetails API Started");
                var result = await _unitOfWork.AdmissionService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllAdmissionDetails API completed Successfully");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmissionStatusTypes()
        {
            try
            {
                _logger.Information($"GetAdmissionStatusTypes API Started");
                var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                return Ok(enumDTOs);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionStatusTypes for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAdmissionStatusTypes API completed Successfully");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmissionDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetAdmissionDetailsById API Started");
                var item = await _unitOfWork.AdmissionService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionDetailsById for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAdmissionDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByAdmissionId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByAdmissionId API Started");
                var item = await _unitOfWork.AdmissionDocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByAdmissionId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByAdmissionId API completed Successfully");
            }

        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(AdmissionFormDto admissionFormDto)
        {
            try
            {
                if (admissionFormDto != null)
                {
                    _logger.Information($"InsertOrUpdate API Started");

                    var result = _mapper.Map<AdmissionForm>(admissionFormDto);
                    result.AdmissionDocuments.Clear();

                    #region Admission Form transaction
                    await _unitOfWork.AdmissionService.InsertOrUpdate(result);
                    await _unitOfWork.CompleteAsync();
                    #endregion

                    #region Upload File and Insert Admission Documents
                    var isUploadtoAzure = _configuration["Upoad:IsUpoadtoAzure"];
                    var filePath = _configuration["Upoad:SaveFilePath"];
                    if (isUploadtoAzure == "Yes")
                    {

                    }
                    else
                    {
                        _unitOfWork.AdmissionDocumentService.RemoveRangeofDocuments(result.FormId);
                        await _unitOfWork.CompleteAsync();

                        if (admissionFormDto.listOfAdmissionDocuments != null && result.FormId != 0)
                        {
                            filePath += "\\" + result.FormId;

                            _unitOfWork.AdmissionDocumentService.createDirectory(filePath);

                            for (var i = 0; i < admissionFormDto.listOfAdmissionDocuments.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(admissionFormDto.listOfAdmissionDocuments[i].FileContentsAsBase64))
                                {
                                    var Base64FileContent = admissionFormDto.listOfAdmissionDocuments[i].FileContentsAsBase64;
                                    var index = Base64FileContent.IndexOf(',');
                                    var base64stringwithoutsignature = Base64FileContent.Substring(index + 1);
                                    byte[] bytes = Convert.FromBase64String(base64stringwithoutsignature);
                                    var fileDetails = admissionFormDto.listOfAdmissionDocuments[i].DocumentName;
                                    var temp = fileDetails.Split('.');

                                    var fileName = temp[0] + "_" + DateTime.Now.ToString("HH_mm_dd-MM-yyyy") + "." + temp[1];
                                    System.IO.File.WriteAllBytes(filePath + "\\" + fileName, bytes);
                                    AdmissionDocument admissionDocument = new()
                                    {
                                        DocumentName = fileName,
                                        DocumentPath = filePath,
                                        FormId = result.FormId,
                                        MstdocumenttypesId = admissionFormDto.listOfAdmissionDocuments[i].MstdocumenttypesId,
                                        CreatedAt = DateTime.Now,
                                        ModifiedAt = DateTime.Now,
                                    };
                                    result.AdmissionDocuments.Add(admissionDocument);
                                }

                            }


                            #region Admission Document Transaction
                            var resultDocuments = _mapper.Map<List<AdmissionDocument>>(result.AdmissionDocuments);
                            if (resultDocuments.Count > 0)
                            {
                                await _unitOfWork.AdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                _unitOfWork.Complete();
                            }
                            #endregion

                        }
                        else
                        {
                            _logger.Information($"listOfAdmissionDocuments or FormID is Null");
                        }

                    }
                    #endregion

                    return Ok();

                }
                else
                {
                    _logger.Information($"Admission Form is null");
                    return StatusCode(500, "Admission Form JSON is null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _unitOfWork.RemoveNullableEntitiesFromDb();
                await _unitOfWork.CompleteAsync();
                #endregion

                _logger.Information($"InsertOrUpdate API completed Successfully");
            }
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(AdmissionFormDto admissionFormDto)
        {
            try
            {
                _logger.Information($"Delete API Started");
                var result = _unitOfWork.AdmissionService.GetById(admissionFormDto.FormId);
                if (result.Result != null)
                {
                    var item = await _unitOfWork.AdmissionService.Remove(result.Result);

                    var documents = result.Result.AdmissionDocuments;
                    foreach (var document in documents)
                    {
                        _unitOfWork.AdmissionDocumentService.createDirectory(document.DocumentPath);
                    }

                    await _unitOfWork.CompleteAsync();
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
                _logger.Error($"Something went wrong inside Delete for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _unitOfWork.RemoveNullableEntitiesFromDb();
                await _unitOfWork.CompleteAsync();
                #endregion
                _logger.Information($"Delete API completed Successfully");
            }
        }
    }
}
