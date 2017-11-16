using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Base
{
	public interface IRepository<T> where T : Entity
	{
		/// <summary>
		/// Retorna <see cref="T"/> a partir do Id
		/// </summary>
		/// <param name="id">Id de <see cref="T"/></param>
		/// <returns>retorna <see cref="T"/></returns>
		T Get(int id);

		/// <summary>
		/// Retorna a lista de <see cref="T"/> de acordo com o predicado
		/// </summary>
		List<T> Find(Func<T, bool> predicate);

		/// <summary>
		/// Retorna todos os registros
		/// </summary>
		IEnumerable<T> ListAll();

		/// <summary>
		/// Atualiza dados da entidade <see cref="T"/>
		/// </summary>
		/// <param name="entity">Passar <see cref="T"/> com Id diferente de 0</param>
		bool Update(T entity);

		/// <summary>
		/// Adiciona dados na entidade <see cref="T"/>
		/// </summary>
		/// <param name="entity">Passar <see cref="T"/> com Id igual a 0</param>
		void Add(T entity);

		/// <summary>
		/// Deleta dados da entidade
		/// </summary>
		/// <param name="id">Passar o Id</param>
		void Delete(T entity);

	}
}
