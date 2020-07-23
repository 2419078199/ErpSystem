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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    /// <summary>
    /// 员工表接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AcStaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAcStaffServices _acStaffServices;

        public AcStaffController(IMapper mapper, IAcStaffServices acStaffServices)
        {
            _mapper = mapper;
            _acStaffServices = acStaffServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaffDto>>> GetAcStaff()
        {
            var res = new MessageModel<IEnumerable<AcStaffDto>>();
            var list = await _acStaffServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcStaffDto>>(list);
            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetAcStaffById))]
        public async Task<ActionResult<IEnumerable<AcStaffDto>>> GetAcStaffById(int id)
        {
            MessageModel<AcStaffDto> res = new MessageModel<AcStaffDto>();
            if (!await _acStaffServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcStaff entity = await _acStaffServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcStaffDto>(entity);
            return Ok(res);
        }

        [HttpGet(Name = nameof(GetAcStaffPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<AcStaffDto>>>> GetAcStaffPaged(
            [FromQuery] AcStaffParams acStaffParams)
        {
            var res = new MessageModel<IEnumerable<AcStaffDto>>();
            PagedList<AcStaff> list = await _acStaffServices.GetAcStaffPaged(acStaffParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, acStaffParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, acStaffParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<AcStaffDto>>(list);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<AcStaffDto>>> AddAcStaff(AcStaffAddDto asStaffAddDto)
        {
            var res = new MessageModel<AcStaffDto>();
            var entity = _mapper.Map<AcStaff>(asStaffAddDto);
            await _acStaffServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcStaffDto>(entity);
            return CreatedAtRoute(nameof(GetAcStaffById), new { id = entity.Id }, res.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteAcStaff(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acStaffServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acStaffServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<AcStaffDto>>> EditAcStaff(AcStaffEditDto acStaffEditDto)
        {
            MessageModel<AcStaffDto> res = new MessageModel<AcStaffDto>();
            if (!await _acStaffServices.ExistEntityAsync(a => a.Id == acStaffEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcStaff entity = _mapper.Map<AcStaff>(acStaffEditDto);
            await _acStaffServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcStaffDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, AcStaffParams acStaffParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetAcStaffPaged), new
                    {
                        PageNum = acStaffParams.PageNum - 1,
                        PageSize = acStaffParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetAcStaffPaged), new
                    {
                        PageNum = acStaffParams.PageNum + 1,
                        PageSize = acStaffParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}