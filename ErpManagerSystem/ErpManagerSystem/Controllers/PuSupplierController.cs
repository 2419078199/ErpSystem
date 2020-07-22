using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Entitys;

namespace ErpManagerSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// 获取经销商信息
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
        /// 通过Id获取经销商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}",Name =nameof(PuSupplierById))]
        public async Task<ActionResult<PuSupplierDto>> PuSupplierById(int id)
        {
            MessageModel<PuSupplierDto> res = new MessageModel<PuSupplierDto>();
            PuSupplier pusupplier = await _pusupplierservices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<PuSupplierDto>(pusupplier);
            return Ok(res);
        }


        /// <summary>
        /// 添加经销商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageModel<PuSupplierAddDto>>> CreatePuSupplier(PuSupplierAddDto puSupplierAddDto)
        {
            MessageModel<PuSupplierAddDto> res = new MessageModel<PuSupplierAddDto>();

            PuSupplier entity = _mapper.Map<PuSupplier>(puSupplierAddDto);

            await _pusupplierservices.AddEntityAsync(entity);

            res.Data = _mapper.Map<PuSupplierAddDto>(entity);

            return CreatedAtRoute(nameof(PuSupplierById), new { id = entity.Id }, res); 
        }


       
    }
}
