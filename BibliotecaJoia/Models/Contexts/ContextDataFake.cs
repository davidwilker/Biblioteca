using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public class ContextDataFake : IContextData
    {

        private static List<Livro> livros = new List<Livro>();

        public ContextDataFake()
        {
            livros = new List<Livro>();
            InitializeData();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(livro.Id);
                livros.Remove(objPesquisa);

                objPesquisa.Nome = livro.Nome;
                objPesquisa.Editora = livro.Editora;
                objPesquisa.Autor = livro.Autor;

                CadastrarLivro(objPesquisa);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(Livro livro)
        {
            try
            {
                livros.Add(livro);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(string id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                livros.Remove(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivro()
        {

            try
            {
                return livros.OrderBy(p => p.Nome).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public Cliente PesquisarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public Livro PesquisarLivroPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario PesquisarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        private void InitializeData()
        {
            var livro = new Livro { Nome = "Implementando Dominio-Driver Design", Autor = "David Wilker", Editora = "Alta Books" };
            livros.Add(livro);

            livro = new Livro { Nome = "OS Vingadores", Autor = "João da Silva", Editora = "Marvel" };
            livros.Add(livro);

            livro = new Livro{ Nome = "Batman VS Superman", Autor = "George Lucas", Editora = "DC Comics"};
            livros.Add(livro);
            
            livro = new Livro{ Nome = "O Livro de Eli", Autor = "Claudia Magalhães", Editora = "Universal" };
            livros.Add(livro);

            livro = new Livro { Nome = "O Retorno do Rei", Autor = "Tim Maia", Editora = "Globo" };
            livros.Add(livro);
        }

    }
}
