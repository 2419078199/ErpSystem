using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SlCustomerController : ControllerBase
    {
        private readonly ISlCustomerServices _slCustomerServices;
        private readonly IMapper _mapper;

        public SlCustomerController(ISlCustomerServices slCustomerServices, IMapper mapper)
        {
            _slCustomerServices = slCustomerServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomerDto>>> GetCustomer()
        {
            MessageModel<IEnumerable<SlCustomerDto>> res = new MessageModel<IEnumerable<SlCustomerDto>>();
            List<SlCustomer> list = await _slCustomerServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<SlCustomerDto>>(list);
            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetCustomerById))]
        public async Task<ActionResult<SlCustomerDto>> GetCustomerById(int id)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(res.FailRequest(404,"请输入正确的Id"));
            }

            SlCustomer entity = await _slCustomerServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<MessageModel<SlCustomerDto>>> AddCustomer(SlCustomerAddDto slCustomerAddDto)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            SlCustomer entity = _mapper.Map<SlCustomer>(slCustomerAddDto);
            await _slCustomerServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return CreatedAtRoute(nameof(GetCustomerById), new {id = entity.Id}, res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteCustomer(int id)
        {
            MessageModel<string> res = new MessageModel<string>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }

            await _slCustomerServices.DeleteEntityByIdAsync(id);
            res.Data = "成功";
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<MessageModel<SlCustomerDto>>> EditCustomer(SlCustomerEditdDto slCustomerAddDto)
        {
            MessageModel<SlCustomerDto> res = new MessageModel<SlCustomerDto>();
            if (!await _slCustomerServices.ExistEntityAsync(a => a.Id == slCustomerAddDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }

            SlCustomer entity = _mapper.Map<SlCustomer>(slCustomerAddDto);
            await _slCustomerServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<SlCustomerDto>(entity);
            return Ok(res);
        }
    }
}