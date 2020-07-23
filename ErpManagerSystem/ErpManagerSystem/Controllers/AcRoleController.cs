using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;
using Model.Params;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AcRoleController:ControllerBase
    {
        private readonly IAcRoleServices _acRoleServices;
        private readonly IMapper _mapper;

        public AcRoleController(IAcRoleServices acRoleServices, IMapper mapper)
        {
            _acRoleServices = acRoleServices;
            _mapper = mapper;
        }
        //查询所有角色数据
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcRoleDto>>> GetRole()
        {
            var res = new MessageModel<IEnumerable<AcRoleDto>>();
            var list = await _acRoleServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcRoleDto>>(list);
            return Ok(res);
        }
        //根据ID查询角色
        [HttpGet("{id}", Name = nameof(GetRoleById))]
        public async Task<ActionResult<IEnumerable<AcRoleDto>>> GetRoleById(int id)
        {
            MessageModel<AcRoleDto> res = new MessageModel<AcRoleDto>();
            if (!await _acRoleServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcRole entity = await _acRoleServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcRoleDto>(entity);
            return Ok(res);
        }
        //[HttpGet(Name = nameof(GetUserInfoPaged))]
        //public async Task<ActionResult<ActionResult<IEnumerable<AcRoleDto>>>> GetUserInfoPaged(
        //    [FromQuery] AcUserInfoParams acUserInfoParams)
        //{
        //    var res = new MessageModel<IEnumerable<AcRoleDto>>();
        //    PagedList<AcUserInfo> list = await _acRoleServices.GetUserInfoPaged(acUserInfoParams);
        //    string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, acUserInfoParams) : null;
        //    string nextLink = list.HasNext ? CreateLink(PagedType.Next, acUserInfoParams) : null;
        //    var pagination = new
        //    {
        //        currentPage = list.PageNum,
        //        totalPage = list.TotalPage,
        //        totalCount = list.TotalCount,
        //        previousLink,
        //        nextLink
        //    };
        //    HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
        //    res.Data = _mapper.Map<IEnumerable<AcRoleDto>>(list);
        //    return Ok(res);
        //}

        //添加角色数据
        [HttpPost]
        public async Task<ActionResult<MessageModel<AcRoleDto>>> AddUserInfo(AcRoleAddDto roleAddDto)
        {
            var res = new MessageModel<AcRoleDto>();
            AcRole entity = _mapper.Map<AcRole>(roleAddDto);
            await _acRoleServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcRoleDto>(entity);
            return CreatedAtRoute(nameof(GetRoleById), new { id = entity.Id }, res.Data);
        }

        //删除角色数据
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteRole(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acRoleServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acRoleServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        //修改角色数据
        [HttpPut]
        public async Task<ActionResult<MessageModel<AcRoleDto>>> EditUserInfo(AcRoleEditDto roleEditDto)
        {
            MessageModel<AcRoleDto> res = new MessageModel<AcRoleDto>();
            if (!await _acRoleServices.ExistEntityAsync(a => a.Id == roleEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcRole entity = _mapper.Map<AcRole>(roleEditDto);
            await _acRoleServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcRoleDto>(entity);
            return Ok(res);
        }

        //private string CreateLink(PagedType pagedType, AcUserInfoParams userInfoParams)
        //{
        //    switch (pagedType)
        //    {
        //        case PagedType.Previous:
        //            return Url.Link(nameof(GetUserInfoPaged), new
        //            {
        //                PageNum = userInfoParams.PageNum - 1,
        //                PageSize = userInfoParams.PageSize
        //            });

        //        case PagedType.Next:
        //            return Url.Link(nameof(GetUserInfoPaged), new
        //            {
        //                PageNum = userInfoParams.PageNum + 1,
        //                PageSize = userInfoParams.PageSize
        //            });
        //    }
        //    return string.Empty;
        //}
    }
}
