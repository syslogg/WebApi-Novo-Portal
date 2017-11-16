using Domain;
using Repository.Base;

namespace Repository.Interfaces
{
	public interface IPostRepository : IRepository<Post>
    {
		Post GetWithIncludes(int id);
    }
}
