using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Contactos.Core.Dto;
using Contactos.Core.Entities;

namespace Contactos.Infra.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario,UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Contacto, ContactoDto>();
            CreateMap<ContactoDto, Contacto>();

            CreateMap<Telefono, TelefonoDto>();
            CreateMap<TelefonoDto, Telefono>();

            CreateMap<Correo, CorreoDto>();
            CreateMap<CorreoDto, Correo>();
        }
    }
}
