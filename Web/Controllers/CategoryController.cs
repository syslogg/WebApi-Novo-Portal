using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Web.Controllers
{
	[Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {

		private readonly IUnitOfWork _uow = null;

		public CategoryController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		
		[HttpGet]
		public IEnumerable<Category> Get ()
		{
			return _uow.CategoryRepository.ListAll().ToList();
		}

    }
}