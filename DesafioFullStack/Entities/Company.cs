namespace DesafioFullStack.Entities
{
    public class Company
    {
        public string Cnpj { get; set; }
        public string TradeName { get; set; }
        public string Cep { get; set; }
        public ICollection<CompanySupplier> CompaniesSuppliers { get; set; }

        public Company(string cnpj, string tradeName, string cep)
        {
            Cnpj = cnpj;
            TradeName = tradeName;
            Cep = cep;
        }
    }
}
