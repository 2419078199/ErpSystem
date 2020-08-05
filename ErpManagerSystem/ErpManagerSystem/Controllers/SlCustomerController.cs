using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class SlCustomerController : ControllerBase
    {
        private readonly ISlCustomerServices _slCustomerServices;
        private readonly IMapper _mapper;

        public SlCustomerController(ISlCustomerServices slCustomerServices, IMapper mapper)
        {
            _slCustomerServices = slCustomerServices;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetCustomer))]
        public async Task<ActionResult<IEnumerable<SlCustomerDto>>> GetCustomer([FromQuery] CustomerParams customerParams)
        {
            MessageModel<IEnumerable<SlCustomerDto>> res = new MessageModel<IEnumerable<SlCustomerDto>>();
            PagedList<SlCustomer> customerPaged = await _slCustomerServices.GetCustomerPaged(customerParams);
            string previousLink = customerPaged.HasPrevious ? CreateUrl(PagedType.Previous, customerParams) : null;
            string nextLink = customerPaged.HasNext ? CreateUrl(PagedType.Next, customerParams) : null;
            var pagination = new
            {
                currentPage = customerPaged.PageNum,
                totalPage = customerPaged.TotalPage,
                totalCount = customerPaged.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<SlCustomerDto>>(customerPaged);
            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetCustomerById))]
        public async Task<ActionResult<SlCustomerDto>> GetCustomerById(int id)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404, "请输入正确的Id"));
            }

            SlCustomer entity = await _slCustomerServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<SlCustomerDto>>> AddCustomer(SlCustomerAddDto slCustomerAddDto)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            SlCustomer entity = _mapper.Map<SlCustomer>(slCustomerAddDto);
            entity.Postcode = "423000";
            entity.Linkman = entity.Name;
            entity.Custtel=entity.Linktel;
            entity.Sex = true;
            entity.Love = "无";
            await _slCustomerServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return CreatedAtRoute(nameof(GetCustomerById), new { id = entity.Id }, res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteCustomer(int id)
        {
            MessageModel<string> res = new MessageModel<string>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }

            await _slCustomerServices.DeleteEntityByIdAsync(id);
            res.Data = "成功";
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<SlCustomerDto>>> EditCustomer(SlCustomerEditdDto slCustomerAddDto)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == slCustomerAddDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }

            SlCustomer entity = _mapper.Map<SlCustomer>(slCustomerAddDto);
            await _slCustomerServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return Ok(res);
        }
        private string CreateUrl(PagedType pagedType, CustomerParams customerParams)
        {
            string url = string.Empty;
            switch (pagedType)
            {
                case PagedType.Previous:
                    url = Url.Link(nameof(GetCustomer), new
                    {
                        PageSize = customerParams.PageSize,
                        CustomerName = customerParams.CustomerName,
                        PageNum = customerParams.PageNum - 1
                    });
                    break;

                case PagedType.Next:
                    url = Url.Link(nameof(GetCustomer), new
                    {
                        PageSize = customerParams.PageSize,
                        CustomerName = customerParams.CustomerName,
                        PageNum = customerParams.PageNum + 1
                    });
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(pagedType), pagedType, null);
            }
            return url;
        }
    }
}