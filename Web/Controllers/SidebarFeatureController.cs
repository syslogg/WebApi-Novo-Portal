using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class SidebarFeatureController : Controller
    {
		private readonly IUnitOfWork _uow;
		public SidebarFeatureController(IUnitOfWork uow)
		{
			_uow = uow;
		}

        // GET api/sidebarfeature
        [HttpGet]
        public IEnumerable<SidebarFeature> Get()
        {
            return _uow.SidebarFeatureRepository.ListAll();
        }

		// GET api/sidebarfeature/5
		[HttpGet("{id}")]
        public SidebarFeature Get(int id)
        {
			return _uow.SidebarFeatureRepository.Get(id);
        }

		// POST api/sidebarfeature
		[HttpPost]
        public async Task Post([FromBody]SidebarFeature value)
        {
			_uow.SidebarFeatureRepository.Add(value);
			await _uow.CommitAsync();
        }

		// PUT api/sidebarfeature/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

		// DELETE api/sidebarfeature/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
