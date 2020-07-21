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
    [Authorize]
    public class AcUserInfoInfoController : ControllerBase
    {
        private readonly IAcUserInfoServices _acUserInfoServices;
        private readonly IMapper _mapper;

        public AcUserInfoInfoController(IAcUserInfoServices acUserInfoServices, IMapper mapper)
        {
            _acUserInfoServices = acUserInfoServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcUserInfoDto>>> GetUserInfo()
        {
            var res = new MessageModel<IEnumerable<AcUserInfoDto>>();
            var list = await _acUserInfoServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcUserInfoDto>>(list);
            return Ok(res);
        }
        [HttpGet("{id}", Name = nameof(GetUserInfoById))]
        public async Task<ActionResult<IEnumerable<AcUserInfoDto>>> GetUserInfoById(int id)
        {
            MessageModel<AcUserInfoDto> res = new MessageModel<AcUserInfoDto>();
            if (!await _acUserInfoServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcUserInfo entity = await _acUserInfoServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcUserInfoDto>(entity);
            return Ok(res);
        }
        [HttpGet(Name = nameof(GetUserInfoPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<AcUserInfoDto>>>> GetUserInfoPaged(
            [FromQuery] AcUserInfoParams acUserInfoParams)
        {
            var res = new MessageModel<IEnumerable<AcUserInfoDto>>();
            PagedList<AcUserInfo> list = await _acUserInfoServices.GetUserInfoPaged(acUserInfoParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, acUserInfoParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, acUserInfoParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<AcUserInfoDto>>(list);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<AcUserInfoDto>>> AddUserInfo(AcUserInfoAddDto userInfoAddDto)
        {
            var res = new MessageModel<AcUserInfoDto>();
            var entity = _mapper.Map<AcUserInfo>(userInfoAddDto);
            await _acUserInfoServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcUserInfoDto>(entity);
            return CreatedAtRoute(nameof(GetUserInfoById), new { id = entity.Id }, res.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteUserInfo(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acUserInfoServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acUserInfoServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<AcUserInfoDto>>> EditUserInfo(AcUserInfoEditDto userInfoEditDto)
        {
            MessageModel<AcUserInfoDto> res = new MessageModel<AcUserInfoDto>();
            if (!await _acUserInfoServices.ExistEntityAsync(a => a.Id == userInfoEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcUserInfo entity = _mapper.Map<AcUserInfo>(userInfoEditDto);
            await _acUserInfoServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcUserInfoDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, AcUserInfoParams userInfoParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetUserInfoPaged), new
                    {
                        PageNum = userInfoParams.PageNum - 1,
                        PageSize = userInfoParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetUserInfoPaged), new
                    {
                        PageNum = userInfoParams.PageNum + 1,
                        PageSize = userInfoParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}