namespace DesafioFullStack.Entities
{
    public class Supplier
    {
        public string CnpjCpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string? RG { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<CompanySupplier> CompaniesSuppliers { get; set; }

        public Supplier(string cnpj, string name, string email, string cep)
        {
            CnpjCpf = cnpj;
            Name = name;
            Email = email;
            Cep = cep;
        }

        public Supplier(string cnpj, string name, string email, string cep, string rg, DateTime birthday) : this(cnpj, name, email, cep)
        {
            RG = rg;
            Birthday = birthday;
        }
    }
}
