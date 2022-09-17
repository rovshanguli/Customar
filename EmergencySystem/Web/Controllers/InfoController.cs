using AutoMapper;
using Domain.Entities.InfoModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Info;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class InfoController : BaseController
    {
        private readonly IInfoService _service;
        private readonly IMapper _mapper;
        public InfoController(IInfoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] InfoDto iCreate)
        {
            var entity = _mapper.Map<Info>(iCreate);
            await _service.CreateAsync(entity);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] InfoDto iUpdate)
        {
            var entity = _mapper.Map<Info>(iUpdate);
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
            var dto = _mapper.Map<InfoDto>(entity);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<InfoDto>>(entities);
            return Ok(dtos);
        }
    }
}
