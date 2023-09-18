﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : GenericController<MstUserRoleDto>
    {
        public UserRoleController(IGenericService<MstUserRoleDto> genericService)
            : base(genericService)
        {

        }
    }
}
