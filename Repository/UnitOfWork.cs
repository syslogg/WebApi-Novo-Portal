using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Implementation;

namespace Repository
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly DbTIContext _context;

		public UnitOfWork(DbTIContext context)
		{
			_context = context;
		}

		public IPostRepository PostRepository
		{
			get
			{
				if(_postRepository == null)
				{
					_postRepository = new PostRepository(_context);
				}
				return _postRepository;
			}
		}

		private IPostRepository _postRepository = null;

		public IAuthorRepository AuthorRepository
		{
			get
			{
				if(_authorRepository == null)
				{
					_authorRepository = new AuthorRepository(_context);
				}
				return _authorRepository;
			}
		}

		private IAuthorRepository _authorRepository = null;

		public ICommentRepository CommentRepository
		{
			get
			{
				if(_commentRepository == null)
				{
					_commentRepository = new CommentRepository(_context);
				}
				return _commentRepository;
			}
		}

		private ICommentRepository _commentRepository = null;

		public ISidebarFeatureRepository SidebarFeatureRepository
		{
			get
			{
				if(_sidebarFeatureRepository == null)
				{
					_sidebarFeatureRepository = new SidebarFeatureRepository(_context);
				}
				return _sidebarFeatureRepository;
			}
		}

		private ISidebarFeatureRepository _sidebarFeatureRepository = null;

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		#region IDisposable Support
		private bool disposedValue = false; // Para detectar chamadas redundantes

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: descartar estado gerenciado (objetos gerenciados).
				}

				// TODO: liberar recursos não gerenciados (objetos não gerenciados) e substituir um finalizador abaixo.
				// TODO: definir campos grandes como nulos.

				disposedValue = true;
			}
		}

		// TODO: substituir um finalizador somente se Dispose(bool disposing) acima tiver o código para liberar recursos não gerenciados.
		// ~UnitOfWork() {
		//   // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
		//   Dispose(false);
		// }

		// Código adicionado para implementar corretamente o padrão descartável.
		public void Dispose()
		{
			// Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
			Dispose(true);
			// TODO: remover marca de comentário da linha a seguir se o finalizador for substituído acima.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
