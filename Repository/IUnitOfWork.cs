using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
		IPostRepository PostRepository { get; }
		IAuthorRepository AuthorRepository { get; }
		ICommentRepository CommentRepository { get; }
		ISidebarFeatureRepository SidebarFeatureRepository { get; }
		ICategoryRepository CategoryRepository { get; }

		void Commit();

		Task CommitAsync();
	}
}
