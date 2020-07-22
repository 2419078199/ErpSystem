using AutoMapper;
using Common.Help;
using IServices;
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
    public class AcDepartmentController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAcDepartmentServices _acDepartmentServices;

        public AcDepartmentController(IMapper mapper, IAcDepartmentServices acDepartmentServices)
        {
            _mapper = mapper;
            _acDepartmentServices = acDepartmentServices;
        }
        //查询部门表所有数据
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartmentDto>>> GetAcDepartment()
        {
            var res = new MessageModel<IEnumerable<AcDepartmentDto>>();
            var list = await _acDepartmentServices.GetEntitys().ToListAsync();
            res.Data = _mapper.Map<IEnumerable<AcDepartmentDto>>(list);
            return Ok(res);
        }
        //根据ID查询部门表数据
        [HttpGet("{id}", Name = nameof(GetAcDepartmentById))]
        public async Task<ActionResult<IEnumerable<AcDepartmentDto>>> GetAcDepartmentById(int id)
        {
            MessageModel<AcDepartmentDto> res = new MessageModel<AcDepartmentDto>();
            if (!await _acDepartmentServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcDepartment entity = await _acDepartmentServices.GetEntityByIdAsync(id);
            res.Data = _mapper.Map<AcDepartmentDto>(entity);
            return Ok(res);
        }
        //增加部门表数据
        [HttpPost]
        public async Task<ActionResult<MessageModel<AcDepartmentDto>>> AddUserInfo(AcDepartmentAddDto departmentAddDto)
        {
            var res = new MessageModel<AcDepartmentDto>();
            var entity = _mapper.Map<AcDepartment>(departmentAddDto);
            await _acDepartmentServices.AddEntityAsync(entity);
            res.Data = _mapper.Map<AcDepartmentDto>(entity);
            return CreatedAtRoute(nameof(GetAcDepartmentById), new { id = entity.Id }, res.Data);
        }
        //删除部门表数据
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel<string>>> DeleteAcDepartment(int id)
        {
            var res = new MessageModel<string>();
            if (!await _acDepartmentServices.ExistEntityAsync(a => a.Id == id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            await _acDepartmentServices.DeleteEntityByIdAsync(id);
            return Ok(res);
        }
        //修改部门表数据
        [HttpPut]
        public async Task<ActionResult<MessageModel<AcDepartmentDto>>> EditUserInfo(AcDepartmentEditDto departmentEditDto)
        {
            MessageModel<AcDepartmentDto> res = new MessageModel<AcDepartmentDto>();
            if (!await _acDepartmentServices.ExistEntityAsync(a => a.Id == departmentEditDto.Id))
            {
                return NotFound(StyleCode.NotFound(res));
            }
            AcDepartment entity = _mapper.Map<AcDepartment>(departmentEditDto);
            await _acDepartmentServices.EditEntityAsync(entity);
            res.Data = _mapper.Map<AcDepartmentDto>(entity);
            return Ok(res);
        }
    }
}
