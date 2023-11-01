using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class DraftAdmissionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IDraftAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILog _logger;

        public DraftAdmissionController(IDraftAdmissionUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllDraftAdmissionDetails()
        {
            try
            {
                _logger.Information($"GetAllDraftAdmissionDetails API Started");
                var result = await _unitOfWork.DraftAdmissionService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDraftAdmissionDetails for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDraftAdmissionDetails API completed Successfully");
            }
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsById API Started");
                var item = await _unitOfWork.DraftAdmissionService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsById for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetDraftAdmissionDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsByUserId(int id)
        {
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserId API Started");
                var item = await _unitOfWork.DraftAdmissionService.GetDraftAdmissionDetailsByUserId(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsByUserId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserId API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsByUserIdAndDraftFormId(int id, int userid)
        {
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserIdAndDraftFormId API Started");
                var item = await _unitOfWork.DraftAdmissionService.GetDraftAdmissionDetailsByUserIdAndDraftformId(id, userid);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsByUserIdAndDraftFormId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserIdAndDraftFormId API completed Successfully");
            }
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByDraftAdmissionId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByDraftAdmissionId API Started");
                var item = await _unitOfWork.DraftAdmissionDocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByDraftAdmissionId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByDraftAdmissionId API completed Successfully");
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdate(ArAdmissionFormDto aradmissionFormDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            bool isValidAdmissionStatus = false;
            try
            {
                if (aradmissionFormDto != null)
                {
                    var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                    if (!int.TryParse(aradmissionFormDto.AdmissionStatus.ToString(), out int value1))
                    {
                        foreach (var enumDTO in enumDTOs)
                        {
                            if (aradmissionFormDto.AdmissionStatus.ToString() == enumDTO.Name)
                            {
                                aradmissionFormDto.AdmissionStatus = enumDTO.Key;
                                isValidAdmissionStatus = true;
                                break;
                            }
                        }

                    }
                    else
                    {
                        int.TryParse(aradmissionFormDto.AdmissionStatus.ToString(), out int value2);
                        isValidAdmissionStatus = enumDTOs.Where(a => a.Key == value2).Count() > 0;
                    }
                    if (isValidAdmissionStatus)
                    {
                        _logger.Information($"InsertOrUpdate API Started");

                        var result = _mapper.Map<ArAdmissionForm>(aradmissionFormDto);
                        result.ArAdmissionDocuments.Clear();

                        #region Admission Form transaction
                        await _unitOfWork.DraftAdmissionService.InsertOrUpdate(result);
                        await _unitOfWork.CompleteAsync();
                        removeNullEntries = true;
                        #endregion

                        #region Upload File and Insert Admission Documents
                        var isUploadtoAzure = _configuration["Upload:IsUpoadtoAzure"];
                        var filePath = _configuration["Upload:SaveFilePath"];
                        if (isUploadtoAzure == "Yes")
                        {

                        }
                        else
                        {

                            #region Admission Document Transaction For FileSystemandDB
                            _unitOfWork.DraftAdmissionDocumentService.RemoveRangeofDocuments(result.ArformId);
                            await _unitOfWork.CompleteAsync();
                            if (aradmissionFormDto.listOfArAdmissionDocuments != null && result.ArformId != 0)
                            {
                                filePath += "\\Archival\\" + result.ArformId;
                                _unitOfWork.DraftAdmissionDocumentService.createDirectory(filePath);

                                for (var i = 0; i < aradmissionFormDto.listOfArAdmissionDocuments.Count; i++)
                                {
                                    try
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

                                        var resultDocuments = _mapper.Map<List<ArAdmissionDocument>>(result.ArAdmissionDocuments);
                                        if (resultDocuments.Count > 0)
                                        {
                                            await _unitOfWork.DraftAdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                            _unitOfWork.Complete();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        statusCode = StatusCodes.Status404NotFound;
                                        value = ex.Message;
                                    }
                                }
                            }
                            else
                            {
                                _logger.Information($"listOfArAdmissionDocuments or ArformID is Null");
                            }
                            #endregion

                        }
                        #endregion

                        value = result.ArformId;
                    }
                    else
                    {
                        statusCode = StatusCodes.Status404NotFound;
                        value = "Invalid Admission Status Code";
                    }
                }
                else
                {
                    _logger.Information($"DraftAdmission Form is null");
                    statusCode = StatusCodes.Status400BadRequest;
                    value = "DraftAdmission Form is null";
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                #region Remove Null Entries
                if (removeNullEntries)
                {
                    _unitOfWork.RemoveNullableEntitiesFromDb();
                    await _unitOfWork.CompleteAsync();
                }
                #endregion
                _logger.Information($"InsertOrUpdate API completed Successfully");

            }
            return StatusCode(statusCode, value);
        }



        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(ArAdmissionFormDto admissionFormDto)
        {
            bool removeNullEntries = false;
            try
            {
                _logger.Information($"Delete API Started");
                var result = _unitOfWork.DraftAdmissionService.GetById(admissionFormDto.ArformId);
                if (result.Result != null)
                {
                    var item = await _unitOfWork.DraftAdmissionService.Remove(result.Result);

                    var documents = result.Result.ArAdmissionDocuments;
                    foreach (var document in documents)
                    {
                        _unitOfWork.DraftAdmissionDocumentService.createDirectory(document.DocumentPath);
                    }

                    await _unitOfWork.CompleteAsync();
                    removeNullEntries = true;
                    return Ok(item);
                }
                else
                {
                    _logger.Information($"DraftAdmission Form is not availablein Database");
                    return StatusCode(StatusCodes.Status404NotFound, "DraftAdmission Form is not available in Database");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                if (removeNullEntries)
                {
                    #region Remove Null Entries
                    _unitOfWork.RemoveNullableEntitiesFromDb();
                    await _unitOfWork.CompleteAsync();
                    #endregion
                }
                _logger.Information($"DraftDelete API completed Successfully");
            }
        }
    }
}
