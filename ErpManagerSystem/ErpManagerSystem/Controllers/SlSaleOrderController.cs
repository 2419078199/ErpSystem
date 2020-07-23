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
    public class SlSaleOrderController : ControllerBase
    {
        private readonly ISlSaleOrderServices _slSaleOrderServices;
        private readonly IMapper _mapper;

        public SlSaleOrderController(ISlSaleOrderServices slSaleOrderServices, IMapper mapper)
        {
            _slSaleOrderServices = slSaleOrderServices;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSaleOrder))]
        public async Task<ActionResult<MessageModel<SlSaleOrderDto>>> GetSaleOrder([FromQuery] SlSaleOrderParams slSaleOrderParams)
        {
            MessageModel<IEnumerable<SlSaleOrderDto>> res = new MessageModel<IEnumerable<SlSaleOrderDto>>();
            PagedList<SlSaleOrder> saleOrderPaged = await _slSaleOrderServices.GetSaleOrderPaged(slSaleOrderParams);
            string previousLink = saleOrderPaged.HasPrevious ? CreateUrl(PagedType.Previous, slSaleOrderParams) : null;
            string nextLink = saleOrderPaged.HasNext ? CreateUrl(PagedType.Next, slSaleOrderParams) : null;
            var pagination = new
            {
                currentPage = saleOrderPaged.PageNum,
                totalPage = saleOrderPaged.TotalPage,
                totalCount = saleOrderPaged.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<SlSaleOrderDto>>(saleOrderPaged);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel<SlSaleOrderDto>>> AddSaleOrder(SlSaleOrderAddDto slSaleOrderAddDto)
        {
            MessageModel<SlSaleOrderDto> res = new MessageModel<SlSaleOrderDto>();
            SlSaleOrder entity = _mapper.Map<SlSaleOrder>(slSaleOrderAddDto);
            entity.No = Guid.NewGuid().ToString().Substring(0, 18);
            await _slSaleOrderServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<SlSaleOrderDto>(entity);
            return Ok(res);
        }
        private string CreateUrl(PagedType pagedType, SlSaleOrderParams slSaleOrderParams)
        {
            string url = string.Empty;
            switch (pagedType)
            {
                case PagedType.Previous:
                    url = Url.Link(nameof(GetSaleOrder), new
                    {
                        PageSize = slSaleOrderParams.PageSize,
                        PageNum = slSaleOrderParams.PageNum - 1
                    });
                    break;
                case PagedType.Next:
                    url = Url.Link(nameof(GetSaleOrder), new
                    {
                        PageSize = slSaleOrderParams.PageSize,
                        PageNum = slSaleOrderParams.PageNum + 1
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pagedType), pagedType, null);
            }
            return url;
        }
    }
}