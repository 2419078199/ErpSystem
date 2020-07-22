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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class IcProductRecordController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIcProductRecordServices _icProductRecordServices;

        public IcProductRecordController(IMapper mapper, IIcProductRecordServices icProductRecordServices)
        {
            _mapper = mapper;
            _icProductRecordServices = icProductRecordServices;
        }
        /// <summary>
        /// IcProductRecord 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcProductRecordDto>>> GetIcProductRecords([FromQuery]  IcProductRecordParams icProductRecordParams)
        {
            var res = new MessageModel<IEnumerable<IcProductRecordDto>>();
            var list = await _icProductRecordServices.GetIcProductRecordPaged(icProductRecordParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, icProductRecordParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, icProductRecordParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<IcProductRecordDto>>(list);
            return Ok(res);
        }
        /// <summary>
        /// IcProductRecord ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetIcProductRecordById))]
        public async Task<ActionResult<IEnumerable<IcProductRecordDto>>> GetIcProductRecordById(int id)
        {
            var res = new MessageModel<IcProductRecordDto>();
            if (!await _icProductRecordServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _icProductRecordServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<IcProductRecordDto>(entity);
            return Ok(res);
        }
        /// <summary>
        /// IcProductRecord 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<IcProductRecordDto>>> AddIcProductRecord(IcProductRecordAddDto icProductRecordAddDto)
        {
            var res = new MessageModel<IcProductRecordDto>();
            var entity = _mapper.Map<IcProductRecord>(icProductRecordAddDto);
            await _icProductRecordServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<IcProductRecordDto>(entity);
            return Ok(res);
        }
        /// <summary>
        /// IcProductRecord 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{IcProductRecordId}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteIcProductRecord(int IcProductRecordId)
        {
            var res = new MessageModel<string>();
            if (!await _icProductRecordServices.ExistEntityAsync(a => a.Id == IcProductRecordId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _icProductRecordServices.DeleteEntityByIdAsync(IcProductRecordId);
            return Ok(res);
        }
        /// <summary>
        /// IcProductRecord 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<IcProductRecordDto>>> EditIcProductRecordId(IcProductRecordEditDto icProductRecordEditDto)
        {
            var res = new MessageModel<IcProductRecordDto>();
            if (!await _icProductRecordServices.ExistEntityAsync(a => a.Id == icProductRecordEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<IcProductRecord>(icProductRecordEditDto);
            await _icProductRecordServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<IcProductRecordDto>(entity);
            return Ok(res);
        }
        private string CreateLink(PagedType pagedType, IcProductRecordParams icProductRecordParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetIcProductRecords), new
                    {
                        PageNum = icProductRecordParams.PageNum - 1,
                        PageSize = icProductRecordParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetIcProductRecords), new
                    {
                        PageNum = icProductRecordParams.PageNum + 1,
                        PageSize = icProductRecordParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
