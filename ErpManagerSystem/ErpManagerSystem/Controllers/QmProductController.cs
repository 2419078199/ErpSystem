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
    public class QmProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQmProductServices _qmProductServices;

        public QmProductController(IMapper mapper, IQmProductServices qmProductServices)
        {
            _mapper = mapper;
            _qmProductServices = qmProductServices;
        }

        /// <summary>
        /// QmProduct 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmProductDto>>> GetQmProducts([FromQuery] QmProductParams qmProductParams)
        {
            var res = new MessageModel<IEnumerable<QmProductDto>>();
            var list = await _qmProductServices.GetQmProductPaged(qmProductParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, qmProductParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, qmProductParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<QmProductDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// QmProduct ID查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetQmProductById))]
        public async Task<ActionResult<IEnumerable<QmProductDto>>> GetQmProductById(int id)
        {
            var res = new MessageModel<QmProductDto>();
            if (!await _qmProductServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = await _qmProductServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<QmProductDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// QmProduct 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<QmProductDto>>> AddQmProduct(QmProductAddDto qmProductAddDto)
        {
            var res = new MessageModel<QmProductDto>();
            var entity = _mapper.Map<QmProduct>(qmProductAddDto);
            await _qmProductServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<QmProductDto>(entity);
            return Ok(res);
        }

        /// <summary>
        /// QmProduct 删除实体
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{QmProductId}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteQmProduct(int QmProductId)
        {
            var res = new MessageModel<string>();
            if (!await _qmProductServices.ExistEntityAsync(a => a.Id == QmProductId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _qmProductServices.DeleteEntityByIdAsync(QmProductId);
            return Ok(res);
        }

        /// <summary>
        /// QmProduct 修改实体
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<QmProductDto>>> EditAuRecord(QmProductEditDto qmProductEditDto)
        {
            var res = new MessageModel<QmProductDto>();
            if (!await _qmProductServices.ExistEntityAsync(a => a.Id == qmProductEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<QmProduct>(qmProductEditDto);
            await _qmProductServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<QmProductDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, QmProductParams qmProductParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetQmProducts), new
                    {
                        PageNum = qmProductParams.PageNum - 1,
                        PageSize = qmProductParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetQmProducts), new
                    {
                        PageNum = qmProductParams.PageNum + 1,
                        PageSize = qmProductParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}