﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface IGenericService<T, Y>
    {
        void Cadastrar(T entidade);
        List<T> Listar();
        T PesquisarPorId(Y id);
        void Atualizar(T usuario);
        void Excluir(Y id);
    }
}
