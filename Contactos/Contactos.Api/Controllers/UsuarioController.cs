using AutoMapper;
using Contactos.Api.Response;
using Contactos.Core.CustonEntities;
using Contactos.Core.Dto;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Services;
using Contactos.Core.QueryFilters;
using Contactos.Core.Services;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService service;
        private readonly IMapper mapper;

        public UsuarioController( IUsuarioService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] UsuarioQueryFilters filters)
        {
            var All = this.service.GetAll(filters);
            var Dto = this.mapper.Map<IEnumerable<UsuarioDto>>(All);
            var response = new ApiResponse<IEnumerable<UsuarioDto>>(Dto);

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
        public async Task<IActionResult> Post([FromBody] UsuarioDto dto)
        {
            var domain = this.mapper.Map<Usuario>(dto);
            var resp = await this.service.Add(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] UsuarioDto dto)
        {
            var domain = this.mapper.Map<Usuario>(dto);
            var resp = await this.service.Update(domain);

            var response = new ApiResponse<bool>(resp);

            return Ok(response);
        }
    }
}
