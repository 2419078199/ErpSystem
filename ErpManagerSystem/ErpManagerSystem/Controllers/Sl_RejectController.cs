using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Entitys;
using Model.Params;
using Newtonsoft.Json;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Sl_RejectController : ControllerBase
    {
        private readonly ISlRejectServices _slRejectServices;
        private readonly IMapper _mapper;

        public Sl_RejectController(ISlRejectServices slRejectServices, IMapper mapper)
        {
            _slRejectServices = slRejectServices;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetReject))]
        public async Task<ActionResult<MessageModel<IEnumerable<SlRejectDto>>>> GetReject([FromQuery] RejectParams rejectParams)
        {
            MessageModel<IEnumerable<SlRejectDto>> res = new MessageModel<IEnumerable<SlRejectDto>>();
            PagedList<SlReject> rejectPaged = await _slRejectServices.GetRejectPaged(rejectParams);
            string previousLink = rejectPaged.HasPrevious ? CreateUrl(PagedType.Previous, rejectParams) : null;
            string nextLink = rejectPaged.HasNext ? CreateUrl(PagedType.Next, rejectParams) : null;
            var pagination = new
            {
                currentPage = rejectPaged.PageNum,
                totalPage = rejectPaged.TotalPage,
                totalCount = rejectPaged.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<SlRejectDto>>(rejectPaged);
            return Ok(res);
        }
        [HttpGet("{id}", Name = nameof(GetRejectById))]
        public async Task<ActionResult<MessageModel<SlRejectDto>>> GetRejectById(int id)
        {
            MessageModel<SlRejectDto> res = new MessageModel<SlRejectDto>();
            if (!await _slRejectServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404, "请输入正确的Id"));
            }
            SlReject entity = await _slRejectServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<SlRejectDto>(entity);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel<SlRejectDto>>> AddReject(SlRejectAddDto slRejectAddDto)
        {
            MessageModel<SlRejectDto> res = new MessageModel<SlRejectDto>();
            SlReject entity = _mapper.Map<SlReject>(slRejectAddDto);
            entity.No = Guid.NewGuid().ToString().Substring(0, 18);
            await _slRejectServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<SlRejectDto>(entity);
            return CreatedAtRoute(nameof(GetRejectById), new { id = entity.Id }, res);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteReject(int id)
        {
            MessageModel<string> res = new MessageModel<string>();
            if (!await _slRejectServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404, "请输入正确的Id"));
            }
            SlReject entity = await _slRejectServices.GetEntityByIdAsync(id);
            await _slRejectServices.DeleteEntityAsync(entity);
            return Ok(res);
        }
        private string CreateUrl(PagedType pagedType, RejectParams rejectParams)
        {
            string url = string.Empty;
            switch (pagedType)
            {
                case PagedType.Previous:
                    url = Url.Link(nameof(GetReject), new
                    {
                        PageSize = rejectParams.PageSize,
                        PageNum = rejectParams.PageNum - 1
                    });
                    break;
                case PagedType.Next:
                    url = Url.Link(nameof(GetReject), new
                    {
                        PageSize = rejectParams.PageSize,
                        PageNum = rejectParams.PageNum + 1
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pagedType), pagedType, null);
            }
            return url;
        }
    }
}