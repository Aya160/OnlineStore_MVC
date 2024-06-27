using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Core.Entities.General
{
    [NotMapped]
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
