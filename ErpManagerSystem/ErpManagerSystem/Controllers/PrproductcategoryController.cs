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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PrproductcategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductCategoryServices _prProductCategoryServices;

        public PrproductcategoryController(IMapper mapper, IPrProductCategoryServices prProductCategoryServices)
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
            if (string.IsNullOrEmpty(prProductCategoryAddDto.Name))
            {
                return Ok(res.FailRequest(400, "Name不正确"));
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
        public async Task<ActionResult<MessageModel<PrProductCategoryDto>>> EditUserInfo(PrProductCategoryEditDto prProductCategoryEditDto)
        {
            MessageModel<PrProductCategoryDto> res = new MessageModel<PrProductCategoryDto>();
            if (!await _prProductCategoryServices.ExistEntityAsync(a => a.Id == prProductCategoryEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            if (string.IsNullOrEmpty(prProductCategoryEditDto.Name))
            {
                return Ok(res.FailRequest(400, "请输入产品类型"));
            }
            PrProductCategory entity = _mapper.Map<PrProductCategory>(prProductCategoryEditDto);
            await _prProductCategoryServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<PrProductCategoryDto>(entity);
            return Ok(res);
        }
    }
}