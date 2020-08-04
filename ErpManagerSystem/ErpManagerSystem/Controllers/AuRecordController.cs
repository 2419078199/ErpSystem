using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class AuRecordController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuRecordServices _auRecordServices;

        public AuRecordController(IMapper mapper, IAuRecordServices auRecordServices)
        {
            _mapper = mapper;
            _auRecordServices = auRecordServices;
        }

        /// <summary>
        /// AuRecord 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuRecordDto>>> GetAuRecords([FromQuery] AuRecordParams auRecordParams)
        {
            var res = new MessageModel<IEnumerable<AuRecordDto>>();
            var list = await _auRecordServices.GetAuRecordPaged(auRecordParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, auRecordParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, auRecordParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<AuRecordDto>>(list);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageModel<AuRecord>>> GetRecordById(int id)
        {
            MessageModel<AuRecordDto> res = new MessageModel<AuRecordDto>();
            if (!await _auRecordServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404, "请输入正确的Id"));
            }
            AuRecord entity = await _auRecordServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AuRecordDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// AuRecord ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetAuRecordById))]
        public async Task<ActionResult<IEnumerable<AuRecordDto>>> GetAuRecordById(int id)
        {
            var res = new MessageModel<AuRecordDto>();
            if (!await _auRecordServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _auRecordServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AuRecordDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// AuRecord 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<AuRecordDto>>> AddAuRecord(AuRecordAddDto auRecordAddDto)
        {
            var res = new MessageModel<Model.Dtos.Dto.AuRecordDto>();
            var entity = _mapper.Map<AuRecord>(auRecordAddDto);
            await _auRecordServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<Model.Dtos.Dto.AuRecordDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// AuRecord 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{AuRecordtId}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteAuRecord(int AuRecordtId)
        {
            var res = new MessageModel<string>();
            if (!await _auRecordServices.ExistEntityAsync(a => a.Id == AuRecordtId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _auRecordServices.DeleteEntityByIdAsync(AuRecordtId);
            return Ok(res);
        }

        /// <summary>
        /// AuRecord 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<AuRecordDto>>> EditAuRecord(AuRecordEditDto auRecordEditDto)
        {
            var res = new MessageModel<Model.Dtos.Dto.AuRecordDto>();
            if (!await _auRecordServices.ExistEntityAsync(a => a.Id == auRecordEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<AuRecord>(auRecordEditDto);
            await _auRecordServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AuRecordDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, AuRecordParams auRecordParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetAuRecords), new
                    {
                        PageNum = auRecordParams.PageNum - 1,
                        PageSize = auRecordParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetAuRecords), new
                    {
                        PageNum = auRecordParams.PageNum + 1,
                        PageSize = auRecordParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}