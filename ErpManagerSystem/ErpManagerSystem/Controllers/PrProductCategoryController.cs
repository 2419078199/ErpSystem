using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PrProductCategoryController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductCategoryServices _prProductCategoryServices;

        public PrProductCategoryController(IMapper mapper, IPrProductCategoryServices prProductCategoryServices)
        {
            this._mapper = mapper;
            this._prProductCategoryServices = prProductCategoryServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductCategoryDto>>> GetPrProductCategoryInfo()
        {
            var res = new MessageModel<IEnumerable<PrProductCategoryDto>>();
            var list = await _prProductCategoryServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PrProductCategoryDto>>(list);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel<PrProductCategoryDto>>> AddPrProductCategoryInfo(PrProductCategoryAddDto prProductCategoryAddDto)
        {
            var res = new MessageModel<PrProductCategoryDto>();
            var entity = _mapper.Map<PrProductCategory>(prProductCategoryAddDto);
            await _prProductCategoryServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<PrProductCategoryDto>(entity);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeletePrProductCategory(int id)
        {
            var res = new MessageModel<string>();
            if (!await _prProductCategoryServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _prProductCategoryServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<MessageModel<PrProductCategoryDto>>> EditUserInfo(AcUserInfoEditDto acUserInfoEditDto)
        {
            MessageModel<PrProductCategoryDto> res = new MessageModel<PrProductCategoryDto>();
            if (!await _prProductCategoryServices.ExistEntityAsync(a => a.Id == acUserInfoEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            PrProductCategory entity = _mapper.Map<PrProductCategory>(acUserInfoEditDto);
            await _prProductCategoryServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PrProductCategoryDto>(entity);
            return Ok(res);
        }
    }
}
