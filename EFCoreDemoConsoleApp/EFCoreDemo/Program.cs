using EFCoreDemo.Data;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureCreated();

        while (true)
        {
            PrintMenu();
            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(context); break;
                case "2": ListAllProducts(context); break;
                case "3": UpdatePriceOrQuantity(context); break;
                case "4": DeleteProduct(context); break;
                case "5": ListLowStockProducts(context); break;
                case "6": CalculateTotalInventoryValue(context); break;
                case "7": AdjustStock(context); break;
                case "8": SortProductsByValue(context); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n=== Inventory Menu ===");
        Console.WriteLine("CRUD");
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. List all products");
        Console.WriteLine("3. Update price or quantity");
        Console.WriteLine("4. Delete product");
        Console.WriteLine();
        Console.WriteLine("Logic");
        Console.WriteLine("5. List low-stock products (Quantity < 5)");
        Console.WriteLine("6. Calculate total inventory value");
        Console.WriteLine("7. Adjust stock (delivery in / sale)");
        Console.WriteLine();
        Console.WriteLine("Extra");
        Console.WriteLine("8. Sort products by value (Quantity * PricePerUnit)");
        Console.WriteLine("0. Exit");
    }

    static void AddProduct(AppDbContext context)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }

        Console.Write("Category: ");
        var category = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(category))
        {
            Console.WriteLine("Category cannot be empty.");
            return;
        }

        if (!TryReadDecimal("Price per unit: ", out var pricePerUnit) || pricePerUnit < 0)
        {
            Console.WriteLine("Invalid price per unit.");
            return;
        }

        if (!TryReadInt("Quantity: ", out var quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Quantity cannot be negative.");
            return;
        }

        var entity = new InventoryItem
        {
            Name = name,
            Category = category,
            Quantity = quantity,
            PricePerUnit = pricePerUnit
        };

        context.Add(entity);
        context.SaveChanges();
        Console.WriteLine($"Added product with Id: {entity.Id}");
    }

    static void ListAllProducts(AppDbContext context)
    {
        var products = context.InventoryItems
            .OrderBy(x => x.Id)
            .ToList();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        foreach (var item in products)
        {
            var value = item.Quantity * item.PricePerUnit;
            Console.WriteLine($"Id: {item.Id} | {item.Name} | Category: {item.Category} | Quantity: {item.Quantity} | PricePerUnit: {item.PricePerUnit:C} | Value: {value:C}");
        }
    }

    static void UpdatePriceOrQuantity(AppDbContext context)
    {
        if (!TryReadInt("Product Id to update: ", out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var entity = context.InventoryItems.Find(id);
        if (entity is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.WriteLine("Update option: 1.Price  2.Quantity  3.Both");
        Console.Write("Choose: ");
        var option = Console.ReadLine();

        if (option is "1" or "3")
        {
            if (!TryReadDecimal("New price per unit: ", out var pricePerUnit) || pricePerUnit < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            entity.PricePerUnit = pricePerUnit;
        }

        if (option is "2" or "3")
        {
            if (!TryReadInt("New quantity: ", out var quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Quantity cannot be negative.");
                return;
            }

            entity.Quantity = quantity;
        }

        if (option is not ("1" or "2" or "3"))
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        context.Update(entity);
        context.SaveChanges();
        Console.WriteLine("Product updated.");
    }

    static void DeleteProduct(AppDbContext context)
    {
        if (!TryReadInt("Product Id to delete: ", out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var entity = context.InventoryItems.Find(id);
        if (entity is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        context.Remove(entity);
        context.SaveChanges();
        Console.WriteLine("Product deleted.");
    }

    static void ListLowStockProducts(AppDbContext context)
    {
        var lowStock = context.InventoryItems
            .Where(x => x.Quantity < 5)
            .OrderBy(x => x.Quantity)
            .ThenBy(x => x.Name)
            .ToList();

        if (lowStock.Count == 0)
        {
            Console.WriteLine("No low-stock products.");
            return;
        }

        Console.WriteLine("Low-stock products:");
        foreach (var item in lowStock)
        {
            Console.WriteLine($"Id: {item.Id} | {item.Name} | Quantity: {item.Quantity}");
        }
    }

    static void CalculateTotalInventoryValue(AppDbContext context)
    {
        var total = context.InventoryItems
            .Sum(x => x.Quantity * x.PricePerUnit);

        Console.WriteLine($"Total inventory value: {total:C}");
    }

    static void AdjustStock(AppDbContext context)
    {
        if (!TryReadInt("Product Id: ", out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var entity = context.InventoryItems.Find(id);
        if (entity is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Type (in/out): ");
        var type = Console.ReadLine()?.Trim().ToLowerInvariant();
        if (type is not ("in" or "out"))
        {
            Console.WriteLine("Invalid type. Use 'in' or 'out'.");
            return;
        }

        if (!TryReadInt("Amount: ", out var amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        var newQuantity = type == "in"
            ? entity.Quantity + amount
            : entity.Quantity - amount;

        if (newQuantity < 0)
        {
            Console.WriteLine("Operation denied. Quantity cannot become negative.");
            return;
        }

        entity.Quantity = newQuantity;
        context.Update(entity);
        context.SaveChanges();

        Console.WriteLine($"Stock adjusted. New quantity: {entity.Quantity}");
    }

    static void SortProductsByValue(AppDbContext context)
    {
        var products = context.InventoryItems
            .AsEnumerable()
            .OrderByDescending(x => x.Quantity * x.PricePerUnit)
            .ToList();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("Products sorted by value:");
        foreach (var item in products)
        {
            var value = item.Quantity * item.PricePerUnit;
            Console.WriteLine($"Id: {item.Id} | {item.Name} | Quantity: {item.Quantity} | PricePerUnit: {item.PricePerUnit:C} | Value: {value:C}");
        }
    }

    static bool TryReadInt(string prompt, out int value)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out value);
    }

    static bool TryReadDecimal(string prompt, out decimal value)
    {
        Console.Write(prompt);
        return decimal.TryParse(Console.ReadLine(), out value);
    }
}
