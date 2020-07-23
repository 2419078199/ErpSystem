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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    /// <summary>
    /// 原材料仓库外键表
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class IcCommodityStockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIcCommodityStockServices _Iccommoditystockservices;

        public IcCommodityStockController(IMapper mapper, IIcCommodityStockServices Iccommoditystockservices)
        {
            _mapper = mapper;
            _Iccommoditystockservices = Iccommoditystockservices;
        }

        /// <summary>
        /// 获取原材料仓库外键信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcCommodityStockDto>>> IcCommodityStock()
        {
            MessageModel<IEnumerable<IcCommodityStockDto>> res = new MessageModel<IEnumerable<IcCommodityStockDto>>();
            List<IcCommodityStock> list = await _Iccommoditystockservices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<IcCommodityStockDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取原材料仓库外键信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(IcCommodityStockById))]
        public async Task<ActionResult<IcCommodityStockDto>> IcCommodityStockById(int id)
        {
            MessageModel<IcCommodityStockDto> res = new MessageModel<IcCommodityStockDto>();
            IcCommodityStock pusupplier = await _Iccommoditystockservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<IcCommodityStockDto>(pusupplier);
            return Ok(res);
        }

        /// <summary>
        /// 原材料仓库外键分页
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(IcCommodityStockPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<IcCommodityStockDto>>>> IcCommodityStockPaged(
           [FromQuery] IcCommodityStockParams puSupplierParams)
        {
            var res = new MessageModel<IEnumerable<IcCommodityStockDto>>();
            PagedList<IcCommodityStock> list = await _Iccommoditystockservices.IcCommodityStockPaged(puSupplierParams);
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
            res.Data = _mapper.Map<IEnumerable<IcCommodityStockDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加原材料仓库外键表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<IcCommodityStockDto>>> CreateIcCommodityStock(IcCommodityStockAddDto puSupplierAddDto)
        {
            var res = new MessageModel<IcCommodityStockDto>();

            var entity = _mapper.Map<IcCommodityStock>(puSupplierAddDto);

            await _Iccommoditystockservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<IcCommodityStockDto>(entity);

            return CreatedAtRoute(nameof(IcCommodityStockById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除原材料仓库外键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _Iccommoditystockservices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _Iccommoditystockservices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改原材料仓库外键信息
        /// </summary>
        /// <param name="puSupplierEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<IcCommodityStockDto>>> EditIcCommodityStock(IcCommodityStockEditDto puSupplierEditDto)
        {
            var res = new MessageModel<IcCommodityStockDto>();
            if (!await _Iccommoditystockservices.ExistEntityAsync(a => a.Id == puSupplierEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<IcCommodityStock>(puSupplierEditDto);
            await _Iccommoditystockservices.EditEntityAsync(entity);
            res.Data = _mapper.Map<IcCommodityStockDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, IcCommodityStockParams puSupplierParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(IcCommodityStockPaged), new
                    {
                        PageNum = puSupplierParams.PageNum - 1,
                        PageSize = puSupplierParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(IcCommodityStockPaged), new
                    {
                        PageNum = puSupplierParams.PageNum + 1,
                        PageSize = puSupplierParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}