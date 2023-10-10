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

    public class ArAdmissionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IArAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILog _logger;

        public ArAdmissionController(IArAdmissionUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArAdmissionDetails()
        {
            try
            {
                _logger.Information($"GetAllArAdmissionDetails API Started");
                var result = await _unitOfWork.ArAdmissionService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllArAdmissionDetails for" + typeof(ArAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllArAdmissionDetails API completed Successfully");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArAdmissionDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetArAdmissionDetailsById API Started");
                var item = await _unitOfWork.ArAdmissionService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetArAdmissionDetailsById for" + typeof(ArAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetArAdmissionDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByArAdmissionId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByArAdmissionId API Started");
                var item = await _unitOfWork.ArAdmissionDocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByArAdmissionId for" + typeof(ArAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByArAdmissionId API completed Successfully");
            }

        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(ArAdmissionFormDto aradmissionFormDto)
        {
            try
            {
                if (aradmissionFormDto != null)
                {
                    _logger.Information($"InsertOrUpdate API Started");

                    var result = _mapper.Map<ArAdmissionForm>(aradmissionFormDto);
                    result.ArAdmissionDocuments.Clear();

                    #region Admission Form transaction
                    await _unitOfWork.ArAdmissionService.InsertOrUpdate(result);
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
                        _unitOfWork.ArAdmissionDocumentService.RemoveRangeofDocuments(result.ArformId);
                        await _unitOfWork.CompleteAsync();

                        if (aradmissionFormDto.listOfArAdmissionDocuments != null && result.ArformId != 0)
                        {
                            filePath += "\\Archival\\" + result.ArformId;

                            _unitOfWork.ArAdmissionDocumentService.createDirectory(filePath);

                            for (var i = 0; i < aradmissionFormDto.listOfArAdmissionDocuments.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(aradmissionFormDto.listOfArAdmissionDocuments[i].FileContentsAsBase64))
                                {
                                    var Base64FileContent = aradmissionFormDto.listOfArAdmissionDocuments[i].FileContentsAsBase64;
                                    var index = Base64FileContent.IndexOf(',');
                                    var base64stringwithoutsignature = Base64FileContent.Substring(index + 1);
                                    byte[] bytes = Convert.FromBase64String(base64stringwithoutsignature);
                                    var fileDetails = aradmissionFormDto.listOfArAdmissionDocuments[i].DocumentName;
                                    var temp = fileDetails.Split('.');

                                    var fileName = temp[0] + "_" + DateTime.Now.ToString("HH_mm_dd-MM-yyyy") + "." + temp[1];
                                    System.IO.File.WriteAllBytes(filePath + "\\" + fileName, bytes);
                                    ArAdmissionDocument aradmissionDocument = new()
                                    {
                                        DocumentName = fileName,
                                        DocumentPath = filePath,
                                        ArformId = result.ArformId,
                                        MstdocumenttypesId = aradmissionFormDto.listOfArAdmissionDocuments[i].MstdocumenttypesId,
                                        CreatedAt = DateTime.Now,
                                        ModifiedAt = DateTime.Now,
                                    };
                                    result.ArAdmissionDocuments.Add(aradmissionDocument);
                                }

                            }


                            #region Admission Document Transaction
                            var resultDocuments = _mapper.Map<List<ArAdmissionDocument>>(result.ArAdmissionDocuments);
                            if (resultDocuments.Count > 0)
                            {
                                await _unitOfWork.ArAdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                _unitOfWork.Complete();
                            }
                            #endregion

                        }
                        else
                        {
                            _logger.Information($"listOfArAdmissionDocuments or ArFormID is Null");
                        }

                    }
                    #endregion

                    return Ok();

                }
                else
                {
                    _logger.Information($"ArAdmission Form is null");
                    return StatusCode(500, "ArAdmission Form JSON is null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside ArInsertOrUpdate for" + typeof(ArAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _unitOfWork.RemoveNullableEntitiesFromDb();
                await _unitOfWork.CompleteAsync();
                #endregion

                _logger.Information($"ArInsertOrUpdate API completed Successfully");
            }
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(ArAdmissionFormDto admissionFormDto)
        {
            try
            {
                _logger.Information($"Delete API Started");
                var result = _unitOfWork.ArAdmissionService.GetById(admissionFormDto.ArformId);
                if (result.Result != null)
                {
                    var item = await _unitOfWork.ArAdmissionService.Remove(result.Result);

                    var documents = result.Result.ArAdmissionDocuments;
                    foreach (var document in documents)
                    {
                        _unitOfWork.ArAdmissionDocumentService.createDirectory(document.DocumentPath);
                    }

                    await _unitOfWork.CompleteAsync();
                    return Ok(item);
                }
                else
                {
                    _logger.Information($"ArAdmission Form is not availablein Database");
                    return StatusCode(404, "ArAdmission Form is not available in Database");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(ArAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                #region Remove Null Entries
                _unitOfWork.RemoveNullableEntitiesFromDb();
                await _unitOfWork.CompleteAsync();
                #endregion
                _logger.Information($"ArDelete API completed Successfully");
            }
        }
    }
}
