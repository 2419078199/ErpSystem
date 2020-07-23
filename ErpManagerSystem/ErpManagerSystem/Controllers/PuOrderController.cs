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
    /// 订单表接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PuOrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPuOrderServices _puorderservices;

        public PuOrderController(IMapper mapper, IPuOrderServices puorderservices)
        {
            _mapper = mapper;
            _puorderservices = puorderservices;
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuOrderDto>>> PuOrder()
        {
            MessageModel<IEnumerable<PuOrderDto>> res = new MessageModel<IEnumerable<PuOrderDto>>();
            List<PuOrder> list = await _puorderservices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PuOrderDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(PuOrderById))]
        public async Task<ActionResult<PuOrderDto>> PuOrderById(int id)
        {
            MessageModel<PuOrderDto> res = new MessageModel<PuOrderDto>();
            PuOrder pusupplier = await _puorderservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PuOrderDto>(pusupplier);
            return Ok(res);
        }

        /// <summary>
        /// 订单分页
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(PuOrderPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<PuOrderDto>>>> PuOrderPaged(
           [FromQuery] PuOrderParams puSupplierParams)
        {
            var res = new MessageModel<IEnumerable<PuOrderDto>>();
            PagedList<PuOrder> list = await _puorderservices.PuOrderPaged(puSupplierParams);
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
            res.Data = _mapper.Map<IEnumerable<PuOrderDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加订单表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PuOrderDto>>> CreatePuOrder(PuOrderAddDto puSupplierAddDto)
        {
            var res = new MessageModel<PuOrderDto>();

            var entity = _mapper.Map<PuOrder>(puSupplierAddDto);

            await _puorderservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<PuOrderDto>(entity);

            return CreatedAtRoute(nameof(PuOrderById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _puorderservices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _puorderservices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改订单信息
        /// </summary>
        /// <param name="puSupplierEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PuOrderDto>>> EditPuOrder(PuOrderEditDto puSupplierEditDto)
        {
            var res = new MessageModel<PuOrderDto>();
            if (!await _puorderservices.ExistEntityAsync(a => a.Id == puSupplierEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PuOrder>(puSupplierEditDto);
            await _puorderservices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PuOrderDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, PuOrderParams puSupplierParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(PuOrderPaged), new
                    {
                        PageNum = puSupplierParams.PageNum - 1,
                        PageSize = puSupplierParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(PuOrderPaged), new
                    {
                        PageNum = puSupplierParams.PageNum + 1,
                        PageSize = puSupplierParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}