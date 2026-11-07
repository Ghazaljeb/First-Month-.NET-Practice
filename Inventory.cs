using System.Net.Http.Headers;

namespace EShopProject
{
    public class Inventory
    {
        private List<Product> _products;
        public Inventory()
        {
            _products = new List<Product>();
            _products.Add(new PhysicalProduct("laptop", 2000m, 500, 40));
            _products.Add(new DigitalProduct("music", 200m, "www.google.com", 390));
            _products.Add(new DigitalProduct("videogame", 356m, "www.openfront.ir", 1000));
        }
        public List<IDiscountable> GetDiscountableItems()
        {
            return _products.OfType<IDiscountable>().ToList();
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"{product.Name} added to inventory successfully!");
        }
        public void DisplayInventory()
        {
            foreach(var item in _products)
            {
                Console.WriteLine($"product name:{item.Name}, product price:{item.Price}");
            }
        }
        public Product FindProductByName(string name)
        {
            foreach(var product in _products)
            {
                if(product.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                    return product;
                }
            }
            return null;
        }
    }
}


    