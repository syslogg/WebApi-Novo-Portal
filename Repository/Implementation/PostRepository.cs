using Domain;
using Repository.Base;
using Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation
{
	public class PostRepository : Repository<Post> , IPostRepository
    {
		public PostRepository(DbTIContext dbTIContext)
			: base(dbTIContext)
		{
		}

		public Post GetWithIncludes(int id)
		{
			return this._dbSet
				.Include(x => x.Author)
				.Include(x => x.Comments)
				.FirstOrDefault(x => x.Id == id);
		}
	}
}
