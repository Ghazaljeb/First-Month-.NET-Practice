namespace EShopProject
{
    public abstract class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name can not be null or whitespace!");
            }
            if (price < 0)
            {
                throw new ArgumentException("price can not be zero!");
            }
            Name = name;
            Price = price;
        }
        public abstract decimal CalculateFinalPrice();
    }
}