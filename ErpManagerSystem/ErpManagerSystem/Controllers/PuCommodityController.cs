using System;
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
    /// <summary>
    /// 原材料表
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PuCommodityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPuCommodityServices _puCommodityServices;

        public PuCommodityController(IMapper mapper, IPuCommodityServices puCommodityServices) {
            _mapper = mapper;
            _puCommodityServices = puCommodityServices;
        }
        /// <summary>
        /// 获取原材料信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityDto>>> PuCommodity()
        {
            MessageModel<IEnumerable<PuCommodityDto>> res = new MessageModel<IEnumerable<PuCommodityDto>>();
            List<PuCommodity> list = await _puCommodityServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PuCommodityDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取原材料信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(PuCommodityById))]
        public async Task<ActionResult<PuCommodityDto>> PuCommodityById(int id)
        {
            MessageModel<PuCommodityDto> res = new MessageModel<PuCommodityDto>();
            PuCommodity PuCommodity = await _puCommodityServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PuCommodityDto>(PuCommodity);
            return Ok(res);
        }

        /// <summary>
        /// 根据原材料名称和产地进行分页
        /// </summary>
        /// <param name="PuCommodityParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(PuCommodityPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<PuCommodityDto>>>> PuCommodityPaged(
           [FromQuery] PuCommodityParams PuCommodityParams)
        {
            var res = new MessageModel<IEnumerable<PuCommodityDto>>();
            PagedList<PuCommodity> list = await _puCommodityServices.PuCommodityInfoPaged(PuCommodityParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, PuCommodityParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, PuCommodityParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<PuCommodityDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加原材料信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PuCommodityDto>>> CreatePuCommodity(PuCommodityAddDto PuCommodityAddDto)
        {
            var res = new MessageModel<PuCommodityDto>();

            var entity = _mapper.Map<PuCommodity>(PuCommodityAddDto);

            await _puCommodityServices.AddEntityAsync(entity);

            res.Data = _mapper.Map<PuCommodityDto>(entity);

            return CreatedAtRoute(nameof(PuCommodityById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除原材料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _puCommodityServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _puCommodityServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改原材料信息
        /// </summary>
        /// <param name="puCommodityEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PuCommodityDto>>> EditPuCommodity(PuCommodityEditDto puCommodityEditDto)
        {
            var res = new MessageModel<PuCommodityDto>();
            if (!await _puCommodityServices.ExistEntityAsync(a => a.Id == puCommodityEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PuCommodity>(puCommodityEditDto);
            await _puCommodityServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PuCommodityDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, PuCommodityParams PuCommodityParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(PuCommodityPaged), new
                    {
                        PageNum = PuCommodityParams.PageNum - 1,
                        PageSize = PuCommodityParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(PuCommodityPaged), new
                    {
                        PageNum = PuCommodityParams.PageNum + 1,
                        PageSize = PuCommodityParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
