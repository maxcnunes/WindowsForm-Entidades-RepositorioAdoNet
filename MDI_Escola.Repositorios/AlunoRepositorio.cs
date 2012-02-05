using System;
using System.Collections.Generic;
using System.Linq;
using MDI_Escola.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace MDI_Escola.Repositorios
{
    public class AlunoRepositorio : RepositorioBase, IRepositorio<Aluno>
    {
        /// <summary>
        /// Obter aluno : Recupera registro do aluno no banco e retorna o objeto aluno
        /// </summary>
        /// <param name="id">Codigo do aluno</param>
        /// <returns>Entidade aluno</returns>
        public Aluno Obter(int id)
        {
            //Define comando SQL
            var comando = new SqlCommand
                              {
                                  CommandText = "SELECT * FROM alunos WHERE id = @id"
                              };

            //Define obj aluno como null
            Aluno aluno = null;

            try
            {
                //Cria objeto de conexao com o banco
                using (comando.Connection = CriarConexao())
                {
                    //Abre conexao com o banco
                    comando.Connection.Open();

                    //Passa paremetro para o comando SQL
                    comando.Parameters.Add(new SqlParameter("id", id));

                    //Executa comando SQL, para leitura dos registros
                    var reader = comando.ExecuteReader();

                    //Le o resultado, linha a linha
                    while (reader.Read())
                    {
                        //Carrega objeto aluno com os valores retornado do banco
                        aluno = new Aluno
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Email = (string)reader["email"],
                            Telefone = (string)reader["telefone"],
                            Endereco = (string)reader["endereco"],
                            Ativo = (bool)reader["ativo"],
                            Genero = (int)reader["genero"]
                        };
                    }
                    //Libera os recursos de leitura
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao retornar aluno do banco. Msg: " + ex.Message);
            }
            finally
            {
                comando.Dispose();
            }
            return aluno;
        }

        /// <summary>
        /// Inserir aluno: Insere um novo registro no banco na tabela de alunos
        /// </summary>
        /// <param name="entidade">Objeto aluno</param>
        /// <returns>Sucesso da operação</returns>
        public bool Inserir(Aluno entidade)
        {
            //Define comando SQL
            var comando = new SqlCommand
                              {
                                  CommandText = "INSERT INTO alunos " +
                                                "VALUES(@nome,@email,@telefone,@endereco,@genero,@ativo)"
                              };

            try
            {
                //Cria objeto de conexao com o banco
                using (comando.Connection = CriarConexao())
                {
                    //Abre a conexao com o banco
                    comando.Connection.Open();

                    //Definindo valores para os parametros do comando SQL
                    comando.Parameters.Add(new SqlParameter("nome", entidade.Nome));
                    comando.Parameters.Add(new SqlParameter("email", entidade.Email));
                    comando.Parameters.Add(new SqlParameter("telefone", entidade.Telefone));
                    comando.Parameters.Add(new SqlParameter("endereco", entidade.Endereco));
                    comando.Parameters.Add(new SqlParameter("genero", entidade.Genero));
                    comando.Parameters.Add(new SqlParameter("ativo", entidade.Ativo));

                    //Executa o comando
                    comando.ExecuteNonQuery();

                    //Retorna operaçao realizada com sucesso
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Dispara uma exceçao caso algum problema ocorra
                throw new ArgumentException("Erro ao inserir. Msg:" + ex.Message);
            }
            finally
            {
                //Libera os recursos
                comando.Dispose();
            }
        }

        /// <summary>
        /// Excluir aluno: Remove registro do aluno do banco
        /// </summary>
        /// <param name="id">Codigo do aluno</param>
        /// <returns>Sucesso da operação</returns>
        public bool Excluir(int id)
        {
            //Define comando SQL
            var comando = new SqlCommand
                              {
                                  CommandText = "DELETE FROM alunos WHERE id = @id"
                              };
            try
            {
                //Cria objeto de conexao com o banco
                using (comando.Connection = CriarConexao())
                {
                    //Abre conexao com o banco
                    comando.Connection.Open();

                    //Adiciona os parametros do comando SQL
                    comando.Parameters.Add(new SqlParameter("id", id));

                    //Executa comando
                    comando.ExecuteNonQuery();

                    //Retorna operacao realizada com sucesso
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Dispara uma exceçao caso algum problema ocorra
                throw new ArgumentException("Erro ao excluir aluno. Msg: " + ex.Message);
            }
            finally
            {
                //Libera os recursos
                comando.Dispose();
            }
        }

        /// <summary>
        /// Atualizar aluno: Atualiza informações do aluno no banco
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns>Sucesso da operação</returns>
        public bool Atualizar(Aluno entidade)
        {
            //Define o comando SQL
            var comando = new SqlCommand
                              {
                                  CommandText = "UPDATE alunos SET " +
                                                "nome = @nome, " +
                                                "email = @email, " +
                                                "telefone = @telefone, " +
                                                "endereco = @endereco, " +
                                                "genero = @genero, " +
                                                "ativo = @ativo, " +
                                                "where id = @id "
                              };

            try
            {
                //Cria objeto de conexao com o banco
                using (comando.Connection = CriarConexao())
                {
                    //Abre a conexao com o banco
                    comando.Connection.Open();

                    //Adiciona os parametros do comando SQL
                    comando.Parameters.Add(new SqlParameter("id", entidade.Id));
                    comando.Parameters.Add(new SqlParameter("nome", entidade.Nome));
                    comando.Parameters.Add(new SqlParameter("email", entidade.Email));
                    comando.Parameters.Add(new SqlParameter("telefone", entidade.Telefone));
                    comando.Parameters.Add(new SqlParameter("endereco", entidade.Endereco));
                    comando.Parameters.Add(new SqlParameter("genero", entidade.Genero));
                    comando.Parameters.Add(new SqlParameter("ativo", entidade.Ativo));

                    //Executa comaando
                    comando.ExecuteNonQuery();

                    //Retorna operacao realizada com sucesso
                    return true;
                }
            }
            catch(Exception ex)
            {
                //Dispara uma exceçao caso uma problema ocorra
                throw new ArgumentException("Erro ao executar comando no banco. Msg:" + ex.Message);
            }
            finally
            {
                comando.Dispose();
            }
        }

        /// <summary>
        /// Todos alunos: Recupera a lista total alunos do banco
        /// </summary>
        /// <returns>Lista com todos os alunos registrados</returns>
        public List<Aluno> Todos()
        {
            //Define comando SQL
            var comando = new SqlCommand
            {
                CommandText = "SELECT * FROM alunos"
            };

            //Cria um a lista vazia de alunos
            var listaAlunos = new List<Aluno>();

            //Cria um objeto de conexao com o banco
            using (comando.Connection = CriarConexao())
            {
                //Abre conexao com o banco
                comando.Connection.Open();

                //Executa comando SQL, para leitura dos registros
                var reader = comando.ExecuteReader();

                //Carrega objeto aluno com os valores retornado do banco
                while (reader.Read())
                {
                    //Carrega objeto aluno com os valores retornado do banco
                    var alunodb = new Aluno
                                      {
                                          Id = (int)reader["id"],
                                          Nome = (string)reader["nome"],
                                          Email = (string)reader["email"],
                                          Telefone = (string)reader["telefone"],
                                          Endereco = (string)reader["endereco"],
                                          Genero = (int)reader["genero"],
                                          Ativo = (bool)reader["ativo"]
                                      };

                    //Adiciona objeto aluno a lista
                    listaAlunos.Add(alunodb);
                }

                //Libera recursos
                reader.Dispose();
                comando.Dispose();
            }
            return listaAlunos;
        }

        /// <summary>
        /// Verifica se o nome preenchido está disponível para cadastro
        /// </summary>
        /// <param name="nome">Nome do aluno</param>
        /// <param name="id">Codigo do aluno</param>
        /// <returns>Disponibilidade para cadastro</returns>
        public bool VerificarNomeDisponivel(string nome, int id)
        {
            //Define o comando SQL
            var comando = new SqlCommand
                            {
                                CommandText = "PR_VerificarNomeDisponivel",
                                CommandType = CommandType.StoredProcedure
                            };

            try
            {
                //Cria obj de conexao com o banco
                using (comando.Connection = CriarConexao())
                {
                    //Abre conexao com o banco
                    comando.Connection.Open();

                    //Passa o parametro para a PROC
                    comando.Parameters.Add(new SqlParameter("NOME", nome));
                    comando.Parameters.Add(new SqlParameter("ID", id));

                    //Recupera a primeira coluna da primeira linha do resultado
                    //Nesse caso o id do aluno
                    var resultado = comando.ExecuteScalar();

                    //Retorna verdadeiro se nao existir um aluno com esse nome ja cadsrado
                    if (resultado == null)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                //Dispara uma msg de erro, caso ocorra algum problema na execuçao do codigo
                throw new ArgumentException("Erro ao verificar disponibilidade de nome. Msg:" + ex.Message);
            }
            finally
            {
                //Libera os recursos utilizados
                comando.Dispose();
            }
        }
    }
}
