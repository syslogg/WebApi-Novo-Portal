using Domain;
using Repository.Base;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(DbTIContext dbContext)
			: base(dbContext)
		{
		}
	}
}
