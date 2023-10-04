﻿using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolController : GenericController<MstSchoolDto>
    {
        public SchoolController(IGenericService<MstSchoolDto> genericService, ILog logger)
            : base(genericService, logger)
        {

        }
    }
}
