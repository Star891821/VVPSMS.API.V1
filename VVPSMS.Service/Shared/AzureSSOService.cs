using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.SSO.Models;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.Service.Shared
{
    public class AzureSSOService : IAzureSSOService<AzureBlobConfigurationDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public AzureSSOService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public AzureBlobConfigurationDto? GetByDomain(string domainName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.AzureBlobConfigurations?.FirstOrDefault(e => e.DomainName.Equals(domainName));
                return _mapper.Map<AzureBlobConfigurationDto>(result);
            }
        }
    }
}
