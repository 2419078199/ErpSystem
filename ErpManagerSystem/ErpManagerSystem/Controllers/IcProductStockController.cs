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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class IcProductStockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIcProductStockServices _icProductStockServices;

        public IcProductStockController(IMapper mapper, IIcProductStockServices icProductStockServices)
        {
            _mapper = mapper;
            _icProductStockServices = icProductStockServices;
        }

        /// <summary>
        /// IcProductStock 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcProductStockDto>>> GetIcProductStocks([FromQuery] IcProductStockParams icProductStockParams)
        {
            var res = new MessageModel<IEnumerable<IcProductStockDto>>();
            var list = await _icProductStockServices.GetIcProductStockPaged(icProductStockParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, icProductStockParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, icProductStockParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<IcProductStockDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// IcProductStock ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetIcProductStockById))]
        public async Task<ActionResult<IEnumerable<IcProductStockDto>>> GetIcProductStockById(int id)
        {
            var res = new MessageModel<IcProductStockDto>();
            if (!await _icProductStockServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _icProductStockServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<IcProductStockDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// IcProductStock 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<IcProductStockDto>>> AddIcProductStock(IcProductStockAddDto icProductStockAddDto)
        {
            var res = new MessageModel<IcProductStockDto>();
            var entity = _mapper.Map<IcProductStock>(icProductStockAddDto);
            await _icProductStockServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<IcProductStockDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// IcProductStock 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{IcProductStockId}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteIcProductStock(int IcProductStockId)
        {
            var res = new MessageModel<string>();
            if (!await _icProductStockServices.ExistEntityAsync(a => a.Id == IcProductStockId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _icProductStockServices.DeleteEntityByIdAsync(IcProductStockId);
            return Ok(res);
        }

        /// <summary>
        /// IcProductStock 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<IcProductStockDto>>> EditIcProductStock(IcProductStockEditDto icProductStockEditDto)
        {
            var res = new MessageModel<IcProductStockDto>();
            if (!await _icProductStockServices.ExistEntityAsync(a => a.Id == icProductStockEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<IcProductStock>(icProductStockEditDto);
            await _icProductStockServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<IcProductStockDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, IcProductStockParams icProductStockParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetIcProductStocks), new
                    {
                        PageNum = icProductStockParams.PageNum - 1,
                        PageSize = icProductStockParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetIcProductStocks), new
                    {
                        PageNum = icProductStockParams.PageNum + 1,
                        PageSize = icProductStockParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}