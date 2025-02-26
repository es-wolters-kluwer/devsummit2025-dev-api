namespace DevSummit2025.Model
{

    public class SaleInvoiceDtoRs
    {
        public object id { get; set; }
        public DateTime date { get; set; }
        public DateTime accountingDate { get; set; }
        public DateTime transactionDate { get; set; }
        public object customerId { get; set; }
        public string activityId { get; set; }
        public string serieId { get; set; }
        public int number { get; set; }
        public string documentNumber { get; set; }
        public object reference { get; set; }
        public string bankId { get; set; }
        public string paymentMethodId { get; set; }
        public string paymentTypeId { get; set; }
        public object vatNumber { get; set; }
        public object vatNumberType { get; set; }
        public object name { get; set; }
        public object email { get; set; }
        public object address { get; set; }
        public object zipCode { get; set; }
        public object town { get; set; }
        public object provinceCode { get; set; }
        public object provinceName { get; set; }
        public string countryCode { get; set; }
        public object addressDetails { get; set; }
        public object directDebitId { get; set; }
        public string operationTypeCode { get; set; }
        public string invoiceType { get; set; }
        public bool isRent { get; set; }
        public string rateId { get; set; }
        public bool isTaxIncluded { get; set; }
        public bool isTaxBaseAffected { get; set; }
        public float totalPromptPayment { get; set; }
        public float promptPaymentPercentage { get; set; }
        public float totalFinancialSurcharge { get; set; }
        public float financialSurchargePercentage { get; set; }
        public float taxRetentionBase { get; set; }
        public float taxRetentionPercentage { get; set; }
        public object annotations { get; set; }
        public float taxBase { get; set; }
        public float totalTax { get; set; }
        public float totalRetention { get; set; }
        public float total { get; set; }
        public string saleCurrency { get; set; }
        public int situation { get; set; }
        public object representativeId { get; set; }
        public object representativeName { get; set; }
        public object version { get; set; }
        public bool isRectificative { get; set; }
        public bool isRectified { get; set; }
        public object[] lines { get; set; }
        public object[] customProperties { get; set; }
        public object chargedAmounts { get; set; }
        public bool isAntiFraudRegistered { get; set; }
        public string warehouseCorrelationId { get; set; }
        public bool isMigrated { get; set; }
        public Extendedinformation extendedInformation { get; set; }
    }

    public class Extendedinformation
    {
        public int id { get; set; }
        public object tenantId { get; set; }
        public int antiFraudeLogStatus { get; set; }
        public int ticketBAILogStatus { get; set; }
        public object aeatResponseDescription { get; set; }
        public object aeatResponseCode { get; set; }
        public DateTime invoiceSent { get; set; }
        public int sifNotApplyReason { get; set; }
        public object sifNotApplyDescriptionMessages { get; set; }
        public DateTime logDate { get; set; }
        public bool subsanacionRejected { get; set; }
    }
}