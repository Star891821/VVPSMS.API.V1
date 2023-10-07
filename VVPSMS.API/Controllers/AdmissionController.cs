using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
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
                _logger.Information($"InsertOrUpdate API Started");
                var isUploadtoAzure = _configuration["Upoad:IsUpoadtoAzure"];
                var filePath = _configuration["Upoad:SaveFilePath"];
                var result = _mapper.Map<AdmissionForm>(admissionFormDto);
                #region Upload File
                if (isUploadtoAzure == "Yes")
                {

                }
                else
                {
                    if (admissionFormDto.listOfAdmissionDocuments != null)
                    {
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

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

                                var fileName = temp[0] + "_" + DateTime.Now.ToString("HH_mm_dd-MM-yyyy");
                                System.IO.File.WriteAllBytes(filePath + "\\" + fileName, bytes);
                                AdmissionDocument admissionDocument = new()
                                {
                                    DocumentName = fileName,
                                    DocumentPath = filePath,
                                    FormId = admissionFormDto.listOfAdmissionDocuments[i].FormId,
                                    MstdocumenttypesId = admissionFormDto.listOfAdmissionDocuments[i].MstdocumenttypesId,
                                    CreatedAt = DateTime.Now,
                                    ModifiedAt = DateTime.Now,
                                };
                                result.AdmissionDocuments.Add(admissionDocument);
                            }

                        }
                    }

                }
                #endregion
                #region Admission transaction
                _unitOfWork.AdmissionDocumentService.RemoveRangeofDocuments(result.FormId);
                await _unitOfWork.AdmissionService.InsertOrUpdate(result);
                await _unitOfWork.CompleteAsync();
                #endregion
                #region Remove Null Entries
                _unitOfWork.RemoveNullableEntitiesFromDb();
                await _unitOfWork.CompleteAsync();
                #endregion

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdate API completed Successfully");
            }
        }
       


        [HttpDelete]
        public async Task<IActionResult> Delete(AdmissionFormDto admissionFormDto)
        {
            try
            {
                _logger.Information($"Delete API Started");
                var result = _mapper.Map<AdmissionForm>(admissionFormDto);
                var item = await _unitOfWork.AdmissionService.Remove(result);
                var documents = _mapper.Map<List<AdmissionDocument>>(admissionFormDto.listOfAdmissionDocuments);
                await _unitOfWork.AdmissionDocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(AdmissionController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"Delete API completed Successfully");
            }
        }
    }
}
