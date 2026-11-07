
namespace EShopProject
{
    public class DigitalProduct : Product, IDiscountable
    {
        public string DownloadLink { get; private set; }
        public double FileSize { get; private set; }

        public DigitalProduct(string name, decimal price, string downloadlink, double filesize) : base(name,price)
        {
            if (price < 0)
            {
                throw new ArgumentException("price can not be zero!");
            }
            DownloadLink = downloadlink;
            FileSize = filesize;
        }
        public override decimal CalculateFinalPrice()
        {
            return Price;
        }
        public decimal ApplyDiscount(decimal discountPercent)
        {

            if (discountPercent < 0 || discountPercent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercent), "price must be between 0 and 100!");
            }
            return Price - (Price * discountPercent / 100);
        }
        public decimal GetDiscountedPrice()
        {
            return Price * 0.7m;
        }
        
    }  
}