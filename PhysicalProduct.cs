
namespace EShopProject
{
    public class PhysicalProduct : Product, IDiscountable
    {
        public int Weight { get; private set; }
        public decimal ShippingCost { get; private set; }

        public PhysicalProduct(string name, decimal price, int weight, decimal shippingcost) : base(name,price)
        {
            if (price < 0)
            {
                throw new ArgumentException("price can not be zero!");
            }
            Weight = weight;
            ShippingCost = shippingcost;
        }
        public override decimal CalculateFinalPrice()
        {
            return Price + ShippingCost;
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
            return Price * 0.6m;
        }
      
    }
}