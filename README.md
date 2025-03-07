# Inventory Management System 🛠️📦

This is a simple **Inventory Management System** built in C# to manage and maintain both **physical** and **digital products**. The application allows users to add, delete, search, and view products in the inventory. It provides functionality for managing product details, such as price, weight, shipping costs (for physical products), and download size and license duration (for digital products). 

### Features: ✨
- **Add New Product**: Add products to the inventory, either physical (with weight and shipping cost) or digital (with download size and license duration). ➕
- **Delete Product**: Remove a product from the inventory using its unique product ID. ❌
- **View All Products**: List all products, categorized by type (Physical or Digital), and display details like product name, price, and calculated final price. 👀
- **View Products By Type**: Filter products by their type: Physical or Digital. 🔍
- **Search Product By Name**: Search for a product by name and display matching results. 🔎

### Product Types: 
- **Physical Products** 🏋️‍♂️: Includes items with weight and shipping cost (e.g., keyboard, monitor).
- **Digital Products** 💻: Includes downloadable products with size and license duration (e.g., antivirus software, e-books).

### Code Highlights: 💡
- **Object-Oriented Programming (OOP)**: Utilizes inheritance and polymorphism. The base `Product.cs` class is extended by `PhysicalProduct.cs` and `DigitalProduct.cs` classes to manage specific product details. 🏗️
- **Data Management**: The system uses an in-memory list to store and manage product data. 💾
- **User Interaction**: Simple text-based interface for managing the inventory. 🖥️

### Technologies: 🛠️
- C# 
- .NET Console Application

This project demonstrates the use of **object-oriented programming** principles like inheritance, polymorphism, and abstraction in a real-world inventory management context. It is designed for educational purposes and can be extended to support additional features like database integration or advanced product filtering.
