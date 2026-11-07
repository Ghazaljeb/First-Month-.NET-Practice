using System;
using EShopProject;

namespace EShopProject
{
    public class Cart
    {
        private List<Product> _list;
        public Cart()
        {
            _list = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            _list.Add(product);
            Console.WriteLine($"{product.Name} added successfully!");
        }
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _list)
            {
                if (item is IDiscountable discountableitem)
                {
                    totalPrice += discountableitem.GetDiscountedPrice();
                }
                else
                {
                    totalPrice += item.Price;
                }
            }
            return totalPrice;
        }
        public void DisplayCart()
        {
            if( _list.Count == 0 )
            {
                Console.WriteLine("your cart is empty!");
                return;
            }
            Console.WriteLine("---your shopping cart---");
            foreach (var item in _list)
            {
                Console.WriteLine($"product name:{item.Name}, product price:{item.Price}");
            }

        }


    }
}

