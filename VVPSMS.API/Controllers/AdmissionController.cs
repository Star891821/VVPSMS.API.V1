using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.Helpers;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Api.Models.Wrappers;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Repository.Services;
using VVPSMS.API.Logger;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AdmissionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        //private ILog _logger;
        private readonly IUriService uriService;
        private readonly ILogger<AdmissionController> _logger;
        public AdmissionController(IAdmissionUnitOfWork unitOfWork, IUriService uriService, IConfiguration configuration, IMapper mapper, ILogger<AdmissionController> logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
            this.uriService = uriService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BackupGetAllAdmissionDetails()
        {
            try
            {
                _logger.LogInformation($"GetAllAdmissionDetails API Started");
                var result = await _unitOfWork.AdmissionService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAllAdmissionDetails API completed Successfully");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdmissionStatusTypes()
        {
            try
            {
                _logger.LogInformation($"GetAdmissionStatusTypes API Started");
                var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                return Ok(enumDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdmissionStatusTypes for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAdmissionStatusTypes API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsByUserId(int id)
        {
            try
            {
                _logger.LogInformation($"GetAdmissionDetailsByUserId API Started");
                var item = await _unitOfWork.AdmissionService.GetAdmissionDetailsByUserId(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdmissionDetailsByUserId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAdmissionDetailsByUserId API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsByUserIdAndFormId(int id, int userid)
        {
            try
            {
                _logger.LogInformation($"GetAdmissionDetailsByUserIdAndFormId API Started");
                var item = await _unitOfWork.AdmissionService.GetAdmissionDetailsByUserIdAndFormId(id, userid);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdmissionDetailsByUserIdAndFormId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAdmissionDetailsByUserIdAndFormId API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsById(int id)
        {
            try
            {
                _logger.LogInformation($"GetAdmissionDetailsById API Started");
                var item = await _unitOfWork.AdmissionService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdmissionDetailsById for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAdmissionDetailsById API completed Successfully");
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAdmissionDetails([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter
                .StatusCode, filter.Name);
            var pagedData = await _unitOfWork.AdmissionService.GetAll(validFilter.PageNumber, validFilter.PageSize, filter
                .StatusCode, filter.Name);
            //var totalRecords =  pagedData.Count();
            // return Ok(new PagedResponse<List<AdmissionForm>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData.Item1, validFilter, pagedData.Item2, uriService, route);
            return Ok(pagedReponse);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByAdmissionId(int id)
        {
            try
            {
                _logger.LogInformation($"GetAllDocumentsByAdmissionId API Started");
                var item = await _unitOfWork.AdmissionDocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDocumentsByAdmissionId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.LogInformation($"GetAllDocumentsByAdmissionId API completed Successfully");
            }

        }

        [HttpGet("{formId}")]
        [Authorize]
        public async Task<IActionResult> GetTrackAdmissionStatusDetails(int formId)
        {
            try
            {
                _logger.LogInformation($"GetTrackAdmissionStatusDetails API Started");
                var item = _unitOfWork.TrackAdmissionStatusService.GetAll(formId);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTrackAdmissionStatusDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500, ex.Message);
            }
            finally
            {
                _logger.LogInformation($"GetTrackAdmissionStatusDetails API completed Successfully");
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdate(AdmissionFormDto admissionFormDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            bool isValidAdmissionStatus = false;
            try
            {
                if (admissionFormDto != null)
                {
                    
                    var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                    if (!int.TryParse(admissionFormDto.AdmissionStatus.ToString(), out int value1))
                    {
                       foreach (var enumDTO in enumDTOs)
                        {
                            if(admissionFormDto.AdmissionStatus.ToString() == enumDTO.Name)
                            {
                                admissionFormDto.AdmissionStatus = enumDTO.Key;
                                isValidAdmissionStatus = true;
                                break;
                            }
                        }
                          
                    }
                    else
                    {
                        int.TryParse(admissionFormDto.AdmissionStatus.ToString(), out int value2);
                        isValidAdmissionStatus = enumDTOs.Where(a => a.Key == value2).Count() > 0;
                    }
                    if(isValidAdmissionStatus)
                    {
                        _logger.LogInformation($"InsertOrUpdate API Started");
                        int admissionStatus = (int)admissionFormDto.AdmissionStatus;
                        admissionFormDto.AdmissionStatus = null;
                        var result = _mapper.Map<AdmissionForm>(admissionFormDto);
                        result.AdmissionDocuments.Clear();
                        result.AdmissionStatus = admissionStatus;
                        #region Admission Form transaction
                        await _unitOfWork.AdmissionService.InsertOrUpdate(result);
                        await _unitOfWork.CompleteAsync();
                        removeNullEntries = true;
                        #endregion

                        #region Track Admission Status
                        TrackAdmissionStatus trackAdmissionStatus = new()
                        {
                            FormId = result.FormId,
                            AdmissionStatus = result.AdmissionStatus,
                            CreatedAt = DateTime.Now,
                            CreatedBy = result.CreatedBy
                        };
                        await _unitOfWork.TrackAdmissionStatusService.Insert(trackAdmissionStatus);
                        await _unitOfWork.CompleteAsync();
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
                            _unitOfWork.AdmissionDocumentService.RemoveRangeofDocuments(result.FormId);
                            await _unitOfWork.CompleteAsync();
                            if (admissionFormDto.listOfAdmissionDocuments != null && result.FormId != 0)
                            {
                                filePath += "\\" + result.FormId;
                                _unitOfWork.AdmissionDocumentService.createDirectory(filePath);

                                for (var i = 0; i < admissionFormDto.listOfAdmissionDocuments.Count; i++)
                                {
                                    try
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

                                        var resultDocuments = _mapper.Map<List<AdmissionDocument>>(result.AdmissionDocuments);
                                        if (resultDocuments.Count > 0)
                                        {
                                            await _unitOfWork.AdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                            _unitOfWork.Complete();
                                        }
                                        value = result.FormId;
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
                                _logger.LogInformation($"listOfAdmissionDocuments or FormID is Null");
                            }
                            #endregion

                        }
                        #endregion

                        value = result.FormId;
                    }
                    else
                    {
                        statusCode = StatusCodes.Status404NotFound;
                        value = "Invalid Admission Status Code";
                    }
                   
                }
                else
                {
                    _logger.LogInformation($"Admission Form is null");
                    statusCode = StatusCodes.Status400BadRequest;
                    value = "Admission Form is null";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertOrUpdate for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
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
                _logger.LogInformation($"InsertOrUpdate API completed Successfully");

            }
            return StatusCode(statusCode, value);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(AdmissionFormDto admissionFormDto)
        {
            bool removeNullEntries = false;
            try
            {
                _logger.LogInformation($"Delete API Started");
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
                    removeNullEntries = true;
                    return Ok(item);
                }
                else
                {
                    _logger.LogInformation($"Admission Form is not availablein Database");
                    return StatusCode(StatusCodes.Status404NotFound, "Admission Form is not available in Database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
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
                _logger.LogInformation($"Delete API completed Successfully");
            }
        }
    }
}
