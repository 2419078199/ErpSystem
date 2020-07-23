using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AddDto;
using Model.Entitys;
using Model.Params;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuRecordController : ControllerBase
    {
        private readonly IAuRecordServices _auRecordServices;
        private readonly IMapper _mapper;

        public AuRecordController(IAuRecordServices auRecordServices, IMapper mapper)
        {
            _auRecordServices = auRecordServices;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRecord))]
        public async Task<ActionResult<MessageModel<IEnumerable<AuRecordDto>>>> GetRecord([FromQuery] AuRecordParams auRecordParams)
        {
            MessageModel<IEnumerable<AuRecordDto>> res = new MessageModel<IEnumerable<AuRecordDto>>();
            PagedList<AuRecord> recordPaged = await _auRecordServices.GetRecordPaged(auRecordParams);
            string previousLink = recordPaged.HasPrevious ? CreateUrl(PagedType.Previous, auRecordParams) : null;
            string nextLink = recordPaged.HasNext ? CreateUrl(PagedType.Next, auRecordParams) : null;
            var pagination = new
            {
                currentPage = recordPaged.PageNum,
                totalPage = recordPaged.TotalPage,
                totalCount = recordPaged.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<AuRecordDto>>(recordPaged);
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

        private string CreateUrl(PagedType pagedType, AuRecordParams auRecordParams)
        {
            string url = string.Empty;
            switch (pagedType)
            {
                case PagedType.Previous:
                    url = Url.Link(nameof(GetRecord), new
                    {
                        PageSize = auRecordParams.PageSize,
                        PageNum = auRecordParams.PageNum - 1
                    });
                    break;
                case PagedType.Next:
                    url = Url.Link(nameof(GetRecord), new
                    {
                        PageSize = auRecordParams.PageSize,
                        PageNum = auRecordParams.PageNum + 1
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pagedType), pagedType, null);
            }
            return url;
        }
    }
}
