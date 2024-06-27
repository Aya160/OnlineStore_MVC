using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class PurchaseBill : BaseEntity
    {
        public string InvoiceName { get; set; }
        public bool CashPayment { get; set; }
        public bool CreditPayment { get; set; }
        public DateOnly DateInvoice { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly CreateDate { get; set; }
        public int? AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
        public DetailsInvoice DetailsInvoice { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
