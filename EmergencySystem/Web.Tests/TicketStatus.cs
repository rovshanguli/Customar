using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.DTOs.TicketStatus;
using Service.Services.Interfaces;
using Web.Controllers;

namespace Web.Tests
{
    public class TicketStatus
    {
        [Fact]
        public void TicketStatusWhenNew()
        {
            var ticketStatus = new TSCreateDto
            {
                Icon = "icon",
                Level = 1,
                Translate = new List<TStatusTranslateDto>
                {
                    new TStatusTranslateDto
                    {
                        LangCode = "en",
                        Name = "name"
                    }
                },
                DateTime = DateTime.Now
            };
            Assert.Equal("icon", ticketStatus.Icon);
            Assert.Equal(1, ticketStatus.Level);
            Assert.Equal("en", ticketStatus.Translate[0].LangCode);
            Assert.Equal("name", ticketStatus.Translate[0].Name);
        }

        [Fact]
        public async Task CreateTicketStatus()
        {
            var ticketStatus = new TSCreateDto
            {
                Icon = "icon",
                Level = 1,
                Translate = new List<TStatusTranslateDto>
                {
                    new TStatusTranslateDto
                    {
                        LangCode = "en",
                        Name = "name"
                    }
                },
                DateTime = DateTime.Now
            };
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.Create(ticketStatus);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateTicketStatus()
        {
            var ticketStatus = new TSUpdateDto
            {
                Id = 1,
                Icon = "icon",
                Level = 1,
                Translate = new List<TStatusTranslateDto>
                {
                    new TStatusTranslateDto
                    {
                        LangCode = "en",
                        Name = "name"
                    }
                },
                DateTime = DateTime.Now
            };
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.Update(ticketStatus);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteTicketStatus()
        {
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.Delete(1);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetTicketStatus()
        {
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.Get(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllTicketStatus()
        {
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTicketStatusByLevel()
        {
            var mock = new Mock<ITicketStatusService>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketStatusController(mock.Object, mapper.Object);
            var result = await controller.GetByLevel(1);
            Assert.IsType<OkObjectResult>(result);
        }

    }
}