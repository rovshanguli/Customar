using AutoMapper;
using Domain.Entities.TicketStatusModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.TicketStatus;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class TicketStatusController : BaseController
    {
        private readonly ITicketStatusService _service;
        private readonly IMapper _mapper;


        public TicketStatusController(ITicketStatusService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] TSCreateDto tSCreate)
        {
            var entity = _mapper.Map<TicketStatus>(tSCreate);
            var data = await _service.CreateAsync(entity);
            return Ok(data);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TSUpdateDto tSUpdate)
        {
            var entity = _mapper.Map<TicketStatus>(tSUpdate);
            await _service.UpdateAsync(entity);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _service.GetAsync(id);
            await _service.DeleteAsync(entity);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var entity = await _service.GetAsync(id);
            var dto = _mapper.Map<TSGetDto>(entity);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<TSGetDto>>(entities);
            return Ok(dtos);
        }

        //Get ticketstatus by level
        [HttpGet]
        [Route("GetByLevel/{level}")]
        public async Task<IActionResult> GetByLevel([FromRoute] int level)
        {
            var entities = await _service.GetByLevelAsync(level);
            var dtos = _mapper.Map<List<TSGetDto>>(entities);
            return Ok(dtos);
        }

    }
}
