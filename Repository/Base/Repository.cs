using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Base;

namespace Repository.Base
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{

		private readonly DbTIContext _dbContext;
		protected DbSet<T> _dbSet;

		public Repository(DbTIContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}
		public void Delete(T entity)
		{
			_dbSet.Attach(entity);
			_dbSet.Remove(entity);
		}

		public List<T> Find(Func<T, bool> predicate)
		{
			return _dbSet.Where(predicate).ToList();
		}
		public T Get(int id)
		{
			return _dbSet.Find(id);
		}

		public IEnumerable<T> ListAll()
		{
			return _dbSet;
		}

		public bool Update(T entity)
		{
			_dbSet.Update(entity);
			return true;
		}
	}
}
