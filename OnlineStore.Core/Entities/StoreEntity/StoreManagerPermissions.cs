using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class StoreManagerPermissions : BaseEntity
    {
        public string Permission {  get; set; }
        public string PermissionStatus { get; set; }
        public int? StoreManagerId { get; set; }
        public StoreManager StoreManager { get; set; }
    }
}
