using AutoMapper;
using Domain.Entities.InfoModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Info;
using Service.Services.Interfaces;
using Web.Services.FileService;

namespace Web.Controllers
{
    public class InfoController : BaseController
    {
        private readonly IInfoService _service;
        private readonly IMapper _mapper;
        private readonly IFileService _file;
        private readonly ICurrentUserService _currentUser;
        public InfoController(IInfoService service,
            IMapper mapper,
            IFileService file,
            ICurrentUserService currentUser
            )
        {
            _service = service;
            _mapper = mapper;
            _file = file;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] InfoDto iCreate)
        {
            var entity = _mapper.Map<Info>(iCreate);
            entity.ImgUrl = await _file.SaveFile(iCreate.Photo);
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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetInfosWithTranslate();
            var dtos = _mapper.Map<List<InfoDto>>(entities);

            return Ok(dtos);
        }
    }
}
