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
    public class PrProductTaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrProductTaskServices _prProductTaskServices;
        private readonly IAcUserInfoServices _acUserInfoServices;
        private readonly IAcStaffServices _acStaffServices;
        private readonly ISlOrderServices _slOrderServices;

        public PrProductTaskController(IMapper mapper, IPrProductTaskServices prProductTaskServices, IAcUserInfoServices acUserInfoServices,IAcStaffServices acStaffServices,ISlOrderServices slOrderServices)
        {
            _mapper = mapper;
            _prProductTaskServices = prProductTaskServices;
            _acUserInfoServices = acUserInfoServices;
            _acStaffServices = acStaffServices;
            _slOrderServices = slOrderServices;
        }
        [HttpGet]
        public async Task<ActionResult<MessageModel<List<string>>>> GetOdernos()
        {
            MessageModel<List<string>> res = new MessageModel<List<string>>();
            var listno = await _slOrderServices.GetEntitys(u => true).ToListAsync();
            var tasks = await _prProductTaskServices.GetEntitys(u => true).ToListAsync();
            List<string> tasknos = new List<string>();
            foreach (var item in tasks)
            {
                tasknos.Add(item.No);
            }
            List<string> nos = new List<string>();
            foreach (var item in listno)
            {
                if (!tasknos.Contains(item.No))
                {
                    nos.Add(item.No);
                }
            }
            res.Data = nos;
            return Ok(res);
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
            string uid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var userentity = await _acUserInfoServices.GetEntityByIdAsync(int.Parse(uid));
            var staffentity = await _acStaffServices.GetEntityByIdAsync(int.Parse(userentity.StaffId.ToString()));
            var res = new MessageModel<PrProductTaskDto>();
            prProductTaskAddDto.Batch = DateTime.Now.ToString("yyyyMMddHHmmss");
            prProductTaskAddDto.OperatorId = userentity.StaffId;
            prProductTaskAddDto.OperateTime = DateTime.Now;
            prProductTaskAddDto.DepartmentId = staffentity.DepartmentId;
            prProductTaskAddDto.Status = 0;
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