


namespace DevSummit2025.Model
{

    public class CustomerDto
    {
        public string id { get; set; }
        public DateTime creationDate { get; set; }
        public object vatNumber { get; set; }
        public object vatNumberType { get; set; }
        public string code { get; set; }
        public object name { get; set; }
        public object businessName { get; set; }
        public object web { get; set; }
        public Address address { get; set; }
        public object phone { get; set; }
        public object mail { get; set; }
        public bool isSameAddress { get; set; }
        public Businessaddress businessAddress { get; set; }
        public object businessPhone { get; set; }
        public object businessMail { get; set; }
        public object annotations { get; set; }
        public string rateId { get; set; }
        public float discountPercentage { get; set; }
        public string bankId { get; set; }
        public string paymentTypeId { get; set; }
        public string paymentMethodId { get; set; }
        public int paymentDay1 { get; set; }
        public int paymentDay2 { get; set; }
        public int paymentDay3 { get; set; }
        public string operationType { get; set; }
        public string taxType { get; set; }
        public bool taxIncluded { get; set; }
        public bool applyIRPF { get; set; }
        public object directDebit { get; set; }
        public string mandateType { get; set; }
        public object mandateReference { get; set; }
        public DateTime mandateSignatureDate { get; set; }
        public string mandateDebType { get; set; }
        public object contact { get; set; }
        public object representativeId { get; set; }
        public object representativeName { get; set; }
        public object saleOfferTemplateId { get; set; }
        public object saleOrderTemplateId { get; set; }
        public object saleDeliveryNoteTemplateId { get; set; }
        public object saleInvoiceTemplateId { get; set; }
        public object[] customProperties { get; set; }
        public object accountCode { get; set; }
        public string accountId { get; set; }
        public object customerFaceData { get; set; }
    }

    public class Address
    {
        public string correlationId { get; set; }
        public object street { get; set; }
        public object town { get; set; }
        public object zipCode { get; set; }
        public object provinceCode { get; set; }
        public string provinceName { get; set; }
        public string countryCode { get; set; }
        public object localization { get; set; }
    }

    public class Businessaddress
    {
        public string correlationId { get; set; }
        public object street { get; set; }
        public object town { get; set; }
        public object zipCode { get; set; }
        public object provinceCode { get; set; }
        public string provinceName { get; set; }
        public string countryCode { get; set; }
        public object localization { get; set; }
    }
}