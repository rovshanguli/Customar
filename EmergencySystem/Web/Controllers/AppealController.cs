using AutoMapper;
using Domain.Entities.AppealModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Appeal;
using Service.Services.Interfaces;
using UploadStream;
using Web.Services.FileService;

namespace Web.Controllers
{
    public class AppealController : BaseController
    {

        [TempData]
        public int AppealId { get; set; } = 2;
        private readonly IAppealService _service;
        private readonly IAppealTypeService _appealTypeService;
        private readonly ILogger<AppealController> _logger;
        private readonly IMapper _mapper;
        private readonly IFileService _file;
        public AppealController(IAppealService service,
            IMapper mapper,
            IAppealTypeService appealTypeService,
            ILogger<AppealController> logger,
            IFileService file
            )
        {
            _service = service;
            _mapper = mapper;
            _appealTypeService = appealTypeService;
            _logger = logger;
            _file = file;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AppealDto appealCreate)
        {
            var entity = _mapper.Map<Appeal>(appealCreate);
            entity.AppealTypes = await _appealTypeService.GetAllWithId(appealCreate.AppealTypes);
            var data = await _service.CreateAsync(entity);
            AppealId = data.Id;
            return Ok(data.Id);
        }


        [HttpPost]
        [Route("AddFile")]
        public async Task<IActionResult> AddFile()
        {
            var appeal = await _service.GetAsync(AppealId);

            var url = "";
            await this.StreamFiles(async x =>
            {
                if (x.ContentType.Contains("image"))
                {
                    var appeal = await _service.GetAsync(AppealId);
                    url = await _file.SaveStreamFile(x);
                    appeal.PhotoUrl = url;
                    await _service.UpdateAsync(appeal);
                }


                if (x.ContentType.Contains("audio"))
                {
                    var appeal = await _service.GetAsync(AppealId);
                    appeal.AudioUrl = await _file.SaveStreamFile(x);
                    await _service.UpdateAsync(appeal);
                }

                if (x.ContentType.Contains("video"))
                {
                    var appeal = await _service.GetAsync(AppealId);
                    appeal.VideoUrl = await _file.SaveStreamFile(x);
                    await _service.UpdateAsync(appeal);
                }
            });


            return Ok(url);
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
            var entity = await _service.GetWithAppealTypes(id);

            var dto = _mapper.Map<AppealGetDto>(entity);
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
