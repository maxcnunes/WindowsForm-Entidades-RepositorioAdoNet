using System.Collections.Generic;

namespace MDI_Escola.Repositorios
{

    /// <summary>
    /// Interface para o Repositorio de dados : Define contratos que as classes repositórios deverão implementar
    /// </summary>
    /// <typeparam name="T">Classe entidade referente ao repositório implementado</typeparam>
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Recuperar uma entidade do banco
        /// </summary>
        /// <param name="id">Código do registro no banco</param>
        /// <returns>Entidade carregada com os valores do banco</returns>
        T Obter(int id);

        /// <summary>
        /// Salvar um novo registro no banco
        /// </summary>
        /// <param name="entidade">Entidade com propriedades preenchidas, para ser inserida no banco</param>
        /// <returns>Sucesso da operação</returns>
        bool Inserir(T entidade);

        /// <summary>
        /// Remover registro do banco
        /// </summary>
        /// <param name="id">Código do registro no banco</param>
        /// <returns>Sucesso da operação</returns>
        bool Excluir(int id);

        /// <summary>
        /// Atualizar um registro no banco
        /// </summary>
        /// <param name="entidade">Entidade com propriedades preenchidas, para ser atualizada no banco</param>
        /// <returns>Sucesso da operação</returns>
        bool Atualizar(T entidade);

        /// <summary>
        /// Recuperar todos os registros da tabela no banco
        /// </summary>
        /// <returns>Lista de entidades referente a todos os registros encontrados na tabela no banco</returns>
        List<T> Todos();
    }
}
