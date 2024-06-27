using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.Users
{
    public class AdministratorPermission : BaseEntity
    {
        public string Permission { get; set; }
        public bool IsPermission { get; set; }
        public int? AdministratorId {  get; set; }
        public Administrator Administrator { get; set;}
    }
}
