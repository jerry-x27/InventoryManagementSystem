using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDivyanshuVerma
{
    public class PhysicalProduct : Product
    {
        public double ProductWeight { get; set; }
        public double ShippingCost { get; set; }
        public PhysicalProduct(int productId, string productName, double price, double productWeight, double shippingCost): base(productId, productName, Program.Type.Physical, price)
        {
            ProductWeight = productWeight;
            ShippingCost = shippingCost;
        }

        public override double CalculatePrice()
        {
            double finalPrice = Price + ShippingCost;
            return finalPrice;
        }

        public override string ToString()
        {
            return $"{"Product Id",-12} {"Product Name",-20} {"Product Type",-15} {"Product Weight (KG)",-20} {"Product Price",-15} {"Shipping Cost",-15} {"Final Price",-15}" +
                $"\n{ ProductID,-12} { ProductName,-20} { ProductType,-15} { ProductWeight,-20} ${ Price,-15} ${ ShippingCost,-15} ${ CalculatePrice(),-15}";
        }
    }
}
