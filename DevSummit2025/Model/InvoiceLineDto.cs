namespace DevSummit2025.Model
{
    public class InvoiceLineDto
    {
        public object id { get; set; }
        public object description { get; set; }
        public float units { get; set; }
        public float packages { get; set; }
        public float bundles { get; set; }
        public float price { get; set; }
        public float discountRate1 { get; set; }
        public object productId { get; set; }
        public string incomeTypeId { get; set; }
        public string taxTypeCode { get; set; }
        public float taxRate { get; set; }
        public float taxSurchargeRate { get; set; }
        public bool isExpense { get; set; }
        public float taxBase { get; set; }
        public object sourceDocument { get; set; }
        public object annotations { get; set; }
        public bool affectStock { get; set; }
        public float commissionPercentage { get; set; }
        public object idFeePeriodLog { get; set; }
        public bool confidentiality { get; set; }
        public object[] customProperties { get; set; }
        public string warehouseCorrelationId { get; set; }
        public object componentsLine { get; set; }
        public object kitProductBehaviours { get; set; }
    }

}
