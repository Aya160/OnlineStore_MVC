using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Web.ViewModels
{
	public class StoreViewModel
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string StreetAddress { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public int? AddressId { get; set; }
		public int? AdministratorId { get; set; }
		public Administrator Administrator { get; set; }
	}
}
