﻿using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public int StatusClienteId { get; set; }
        public StatusCliente StatusCliente { get; set; }
        public void Cadastrar()
        {
            this.StatusCliente = StatusCliente.ATIVO;
            this.StatusClienteId = StatusCliente.GetHashCode();
        }
        public ClienteDto ConverterParaDto()
        {
            return new ClienteDto
            {
                Id = this.Id,
                Nome = this.Nome,
                Cpf = this.Cpf,
                Email = this.Email,
                Fone = this.Fone,
                StatusClienteId = this.StatusClienteId.ToString(),
                Status = GerenciadorDeStatus.PesquisarStatusdDoClientePeloId(this.StatusClienteId).ToString()
            };
        }

    }
}
