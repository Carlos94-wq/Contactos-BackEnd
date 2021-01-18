using Contactos.Api.Response;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
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
    public class CatalogoController : ControllerBase
    {
        private readonly IUnitOfWork work;

        public CatalogoController(IUnitOfWork work)
        {
            this.work = work;
        }

        [HttpGet]
        public IActionResult GetEstatus()
        {
            var estatus = this.work.CatalogoRepo.GetEstatus();
            var response = new ApiResponse<IEnumerable<Estatus>>(estatus);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var estatus = this.work.CatalogoRepo.GetRoles();
            var response = new ApiResponse<IEnumerable<Rol>>(estatus);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetipoCorreo()
        {
            var estatus = this.work.CatalogoRepo.tipoCorreos();
            var response = new ApiResponse<IEnumerable<TipoCorreo>>(estatus);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetTipoTelefono()
        {
            var estatus = this.work.CatalogoRepo.tipoTelefonos();
            var response = new ApiResponse<IEnumerable<TipoTelefono>>(estatus);

            return Ok(response);
        }

    }
}
