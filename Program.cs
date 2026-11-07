using System;
using EShopProject;

namespace EShopProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Cart mycart = new Cart();
            bool running = true;

            Console.WriteLine("Welcome to EShop!");
            while(running)
            {
                Console.WriteLine("EShop main Menu");
                Console.WriteLine("1.Products List Display");
                Console.WriteLine("2.Discounted Products List Display");
                Console.WriteLine("3.Add New Product");
                Console.WriteLine("4.Add New Product to Mycart");
                Console.WriteLine("5.Total Price Display");
                Console.WriteLine("6.Cart Display");
                Console.WriteLine("7.Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.DisplayInventory();
                        break;

                    case "2":
                        var discountableitems = inventory.GetDiscountableItems();
                        foreach (var discountableitem in discountableitems)
                        {
                            Console.WriteLine($"product name:{discountableitem.Name}, product Discounted price:{discountableitem.GetDiscountedPrice()}");
                        }
                        break;

                    case "3":
                        Product newproduct = null;
                        Console.Write("Enter the Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter the Type [1] for PhysicalProduct or [2] DigitalProduct: ");
                        string typechoice = Console.ReadLine();

                        if (typechoice == "1")
                        {
                            Console.Write("Enter the Weight: ");
                            int weight = int.Parse(Console.ReadLine());

                            Console.Write("Enter the ShippingCost: ");
                            decimal shippingcost = decimal.Parse(Console.ReadLine());

                            newproduct = new PhysicalProduct(name, price, weight, shippingcost);
                        }
                        else if (typechoice == "2")
                        {
                            Console.Write("Enter the DownloadLink: ");
                            string downloadlink = Console.ReadLine();

                            Console.Write("Enter the FileSize: ");
                            double filesize = double.Parse(Console.ReadLine());

                            newproduct = new DigitalProduct(name, price, downloadlink, filesize);
                        }
                        else
                        {
                            Console.WriteLine("invalid type error!");
                        }
                       if(newproduct != null)
                        {
                            inventory.AddProduct(newproduct);
                        }
                        break;
                    case "4":
                        inventory.DisplayInventory();
                        Console.Write("Which Product you want to buy?");
                        string productname = Console.ReadLine();

                        Product foundproduct = inventory.FindProductByName(productname);
                        if(foundproduct != null)
                        {
                            mycart.AddProduct(foundproduct);
                            Console.WriteLine("product added to your cart successfully!");
                        }
                        else
                        {
                            Console.WriteLine("product not found!");
                        }
                        break;

                    case "5":
                         decimal total = mycart.CalculateTotalPrice();
                        Console.WriteLine($"{total} is total price for this cart!");
                        break;

                    case "6":
                        mycart.DisplayCart();
                        break;

                    case "7":
                        Console.WriteLine("ending program...good luck!");
                        return;
                }
                
            }
        }
    }
}
