namespace DevSummit2025.Model
{
    public class ProductGetAllDto
    {
        public string id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string incomeTypeDescription { get; set; }
        public float salePrice { get; set; }
        public string saleCurrency { get; set; }
        public string purchaseTypeDescription { get; set; }
        public float purchasePrice { get; set; }
        public string purchaseCurrency { get; set; }
        public DateTime creationDate { get; set; }
        public bool affectsStock { get; set; }
        public float stockUnits { get; set; }
        public float unitsInPackage { get; set; }
        public float packagesInBundle { get; set; }
        public bool isKit { get; set; }
        public bool hasTraceability { get; set; }
    }


}
