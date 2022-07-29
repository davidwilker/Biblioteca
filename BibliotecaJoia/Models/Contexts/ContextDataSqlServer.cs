using BibliotecaJoia.Models.Contracts.Contexts;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Dtos;
using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using BibliotecaJoia.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public class ContextDataSqlServer : IContextData
    {

        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        #region Contexto de Cliente
        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.Cpf;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@statuClienteId", SqlDbType.VarChar).Value = cliente.StatusCliente.GetHashCode();

                command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.Cpf;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@statusClienteId", SqlDbType.VarChar).Value = cliente.StatusCliente.GetHashCode();

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void ExcluirCliente(string id)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public List<Cliente> ListarClientes()
        {
            var clientes = new List<Cliente>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusCliente = colunas[5].ToString();

                    var cliente = new Cliente { Id = id, Nome = nome, Cpf = cpf, Email = email, Fone = fone, StatusClienteId = statusCliente.GetHashCode() };
                    clientes.Add(cliente);
                }

                adapter = null;
                dataset = null;

                return clientes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente PesquisarClientePorId(string id)
        {
            try
            {
                Cliente cliente = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusCliente = colunas[5].ToString();

                    cliente = new Cliente { Id = codigo, Nome = nome, Cpf = cpf, Email = email, Fone = fone, StatusClienteId = Int32.Parse(statusCliente.ToString()) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusdDoClientePeloId(cliente.StatusClienteId);
                }
                return cliente;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        #endregion

        #region Contexto de Livros
        public void AtualizarLivro(Livro livro)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void CadastrarLivro(Livro livro)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
                command.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = livro.StatusLivro.GetHashCode();

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void ExcluirLivro(string id)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public List<Livro> ListarLivro()
        {
            var livros = new List<Livro>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);
                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    var livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora };
                    livros.Add(livro);
                }

                adapter = null;
                dataset = null;

                return livros;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public Livro PesquisarLivroPorId(string id)
        {
            try
            {
                Livro livro = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    livro = new Livro { Id = codigo, Nome = nome, Autor = autor, Editora = editora };
                }
                return livro;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        #endregion

        #region Contexto de Usuarios
        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();

                var query = SqlManager.GetSql(TSql.ATUALIZAR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {

                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }   
        public void ExcluirUsuario(int id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public List<Usuario> ListarUsuarios()
        {
            var usuarios = new List<Usuario>();

            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_USUARIO);
                var command = new SqlCommand(query, _connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    var usuario = new Usuario { Id = id, Login = login, Senha = senha };
                    usuarios.Add(usuario);
                }

                adapter = null;
                dataset = null;
                
                return usuarios;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Usuario PesquisarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuario = null;
                var query = SqlManager.GetSql(TSql.PESQUISAR_USUARIO);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var coluna = item.ItemArray;

                    var codigo = int.Parse(coluna[0].ToString());
                    var login = coluna[1].ToString();
                    var senha = coluna[2].ToString();

                    usuario = new Usuario { Id = codigo, Login = login, Senha = senha };
                }

                dataset = null;
                adapter = null;

                return usuario;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            try
            {
                var query = SqlManager.GetSql(TSql.EFETUAR_LOGIN);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var coluna = item.ItemArray;

                    var id = Int32.Parse(coluna[0].ToString());
                    var login = coluna[1].ToString();

                    usuario = new UsuarioDto { Id = id, Login = login };
                }

                adapter = null;
                dataset = null;

                return usuario;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
