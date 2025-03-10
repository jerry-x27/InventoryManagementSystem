﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDivyanshuVerma
{
    public abstract class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Program.Type ProductType { get; set; }
        public double Price { get; set; }

        public Product(int productId, string productName, Program.Type productType, double price)
        {
            ProductID = productId;
            ProductName = productName;
            ProductType = productType;
            Price = price;
        }

        public abstract double CalculatePrice();
        public override string ToString()
        {
            return $"ID: {ProductID}\t Name: {ProductName}\t Product Type: {ProductType}\t Product Price: ${CalculatePrice}";
        }
    }
}
