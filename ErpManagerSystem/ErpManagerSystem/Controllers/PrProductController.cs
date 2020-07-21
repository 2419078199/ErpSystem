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
    public class PrProductController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductServices _prProductServices;

        public PrProductController(IMapper mapper, IPrProductServices prProductServices)
        {
            _mapper = mapper;
            _prProductServices = prProductServices;
        }
        /// <summary>
        /// PrProduct分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductDto>>> GetPrProducts([FromQuery] PrProductParams productParams)
        {
            var res = new MessageModel<IEnumerable<PrProductDto>>();
            var list = await _prProductServices.GetPrProductPaged(productParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, productParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, productParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<PrProductDto>>(list);
            return Ok(res);
        }
        /// <summary>
        /// PrProduct ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetPrProductById))]
        public async Task<ActionResult<IEnumerable<PrProductDto>>> GetPrProductById(int id)
        {
            var res = new MessageModel<PrProductDto>();
            if (!await _prProductServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _prProductServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PrProductDto>(entity);
            return Ok(res);
        }
        /// <summary>
        /// PrProduct添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PrProductDto>>> AddPrProduct(PrProductAddDto prProductAddDto)
        {
            var res = new MessageModel<PrProductDto>();
            var entity = _mapper.Map<PrProduct>(prProductAddDto);
            await _prProductServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<PrProductDto>(entity);
            return Ok(res);
        }
        /// <summary>
        /// PrProduct 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{PrProductId}")]
        public async Task<ActionResult<MessageModel<string>>> DeletePrProduct(int PrProductId)
        {
            var res = new MessageModel<string>();
            if (!await _prProductServices.ExistEntityAsync(a => a.Id == PrProductId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _prProductServices.DeleteEntityByIdAsync(PrProductId);
            return Ok(res);
        }
        /// <summary>
        /// PrProduct修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PrProductDto>>> EditPrProduct(PrProductEditDto prProductEditDto)
        {
            var res = new MessageModel<PrProductDto>();
            if (!await _prProductServices.ExistEntityAsync(a => a.Id == prProductEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PrProduct>(prProductEditDto);
            await _prProductServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PrProductDto>(entity);
            return Ok(res);
        }
        private string CreateLink(PagedType pagedType, PrProductParams prProductParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetPrProducts), new
                    {
                        PageNum = prProductParams.PageNum - 1,
                        PageSize = prProductParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetPrProducts), new
                    {
                        PageNum = prProductParams.PageNum + 1,
                        PageSize = prProductParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
