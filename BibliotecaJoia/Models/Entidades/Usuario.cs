using BibliotecaJoia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public UsuarioDto ConverterParaDto()
        {
            return new UsuarioDto
            {
                Id = this.Id,
                Login = this.Login,
                Senha = this.Senha
            };
        }

    }

}
