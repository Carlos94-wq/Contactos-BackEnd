using AutoMapper;
using Contactos.Api.Response;
using Contactos.Core.Dto;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactos.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoService service;
        private readonly IMapper mapper;

        public TelefonoController(ITelefonoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var All = this.service.GetAll(id);
            var Dto = this.mapper.Map<IEnumerable<TelefonoDto>>(All);
            var response = new ApiResponse<IEnumerable<TelefonoDto>>(Dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var All = await this.service.GetById(id);
            var Dto = this.mapper.Map<TelefonoDto>(All);
            var response = new ApiResponse<TelefonoDto>(Dto);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var resp = await this.service.Delete(id);
            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<TelefonoDto> dto)
        {
            var domain = this.mapper.Map<List<Telefono>>(dto);
            var resp = await this.service.Add(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] Telefono dto)
        {
            var domain = this.mapper.Map<Telefono>(dto);
            var resp = await this.service.Update(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }
    }
}
