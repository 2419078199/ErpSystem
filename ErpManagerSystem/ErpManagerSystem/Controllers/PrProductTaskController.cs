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
    public class PrProductTaskController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductTaskServices _prProductTaskServices;

        public PrProductTaskController(IMapper mapper, IPrProductTaskServices prProductTaskServices)
        {
            _mapper = mapper;
            _prProductTaskServices = prProductTaskServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductTaskDto>>> GetPrProductTasks([FromQuery] PrProductTaskParams prProductTaskParams)
        {
            var res = new MessageModel<IEnumerable<PrProductTaskDto>>();
            var list = await _prProductTaskServices.GetPrProductTaskPaged(prProductTaskParams);
            string previousLink = list.HasPrevious ? CreateLink(PagedType.Previous, prProductTaskParams) : null;
            string nextLink = list.HasNext ? CreateLink(PagedType.Next, prProductTaskParams) : null;
            var pagination = new
            {
                currentPage = list.PageNum,
                totalPage = list.TotalPage,
                totalCount = list.TotalCount,
                previousLink,
                nextLink
            };
            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            res.Data = _mapper.Map<IEnumerable<PrProductTaskDto>>(list);
            return Ok(res);
        }
        [HttpGet("{id}", Name = nameof(GetPrProductTasksById))]
        public async Task<ActionResult<IEnumerable<PrProductTaskDto>>> GetPrProductTasksById(int id)
        {
            var res = new MessageModel<PrProductTaskDto>();
            if (!await _prProductTaskServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            PrProductTask entity = await _prProductTaskServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PrProductTaskDto>(entity);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel<PrProductTaskDto>>> AddPrProductTask(PrProductTaskAddDto prProductTaskAddDto)
        {
            var res = new MessageModel<PrProductTaskDto>();
            var entity = _mapper.Map<PrProductTask>(prProductTaskAddDto);
            await _prProductTaskServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<PrProductTaskDto>(entity);
            return Ok(res);
        }

        [HttpDelete("{PrProductTaskId}")]
        public async Task<ActionResult<MessageModel<string>>> DeletePrProductTask(int PrProductTaskId)
        {
            var res = new MessageModel<string>();
            if (!await _prProductTaskServices.ExistEntityAsync(a => a.Id == PrProductTaskId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _prProductTaskServices.DeleteEntityByIdAsync(PrProductTaskId);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<PrProductTaskDto>>> EditPrProductTask(PrProductTaskEditDto prProductTaskEditDto)
        {
            var res = new MessageModel<PrProductTaskDto>();
            if (!await _prProductTaskServices.ExistEntityAsync(a => a.Id == prProductTaskEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            PrProductTask entity = _mapper.Map<PrProductTask>(prProductTaskEditDto);
            await _prProductTaskServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PrProductTaskDto>(entity);
            return Ok(res);
        }
        private string CreateLink(PagedType pagedType, PrProductTaskParams prProductTaskParams)
        {
            switch (pagedType)
            {
                case PagedType.Previous:
                    return Url.Link(nameof(GetPrProductTasks), new
                    {
                        PageNum = prProductTaskParams.PageNum - 1,
                        PageSize = prProductTaskParams.PageSize
                    });

                case PagedType.Next:
                    return Url.Link(nameof(GetPrProductTasks), new
                    {
                        PageNum = prProductTaskParams.PageNum + 1,
                        PageSize = prProductTaskParams.PageSize
                    });
            }
            return string.Empty;
        }
    }
}
