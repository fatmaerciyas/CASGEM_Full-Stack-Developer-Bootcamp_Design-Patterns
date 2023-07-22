namespace CQRS.CQRSPattern.Results
{
    public class GetProductByIdQueryResult
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductBrand { get; set; }
    }
}
