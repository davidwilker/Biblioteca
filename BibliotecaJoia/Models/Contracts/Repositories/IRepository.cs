using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface IRepository<T, Y>
    {
        void Cadastrar(T endidade);
        List<T> Listar();
        T PesquisarPorId(Y id);
        void Atualizar(T endidade);
        void Excluir(Y id);
    }
}
