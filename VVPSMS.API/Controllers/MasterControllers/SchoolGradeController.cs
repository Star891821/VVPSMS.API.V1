﻿using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolGradeController : GenericController<MstSchoolGradeDto>
    {
        public SchoolGradeController(IGenericService<MstSchoolGradeDto> genericService, ILog logger, ILoggerService loggerService)
            : base(genericService, logger, loggerService)
        {

        }
    }
}
