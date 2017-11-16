using Domain;
using Repository.Base;
using Repository.Interfaces;

namespace Repository.Implementation
{
	public class CommentRepository : Repository<Comment>, ICommentRepository
	{
		public CommentRepository(DbTIContext dbContext)
			: base(dbContext)
		{
		}
	}
}
