using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using ErpManagerSystem.Profiles;
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
    public class AcPermissionController: ControllerBase
    {
        private readonly IAcPermissionServices _acPermissionServices;
        private readonly IMapper _mapper;

        public AcPermissionController(IAcPermissionServices acPermissionServices, IMapper mapper)
        {
            _acPermissionServices = acPermissionServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcPermissionDto>>> GetAcPermission()
        {
            var res = new MessageModel<IEnumerable<AcPermissionDto>>();
            var list = await _acPermissionServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcPermissionDto>>(list);
            return Ok(res);
        }
        [HttpGet("{id}", Name = nameof(GetAcPermissionById))]
        public async Task<ActionResult<IEnumerable<AcPermissionDto>>> GetAcPermissionById(int id)
        {
            MessageModel<AcPermissionDto> res = new MessageModel<AcPermissionDto>();
            if (!await _acPermissionServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcPermission entity = await _acPermissionServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcPermissionDto>(entity);
            return Ok(res);
        }
        [HttpGet(Name = nameof(GetAcPermissionPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<AcPermissionDto>>>> GetAcPermissionPaged(
            [FromQuery] AcPermissionParams acPermissionParams)
        {
            var res = new MessageModel<IEnumerable<AcPermissionDto>>();
            PagedList<AcPermission> list = await _acPermissionServices.GetAcPermissionPaged(acPermissionParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, acPermissionParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, acPermissionParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<AcPermissionDto>>(list);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<AcPermissionDto>>> AddAcPermission(AcPermissionAddDto acPermissionAddDto)
        {
            var res = new MessageModel<AcPermissionDto>();
            var entity = _mapper.Map<AcPermission>(acPermissionAddDto);
            await _acPermissionServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcPermissionDto>(entity);
            return CreatedAtRoute(nameof(GetAcPermissionById), new { id = entity.Id }, res.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteAcPermission(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acPermissionServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acPermissionServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<AcPermissionDto>>> EditAcPermission(AcPermissionEditDto acPermissionEditDto)
        {
            MessageModel<AcPermissionDto> res = new MessageModel<AcPermissionDto>();
            if (!await _acPermissionServices.ExistEntityAsync(a => a.Id == acPermissionEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcPermission entity = _mapper.Map<AcPermission>(acPermissionEditDto);
            await _acPermissionServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcPermissionDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, AcPermissionParams acPermissionParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetAcPermissionPaged), new
                    {
                        PageNum = acPermissionParams.PageNum - 1,
                        PageSize = acPermissionParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetAcPermissionPaged), new
                    {
                        PageNum = acPermissionParams.PageNum + 1,
                        PageSize = acPermissionParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
