﻿using AutoMapper;
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
    /// 供应商API  供应商档案员操作
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PuSupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPuSupplierServices _pusupplierservices;

        public PuSupplierController(IMapper mapper, IPuSupplierServices pusupplierservices)
        {
            _mapper = mapper;
            _pusupplierservices = pusupplierservices;
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuSupplierDto>>> PuSupplier()
        {
            MessageModel<IEnumerable<PuSupplierDto>> res = new MessageModel<IEnumerable<PuSupplierDto>>();
            List<PuSupplier> list = await _pusupplierservices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PuSupplierDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 通过Id获取供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(PuSupplierById))]
        public async Task<ActionResult<PuSupplierDto>> PuSupplierById(int id)
        {
            MessageModel<PuSupplierDto> res = new MessageModel<PuSupplierDto>();
            PuSupplier pusupplier = await _pusupplierservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PuSupplierDto>(pusupplier);
            return Ok(res);
        }

        /// <summary>
        /// 供应商分页
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(PuSupplierPaged))]
        public async Task<ActionResult<ActionResult<IEnumerable<PuSupplierDto>>>> PuSupplierPaged(
           [FromQuery] PuSupplierParams puSupplierParams)
        {
            var res = new MessageModel<IEnumerable<PuSupplierDto>>();
            PagedList<PuSupplier> list = await _pusupplierservices.PuSupplierPaged(puSupplierParams);
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
            res.Data = _mapper.Map<IEnumerable<PuSupplierDto>>(list);
            return Ok(res);
        }

        /// <summary>
        /// 添加供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PuSupplierDto>>> CreatePuSupplier(PuSupplierAddDto puSupplierAddDto)
        {
            var res = new MessageModel<PuSupplierDto>();

            var entity = _mapper.Map<PuSupplier>(puSupplierAddDto);

            await _pusupplierservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<PuSupplierDto>(entity);

            return CreatedAtRoute(nameof(PuSupplierById), new { id = entity.Id }, res);
        }

        /// <summary>
        /// 根据ID删除供应商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> Delete(int id)
        {
            var res = new MessageModel<string>();
            if (!await _pusupplierservices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _pusupplierservices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="puSupplierEditDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MessageModel<PuSupplierDto>>> EditPuSupplier(PuSupplierEditDto puSupplierEditDto)
        {
            var res = new MessageModel<PuSupplierDto>();
            if (!await _pusupplierservices.ExistEntityAsync(a => a.Id == puSupplierEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            var entity = _mapper.Map<PuSupplier>(puSupplierEditDto);
            await _pusupplierservices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PuSupplierDto>(entity);
            return Ok(res);
        }

        private string CreateLink(PagedType pagedType, PuSupplierParams puSupplierParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(PuSupplierPaged), new
                    {
                        PageNum = puSupplierParams.PageNum - 1,
                        PageSize = puSupplierParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(PuSupplierPaged), new
                    {
                        PageNum = puSupplierParams.PageNum + 1,
                        PageSize = puSupplierParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}