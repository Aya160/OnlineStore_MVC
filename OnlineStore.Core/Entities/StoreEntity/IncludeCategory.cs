namespace OnlineStore.Core.Entities.StoreEntity
{
    public class IncludeCategory
    {

        public DateOnly DateInclude { get; set; } 
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
