using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;

namespace Web.Controllers
{
	[Route("api/[controller]")]
    public class AuthorController : Controller
    {
		private readonly IUnitOfWork _uow;
		public AuthorController(IUnitOfWork uow)
		{
			_uow = uow;
		}

        // GET api/author
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uow.AuthorRepository.ListAll());
        }

	
    }
}
