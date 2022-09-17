using AutoMapper;
using Domain.Entities.Language;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Language;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _service;
        private readonly IMapper _mapper;
        public LanguageController(ILanguageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] LanguageDto lCreate)
        {
            var entity = _mapper.Map<Language>(lCreate);
            await _service.CreateAsync(entity);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] LanguageDto lUpdate)
        {
            var entity = _mapper.Map<Language>(lUpdate);
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
            var dto = _mapper.Map<LanguageDto>(entity);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<LanguageDto>>(entities);
            return Ok(dtos);
        }
    }
}
