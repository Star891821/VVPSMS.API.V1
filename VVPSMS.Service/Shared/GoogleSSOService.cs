using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.SSO.Models;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.Service.Shared
{
    public class GoogleSSOService : IGoogleSSOService<GoogleConfigurationDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public GoogleSSOService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public GoogleConfigurationDto? GetByDomain(string domainName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.GoogleConfigurations?.FirstOrDefault(e => e.DomainName.Equals(domainName));
                return _mapper.Map<GoogleConfigurationDto>(result);
            }
        }
    }
}
