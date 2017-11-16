using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {

		private readonly IUnitOfWork _uow;
		public PostController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		// GET api/Post
		[HttpGet]
		public IEnumerable<Post> Get()
		{
			return _uow.PostRepository.ListAll();
		}

		// GET api/Post
		[HttpGet("{id}")]
		public Post Get(int id)
		{
			return _uow.PostRepository.GetWithIncludes(id);
		}

		// POST api/post
		[HttpPost]
		public async Task Post([FromBody] Post value)
		{
			_uow.PostRepository.Add(value);
			await _uow.CommitAsync();
		}

	}
}