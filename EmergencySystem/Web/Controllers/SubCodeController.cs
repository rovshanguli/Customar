using AutoMapper;
using Domain.Entities.SubCodeModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.SubCode;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class SubCodeController : BaseController
    {
        private readonly ISubCodeService _service;
        private readonly IMapper _mapper;
        public SubCodeController(ISubCodeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] SubCodeDto subCodeCreate)
        {
            var entity = _mapper.Map<SubscriptionCode>(subCodeCreate);
            await _service.CreateAsync(entity);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] SubCodeDto subCodeUpdate)
        {
            var entity = _mapper.Map<SubscriptionCode>(subCodeUpdate);
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
            var dto = _mapper.Map<SubCodeDto>(entity);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<SubCodeDto>>(entities);
            return Ok(dtos);
        }
    }
}
