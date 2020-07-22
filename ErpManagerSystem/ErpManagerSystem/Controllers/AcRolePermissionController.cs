using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;
using Model.Params;
using Newtonsoft.Json;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AcRolePermissionController:Controller
    {
        private readonly IAcRolePermissionServices _acRolePermissionServices;
        private readonly IMapper _mapper;

        public AcRolePermissionController(IAcRolePermissionServices acRolePermissionServices, IMapper mapper)
        {
            _acRolePermissionServices = acRolePermissionServices;
            _mapper = mapper;
        }
        //查询所有角色菜单表数据
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcRolePermissionDto>>> GetRolePermission()
        {
            var res = new MessageModel<IEnumerable<AcRolePermissionDto>>();
            var list = await _acRolePermissionServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcRolePermissionDto>>(list);
            return Ok(res);
        }
        //根据主键ID查询角色菜单表数据
        [HttpGet("{id}", Name = nameof(GetRolePermissionById))]
        public async Task<ActionResult<IEnumerable<AcRolePermissionDto>>> GetRolePermissionById(int id)
        {
            MessageModel<AcRolePermissionDto> res = new MessageModel<AcRolePermissionDto>();
            if (!await _acRolePermissionServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcRolePermission entity = await _acRolePermissionServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcRolePermissionDto>(entity);
            return Ok(res);
        }

        //添加菜单角色表数据
        [HttpPost]
        public async Task<ActionResult<MessageModel<AcRolePermissionDto>>> AddRolePermission(AcRolePermissionAddDto rolePermissionAddDto)
        {
            var res = new MessageModel<AcRolePermissionDto>();
            var entity = _mapper.Map<AcRolePermission>(rolePermissionAddDto);
            await _acRolePermissionServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcRolePermissionDto>(entity);
            return CreatedAtRoute(nameof(GetRolePermissionById), new { id = entity.Id }, res.Data);
        }

        //根据ID删除角色菜单表数据
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteRolePermission(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acRolePermissionServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acRolePermissionServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<AcRolePermissionDto>>> EditRolePermission(AcRolePermissionEditDto RolePermissionEditDto)
        {
            MessageModel<AcRolePermissionDto> res = new MessageModel<AcRolePermissionDto>();
            if (!await _acRolePermissionServices.ExistEntityAsync(a => a.Id == RolePermissionEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcRolePermission entity = _mapper.Map<AcRolePermission>(RolePermissionEditDto);
            await _acRolePermissionServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcRolePermissionDto>(entity);
            return Ok(res);
        }
    }
}
