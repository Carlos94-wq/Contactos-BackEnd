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
    public class CorreoController : ControllerBase
    {
        private readonly ICorreoService service;
        private readonly IMapper mapper;

        public CorreoController(ICorreoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var All = this.service.GetAll(id);
            var Dto = this.mapper.Map<IEnumerable<CorreoDto>>(All);
            var response = new ApiResponse<IEnumerable<CorreoDto>>(Dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var All = await this.service.GetById(id);
            var Dto = this.mapper.Map<CorreoDto>(All);
            var response = new ApiResponse<CorreoDto>(Dto);

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
        public async Task<IActionResult> Post([FromBody] List<CorreoDto> dto)
        {
            var domain = this.mapper.Map<List<Correo>>(dto);
            var resp = await this.service.Add(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] CorreoDto dto)
        {
            var domain = this.mapper.Map<Correo>(dto);
            var resp = await this.service.Update(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }
    }
}
