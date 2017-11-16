using Domain;
using Repository.Base;
using Repository.Interfaces;

namespace Repository.Implementation
{
	public class SidebarFeatureRepository : Repository<SidebarFeature>, ISidebarFeatureRepository
	{
		public SidebarFeatureRepository(DbTIContext dbContext)
			: base(dbContext)
		{
		}
	}
}
