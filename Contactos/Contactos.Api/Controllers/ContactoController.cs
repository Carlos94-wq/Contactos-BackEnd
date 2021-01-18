using AutoMapper;
using Contactos.Api.Response;
using Contactos.Core.Dto;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Services;
using Contactos.Core.QueryFilters;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoService service;
        private readonly IMapper mapper;

        public ContactoController(IContactoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ContactoQueryFilters filters)
        {
            var All = this.service.GetAll(filters);
            var Dto = this.mapper.Map<IEnumerable<IEnumerable<ContactoDto>>>(All);
            var response = new ApiResponse<IEnumerable<IEnumerable<ContactoDto>>>(Dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var All = await this.service.GetById(id);
            var Dto = this.mapper.Map<UsuarioDto>(All);
            var response = new ApiResponse<UsuarioDto>(Dto);

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
        public async Task<IActionResult> Post([FromBody] Contacto dto)
        {
            var resp = await this.service.Add(dto);
            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] ContactoDto dto)
        {
            var domain = this.mapper.Map<Contacto>(dto);
            var resp = await this.service.Update(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }
    }
}
