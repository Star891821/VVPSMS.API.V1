﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SchoolGradeController : GenericController<MstSchoolGradeDto>
    {
        public SchoolGradeController(IGenericService<MstSchoolGradeDto> genericService)
            : base(genericService)
        {

        }
    }
}
