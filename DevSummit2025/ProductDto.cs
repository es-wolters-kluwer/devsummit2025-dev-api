public class ProductDto
{
    public string? Id { get; set; }
    public string? code { get; set; }
    public string? description { get; set; }
    public string? alternativeProductId { get; set; }
    public string? supplierId { get; set; }
    public string? supplierReference { get; set; }
    public bool isSale { get; set; }
    public string? incomeTypeId { get; set; }
    public string? saleTaxCode { get; set; }
    public bool isPurchase { get; set; }
    public string? expenseTypeId { get; set; }
    public string? purchaseTaxCode { get; set; }
    public bool blocked { get; set; }
    public string? blockedReason { get; set; }
    public bool affectsStock { get; set; }
    public int stockUnits { get; set; }
    public int unitsInPackage { get; set; }
    public int packagesInBundle { get; set; }
    public int standardPrice { get; set; }
    public string? lastPurchaseDate { get; set; }
    public int lastUnitPurchasePrice { get; set; }
    public int lastPurchaseDiscount { get; set; }
    public int lastNetPurchasePrice { get; set; }
    public string? criteriaValuation { get; set; }
    public int unitValuation { get; set; }
    public int stockValuation { get; set; }
    public int salePrice { get; set; }
    public string? saleCurrency { get; set; }
    public int purchasePrice { get; set; }
    public string? purchaseCurrency { get; set; }
    public string? annotations { get; set; }
    public DateTime creationDate { get; set; }
    public List<object> customProperties { get; set; }
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
