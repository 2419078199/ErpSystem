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
    public class PrProductMaterialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductMaterialServices _prProductMaterialServices;

        public PrProductMaterialController(IMapper mapper, IPrProductMaterialServices prProductMaterialServices)
        {
            _mapper = mapper;
            _prProductMaterialServices = prProductMaterialServices;
        }

        /// <summary>
        /// PrProductMaterial 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductMaterialDto>>> GetPrProductMaterials([FromQuery] PrProductMaterialParams prProductMaterialParams)
        {
            var res = new MessageModel<IEnumerable<IcProductRecordDto>>();
            var list = await _prProductMaterialServices.GetPrProductMaterialPaged(prProductMaterialParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, prProductMaterialParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, prProductMaterialParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<IcProductRecordDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// PrProductMaterial ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetPrProductMaterialById))]
        public async Task<ActionResult<IEnumerable<PrProductMaterialDto>>> GetPrProductMaterialById(int id)
        {
            var res = new MessageModel<PrProductMaterialDto>();
            if (!await _prProductMaterialServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _prProductMaterialServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PrProductMaterialDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// PrProductMaterial 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PrProductMaterialDto>>> AddPrProductMaterial(PrProductMaterialAddDto prProductMaterialAddDto)
        {
            var res = new MessageModel<PrProductMaterialDto>();
            var entity = _mapper.Map<PrProductMaterial>(prProductMaterialAddDto);
            await _prProductMaterialServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<PrProductMaterialDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// PrProductMaterial 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{PrProductMaterialId}")]
        public async Task<ActionResult<MessageModel<string>>> DeletePrProductMaterialId(int PrProductMaterialId)
        {
            var res = new MessageModel<string>();
            if (!await _prProductMaterialServices.ExistEntityAsync(a => a.Id == PrProductMaterialId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _prProductMaterialServices.DeleteEntityByIdAsync(PrProductMaterialId);
            return Ok(res);
        }

        /// <summary>
        /// PrProductMaterial 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PrProductMaterialDto>>> EditIcProductRecordId(PrProductMaterialEditDto prProductMaterialEditDto)
        {
            var res = new MessageModel<PrProductMaterialDto>();
            if (!await _prProductMaterialServices.ExistEntityAsync(a => a.Id == prProductMaterialEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PrProductMaterial>(prProductMaterialEditDto);
            await _prProductMaterialServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PrProductMaterialDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, PrProductMaterialParams prProductMaterialParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetPrProductMaterials), new
                    {
                        PageNum = prProductMaterialParams.PageNum - 1,
                        PageSize = prProductMaterialParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetPrProductMaterials), new
                    {
                        PageNum = prProductMaterialParams.PageNum + 1,
                        PageSize = prProductMaterialParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}