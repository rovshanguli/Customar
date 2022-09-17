using AutoMapper;
using Domain.Entities.AppealModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Appeal;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class AppealController : BaseController
    {
        private readonly IAppealService _service;
        private readonly IAppealTypeService _appealTypeService;

        private readonly IMapper _mapper;
        public AppealController(IAppealService service, IMapper mapper, IAppealTypeService appealTypeService)
        {
            _service = service;
            _mapper = mapper;
            _appealTypeService = appealTypeService;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AppealDto appealCreate)
        {
            var entity = _mapper.Map<Appeal>(appealCreate);
            entity.AppealTypes = await _appealTypeService.GetAllWithId(appealCreate.AppealTypes);
            await _service.CreateAsync(entity);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] AppealDto appealUpdate)
        {
            var entity = _mapper.Map<Appeal>(appealUpdate);
            await _service.UpdateAsync(entity);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _service.GetAsync(id);
            await _service.SoftDeleteAsync(entity);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var entity = await _service.GetAsync(id);
            var dto = _mapper.Map<AppealDto>(entity);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<AppealDto>>(entities);
            return Ok(dtos);
        }

        [HttpGet]
        [Route("GetAllPaginate")]
        public async Task<IActionResult> GetAllPaginate([FromQuery] int page, [FromQuery] int pageSize)
        {
            var entities = await _service.GetAllPaginate(page, pageSize);
            var dtos = _mapper.Map<List<AppealDto>>(entities);
            return Ok(dtos);
        }

    }
}
