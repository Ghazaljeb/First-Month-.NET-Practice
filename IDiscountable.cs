namespace EShopProject
{
    public interface IDiscountable
    {
        public string Name { get; }
        public decimal Price { get; }
        public decimal ApplyDiscount(decimal discountPercent);
        public decimal GetDiscountedPrice();
    }
}