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
using Model;
using Model.Dtos.AddDto;
using Model.Dtos.EditDto;
using Model.Entitys;
using Model.Params;
using Newtonsoft.Json;

namespace ErpManagerSystem.Controllers
{
    /// <summary>
    /// 原材料分类表
    /// </summary>
   
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PuCommodityCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPuCommodityCategoryServices _puCommodityCategoryServices;

        public PuCommodityCategoryController(IMapper mapper, IPuCommodityCategoryServices puCommodityCategoryServices) {
            _mapper = mapper;
            _puCommodityCategoryServices = puCommodityCategoryServices;
        }
        /// <summary>
        /// 获取原材料分类信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityCategoryDto>>> PuCommodityCategory()
        {
            MessageModel<IEnumerable<PuCommodityCategoryDto>> res = new MessageModel<IEnumerable<PuCommodityCategoryDto>>();
            List<PuCommodityCategory> list = await _puCommodityCategoryServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PuCommodityCategoryDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(PuCommodityCategoryById))]
        public async Task<ActionResult<PuCommodityCategoryDto>> PuCommodityCategoryById(int id)
        {
            MessageModel<PuCommodityCategoryDto> res = new MessageModel<PuCommodityCategoryDto>();
            PuCommodityCategory PuCommodityCategory = await _puCommodityCategoryServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PuCommodityCategoryDto>(PuCommodityCategory);
            return Ok(res);
        }

        /// <summary>
        /// 根据原材料类别名称进行原材料分类信息分页
        /// </summary>
        /// <param name="PuCommodityCategoryParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(PuCommodityCategoryPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<PuCommodityCategoryDto>>>> PuCommodityCategoryPaged(
           [FromQuery] PuCommodityCategoryParams PuCommodityCategoryParams)
        {
            var res = new MessageModel<IEnumerable<PuCommodityCategoryDto>>();
            PagedList<PuCommodityCategory> list = await _puCommodityCategoryServices.PuCommodityCategoryPaged(PuCommodityCategoryParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, PuCommodityCategoryParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, PuCommodityCategoryParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<PuCommodityCategoryDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加原材料分类信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PuCommodityCategoryDto>>> CreatePuCommodityCategory(PuCommodityCategoryAddDto PuCommodityCategoryAddDto)
        {
            var res = new MessageModel<PuCommodityCategoryDto>();

            var entity = _mapper.Map<PuCommodityCategory>(PuCommodityCategoryAddDto);

            await _puCommodityCategoryServices.AddEntityAsync(entity);

            res.Data = _mapper.Map<PuCommodityCategoryDto>(entity);

            return CreatedAtRoute(nameof(PuCommodityCategoryById), new { id = entity.Id }, res);
        }



        /// <summary>
        /// 根据ID删除原材料分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _puCommodityCategoryServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _puCommodityCategoryServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改原材料分类信息
        /// </summary>
        /// <param name="puCommodityCategoryEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PuCommodityCategoryDto>>> EditPuCommodityCategory(PuCommodityCategoryEditDto puCommodityCategoryEditDto)
        {
            var res = new MessageModel<PuCommodityCategoryDto>();
            if (!await _puCommodityCategoryServices.ExistEntityAsync(a => a.Id == puCommodityCategoryEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PuCommodityCategory>(puCommodityCategoryEditDto);
            await _puCommodityCategoryServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PuCommodityCategoryDto>(entity);
            return Ok(res);
        }
        private string CreateLink(PagedType pagedType, PuCommodityCategoryParams PuCommodityCategoryParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(PuCommodityCategoryPaged), new
                    {
                        PageNum = PuCommodityCategoryParams.PageNum - 1,
                        PageSize = PuCommodityCategoryParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(PuCommodityCategoryPaged), new
                    {
                        PageNum = PuCommodityCategoryParams.PageNum + 1,
                        PageSize = PuCommodityCategoryParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
