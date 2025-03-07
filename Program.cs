using System.Globalization;
using System.Security.Cryptography;

namespace InventoryManagementDivyanshuVerma
{
    public class Program
    {
        public enum Type
        {
            Physical,
            Digital
        }
        static int pId = 1;

        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            products.Add(new PhysicalProduct(pId++, "Keyboard", 199.0, 0.45, 25));
            products.Add(new DigitalProduct(pId++, "Antivirus Software", 149.0, 200, 24));


            while (true)
            {
                Console.WriteLine("*~*~*~*~*~*~ INVENTORY MANAGEMENT SOFTWARE ~*~*~*~*~*~*");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Delete Product By ID");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. View Prodcuts By Type (PHYSICAL OR DIGITAL)");
                Console.WriteLine("5. Search Product By Name");
                Console.WriteLine("6. Exit Application");
                Console.Write("Choose Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddProduct(); break;
                    case "2": DeleteProduct(); break;
                    case "3": ViewAllProducts(); break;
                    case "4": ViewProductByType(); break;
                    case "5": SearchProductByName(); break;
                    case "6": return;
                    default: Console.WriteLine(); break;
                }
                Console.WriteLine("\n");
            }
        }
        static void AddProduct()
        {
            string name;
            do
            {
                Console.Write("Enter Product Name: ");
                name = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid Name");
                }
            }
            while (string.IsNullOrEmpty(name));

            Console.Write("Enter Product Price: ");
            string priceInput;
            int price;
            do {
                priceInput = Console.ReadLine();
                if (!int.TryParse(priceInput, out price) || price <= 0)              //TryParse method studied from Stack Overflow and Microsoft Learn (.Net Documentation)
                {
                    Console.WriteLine("Invalid Price..!!");
                    Console.Write("Enter Product Price: ");
                }
            }
            while (price <=0);

            Console.Write("Enter Product Type (1: Physical, 2: Digital): ");
            string typeChose = Console.ReadLine();
            Type pType = typeChose == "1" ? Type.Physical : Type.Digital;

            if (pType == Type.Physical)
            {
                Console.Write("Enter Product Weight (kg): ");
                string weightInput;
                double weight;
                do {
                    weightInput = Console.ReadLine();
                    if (!double.TryParse(weightInput, out weight) || weight <= 0)              
                    {
                        Console.WriteLine("Invalid Weight..!!");
                        Console.Write("Enter Product Weight (kg): ");
                    }

                } while (weight <= 0);

                Console.Write("Enter Shipping Cost: ");
                string sCostInput;
                double sCost;
                do
                {
                    sCostInput = Console.ReadLine();
                    if (!double.TryParse(sCostInput, out sCost) || sCost <= 0)
                    {
                        Console.WriteLine("Invalid Shipping Cost..!!");
                        Console.Write("Enter Shipping Cost: ");
                    }

                } while (sCost <= 0);

                products.Add(new PhysicalProduct(pId++, name, price, weight, sCost));
                Console.WriteLine("\n~~~~~~* Product Addedd Successfully *~~~~~~");

            }
            else
            {
                Console.Write("Enter Download Size (MB): ");
                string sizeInput;
                int size;
                do
                {
                    sizeInput = Console.ReadLine();
                    if (!int.TryParse(sizeInput, out size) || size <= 0)
                    {
                        Console.WriteLine("Invalid Download Size..!!");
                        Console.Write("Enter Download Size (MB): ");
                    }

                } while (size <= 0);

                Console.Write("Enter Licence Duration (MONTHS): ");
                string durationInput;
                int duration;
                do
                {
                    durationInput = Console.ReadLine();
                    if (!int.TryParse(durationInput, out duration) || duration <= 0)
                    {
                        Console.WriteLine("Invalid Licence Duration..!!");
                        Console.Write("Enter Licence Duration (MONTHS): ");
                    }

                } while (duration <= 0);

                products.Add(new DigitalProduct(pId++, name, price, size, duration));
            }
        }

        static void DeleteProduct()
        {
            int id;
            bool isValid = false;

            do
            {
                Console.Write("Enter Product ID to Delete: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out id))
                {
                    Console.WriteLine("Invalid ID! Please enter a valid number.");
                }
                else
                {
                    isValid = true;  
                }

            } while (!isValid);  

            Product deletedProduct = null;

            foreach (Product p in products)
            {
                if (p.ProductID == id)
                {
                    deletedProduct = p;
                    break;
                }
            }

            if (deletedProduct != null)
            {
                products.Remove(deletedProduct);
                Console.WriteLine("Product Deleted Successfully..!!");
            }
            else
            {
                Console.WriteLine("**** Product Not Found ****");
            }

        }

        static void ViewAllProducts()
        {
            Console.WriteLine("******Physical Products******\n");
            Console.WriteLine($"{"Product Id",-12} {"Product Name",-20} {"Product Type",-15} {"Product Weight (KG)",-20} {"Product Price",-15} {"Shipping Cost",-15} {"Final Price", -15}\n");
            
            foreach (Product p in products)
            {
                if(p.ProductType == Type.Physical)
                {
                    PhysicalProduct product = (PhysicalProduct)p;
                    Console.WriteLine($"{product.ProductID, -12} {product.ProductName,-20} {product.ProductType,-15} {product.ProductWeight,-20} ${product.Price,-15} ${product.ShippingCost,-15} ${product.CalculatePrice(), -15}");
                }
            }
            Console.WriteLine("\n******Digital Products******\n");
            Console.WriteLine($"{"Product Id",-12} {"Product Name",-20} {"Product Type",-15} {"Download Size (MB)",-20} {"Product Price",-15} {"Licence Duration (MONTHS)",-17} {"Final Price",-15}\n");
            foreach (Product p in products)
            {
                if (p.ProductType == Type.Digital)
                {
                    DigitalProduct product = (DigitalProduct)p;
                    Console.WriteLine($"{product.ProductID,-12} {product.ProductName,-20} {product.ProductType,-15} {product.DownloadSize,-20} ${product.Price,-15} {product.LicenceDuration,-25} ${product.CalculatePrice(), -15}");
                }
            }
        }

        static void ViewProductByType()
        {
            Console.WriteLine("Enter Type (1: Physical, 2: Digital): ");
            string typeChose = Console.ReadLine();
            Type pType = typeChose == "1" ? Type.Physical : Type.Digital;

            var filteredProducts = from p in products
                                   where p.ProductType == pType
                                   select p;

            if (filteredProducts.Any())
            {
                foreach (var product in filteredProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Product Not Found..!!");
            }

        }

        static void SearchProductByName()
        {
            Console.WriteLine("Enter Product Name To Search: ");
            string searchResult = Console.ReadLine().Trim().ToLower();

            bool found = false;

            foreach (Product p in products)
            {
                if (p.ProductName.ToLower().Contains(searchResult))
                {
                    Console.WriteLine("\nSearch Results: \n");
                    Console.WriteLine(p);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Matching Results Found..!!");
            }

        }
    }
}
