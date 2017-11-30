using Domain.Base;
using System.Collections.Generic;

namespace Domain
{
	public class Category : Entity
    {
		public string Name { get; set; }
		
		public string Description { get; set; }

		public IList<Post> Posts { get; set; }
		
		public Category()
		{
			Posts = new List<Post>();
		}

	}
}
