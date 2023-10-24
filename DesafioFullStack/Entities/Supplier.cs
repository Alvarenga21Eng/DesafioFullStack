namespace DesafioFullStack.Entities
{
    public class Supplier
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string? RG { get; set; }
        public DateTime? Birthday { get; set; }

        public Supplier() { }

        public Supplier(string pCNPJ, string pName, string pEmail, string pCEP)
        {
            CNPJ = pCNPJ;
            Name = pName;
            Email = pEmail;
            CEP = pCEP;
        }

        public Supplier(string pCNPJ, string pName, string pEmail, string pCEP, string pRG, DateTime pBirthday) : this(pCNPJ, pName, pEmail, pCEP)
        {
            RG = pRG;
            Birthday = pBirthday;
        }
    }
}
