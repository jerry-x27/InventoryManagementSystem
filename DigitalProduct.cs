using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDivyanshuVerma
{
    public class DigitalProduct : Product
    {
        public double DownloadSize { get; set; }
        public int LicenceDuration { get; set; }
        public DigitalProduct(int productId, string productName, double price, double downloadSize, int licenceDuration) : base(productId, productName, Program.Type.Digital, price)
        {
            DownloadSize = downloadSize;
            LicenceDuration = licenceDuration;
        }

        public override double CalculatePrice()
        {
            double finalPrice = Price * LicenceDuration;
            return finalPrice;
        }

        public override string ToString()
        {
            return $"{"Product Id",-12} {"Product Name",-20} {"Product Type",-15} {"Download Size (MB)",-20} {"Product Price",-15} {"Licence Duration (MONTHS)",-17} {"Final Price",-15}" +
                $"\n{ ProductID,-12} { ProductName,-20} { ProductType,-15} { DownloadSize,-20} ${Price,-15} {LicenceDuration,-25} ${CalculatePrice(),-15}";
        }
    }
}
