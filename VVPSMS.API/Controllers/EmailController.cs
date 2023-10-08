using AutoMapper;
using Castle.Core.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.DataManagers.EmailDataManagers;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Repository.Email;
using IEmailSender = VVPSMS.Service.Repository.Email.IEmailSender;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : Controller
    {
        private IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private IMapper _mapper;
        private ILog _logger;
        public EmailController(IEmailSender emailSender, IConfiguration configuration, IMapper mapper, ILog logger)
        {
            _emailSender = emailSender;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(Message message)
        {
            var files = message.Attachments.Any() ? message.Attachments : new FormFileCollection();
            message.Attachments = files;
            await _emailSender.SendEmailAsync(message);
            return Ok();
        }

    }
}
