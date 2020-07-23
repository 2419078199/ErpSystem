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
    /// 原材料质检表接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class QmCommodityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQmCommodityServices _qmcommodityservices;

        public QmCommodityController(IMapper mapper, IQmCommodityServices qmcommodityservices)
        {
            _mapper = mapper;
            _qmcommodityservices = qmcommodityservices;
        }
        /// <summary>
        /// 获取原材料质检信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmCommodityDto>>> QmCommodity()
        {
            MessageModel<IEnumerable<QmCommodityDto>> res = new MessageModel<IEnumerable<QmCommodityDto>>();
            List<QmCommodity> list = await _qmcommodityservices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<QmCommodityDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取原材料质检信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(QmCommodityById))]
        public async Task<ActionResult<QmCommodityDto>> QmCommodityById(int id)
        {
            MessageModel<QmCommodityDto> res = new MessageModel<QmCommodityDto>();
            QmCommodity pusupplier = await _qmcommodityservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<QmCommodityDto>(pusupplier);
            return Ok(res);
        }
        /// <summary>
        /// 原材料质检分页
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(QmCommodityPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<QmCommodityDto>>>> QmCommodityPaged(
           [FromQuery] QmCommodityParams puSupplierParams)
        {
            var res = new MessageModel<IEnumerable<QmCommodityDto>>();
            PagedList<QmCommodity> list = await _qmcommodityservices.QmCommodityPaged(puSupplierParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, puSupplierParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, puSupplierParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<QmCommodityDto>>(list);
            return Ok(res);
        }
        /// <summary>
        /// 添加原材料质检表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<QmCommodityDto>>> CreateQmCommodity(QmCommodityAddDto puSupplierAddDto)
        {
            var res = new MessageModel<QmCommodityDto>();

            var entity = _mapper.Map<QmCommodity>(puSupplierAddDto);

            await _qmcommodityservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<QmCommodityDto>(entity);

            return CreatedAtRoute(nameof(QmCommodityById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除原材料质检
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _qmcommodityservices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _qmcommodityservices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改原材料质检信息
        /// </summary>
        /// <param name="puSupplierEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<QmCommodityDto>>> EditQmCommodity(QmCommodityEditDto puSupplierEditDto)
        {
            var res = new MessageModel<QmCommodityDto>();
            if (!await _qmcommodityservices.ExistEntityAsync(a => a.Id == puSupplierEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<QmCommodity>(puSupplierEditDto);
            await _qmcommodityservices.EditEntityAsync(entity);
            res.Data = _mapper.Map<QmCommodityDto>(entity);
            return Ok(res);
        }


        private string CreateLink(PagedType pagedType, QmCommodityParams puSupplierParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(QmCommodityPaged), new
                    {
                        PageNum = puSupplierParams.PageNum - 1,
                        PageSize = puSupplierParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(QmCommodityPaged), new
                    {
                        PageNum = puSupplierParams.PageNum + 1,
                        PageSize = puSupplierParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}

