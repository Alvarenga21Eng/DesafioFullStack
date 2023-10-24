namespace DesafioFullStack.Entities
{
    public class Company
    {
        public string CNPJ { get; set; }
        public string TradeName { get; set; }
        public string CEP { get; set; }

        public Company() { }

        public Company(string pCNPJ, string pTradeName, string pCEP)
        {
            CNPJ = pCNPJ;
            TradeName = pTradeName;
            CEP = pCEP;
        }
    }
}
