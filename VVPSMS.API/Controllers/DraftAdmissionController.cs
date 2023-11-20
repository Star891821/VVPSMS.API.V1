using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using System.Text;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

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
        private readonly ILoggerService _loggerService;

        public DraftAdmissionController(IDraftAdmissionUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, ILog logger, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllDraftAdmissionDetails()
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAllDraftAdmissionDetails API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDraftAdmissionDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = await _unitOfWork.DraftAdmissionService.GetAll();
                var itemsDto = GetArAdmissionForm(result);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AllDraftAdmissionDetails data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
                _logger.Error($"Something went wrong inside GetAllDraftAdmissionDetails for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDraftAdmissionDetails for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" }); return StatusCode(500);
                
            }
            finally
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDraftAdmissionDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                _logger.Information($"GetAllDraftAdmissionDetails API completed Successfully");
            }
            return StatusCode(statusCode, value);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsById(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                var item = await _unitOfWork.DraftAdmissionService.GetById(id);
                var itemsDto = GetArAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DraftAdmissionDetailsById data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsById for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetDraftAdmissionDetailsById for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetDraftAdmissionDetailsById API completed Successfully");

                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
            }
            return StatusCode(statusCode, value);
        }
        private List<ArAdmissionDocumentDto>? GetArAdmissionDocumentDto(List<ArAdmissionDocument> items)
        {
            if (items != null)
            {
                List<ArAdmissionDocumentDto> itemsDto = new List<ArAdmissionDocumentDto>();
                foreach (var item1 in items)
                {
                    ArAdmissionDocumentDto a = new ArAdmissionDocumentDto()
                    {
                        ArdocumentId = item1.ArdocumentId,
                        ArformId = item1.ArformId,
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
        private ArAdmissionFormDto? GetArAdmissionForm(ArAdmissionForm item)
        {
            if (item != null)
            {
                ArAdmissionFormDto itemsDto = _mapper.Map<ArAdmissionFormDto>(item);
                itemsDto.ArAdmissionDocuments = new List<ArAdmissionDocumentDto>();
                var datalist = GetArAdmissionDocumentDto((List<ArAdmissionDocument>)item.ArAdmissionDocuments);
                if (datalist != null)
                {
                    itemsDto.ArAdmissionDocuments = datalist;
                    return itemsDto;
                }
            }
            return null;
        }
        private List<ArAdmissionFormDto>? GetArAdmissionForm(List<ArAdmissionForm> items)
        {
            if (items != null)
            {
                List<ArAdmissionFormDto> itemsDto = new List<ArAdmissionFormDto>();
                foreach (var item in items)
                {
                    itemsDto.Add(GetArAdmissionForm(item));
                }
                return itemsDto;
            }
            return null;
        }      
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsByUserId(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsByUserId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = await _unitOfWork.DraftAdmissionService.GetDraftAdmissionDetailsByUserId(id);
                var itemsDto = GetArAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DraftAdmissionDetailsByUserId data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsByUserId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetDraftAdmissionDetailsByUserId for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsByUserId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDraftAdmissionDetailsByUserIdAndDraftFormId(int id, int userid)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetDraftAdmissionDetailsByUserIdAndDraftFormId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsByUserIdAndDraftFormId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                var item = await _unitOfWork.DraftAdmissionService.GetDraftAdmissionDetailsByUserIdAndDraftformId(id, userid);
                var itemsDto = GetArAdmissionForm(item);
                if (itemsDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DraftAdmissionDetailsByUserIdAndDraftFormId data is not found";
                }
                else
                {
                    value = itemsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetDraftAdmissionDetailsByUserIdAndDraftFormId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetDraftAdmissionDetailsByUserIdAndDraftFormId for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetDraftAdmissionDetailsByUserIdAndDraftFormId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                _logger.Information($"GetDraftAdmissionDetailsByUserIdAndDraftFormId API completed Successfully");
            }
            return StatusCode(statusCode, value);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByDraftAdmissionId(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAllDocumentsByDraftAdmissionId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByDraftAdmissionId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });

                var item = await _unitOfWork.DraftAdmissionDocumentService.GetAll(id);
                var itemDto = GetArAdmissionDocumentDto(item);
                if (itemDto == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AllDocumentsByDraftAdmissionId data is not found";
                }
                else
                {
                    value = itemDto;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByDraftAdmissionId for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDocumentsByDraftAdmissionId for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByDraftAdmissionId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByDraftAdmissionId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
            }
            return StatusCode(statusCode, value);
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
                    if(aradmissionFormDto.AdmissionStatus != null)
                    {
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
                            aradmissionFormDto.AdmissionStatus = value2;
                            isValidAdmissionStatus = enumDTOs.Where(a => a.Key == value2).Count() > 0;
                        }
                    }
                    if (!isValidAdmissionStatus)
                    {
                        aradmissionFormDto.AdmissionStatus = null;
                    }
                    _logger.Information($"InsertOrUpdate API Started");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
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
                        if (aradmissionFormDto.ArAdmissionDocuments != null && result.ArformId != 0)
                        {
                            filePath += "\\Archival\\" + result.ArformId;
                            _unitOfWork.DraftAdmissionDocumentService.createDirectory(filePath);

                            for (var i = 0; i < aradmissionFormDto.ArAdmissionDocuments.Count; i++)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(aradmissionFormDto.ArAdmissionDocuments[i].FileContentsAsBase64))
                                    {
                                        var Base64FileContent = aradmissionFormDto.ArAdmissionDocuments[i].FileContentsAsBase64;
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
                                            var fileDetails = aradmissionFormDto.ArAdmissionDocuments[i].DocumentName;
                                            var temp = fileDetails.Split('.');
                                            string fileName = string.Empty;
                                            if (temp.Length > 1)
                                            {
                                                fileName = temp[0] + "_" + DateTime.Now.ToString("HH_mm_dd-MM-yyyy") + "." + temp[1];
                                                System.IO.File.WriteAllBytes(filePath + "\\" + fileName, bytes);

                                            }

                                            ArAdmissionDocument aradmissionDocument = new()
                                            {
                                                DocumentName = fileName,
                                                DocumentPath = filePath,
                                                ArformId = result.ArformId,
                                                MstdocumenttypesId = aradmissionFormDto.ArAdmissionDocuments[i].MstdocumenttypesId,
                                                CreatedAt = DateTime.Now,
                                                ModifiedAt = DateTime.Now,
                                            };
                                            result.ArAdmissionDocuments.Add(aradmissionDocument);
                                            

                                        }
                                        else
                                        {
                                            _logger.Information($"ArAdmissionDocuments File Didn't save since FileContents is not of type Base64 ");
                                            _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "listOfArAdmissionDocuments or ArformID is Null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });


                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    statusCode = StatusCodes.Status404NotFound;
                                    value = new { DraftAdmissionID = "", Message = ex.Message };
                                }
                            }
                            if (result.ArAdmissionDocuments != null && result.ArAdmissionDocuments.Count > 0)
                            {
                                var resultDocuments = _mapper.Map<List<ArAdmissionDocument>>(result.ArAdmissionDocuments);
                                if (resultDocuments.Count > 0)
                                {
                                    await _unitOfWork.DraftAdmissionDocumentService.InsertOrUpdateRange(resultDocuments);
                                    _unitOfWork.Complete();
                                }
                            }
                          
                        }
                        else
                        {
                            _logger.Information($"listOfArAdmissionDocuments or ArformID is Null");
                            _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "listOfArAdmissionDocuments or ArformID is Null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                        }
                        #endregion

                    }
                    #endregion
                    value = new { DraftAdmissionID = result.ArformId, Message = "Success" };
                }
                else
                {
                    _logger.Information($"DraftAdmission Form is null");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DraftAdmission Form is null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status400BadRequest;
                    value = new { DraftAdmissionID = "", Message = "DraftAdmission Form is null" };
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdate for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = new { DraftAdmissionID = "", Message = ex.Message };
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
        public async Task<IActionResult> Delete(ArAdmissionFormDto admissionFormDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            try
            {
                _logger.Information($"Delete API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
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
                    value=item;
                }
                else
                {
                    _logger.Information($"DraftAdmission Form is not available in Database");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DraftAdmission Form is not available in Database", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DraftAdmission Form is not available in Database";
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at Delete for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
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
                _logger.Information($"DraftDelete API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DraftDelete API completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

            }
            return StatusCode(statusCode, value);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteByArFormId(int arformId)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            bool removeNullEntries = false;
            try
            {
                _logger.Information($"DeleteByArFormId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = _unitOfWork.DraftAdmissionService.GetById(arformId);
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
                    value = item;
                }
                else
                {
                    _logger.Information($"DeleteByArFormId is not available in Database");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DraftAdmission Form is not available in Database", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DeleteByArFormId is not available in Database";
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(DraftAdmissionController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at DeleteByArFormId for" + typeof(DraftAdmissionController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = ""  });
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
                _logger.Information($"DeleteByArFormId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DraftDelete API completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

            }
            return StatusCode(statusCode, value);
        }

    }
}
