using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.Helpers;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;

using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Repository.Services;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

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
        private readonly IUriService uriService;
        private readonly ILoggerService _loggerService;
        private readonly IValidator<AdmissionFormDto> _admissionValidator;
        public AdmissionController(IAdmissionUnitOfWork unitOfWork, IValidator<AdmissionFormDto> validator, IUriService uriService, IConfiguration configuration, IMapper mapper, ILog logger, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
            this.uriService = uriService;
            _loggerService = loggerService;
            _admissionValidator = validator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BackupGetAllAdmissionDetails()
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "BackupGetAllAdmissionDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"BackupGetAllAdmissionDetails API Started");
                var result = await _unitOfWork.AdmissionService.GetAll();
                var resultDto = GetAdmissionForm(result);
                value = resultDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error at BackupGetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at BackupGetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"BackupGetAllAdmissionDetails API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "BackupGetAllAdmissionDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

            }
            return StatusCode(statusCode, value);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdmissionStatusTypes()
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionStatusTypes API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetAdmissionStatusTypes API Started");
                var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                value = enumDTOs;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionStatusTypes for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAdmissionStatusTypes for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAdmissionStatusTypes API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionStatusTypes API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsByUserId(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsByUserId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                _logger.Information($"GetAdmissionDetailsByUserId API Started");
                var item = await _unitOfWork.AdmissionService.GetAdmissionDetailsByUserId(id);
                var itemsDto = GetAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AdmissionDetailsByUserId is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionDetailsByUserId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAdmissionDetailsByUserId for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAdmissionDetailsByUserId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsByUserId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsByUserIdAndFormId(int id, int userid)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsByUserIdAndFormId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetAdmissionDetailsByUserIdAndFormId API Started");
                var item = await _unitOfWork.AdmissionService.GetAdmissionDetailsByUserIdAndFormId(id, userid);
                var itemsDto = GetAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AdmissionDetailsByUserIdAndFormId data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionDetailsByUserIdAndFormId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAdmissionDetailsByUserIdAndFormId for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAdmissionDetailsByUserIdAndFormId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsByUserIdAndFormId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdmissionDetailsById(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                _logger.Information($"GetAdmissionDetailsById API Started");
                var item = await _unitOfWork.AdmissionService.GetById(id);
                var itemsDto = GetAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AdmissionDetailsById data is not found";
                }
                else
                {
                    value = itemsDto;
                }

            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAdmissionDetailsById for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAdmissionDetailsById for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAdmissionDetailsById API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAdmissionDetailsById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAdmissionDetails([FromQuery] PaginationFilter filter)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllAdmissionDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter
                    .StatusCode, filter.Name);
                var pagedData = await _unitOfWork.AdmissionService.GetAll(validFilter.PageNumber, validFilter.PageSize, filter
                    .StatusCode, filter.Name);
                var itemsDto = GetAdmissionForm(pagedData.Item1);

                var pagedReponse = PaginationHelper.CreatePagedReponse(itemsDto, validFilter, pagedData.Item2, uriService, route);
                value = pagedReponse;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllAdmissionDetails for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAllAdmissionDetails API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllAdmissionDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByAdmissionId(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByAdmissionId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetAllDocumentsByAdmissionId API Started");
                var item = await _unitOfWork.AdmissionDocumentService.GetAll(id);
                var itemsDto = GetAdmissionDocumentDto(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AllDocumentsByAdmissionId data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByAdmissionId for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDocumentsByAdmissionId for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByAdmissionId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetAllDocumentsByAdmissionId API completed Successfully");
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{formId}")]
        [Authorize]
        public async Task<IActionResult> GetTrackAdmissionStatusDetails(int formId)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetTrackAdmissionStatusDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                _logger.Information($"GetTrackAdmissionStatusDetails API Started");
                var item = _unitOfWork.TrackAdmissionStatusService.GetAll(formId);

                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "Admission Doesn't have tracking details";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetTrackAdmissionStatusDetails for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetTrackAdmissionStatusDetails for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetTrackAdmissionStatusDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetTrackAdmissionStatusDetails API completed Successfully");
            }
            return StatusCode(statusCode, value);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdate(AdmissionFormDto admissionFormDto)
        {

            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            bool isValidAdmissionStatus = false;

            var validationResult = _admissionValidator.Validate(admissionFormDto);
            if (validationResult.IsValid)
            {
                try
                {
                    if (admissionFormDto != null)
                    {

                        var enumDTOs = Enum<AdmissionStatusDto>.GetAllValuesAsIEnumerable().Select(d => new EnumDTO(d));
                        if (!int.TryParse(admissionFormDto.AdmissionStatus.ToString(), out int value1))
                        {
                            foreach (var enumDTO in enumDTOs)
                            {
                                if (admissionFormDto.AdmissionStatus.ToString() == enumDTO.Name)
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
                            admissionFormDto.AdmissionStatus = value2;
                            isValidAdmissionStatus = enumDTOs.Where(a => a.Key == value2).Count() > 0;
                        }
                        if (isValidAdmissionStatus)
                        {
                            _unitOfWork.BeginTransaction();
                            _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                            _logger.Information($"InsertOrUpdate API Started");
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
                                if (admissionFormDto.AdmissionDocuments != null && result.FormId != 0)
                                {
                                    filePath += "\\" + result.FormId;
                                    _unitOfWork.AdmissionDocumentService.createDirectory(filePath);
                                    int noOfDocumentsSaved = 0;
                                    for (var i = 0; i < admissionFormDto.AdmissionDocuments.Count; i++)
                                    {
                                        try
                                        {
                                            if (!string.IsNullOrEmpty(admissionFormDto.AdmissionDocuments[i].FileContentsAsBase64))
                                            {
                                                var Base64FileContent = admissionFormDto.AdmissionDocuments[i].FileContentsAsBase64;
                                                string base64stringwithoutsignature = string.Empty;
                                                if (Base64FileContent.IndexOf(',') != -1)
                                                {
                                                    var index = Base64FileContent.IndexOf(',');
                                                    base64stringwithoutsignature = Base64FileContent.Substring(index + 1);
                                                }
                                                else
                                                {
                                                    base64stringwithoutsignature = Base64FileContent;
                                                }
                                                if (IsBase64(base64stringwithoutsignature))
                                                {
                                                    byte[] bytes = Convert.FromBase64String(base64stringwithoutsignature);
                                                    var fileDetails = admissionFormDto.AdmissionDocuments[i].DocumentName;
                                                    var temp = fileDetails.Split('.');
                                                    string fileName = string.Empty;
                                                    if (temp.Length > 1)
                                                    {
                                                        fileName = temp[0] + "_" + DateTime.Now.ToString("HH_mm_dd-MM-yyyy") + "." + temp[1];
                                                        System.IO.File.WriteAllBytes(filePath + "\\" + fileName, bytes);
                                                        AdmissionDocument admissionDocument = new()
                                                        {
                                                            DocumentName = fileName,
                                                            DocumentPath = filePath,
                                                            FormId = result.FormId,
                                                            MstdocumenttypesId = admissionFormDto.AdmissionDocuments[i].MstdocumenttypesId,
                                                            CreatedAt = admissionFormDto.AdmissionDocuments[i].CreatedAt,
                                                            CreatedBy = admissionFormDto.AdmissionDocuments[i].CreatedBy,
                                                            ModifiedAt = admissionFormDto.AdmissionDocuments[i].ModifiedAt,
                                                            ModifiedBy = admissionFormDto.AdmissionDocuments[i].ModifiedBy
                                                        };
                                                        result.AdmissionDocuments.Add(admissionDocument);
                                                        noOfDocumentsSaved++;
                                                    }

                                                }
                                                else
                                                {
                                                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Admission Is not Saved since in Document  File Content is not Base64 Type", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                                                    _logger.Information($"Admission Is not Saved since in Document  File Content is not Base64 Type");

                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            statusCode = StatusCodes.Status404NotFound;
                                            value = new { AdmissionID = "", Message = ex.Message };
                                        }
                                    }
                                    if (result.AdmissionDocuments != null && result.AdmissionDocuments.Count > 0)
                                    {
                                        var resultDocuments = _mapper.Map<List<AdmissionDocument>>(result.AdmissionDocuments);
                                        if (resultDocuments.Count > 0)
                                        {
                                            await _unitOfWork.AdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                            _unitOfWork.Complete();

                                        }
                                    }
                                    if (noOfDocumentsSaved == admissionFormDto.AdmissionDocuments.Count)
                                    {
                                        _unitOfWork.CommitTransaction();
                                        value = new { AdmissionID = result.FormId, Message = "Success" };
                                        statusCode = StatusCodes.Status200OK;
                                    }
                                    else
                                    {
                                        _unitOfWork.RollBack();
                                        value = new { AdmissionID = "", Message = "Transaction Failed Since Documents Didnot Saved" };
                                        statusCode = StatusCodes.Status422UnprocessableEntity;
                                    }
                                }
                                else
                                {
                                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "listOfAdmissionDocuments or FormID is Null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                                    _logger.Information($"listOfAdmissionDocuments or FormID is Null");
                                }
                                #endregion
                            }
                            #endregion

                        }
                        else
                        {
                            statusCode = StatusCodes.Status404NotFound;
                            value = new { AdmissionID = "", Message = "Failure due to invalid status code" };
                            _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Invalid Admission Status Code", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                            _logger.Information($"Invalid Admission Status Code");
                        }

                    }
                    else
                    {
                        _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Admission Form is null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                        _logger.Information($"Admission Form is null");
                        statusCode = StatusCodes.Status400BadRequest;
                        value = new { AdmissionID = "", Message = "Admission form is null" };
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                    _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdate for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status500InternalServerError;
                    _unitOfWork.RollBack();
                    value = new { AdmissionID = "", Message = ex.Message };
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
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                }

            }
            else
            {
                var errors = validationResult.Errors.Select(e => new Error(e.ErrorCode, e.ErrorMessage));
                statusCode = StatusCodes.Status400BadRequest; value = errors;
                foreach (var error in errors)
                {
                    _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Error.ToString(), Message = error.Description, Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                }
            }
            return StatusCode(statusCode, value);
        }
        public static bool IsBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception exception)
            {
                // Handle the exception
            }
            return false;
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(AdmissionFormDto admissionFormDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
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
                    removeNullEntries = true;
                    value = item;
                }
                else
                {
                    _logger.Information($"Admission Form is not availablein Database");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Admission Form is not availablein Database", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status404NotFound;
                    value = "Admission Form is not available in Database";
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);

                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at Delete for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
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
                _logger.Information($"Delete API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteByFormId(int formID)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            try
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"DeleteByFormId API Started");
                var result = _unitOfWork.AdmissionService.GetById(formID);
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
                    value = item;
                }
                else
                {
                    _logger.Information($"Admission Form is not availablein Database");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Admission Form is not availablein Database", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status404NotFound;
                    value = "Admission Form is not available in Database";
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);

                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at DeleteByFormId for" + typeof(AdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
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
                _logger.Information($"DeleteByFormId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        private List<AdmissionDocumentDto>? GetAdmissionDocumentDto(List<AdmissionDocument> items)
        {
            if (items != null)
            {
                List<AdmissionDocumentDto> itemsDto = new List<AdmissionDocumentDto>();
                foreach (var item1 in items)
                {
                    AdmissionDocumentDto a = new AdmissionDocumentDto()
                    {
                        DocumentId = item1.DocumentId,
                        FormId = item1.FormId,
                        DocumentName = item1.DocumentName,
                        DocumentPath = item1.DocumentPath,
                        CreatedAt = item1.CreatedAt,
                        CreatedBy = item1.CreatedBy,
                        ModifiedAt = item1.ModifiedAt,
                        ModifiedBy = item1.ModifiedBy,
                    };

                    itemsDto.Add(a);
                }
                foreach (var document in itemsDto.ToList())
                {
                    if (Directory.Exists(document.DocumentPath))
                    {
                        foreach (FileInfo fileInfo in new DirectoryInfo(document.DocumentPath).GetFiles())
                        {
                            using FileStream fs = new FileStream(fileInfo.FullName.ToString(), FileMode.Open, FileAccess.Read);
                            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                            var lines = sr.ReadToEnd();
                           
                           // string content = new StreamReader(fileInfo.FullName.ToString(), Encoding.UTF8).ReadToEnd();
                            byte[] bytes = Encoding.UTF8.GetBytes(lines);
                            document.FileContentsAsBase64 = Convert.ToBase64String(bytes);
                            sr.Close();
                            fs.Close();
                        }
                    }
                }
                return itemsDto;
            }
            return null;
        }
        private AdmissionFormDto? GetAdmissionForm(AdmissionForm item)
        {
            if (item != null)
            {
                AdmissionFormDto itemsDto = _mapper.Map<AdmissionFormDto>(item);
                itemsDto.AdmissionDocuments = new List<AdmissionDocumentDto>();
                var datalist = GetAdmissionDocumentDto((List<AdmissionDocument>)item.AdmissionDocuments);
                if (datalist != null)
                {
                    itemsDto.AdmissionDocuments = datalist;
                    return itemsDto;
                }
            }
            return null;
        }
        private List<AdmissionFormDto>? GetAdmissionForm(List<AdmissionForm> items)
        {
            if (items != null)
            {
                List<AdmissionFormDto> itemsDto = new List<AdmissionFormDto>();
                foreach (var item in items)
                {
                    itemsDto.Add(GetAdmissionForm(item));
                }
                return itemsDto;
            }
            return null;
        }

    }
}
