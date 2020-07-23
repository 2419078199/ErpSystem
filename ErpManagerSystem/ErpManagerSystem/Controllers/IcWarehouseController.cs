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
    public class IcWarehouseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIcWarehouseServices _icWarehouseServices;

        public IcWarehouseController(IMapper mapper, IIcWarehouseServices icWarehouseServices)
        {
            _mapper = mapper;
            _icWarehouseServices = icWarehouseServices;
        }

        /// <summary>
        /// IcWarehouse 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcWarehouseDto>>> GetIcWarehouses([FromQuery] IcWarehouseParams icWarehouseParams)
        {
            var res = new MessageModel<IEnumerable<IcWarehouseDto>>();
            var list = await _icWarehouseServices.GetIcWarehousePaged(icWarehouseParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, icWarehouseParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, icWarehouseParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<IcWarehouseDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// IcWarehouse ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetIcWarehouseById))]
        public async Task<ActionResult<IEnumerable<IcWarehouseDto>>> GetIcWarehouseById(int id)
        {
            var res = new MessageModel<IcWarehouseDto>();
            if (!await _icWarehouseServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _icWarehouseServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<IcWarehouseDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// IcWarehouse 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<IcWarehouseDto>>> AddIcWarehouse(IcWarehouseAddDto icWarehouseAddDto)
        {
            var res = new MessageModel<IcWarehouseDto>();
            var entity = _mapper.Map<IcWarehouse>(icWarehouseAddDto);
            await _icWarehouseServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<IcWarehouseDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// IcWarehouse 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{IcWarehousetId}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteIcWarehouse(int IcWarehousetId)
        {
            var res = new MessageModel<string>();
            if (!await _icWarehouseServices.ExistEntityAsync(a => a.Id == IcWarehousetId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _icWarehouseServices.DeleteEntityByIdAsync(IcWarehousetId);
            return Ok(res);
        }

        /// <summary>
        /// IcWarehouse 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<IcWarehouseDto>>> EditIcWarehouse(IcWarehouseEditDto icWarehouseEditDto)
        {
            var res = new MessageModel<IcWarehouseDto>();
            if (!await _icWarehouseServices.ExistEntityAsync(a => a.Id == icWarehouseEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<IcWarehouse>(icWarehouseEditDto);
            await _icWarehouseServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<IcWarehouseDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, IcWarehouseParams icWarehouseParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetIcWarehouses), new
                    {
                        PageNum = icWarehouseParams.PageNum - 1,
                        PageSize = icWarehouseParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetIcWarehouses), new
                    {
                        PageNum = icWarehouseParams.PageNum + 1,
                        PageSize = icWarehouseParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}