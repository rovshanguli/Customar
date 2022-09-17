using AutoMapper;
using Domain.Entities.TicketModels;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Ticket;
using Service.Services.Interfaces;
using System.Text;

namespace Web.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _service;
        private readonly IAppealService _appealService;
        private readonly IMapper _mapper;
        public TicketController(ITicketService service, IMapper mapper, IAppealService appealService)
        {
            _service = service;
            _mapper = mapper;
            _appealService = appealService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<TicketGetDto>>(entities);
            return Ok(dtos);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var entity = await _service.GetAsync(id);
            var dto = _mapper.Map<TicketGetDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] TicketCreateDto ticketCreate)
        {

            StringBuilder _builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(8)
                .ToList().ForEach(e => _builder.Append(e));
            var id = _builder.ToString();
            ticketCreate.TicketId = id;
            var entity = _mapper.Map<Ticket>(ticketCreate);
            await _service.CreateAsync(entity);

            foreach (var appealId in ticketCreate.AppealsId)
            {
                var appeal = _appealService.GetAsync(appealId);
                appeal.Result.TicketId = id;
                await _appealService.UpdateAsync(appeal.Result);
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TicketUpdateDto ticketUpdate)
        {
            var entity = _mapper.Map<Ticket>(ticketUpdate);
            await _service.UpdateAsync(entity);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var entity = await _service.GetAsync(id);
            await _service.SoftDeleteAsync(entity);
            return Ok();
        }



        [HttpPost]
        [Route("CreateId")]
        public IActionResult CreateId()
        {
            var list = new List<string>();
            for (int i = 0; i < 100000000; i++)
            {
                StringBuilder _builder = new StringBuilder();
                Enumerable
                    .Range(65, 26)
                    .Select(e => ((char)e).ToString())
                    .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                    .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                    .OrderBy(e => Guid.NewGuid())
                    .Take(8)
                    .ToList().ForEach(e => _builder.Append(e));
                var id = _builder.ToString();

                list.Add(id);
            }

            List<string> duplicates = list.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            return Ok(duplicates);
        }


    }
}
