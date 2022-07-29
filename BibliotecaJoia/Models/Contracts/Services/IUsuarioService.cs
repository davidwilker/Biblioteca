﻿using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface IUsuarioService : IGenericService<UsuarioDto, int>
    {
        UsuarioDto EfetuarLogin(UsuarioDto usuario);
    }
}
