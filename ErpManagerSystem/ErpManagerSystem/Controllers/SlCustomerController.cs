using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Help;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos.Dto;
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
    }
}