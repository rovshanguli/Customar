using AutoMapper;
using Domain.Entities.AppealTypeModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AppealType;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    public class AppealTypeController : BaseController
    {

        private readonly IAppealTypeService _appealTypeService;
        private readonly IMapper _mapper;
        public AppealTypeController(IAppealTypeService appealTypeService, IMapper mapper)
        {
            _appealTypeService = appealTypeService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var appealTypes = await _appealTypeService.GetAllWithTranslates();
            return Ok(appealTypes);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var appealType = await _appealTypeService.GetAsync(id);
            return Ok(appealType);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] AppealTypeDto appealTypeCreate)
        {
            var appealType = _mapper.Map<AppealType>(appealTypeCreate);
            var result = _appealTypeService.CreateAsync(appealType);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] AppealTypeDto appealTypeUpdate)
        {
            var appealType = _mapper.Map<AppealType>(appealTypeUpdate);
            _appealTypeService.UpdateAsync(appealType);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _appealTypeService.GetAsync(id);
            await _appealTypeService.DeleteAsync(entity);
            return Ok();
        }



    }
}
