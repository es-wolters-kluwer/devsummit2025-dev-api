namespace DevSummit2025.Model
{

    public class ProductRsDto
    {
        public object id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public object alternativeProductId { get; set; }
        public object supplierId { get; set; }
        public object supplierReference { get; set; }
        public bool isSale { get; set; }
        public string incomeTypeId { get; set; }
        public string saleTaxCode { get; set; }
        public bool isPurchase { get; set; }
        public string expenseTypeId { get; set; }
        public string purchaseTaxCode { get; set; }
        public bool blocked { get; set; }
        public string blockedReason { get; set; }
        public bool affectsStock { get; set; }
        public float stockUnits { get; set; }
        public float unitsInPackage { get; set; }
        public int? packagesInBundle { get; set; }
        public float standardPrice { get; set; }
        public object lastPurchaseDate { get; set; }
        public float lastUnitPurchasePrice { get; set; }
        public float lastPurchaseDiscount { get; set; }
        public float lastNetPurchasePrice { get; set; }
        public string criteriaValuation { get; set; }
        public float unitValuation { get; set; }
        public float stockValuation { get; set; }
        public float salePrice { get; set; }
        public string saleCurrency { get; set; }
        public float purchasePrice { get; set; }
        public string purchaseCurrency { get; set; }
        public object annotations { get; set; }
        public DateTime creationDate { get; set; }
        public object[] customProperties { get; set; }
        public bool confidentiality { get; set; }
        public bool isKit { get; set; }
        public bool excludedEquivalenceSurcharge { get; set; }
        public bool batches { get; set; }
        public bool expiredDates { get; set; }
        public bool allowExpiredDates { get; set; }
        public int expiredFormat { get; set; }
        public bool serialNumbers { get; set; }
        public int salesCriteria { get; set; }
    }



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
