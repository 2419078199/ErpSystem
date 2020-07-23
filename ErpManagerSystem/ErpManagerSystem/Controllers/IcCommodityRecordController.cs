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
    /// 原材料审批外键表接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class IcCommodityRecordController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIcCommodityRecordServices _iccommodityrecordservices;

        public IcCommodityRecordController(IMapper mapper, IIcCommodityRecordServices iccommodityrecordservices)
        {
            _mapper = mapper;
            _iccommodityrecordservices = iccommodityrecordservices;
        }

        /// <summary>
        /// 获取原材料审批外键表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcCommodityRecordDto>>> IcCommodityRecord()
        {
            MessageModel<IEnumerable<IcCommodityRecordDto>> res = new MessageModel<IEnumerable<IcCommodityRecordDto>>();
            List<IcCommodityRecord> list = await _iccommodityrecordservices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<IcCommodityRecordDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取原材料审批外键表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(IcCommodityRecordById))]
        public async Task<ActionResult<IcCommodityRecordDto>> IcCommodityRecordById(int id)
        {
            MessageModel<IcCommodityRecordDto> res = new MessageModel<IcCommodityRecordDto>();
            IcCommodityRecord pusupplier = await _iccommodityrecordservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<IcCommodityRecordDto>(pusupplier);
            return Ok(res);
        }

        /// <summary>
        /// 原材料审批外键表分页
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(IcCommodityRecordPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<IcCommodityRecordDto>>>> IcCommodityRecordPaged(
           [FromQuery] IcCommodityRecordParams puSupplierParams)
        {
            var res = new MessageModel<IEnumerable<IcCommodityRecordDto>>();
            PagedList<IcCommodityRecord> list = await _iccommodityrecordservices.IcCommodityRecordPaged(puSupplierParams);
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
            res.Data = _mapper.Map<IEnumerable<IcCommodityRecordDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加原材料审批外键表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<IcCommodityRecordDto>>> CreateIcCommodityRecord(IcCommodityRecordAddDto puSupplierAddDto)
        {
            var res = new MessageModel<IcCommodityRecordDto>();

            var entity = _mapper.Map<IcCommodityRecord>(puSupplierAddDto);

            await _iccommodityrecordservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<IcCommodityRecordDto>(entity);

            return CreatedAtRoute(nameof(IcCommodityRecordById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除原材料审批外键表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _iccommodityrecordservices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _iccommodityrecordservices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改原材料审批外键表信息
        /// </summary>
        /// <param name="puSupplierEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<IcCommodityRecordDto>>> EditIcCommodityRecord(IcCommodityRecordEditDto puSupplierEditDto)
        {
            var res = new MessageModel<IcCommodityRecordDto>();
            if (!await _iccommodityrecordservices.ExistEntityAsync(a => a.Id == puSupplierEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<IcCommodityRecord>(puSupplierEditDto);
            await _iccommodityrecordservices.EditEntityAsync(entity);
            res.Data = _mapper.Map<IcCommodityRecordDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, IcCommodityRecordParams puSupplierParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(IcCommodityRecordPaged), new
                    {
                        PageNum = puSupplierParams.PageNum - 1,
                        PageSize = puSupplierParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(IcCommodityRecordPaged), new
                    {
                        PageNum = puSupplierParams.PageNum + 1,
                        PageSize = puSupplierParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}