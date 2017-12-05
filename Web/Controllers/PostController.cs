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
		public async Task<IActionResult> Post([FromBody] Post value)
		{
			_uow.PostRepository.Add(value);
			await _uow.CommitAsync();
			return Ok(value);
		}

		// POST addComment api/post/1/comment/
		[HttpPost(template: "{id}/comment")]
		public async Task<IActionResult> AddComment(int id ,[FromBody] Comment cmm)
		{
			cmm.PostId = id;
			_uow.CommentRepository.Add(cmm);
			await _uow.CommitAsync();
			return Ok(cmm);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update (int id, [FromBody] Post post)
		{
			post.Id = id;
			_uow.PostRepository.Update(post);
			await _uow.CommitAsync();
			return Ok(post);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete (int id)
		{
			var post = _uow.PostRepository.Get(id);
			_uow.PostRepository.Delete(post);
			_uow.Commit();
			return Ok(post);
		}

	}
}