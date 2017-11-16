using Domain;
using Repository.Base;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
	public class AuthorRepository : Repository<Author>, IAuthorRepository
	{
		public AuthorRepository(DbTIContext dbContext)
			: base(dbContext)
		{
		}
	}
}
