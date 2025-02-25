namespace DevSummit2025.Model
{
    public class UserRsDto
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public string mail { get; set; }
        public string locale { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string version { get; set; }
        public bool isAdvisor { get; set; }
        public Company[] companies { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string idCDA { get; set; }
        public bool _default { get; set; }
        public int companyStatus { get; set; }
    }



    public class SelectCompanyResultDto 
    {
        public int companyStatus { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
        public int productType { get; set; }
    }


}
