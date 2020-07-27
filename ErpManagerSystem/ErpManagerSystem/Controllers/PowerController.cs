using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.Dto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PowerController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAcUserInfoServices _acUserInfoServices;
        private readonly IAcRolePermissionServices _acRolePermissionServices;
        private readonly IAcPermissionServices _acPermissionServices;

        public PowerController(IMapper mapper, IAcUserInfoServices acUserInfoServices, IAcRolePermissionServices acRolePermissionServices,IAcPermissionServices acPermissionServices)
        {
            _mapper = mapper;
            _acUserInfoServices = acUserInfoServices;
            _acRolePermissionServices = acRolePermissionServices;
            _acPermissionServices = acPermissionServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowerAcPermissionDto>>> GetMenus()
        {
            //获取请求token中的用户id
            string uid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var res = new MessageModel<IEnumerable<PowerAcPermissionDto>>();
            var entity = await _acUserInfoServices.GetEntityByIdAsync(int.Parse(uid));
            //获取该用户所有的菜单权限ID
            var AllPermissionIds = await _acRolePermissionServices.GetEntitys(u => u.RoleId == entity.RoleId).Select(u=>u.PermissionId).ToListAsync();
            //获取该用户所有的一级菜单
            var MenuParents = _acPermissionServices.GetEntitys().Where(a => AllPermissionIds.Contains(a.Id) && a.Pid == 0);
            IEnumerable<PowerAcPermissionDto> menuDtoList = _mapper.Map<IEnumerable<PowerAcPermissionDto>>(MenuParents);
            foreach (var item in menuDtoList)
            {
                var MuneChildren = _acPermissionServices.GetEntitys().Where(a => a.Pid == item.Id && AllPermissionIds.Contains(a.Id));
                item.SecondMenus = _mapper.Map<IEnumerable<PowerAcPermissionDto>>(MuneChildren);
            }
            res.Data = menuDtoList;
            return Ok(res);
        }
    }
}
