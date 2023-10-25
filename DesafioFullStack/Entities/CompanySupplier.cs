namespace DesafioFullStack.Entities
{
    public class CompanySupplier
    {
        public int CompanySupplierId { get; set; }
        public string CompanyCnpj { get; set; }
        public string SupplierCnpj { get; set; }

        public Company Company { get; set; }
        public Supplier Supplier { get; set; }
    }
}
