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
    public class PrproductcategoryController : ControllerBase
    {
        //var model = HttpContext.User.Claims.Where(a => a.Type == "id").FirstOrDefault().Value;
        private readonly IMapper _mapper;
        private readonly IPrProductCategoryServices _prProductCategoryServices;

        public PrproductcategoryController(IMapper mapper, IPrProductCategoryServices prProductCategoryServices)
        {
            _mapper = mapper;
            _prProductCategoryServices = prProductCategoryServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductCategoryDto>>> GetPrProductCategorys()
        {
            var res = new MessageModel<IEnumerable<PrProductCategoryDto>>();
            var list = await _prProductCategoryServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<PrProductCategoryDto>>(list);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel<PrProductCategoryDto>>> AddPrProductCategory(PrProductCategoryAddDto prProductCategoryAddDto)
        {
            var res = new MessageModel<PrProductCategoryDto>();
            if (string.IsNullOrEmpty(prProductCategoryAddDto.Name))
            {
                res.Success = false;
                res.Code = 400;
                res.Msg = "请输入产品类型名称";
                return Ok(res);
            }
            var entity = _mapper.Map<PrProductCategory>(prProductCategoryAddDto);
            await _prProductCategoryServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<PrProductCategoryDto>(entity);
            return Ok(res);
        }
        [HttpDelete("{PrProductCategoryId}")]
        public async Task<ActionResult<MessageModel<string>>> DeletePrProductCategory(int PrProductCategoryId)
        {
            var res = new MessageModel<string>();
            if (!await _prProductCategoryServices.ExistEntityAsync(a => a.Id == PrProductCategoryId))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _prProductCategoryServices.DeleteEntityByIdAsync(PrProductCategoryId);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<MessageModel<PrProductCategoryDto>>> EditPrProductCategory(PrProductCategoryEditDto prProductCategoryEditDto)
        {
            var res = new MessageModel<PrProductCategoryDto>();
          
            if (!await _prProductCategoryServices.ExistEntityAsync(a => a.Id == prProductCategoryEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            if (string.IsNullOrEmpty(prProductCategoryEditDto.Name))
            {
                res.Success = false;
                res.Code = 400;
                res.Msg = "请输入产品类型名称";
                return Ok(res);
            }
            var Entity = _mapper.Map<PrProductCategory>(prProductCategoryEditDto);
            await _prProductCategoryServices.EditEntityAsync(Entity);
            res.Data = _mapper.Map<PrProductCategoryDto>(Entity);
            return Ok(res);
        }
    }
}
