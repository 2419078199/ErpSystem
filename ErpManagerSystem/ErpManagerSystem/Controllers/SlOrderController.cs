using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
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
    public class SlOrderController : ControllerBase
    {
        private readonly ISlOrderServices _slOrderServices;
        private readonly IMapper _mapper;

        public SlOrderController(ISlOrderServices slOrderServices, IMapper mapper)
        {
            _slOrderServices = slOrderServices;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetOrders))]
        public async Task<ActionResult<MessageModel<IEnumerable<SlOrderDto>>>> GetOrders(
            [FromQuery] SlOrderParams slOrderParams)
        {
            MessageModel<IEnumerable<SlOrderDto>> res = new MessageModel<IEnumerable<SlOrderDto>>();
            PagedList<SlOrder> orderPaged = await _slOrderServices.GetOrderPaged(slOrderParams);
            string previousLink = orderPaged.HasPrevious ? CreateUrl(PagedType.Previous, slOrderParams) : null;
            string nextLink = orderPaged.HasNext ? CreateUrl(PagedType.Next, slOrderParams) : null;
            var pagination = new
            {
                currentPage = orderPaged.PageNum,
                totalPage = orderPaged.TotalPage,
                totalCount = orderPaged.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<SlOrderDto>>(orderPaged);
            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetOrderById))]
        public async Task<ActionResult<MessageModel<SlOrderDto>>> GetOrderById(int id)
        {
            MessageModel<SlOrderDto> res = new MessageModel<SlOrderDto>();
            if (!await _slOrderServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404, "请输入正确的Id"));
            }

            SlOrder entity = await _slOrderServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<SlOrderDto>(entity);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<SlOrderDto>>> AddOrder(SlOrderAddDto slOrderAddDto)
        {
            MessageModel<SlOrderDto> res = new MessageModel<SlOrderDto>();
            SlOrder entity = _mapper.Map<SlOrder>(slOrderAddDto);
            entity.No = Guid.NewGuid().ToString().Substring(0, 18);
            await _slOrderServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<SlOrderDto>(entity);
            return CreatedAtRoute(nameof(GetOrderById), new { id = entity.Id }, res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<SlOrderDto>>> EditOrder(SlOrderEditDto slOrderEditDto)
        {
            MessageModel<SlOrderDto> res = new MessageModel<SlOrderDto>();
            SlOrder entity = _mapper.Map<SlOrder>(slOrderEditDto);
            await _slOrderServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<SlOrderDto>(entity);
            return Ok(res);
        }

        private string CreateUrl(PagedType pagedType, SlOrderParams slOrderParams)
        {
            string url = string.Empty;
            switch (pagedType)
            {
                case PagedType.Previous:
                    url = Url.Link(nameof(GetOrders), new
                    {
                        PageSize = slOrderParams.PageSize,
                        PageNum = slOrderParams.PageNum - 1
                    });
                    break;

                case PagedType.Next:
                    url = Url.Link(nameof(GetOrders), new
                    {
                        PageSize = slOrderParams.PageSize,
                        PageNum = slOrderParams.PageNum + 1
                    });
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(pagedType), pagedType, null);
            }
            return url;
        }
    }
}